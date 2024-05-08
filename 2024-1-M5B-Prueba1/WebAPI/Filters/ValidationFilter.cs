using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("dictado", out var headerValue))
            {
                context.Result = new UnauthorizedObjectResult("Solicitud inválida");
                return;
            }

            if (headerValue != "M5B-AN")
            {
                context.Result = new UnauthorizedObjectResult("Solicitud inválida");
            }

            base.OnActionExecuting(context);
        }
    }
}
