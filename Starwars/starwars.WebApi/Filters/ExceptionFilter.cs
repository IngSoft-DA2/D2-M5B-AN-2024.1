using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using starwars.Exceptions.BusinessLogicExceptions;

namespace starwars.WebApi.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
    public void OnException(ExceptionContext context)
        {
            // Type type = context.GetType();
            //Wrong
            // switch (type)
            // {
                
            //     default:
            // }
            try
            {
                throw context.Exception;
            }
            catch (ResourceNotFoundException e)
            {
                context.Result = new ObjectResult(new { Message = e.Message }) { StatusCode = 404 };
            }
            catch (InvalidResourceException e)
            {
                context.Result = new ObjectResult(new { Message = e.Message }) { StatusCode = 400 };
            }
            catch (InvalidOperationException e)
            {
                // 409 - Conflict
                context.Result = new ObjectResult(new { Message = e.Message }) { StatusCode = 409 };
            }
            catch (InvalidCredentialException e)
            {
                context.Result = new ObjectResult(new { Message = e.Message }) { StatusCode = 401 };
            }
            catch (Exception e)
            {
                // En un proyecto real, se agrega logging mas sofisticado
                Console.WriteLine($"Message: {e.Message} - StackTrace: {e.StackTrace}");

                context.Result = new ObjectResult(new
                        { Message = "We encountered some issues, try again later" })
                        { StatusCode = 500 };
            }
        }
    }
}

