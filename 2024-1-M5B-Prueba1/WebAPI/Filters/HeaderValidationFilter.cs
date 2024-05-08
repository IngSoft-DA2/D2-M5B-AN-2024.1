using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters;

public class HeaderValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("dictado", out var dictadoValue) || dictadoValue != "M5B-AN")
        {
            context.Result = new ContentResult()
            {
                StatusCode = 401,
                Content = "Solicitud inválida",
                ContentType = "text/plain"
            };
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // No es necesario realizar acciones después de la ejecución del controlador
    }
}