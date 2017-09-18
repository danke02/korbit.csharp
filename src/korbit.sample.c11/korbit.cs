using OdinSdk.BaseLib.Configuration;
using System;
using XCT.BaseLib.API.Korbit.Public;
using XCT.BaseLib.API.Korbit.Trading;
using XCT.BaseLib.API.Korbit.User;


namespace Korbit.Sample
{
    public partial class Korbit
    {
        private static CLogger __clogger = new CLogger();
        private static CConfig __cconfig = new CConfig();

        private static KPublicApi __k_public_api = new KPublicApi();
        private static KUserApi __k_user_api = new KUserApi("", "", "", "");
        private static KTradeApi __k_trade_api = new KTradeApi("", "", "", "");

        /// <summary>
        /// 1. Public API
        /// </summary>
        public static async void XPublicApi(int debug_step = 4)
        {
            if (debug_step == 1)
            {
                var _ticker = await __k_public_api.Ticker();
                Console.WriteLine(_ticker.last);
            }

            if (debug_step == 2)
            {
                var _deailed_ticker = await __k_public_api.DetailedTicker();
                Console.WriteLine(_deailed_ticker.last);
            }

            if (debug_step == 3)
            {
                var _order_book = await __k_public_api.OrderBook();
                Console.WriteLine(_order_book.timestamp);
            }

            if (debug_step == 4)
            {
                var _orders = await __k_public_api.CompleteOrders();
                Console.WriteLine(_orders.Count);
            }

            if (debug_step == 5)
            {
                var _constants = await __k_public_api.Constants();
                Console.WriteLine(_constants.minTradableLevel);
            }
        }

        /// <summary>
        /// 2. User API
        /// </summary>
        public static async void XUserApi(int debug_step = 3)
        {
            if (debug_step == 1)
            {
                var _balances = await __k_user_api.UserBalances();
                Console.WriteLine(_balances.krw.available);
            }

            if (debug_step == 2)
            {
                var _coins_out = await __k_user_api.Withdrawal("eth", 0.1m, "");
                if (_coins_out != null)
                    Console.WriteLine(_coins_out.status);
            }

            if (debug_step == 3)
            {
                var _coins_status = await __k_user_api.DepositsAndWithdrawals("eth");
                if (_coins_status != null)
                    Console.WriteLine(_coins_status.Count);
            }

            if (debug_step == 4)
            {
                var _accounts = await __k_user_api.UserAccounts();
                Console.WriteLine(_accounts.deposit.krw.account_name);
            }
        }

        /// <summary>
        /// 3. Trade API
        /// </summary>
        public static async void XTradeApi(int debug_step = 4)
        {
            if (debug_step == 1)
            {
                var _bid_order = await __k_trade_api.PlaceLimitBuy("eth_krw", 1.0m, 200000m, 200000m);
                if (_bid_order != null)
                    Console.WriteLine(_bid_order.orderId);
            }

            if (debug_step == 2)
            {
                var _ask_order = await __k_trade_api.PlaceLimitSell("eth_krw", 1.0m, 500000);
                if (_ask_order != null)
                    Console.WriteLine(_ask_order.orderId);
            }

            if (debug_step == 3)
            {
                var _cancel_orders = await __k_trade_api.CancelOrder("eth_krw", "6764154");
                if (_cancel_orders != null)
                    Console.WriteLine(_cancel_orders.Count);
            }

            if (debug_step == 4)
            {
                var _open_orders = await __k_trade_api.OpenOrders("eth_krw");
                if (_open_orders != null)
                    Console.WriteLine(_open_orders.Count);
            }
        }

        public static void Start(int debug_step = 1)
        {
            // 1. Public API
            if (debug_step == 1)
                XPublicApi();

            // 2. Private API
            if (debug_step == 2)
                XUserApi();

            // 3. Trade API
            if (debug_step == 3)
                XTradeApi();
        }
    }
}