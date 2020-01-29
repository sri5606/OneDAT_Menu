using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneDAT.Helper.Models;

namespace OneDAT.Web.Helper.HttpResult
{
    /// <summary>
    /// 
    /// </summary>
    public class GatewayTimeoutResult : ObjectResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public GatewayTimeoutResult(OneDATApiResponse response) : base(response)
        {
            StatusCode = StatusCodes.Status504GatewayTimeout;
        }
    }
}
