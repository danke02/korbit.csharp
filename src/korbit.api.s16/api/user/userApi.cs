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
        /// <returns>Constants</returns>
        public async Task<UserWallet> UserWallet(string currency_pair = "btc_krw")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency_pair", currency_pair);
            }

            return await UserClient.CallApiGetAsync<UserWallet>("/v1/user/wallet", _params);
        }
    }
}