namespace XCT.BaseLib.API.Korbit.Public
{
    /// <summary>
    /// 시장 현황 (Ticker)
    /// </summary>
    public class PublicTickerData
    {
        /// <summary>
        /// Unix timestamp in milliseconds of the last filled order.
        /// </summary>
        public long timestamp;

        /// <summary>
        /// Price of the last filled order.
        /// </summary>
        public decimal last;
    }
}