using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneDAT.Helper.Models;

namespace OneDAT.Web.Helper.HttpResult
{
    /// <summary>
    /// 
    /// </summary>
    public class InternalServerErrorResult : ObjectResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public InternalServerErrorResult(OneDATApiResponse response) : base(response)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
