using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OneDAT.Helper.Enumerations;
using OneDAT.Helper.Models;
using OneDAT.Web.Helper.HttpResult;

namespace OneDAT.Menu.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Tc"></typeparam>
    /// <typeparam name="Ts"></typeparam>
    public abstract class BaseApiController<Tc, Ts> : ControllerBase
    {
        protected internal readonly ILogger<Tc> Logger;
        protected internal readonly Ts Service;
        protected internal readonly IOptions<AppInformation> AppInformation;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appInformation"></param>
        /// <param name="logger"></param>
        /// <param name="service"></param>
        public BaseApiController(IOptions<AppInformation> appInformation, ILogger<Tc> logger, Ts service)
        {
            AppInformation = appInformation;
            Logger = logger;
            Service = service;
        }

        #region Response Result
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        protected internal virtual ObjectResult ServerError(string message, object data, Exception exception)
        {
            if (AppInformation.Value.DatabaseType == DatabaseType.AmazonDynamoDB && exception is System.Net.Http.HttpRequestException && exception.InnerException != null && exception.InnerException.Message == "The server name or address could not be resolved")
            {
                return new GatewayTimeoutResult(new OneDATApiResponse("Amazon DynamoDb not found or credentials not valid", false));
            }
            else return new InternalServerErrorResult(new OneDATApiResponse(message, data));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected internal OneDAT.Web.Helper.HttpResult.ConflictResult Conflict(string message, object data)
        {
            return new OneDAT.Web.Helper.HttpResult.ConflictResult(new OneDATApiResponse(message, data));
        }
        #endregion
    }
}