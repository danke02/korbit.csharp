namespace XCT.BaseLib.API.Korbit.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAccountData
    {
        /// <summary>
        /// The address of your wallet.
        /// </summary>
        public string address;

        /// <summary>
        /// Destination tag used in XRP transactions. Only shows for XRP account.
        /// </summary>
        public string destination_tag;

        /// <summary>
        /// The name of the bank. Shows only for KRW.
        /// </summary>
        public string bank_name;

        /// <summary>
        /// The account number of the bank. Shows only for KRW.
        /// </summary>
        public string account_number;

        /// <summary>
        /// The name of the owner of the registered bank. Shows only for KRW.
        /// </summary>
        public string account_name;

    }

    /// <summary>
    /// 
    /// </summary>
    public class UserAccountDeposit
    {
        /// <summary>
        /// 
        /// </summary>
        public UserAccountData btc;

        /// <summary>
        /// 
        /// </summary>
        public UserAccountData etc;

        /// <summary>
        /// 
        /// </summary>
        public UserAccountData eth;

        /// <summary>
        /// 
        /// </summary>
        public UserAccountData xrp;

        /// <summary>
        /// 
        /// </summary>
        public UserAccountData krw;
    }

    /// <summary>
    /// GET https://api.korbit.co.kr/v1/user/accounts
    /// </summary>
    public class UserAccounts
    {
        /// <summary>
        /// 
        /// </summary>
        public UserAccountDeposit deposit;
    }
}