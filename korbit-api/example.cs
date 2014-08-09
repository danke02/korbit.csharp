using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace korbit_api
{
    class Program
    {
        static void Main(string[] args) {

		String port = System.getenv("KORBIT_API_PORT");
		if (port == null || port.equals("")) {
			Console.WriteLine("You need to set KORBIT_API_PORT environment variable.");
			Console.WriteLine("To connect to api.korbit.co.kr:8080 (korbitdevday.herokuapp.com), set KORBIT_API_PORT to 8080.");
			Console.WriteLine("To connect to api.korbit.co.kr (www.korbit.co.kr), set KORBIT_API_PORT to 443.");
		}

		String key = System.getenv("KORBIT_API_KEY"); 
		String secret = System.getenv("KORBIT_API_SECRET");
		if (key == null || key.equals("") || secret == null || secret.equals("")) {
			Console.WriteLine("You need to set KORBIT_API_KEY and KORBIT_API_SECRET environment variable.");
			Console.WriteLine("To get the key, see the following URL.");
			Console.WriteLine("https://bitbucket.org/korbit/korbit-api/wiki/Home");	
		}

		String username = System.getenv("KORBIT_API_USERNAME");
		String password = System.getenv("KORBIT_API_PASSWORD");
		if (username == null || username.equals("") || password == null || password.equals("")) {
			Console.WriteLine("You need to set KORBIT_API_USERNAME and KORBIT_API_PASSWORD environment variable.");
			Console.WriteLine("To connect to api.korbit.co.kr:8080, use your username and password on korbitdevday.herokuapp.com.");
			Console.WriteLine("To connect to api.korbit.co.kr, use your username and password on www.korbit.co.kr.");
		}

	    //////////////////////////////////////////////////////////////
	    // Set URL prefix. 
	    //////////////////////////////////////////////////////////////

	    // To use the test server, you need to override the default prefix value on the URLPrefix class.
		JConfig.setUrlPrefix("https://api.korbit.co.kr:"+port+"/v1/");

	    //////////////////////////////////////////////////////////////
	    // APIs Without Authentication
	    //////////////////////////////////////////////////////////////
	    Console.WriteLine("API : Get API version");
	    try {
	      Version version = JAPI.version(); 
	      Console.WriteLine(version.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }

	    Console.WriteLine("API : Get constants such as minimum amount of BTC you can transfer.");
	    try {
	      Constants constants = JAPI.constants(); 
	      Console.WriteLine(constants.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }

	    Console.WriteLine("API : Get current price.");
	    try {
	      Ticker ticker = JAPI.market.ticker();
	      Console.WriteLine("success : " + ticker);
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }

	    Console.WriteLine("API : Get current price and low/high/volume of the recent 24 hours.");
	    try {
	      FullTicker fullTicker = JAPI.market.fullTicker();
	      Console.WriteLine("success : " + fullTicker);
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }

	    Console.WriteLine("API : Get complete orderbook.");
	    try {
	      OrderBook orderbook = JAPI.market.orderbook();
	      Console.WriteLine("success : " + orderbook.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }

	    Console.WriteLine("API : Get transactions since transaction id 1.");
	    try {
	      long since = 1;
	      java.util.List<Transaction> transactions = JAPI.market.transactions(since) ;
	      Console.WriteLine("success : " + transactions.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }

	    //////////////////////////////////////////////////////////////
	    // APIs With Authentication : User Information
	    //////////////////////////////////////////////////////////////
	    Console.WriteLine("Authentication : Get an authenticated channel with single user API-key.");
	    // Note : Multi user API-keys are not supported in this library.
	    JChannel channel = JAPI.createChannel(key, secret, username, password);

	    Console.WriteLine("API : Get user information.");
	    try {
	      User user = channel.user.info();
	      Console.WriteLine("success : " + user.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }    

	    Console.WriteLine("API : Get user wallet information.");
	    try {
	      Wallet wallet = channel.user.wallet();
	      Console.WriteLine("success : " + wallet.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }  

	    //////////////////////////////////////////////////////////////
	    // APIs With Authentication : Managing Orders
	    //////////////////////////////////////////////////////////////
	    Console.WriteLine("API : Get transactions of the user.");
	    try {
	      java.util.List<UserTransaction> txs = channel.order.transactions();
	      Console.WriteLine("success : " + txs.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }  

	    Console.WriteLine("API : Get open orders of the user.");
	    try {
	      java.util.List<OpenOrder> openOrders = channel.order.openOrders();
	      Console.WriteLine("success : " + openOrders.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }  
	    
	    Console.WriteLine("API : Place a limit order (buy).");
	    try {
	      OrderId id = channel.order.placeLimitOrder(JORDER_TYPE.BUY, 400000, 0.01);
	      Console.WriteLine("success : " + id.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    } 

	    Console.WriteLine("API : Place a limit order (sell).");
	    try {
	      OrderId id = channel.order.placeLimitOrder(JORDER_TYPE.SELL, 500000, 0.01);
	      Console.WriteLine("success : " + id.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    } 

	    Console.WriteLine("API : Place a market order (buy).");
	    try {
	      OrderId id = channel.order.placeMarketOrder(JORDER_TYPE.BUY, 10000);
	      Console.WriteLine("success : " + id.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }  

	    Console.WriteLine("API : Place a market order (sell).");
	    try {
	      OrderId id = channel.order.placeMarketOrder(JORDER_TYPE.SELL, 0.01);

	      Console.WriteLine("success : " + id.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }  

	    Console.WriteLine("API : Place an order, and cancel it right after it was placed.");
	    try {
	      OrderId orderId = channel.order.placeLimitOrder(JORDER_TYPE.BUY, 410000, 0.01);
	      Console.WriteLine("success(place order) : " + orderId.toString());

	      java.util.List<CancelOrderResult> result = channel.order.cancelOrder(java.util.Arrays.asList( new OrderId(orderId.id() ) ) );
	      Console.WriteLine("result(cancel order) : " + result.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    } 

	    Console.WriteLine("API : Place an order, and check the order status right after it was placed.");
	    try {    
	      OrderId orderId = channel.order.placeLimitOrder(JORDER_TYPE.BUY, 420000, 0.01);
	      Console.WriteLine("success(place order) : " + orderId.toString());

	      java.util.List<UserTransaction> result = channel.order.transactions(orderId);
	      Console.WriteLine("result(get order if filled) : " + result.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    } 

	    //////////////////////////////////////////////////////////////
	    // APIs With Authentication : Managing Fiats
	    //////////////////////////////////////////////////////////////

	    Console.WriteLine("API : Assign KRW Bank address to which the user can deposit KRW.");
	    try {
	      FiatAddress inAddress = channel.fiat.assignInAddress();
	      Console.WriteLine("success : " + inAddress.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    } 

	    Console.WriteLine("API : Register KRW Bank address to which the user can withdraw KRW.");
	    try {
	      FiatAddress outAddress = channel.fiat.registerOutAddress("우리은행", "1001-100-100000");
	      Console.WriteLine("success : " + outAddress.toString()); 
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }  

	    Console.WriteLine("API : Request KRW withdrawal.");
	    try {
	      FiatOutRequest req = channel.fiat.requestFiatOut(10000);
	      Console.WriteLine("success : " + req.toString());

	      // Query the request
	      java.util.List<FiatStatus> status = channel.fiat.queryFiatOut(req);
	      Console.WriteLine("result(status) : " + status.toString());

	      channel.fiat.cancelFiatOut(req);
	      Console.WriteLine("result(cancel) : success");
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    } 

	    //////////////////////////////////////////////////////////////
	    // APIs With Authentication : Managing Coins
	    //////////////////////////////////////////////////////////////

	    Console.WriteLine("API : Assign BTC address to which the user can deposit BTC.");
	    try {
	      CoinAddress inAddress = channel.coin.assignInAddress();
	      Console.WriteLine("result(cancel) : " + inAddress.toString());
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    } 
	    
	    Console.WriteLine("API : Request BTC withdrawal.");
	    try {
	      String address = null;

	      if ( JConfig.getUrlPrefix().contains("8080") )
	        address = "myxvvKU8FrYgkztK4h2xwU88atorcqybMn"; // Testnet address
	      else
	        address = "1anjg6B2XbpjHh8LFw8mXHATH54vrxs2F"; // Bitcoin address
	      
	      CoinOutRequest req = channel.coin.requestCoinOut(address, 0.01);
	      Console.WriteLine("success : " + req.toString());

	      java.util.List<CoinStatus> status = channel.coin.queryCoinOut(req);
	      Console.WriteLine("result(status) : " + status.toString());

	      channel.coin.cancelCoinOut(req);
	      Console.WriteLine("result(cancel) : success");
	    } catch(APIException e) {
	      Console.WriteLine("failure : " + e.toString());
	    }  		
}}