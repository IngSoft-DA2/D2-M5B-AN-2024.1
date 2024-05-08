using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI
{
    public class ResponseFormatFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var response = new ApiResponse
                {
                    Success = true,
                    Response = objectResult.Value
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = objectResult.StatusCode
                };
            }
        }
    }

    public class ValidateRequestFilter : IActionFilter
    {
        private const string RequiredHeaderName = "dictado";
        private const string RequiredHeaderValue = "M5B-AN";
        private const string InvalidRequestMessage = "Solicitud inválida";

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;

            if (!headers.ContainsKey(RequiredHeaderName) || headers[RequiredHeaderName] != RequiredHeaderValue)
            {
                context.Result = new UnauthorizedObjectResult(InvalidRequestMessage);
            }
        }
    }

    public class ApiResponse
    {
        public bool Success { get; set; }
        public object Response { get; set; }
    }
}

