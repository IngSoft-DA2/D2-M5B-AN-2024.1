
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI;

    public class RequestFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try{
                string token = context.HttpContext.Request.Headers["dictado"];
                if (token is null)
                {
                    context.Result = new ContentResult()
                    {
                        Content = "Se necesita un token",
                        StatusCode = 401
                    };
                }
                else
                {
                    if (token != "M5B-AN")
                    {
                        context.Result = new ContentResult()
                        {
                            Content = "Token incorrecto",
                            StatusCode = 401
                        };
                    }
                }
            }
            catch(Exception e)
            {
                context.Result = new ContentResult()
                {
                    Content = e.Message,
                    StatusCode = 401
                };
            
            }
        }
    }

