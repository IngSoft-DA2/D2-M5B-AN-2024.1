using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Filter
{
    [AttributeUsage(AttributeTargets.All)]
    public class ValidatorFilter(string s) : Attribute, IActionFilter
    {
        private readonly string Clase = s;

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string? header = context.HttpContext.Request.Headers.Authorization;

            if (header is null)
                context.Result = new ObjectResult(new { ErrorMessage = "Solicitud Invalida" }) { StatusCode = 401 };


                    if(!Clase.Equals("M5B-AN"))
                    {

                        context.Result = new ObjectResult(new { ErrorMessage = "Header Invalido" }) { StatusCode = 403 };
                    }
            }
        }
    }

