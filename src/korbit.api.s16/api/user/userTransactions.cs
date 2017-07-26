using System.Collections.Generic;
using System.Linq;

namespace XCT.BaseLib.API.Korbit.User
{
    /// <summary>
    /// You have following sub-fields under 'fillsDetail’ field, which comes only if the category is 'fills’.
    /// https://apidocs.korbit.co.kr/#user-:-transaction-history---order-fills,-krw/btc-deposit-and-transfer
    /// </summary>
    public class FillsDetail
    {
        /// <summary>
        /// The price of an order fill. 
        /// You have two sub-fields. One is 'currency’, which is always set to 'krw’ for now. 
        /// Another is 'value’, which is set to the filled price.
        /// </summary>
        public CurrencyValue price;

        /// <summary>
        /// The amount of selected currency in the order fill. 
        /// You have two sub-fields. 
        /// One is 'currency’, which is set to one currency you selected in currency_pair field among 'btc’, 'etc’ or 'eth’. 
        /// Another is 'value’, which is set to the filled amount of that selected currency.
        /// </summary>
        public CurrencyValue amount;

        /// <summary>
        /// The calculated amount of the order represented in KRW, based on the filled price.
        /// </summary>
        public CurrencyValue native_amount;

        /// <summary>
        /// The ID of the filled order. This is the ID of order you placed
        /// </summary>
        public string orderId;
    }

    /// <summary>
    /// 
    /// </summary>
    public class TransactionData
    {
        /// <summary>
        /// Unix timestamp in milliseconds specifying the time that the transaction happened.
        /// </summary>
        public long timestamp;

        /// <summary>
        /// Unix timestamp in milliseconds specifying the time the transaction was completed. 
        /// For 'fills’ category this field is always set. 
        /// For deposits and withdrawals of BTC and KRW, you have this field only if it is successfully completed. 
        /// Any pending deposits or withdrawals do not have this field set.
        /// </summary>
        public long completedAt;

        /// <summary>
        /// The unique identifier of the transaction. 
        /// The ID is unique within the category boundary.
        /// For example, the 'id’ field is unique within 'fills’ category, but the same ID can be used in 'krw’ or 'btc’ category.
        /// </summary>
        public string id;

        /// <summary>
        /// The type of transaction. See the list of Transaction Types shown below.
        /// </summary>
        public string type;

        /// <summary>
        /// In case category is 'fills’, you have the fee paid by user in this field. 
        /// The fee paid by buyer comes with 'btc’ currency, and the fee paid by seller comes with 'krw’ currency. 
        /// In case category is 'fiats’ and type is 'fiat-out’, you have the fee paid for KRW withdrawal. 
        /// In case category is 'coins’ and type is 'coin-out’, you have the fee paid for BTC withdrawal. 
        /// In other cases, you don’t have this field in the response.
        /// </summary>
        public CurrencyValue fee;

        /// <summary>
        /// The balance after the transaction completed. 
        /// You have an array of balances for different currencies. 
        /// Each item in the array as two fields. 
        /// One is currency which can be 'krw’ for Korean Won and 'btc’ for Bitcoin. 
        /// Another is 'value’ which has the balance of the currency.
        /// </summary>
        public List<CurrencyValue> balances;

        /// <summary>
        /// 
        /// </summary>
        public FillsDetail fillsDetail;
    }

    /// <summary>
    /// 
    /// </summary>
    public class Transactions : List<TransactionData>
    {

    }
}