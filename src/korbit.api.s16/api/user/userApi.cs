using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XCT.BaseLib.API.Korbit.User
{
    /// <summary>
    /// 
    /// </summary>
    public class KUserApi
    {
        private string __connect_key;
        private string __secret_key;
        private string __user_name;
        private string __user_password;

        /// <summary>
        /// 
        /// </summary>
        public KUserApi(string connect_key, string secret_key, string user_name, string user_password)
        {
            __connect_key = connect_key;
            __secret_key = secret_key;
            __user_name = user_name;
            __user_password = user_password;
        }

        private KorbitClient __user_client = null;

        private KorbitClient UserClient
        {
            get
            {
                if (__user_client == null)
                    __user_client = new KorbitClient(__connect_key, __secret_key, __user_name, __user_password);
                return __user_client;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns>Constants</returns>
        public async Task<UserInfo> UserInfo()
        {
            return await UserClient.CallApiGetAsync<UserInfo>("/v1/user/info");
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<UserAccounts> UserAccounts()
        {
            var _params = new Dictionary<string, object>();

            return await UserClient.CallApiGetAsync<UserAccounts>("/v1/user/accounts", _params);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<UserBalances> UserBalances()
        {
            var _params = new Dictionary<string, object>();

            return await UserClient.CallApiGetAsync<UserBalances>("/v1/user/balances", _params);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns>Constants</returns>
        public async Task<UserWallet> UserWallet(string currency_pair = "btc_krw")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency_pair", currency_pair);
            }

            return await UserClient.CallApiGetAsync<UserWallet>("/v1/user/wallet", _params);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currency_pair"></param>
        /// <returns></returns>
        public async Task<Transactions> Transactions(string currency_pair = "btc_krw")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency_pair", currency_pair);
            }

            return await UserClient.CallApiGetAsync<Transactions>("/v1/user/transactions", _params);
        }

        /// <summary>
        /// Request BTC Withdrawal
        /// </summary>
        /// <param name="currency">A mandatory parameter. Currently only currency=“btc”, which means Bitcoin is supported.</param>
        /// <param name="amount">The amount of BTC to withdraw.</param>
        /// <param name="address">The BTC address to where the BTC is sent.</param>
        /// <param name="fee_priority">Optional parameter to select withdrawal fee. Set “normal” for fee 0.001 or “saver” for 0.0005. If it is not set, “normal” fee is applied. (Starting from 2017-03-17 2pm KST)</param>
        /// <returns></returns>
        public async Task<CoinsOut> CoinsOut(string currency, decimal amount, string address, decimal? fee_priority = null)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
                _params.Add("amount", amount);
                _params.Add("address", address);

                if (fee_priority != null)
                    _params.Add("fee_priority", fee_priority);
            }

            return await UserClient.CallApiGetAsync<CoinsOut>("/v1/user/coins/out", _params);
        }

        /// <summary>
        /// Cancel BTC Transfer Request
        /// </summary>
        /// <param name="currency">A mandatory parameter. Currently only currency=“btc”, which means Bitcoin is supported.</param>
        /// <param name="id">The unique ID of the BTC withdrawal request.</param>
        /// <returns></returns>
        public async Task<CoinsOut> CoinsCancel(string currency, string id)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
                _params.Add("id", id);
            }

            return await UserClient.CallApiGetAsync<CoinsOut>("/v1/user/coins/cancel", _params);
        }

        /// <summary>
        /// Query Status of BTC Deposit and Transfer
        /// You can query status of BTC deposits and transfers by using the following API
        /// </summary>
        /// <param name="currency">A mandatory parameter. Currently only currency=“btc”, which means Bitcoin is supported.</param>
        /// <param name="id">The unique ID of the BTC withdrawal request. If this parameter is not specified, the API responds with a pending BTC withdrawal request if any.</param>
        /// <returns></returns>
        public async Task<CoinsStatus> CoinsStatus(string currency = "btc", string id = "")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
                if (String.IsNullOrEmpty(id) == false)
                    _params.Add("id", id);
            }

            return await UserClient.CallApiGetAsync<CoinsStatus>("/v1/user/coins/status", _params);
        }
    }
}