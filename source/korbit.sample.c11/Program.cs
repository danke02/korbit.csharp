using Korbit.API.Public;
using System;

namespace Korbit.Sample
{
    class Program
    {
        /// <summary>
        /// 1. Public API
        /// </summary>
        public static async void XPublicApi()
        {
            var _public_api = new XPublicApi();

            var _ticker = await _public_api.GetTicker();
            Console.WriteLine(_ticker.last);

            var _deailed_ticker = await _public_api.GetDetailedTicker();
            Console.WriteLine(_deailed_ticker.last);

            var _order_book = await _public_api.GetOrderBook();
            Console.WriteLine(_order_book.timestamp);

            var _transactions = await _public_api.GetTransactions();
            Console.WriteLine(_transactions.Count);

            var _constants = await _public_api.GetConstants();
            Console.WriteLine(_constants.minTradableLevel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var _debug_step = 1;

            // 1. Public API
            if (_debug_step == 1)
                XPublicApi();

            Console.WriteLine("hit any key to quit...");
            Console.ReadKey();
        }
    }
}