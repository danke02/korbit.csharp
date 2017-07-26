using System.Collections.Generic;
using System.Linq;

namespace XCT.BaseLib.API.Korbit.User
{
    /// <summary>
    /// 
    /// </summary>
    public class CoinsOut
    {
        /// <summary>
        /// The unique ID of the BTC withdrawal request. You can use this ID to cancel a BTC withdrawal request or get the status of it.
        /// </summary>
        public string transferId;

        /// <summary>
        /// 'success’ if the BTC withdrawal was successful, an error symbol otherwise.
        /// </summary>
        public string status;
    }
}