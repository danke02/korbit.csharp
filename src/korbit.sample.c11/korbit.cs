using System;
using XCT.BaseLib.API.Korbit.Public;
using XCT.BaseLib.API.Korbit.Trading;
using XCT.BaseLib.API.Korbit.User;

namespace Korbit.Sample
{
    public class Korbit
    {
        /// <summary>
        /// 1. Public API
        /// </summary>
        public static async void XPublicApi(int debug_step = 6)
        {
            var _public_api = new KPublicApi();

            if (debug_step == 1)
            {
                var _ticker = await _public_api.Ticker();
                Console.WriteLine(_ticker.last);
            }

            if (debug_step == 2)
            {
                var _deailed_ticker = await _public_api.DetailedTicker();
                Console.WriteLine(_deailed_ticker.last);
            }

            if (debug_step == 3)
            {
                var _order_book = await _public_api.OrderBook();
                Console.WriteLine(_order_book.timestamp);
            }

            if (debug_step == 4)
            {
                var _transactions = await _public_api.Transactions();
                Console.WriteLine(_transactions.Count);
            }

            if (debug_step == 5)
            {
                var _constants = await _public_api.Constants();
                Console.WriteLine(_constants.minTradableLevel);
            }
        }

        /// <summary>
        /// 2. User API
        /// </summary>
        public static async void XUserApi(int debug_step = 6)
        {
            var __user_api = new KUserApi("", "", "", "");

            if (debug_step == 1)
            {
                var _wallet = await __user_api.UserWallet("eth_krw");
                Console.WriteLine(_wallet.available_qty("eth_krw"));
            }

            if (debug_step == 2)
            {
                var _traxs = await __user_api.Transactions("eth_krw");
                Console.WriteLine(_traxs.Count);
            }

            if (debug_step == 3)
            {
                var _coins_out = await __user_api.CoinsOut("btc", 0.1m, "");
                Console.WriteLine(_coins_out.status);
            }

            if (debug_step == 4)
            {
                var _coins_status = await __user_api.CoinsStatus("btc");
                Console.WriteLine(_coins_status.Count);
            }

            if (debug_step == 5)
            {
                var _accounts = await __user_api.UserAccounts();
                Console.WriteLine(_accounts.deposit.krw.account_name);
            }

            if (debug_step == 6)
            {
                var _balances = await __user_api.UserBalances();
                Console.WriteLine(_balances.krw.available);
            }
        }

        /// <summary>
        /// 3. Trade API
        /// </summary>
        public static async void XTradeApi(int debug_step = 1)
        {
            var __trade_api = new KTradeApi("", "", "", "");

        }

        public static void Start(int debug_step = 2)
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