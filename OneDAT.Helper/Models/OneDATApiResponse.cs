namespace OneDAT.Helper.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class OneDATApiResponse
    {
        public string Message { get; private set; }
        public object Data { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public OneDATApiResponse(string message, object data)
        {
            Message = message;
            Data = data;
        }
    }
}
