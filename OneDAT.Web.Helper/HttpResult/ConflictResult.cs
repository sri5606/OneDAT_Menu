using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneDAT.Helper.Models;

namespace OneDAT.Web.Helper.HttpResult
{
    /// <summary>
    /// 
    /// </summary>
    public class ConflictResult : ObjectResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public ConflictResult(OneDATApiResponse response) : base(response)
        {
            StatusCode = StatusCodes.Status409Conflict;
        }
    }
}
