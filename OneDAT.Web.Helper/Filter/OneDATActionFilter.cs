using Microsoft.AspNetCore.Mvc.Filters;
using OneDAT.Web.Helper.HttpResult;

namespace OneDAT.Web.Helper.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class OneDATActionFilter : IActionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ModelStateValidationFailedResult(context.ModelState);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }
}
