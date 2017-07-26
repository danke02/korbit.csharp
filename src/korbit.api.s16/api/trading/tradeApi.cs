using System.Collections.Generic;
using System.Threading.Tasks;

namespace XCT.BaseLib.API.Korbit.Trading
{
    /// <summary>
    /// 
    /// </summary>
    public class KTradeApi
    {
        private string __connect_key;
        private string __secret_key;
        private string __user_name;
        private string __user_password;

        /// <summary>
        /// 
        /// </summary>
        public KTradeApi(string connect_key, string secret_key, string user_name, string user_password)
        {
            __connect_key = connect_key;
            __secret_key = secret_key;
            __user_name = user_name;
            __user_password = user_password;
        }

        private KorbitClient __trade_client = null;

        private KorbitClient TradeClient
        {
            get
            {
                if (__trade_client == null)
                    __trade_client = new KorbitClient(__connect_key, __secret_key, __user_name, __user_password);
                return __trade_client;
            }
        }
    }
}