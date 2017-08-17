namespace XCT.BaseLib.API.Korbit.User
{
    /// <summary>
    ///
    /// </summary>
    public class UserBalanceData
    {
        /// <summary>
        /// The amount of funds you can use.
        /// </summary>
        public decimal available;

        /// <summary>
        /// The amount of funds that are being used in trade.
        /// </summary>
        public decimal trade_in_use;

        /// <summary>
        /// The amount of funds that are being processed for withdrawal.
        /// </summary>
        public decimal withdrawal_in_use;
    }

    /// <summary>
    /// GET https://api.korbit.co.kr/v1/user/balances
    /// </summary>
    public class UserBalances
    {
        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData bch;

        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData btc;

        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData dash;

        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData etc;

        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData eth;

        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData ltc;

        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData rep;

        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData steem;

        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData xmr;

        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData xrp;

        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData zec;

        /// <summary>
        /// 
        /// </summary>
        public UserBalanceData krw;
    }
}