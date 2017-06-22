namespace Korbit.API
{
    /// <summary>
    /// 
    /// </summary>
    public class KApiResult
    {
        public KApiResult()
        {
            this.success = false;
            this.message = "";
        }

        /// <summary>
        /// 
        /// </summary>
        public bool success
        {
            get;
            set;
        }

        /// <summary>
        /// 결과 메시지
        /// </summary>
        public string message
        {
            get;
            set;
        }
    }
}