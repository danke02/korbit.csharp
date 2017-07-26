﻿using System;
using XCT.BaseLib.API.Korbit.Public;
using XCT.BaseLib.API.Korbit.Trading;
using XCT.BaseLib.API.Korbit.User;

namespace Korbit.Sample
{
    class Program
    {
        /// <summary>
        /// 1. Public API
        /// </summary>
        public static async void XPublicApi(int debug_step = 1)
        {
            var _public_api = new KPublicApi();

            if (debug_step == 1)
            {
                var _ticker = await _public_api.Ticker();
                Console.WriteLine(_ticker.last);
            }

            if (debug_step == 1)
            {
                var _deailed_ticker = await _public_api.DetailedTicker();
                Console.WriteLine(_deailed_ticker.last);
            }

            if (debug_step == 1)
            {
                var _order_book = await _public_api.OrderBook();
                Console.WriteLine(_order_book.timestamp);
            }

            if (debug_step == 1)
            {
                var _transactions = await _public_api.Transactions();
                Console.WriteLine(_transactions.Count);
            }

            if (debug_step == 1)
            {
                var _constants = await _public_api.Constants();
                Console.WriteLine(_constants.minTradableLevel);
            }
        }

        /// <summary>
        /// 2. User API
        /// </summary>
        public static async void XUserApi(int skip_step = 3)
        {
            var __info_api = new KUserApi("", "", "", "");

        }

        /// <summary>
        /// 3. Trade API
        /// </summary>
        public static async void XTradeApi(int skip_step = 1)
        {
            var __trade_api = new KTradeApi("", "", "", "");

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

            // 2. Private API
            if (_debug_step == 2)
                XUserApi();

            // 3. Trade API
            if (_debug_step == 3)
                XTradeApi();

            Console.WriteLine("hit any key to quit...");
            Console.ReadKey();
        }
    }
}