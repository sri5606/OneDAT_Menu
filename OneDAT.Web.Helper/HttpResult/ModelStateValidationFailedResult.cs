using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace OneDAT.Web.Helper.HttpResult
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelStateValidationFailedResult : ObjectResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelState"></param>
        public ModelStateValidationFailedResult(ModelStateDictionary modelState)
            : base(new ValidationErrorModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ValidationErrorModel
    {
        public string Message { get; }

        public List<ValidationError> Data { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelState"></param>

        public ValidationErrorModel(ModelStateDictionary modelState)
        {
            Message = "Validation Failed";
            Data = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        public string Message { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="message"></param>

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }

}
