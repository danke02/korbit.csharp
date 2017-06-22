using System.Collections.Generic;
using System.Threading.Tasks;
using Korbit.API.Types;

namespace Korbit.API.Public
{
    /// <summary>
    /// Check the current status of the market by listing open and filled orders.
    /// </summary>
    public class XPublicApi
    {
        private XApiClient __api_client = null;

        private XApiClient APiClient
        {
            get
            {
                if (__api_client == null)
                    __api_client = new XApiClient();
                return __api_client;
            }
        }

        /// <summary>
        /// https://bitbucket.org/korbit/public-api/wiki/browse/
        /// </summary>
        /// <returns></returns>
        public async Task<Version> GetVersion()
        {
            return await APiClient.CallApiGetAsync<Version>("/v1/version");
        }

        /// <summary>
        /// 시장 현황 (Ticker)
        /// </summary>
        /// <param name="currency_pair">The type of trading currency of which information you want to query for. 
        /// Bitcoin trading is default. As our BETA service, you can also specify “etc_krw” for Ethereum Classic 
        /// trading and “eth_krw” for Ethereum trading.</param>
        /// <returns></returns>
        public async Task<PublicTicker> GetTicker(string currency_pair = "btc_krw")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency_pair", currency_pair);
            }

            return await APiClient.CallApiGetAsync<PublicTicker>("/v1/ticker", _params);
        }

        /// <summary>
        /// 시장 현황 상세정보 (DeatiledTicker)
        /// </summary>
        /// <param name="currency_pair">The type of trading currency of which information you want to query for. 
        /// Bitcoin trading is default. As our BETA service, you can also specify “etc_krw” for 
        /// Ethereum Classic trading and “eth_krw” for Ethereum trading.</param>
        /// <returns></returns>
        public async Task<PublicDetailedTicker> GetDetailedTicker(string currency_pair = "btc_krw")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency_pair", currency_pair);
            }

            return await APiClient.CallApiGetAsync<PublicDetailedTicker>("/v1/ticker/detailed", _params);
        }

        /// <summary>
        /// 매수/매도 호가 ( Orderbook )
        /// </summary>
        /// <param name="currency_pair">The type of trading currency of which information you want to query for. 
        /// Bitcoin trading is default. As our BETA service, you can also specify “etc_krw” for 
        /// Ethereum Classic trading and “eth_krw” for Ethereum trading.</param>
        /// <param name="category">List ask orders only if category=“ask”, bid orders only if category=“bid”, all orders if category=“all”.</param>
        /// <returns></returns>
        public async Task<OrderBook> GetOrderBook(string currency_pair = "btc_krw", OrderCategory category = OrderCategory.all)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency_pair", currency_pair);
                _params.Add("category", category);
            }

            return await APiClient.CallApiGetAsync<OrderBook>("/v1/orderbook", _params);
        }

        /// <summary>
        /// List of Filled Orders
        /// </summary>
        /// <param name="currency_pair">The type of trading currency of which information you want to query for. 
        /// Bitcoin trading is default. As our BETA service, you can also specify “etc_krw” for 
        /// Ethereum Classic trading and “eth_krw” for Ethereum trading.</param>
        /// <param name="time">The time period you want to query. 
        /// If this parameter is specified as minute, it queries data within the last minute, 
        /// hour means the last hour, day means the last 24 hours.</param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactions(string currency_pair = "btc_krw", Symbol time = Symbol.hour)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency_pair", currency_pair);
                _params.Add("time", time);
            }

            return await APiClient.CallApiGetAsync<List<Transaction>>("/v1/transactions", _params);
        }

        /// <summary>
        /// You can get constant values such as fee rates and minimum amount of BTC to transfer, etc.
        /// </summary>
        /// <returns>Constants</returns>
        public async Task<Constants> GetConstants()
        {
            return await APiClient.CallApiGetAsync<Constants>("/v1/constants");
        }
    }
}