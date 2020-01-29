using OneDAT.Helper.Enumerations;

namespace OneDAT.Helper.Exception
{
    /// <summary>
    /// 
    /// </summary>
    public class OneDATException : System.Exception
    {
        public readonly OneDATExceptionCode Code = OneDATExceptionCode.None;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public OneDATException(string message) : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        public OneDATException(string message, OneDATExceptionCode code) : base(message)
        {
            Code = code;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public OneDATException(OneDATExceptionCode code) : base(string.Empty)
        {
            Code = code;
        }

    }
}
