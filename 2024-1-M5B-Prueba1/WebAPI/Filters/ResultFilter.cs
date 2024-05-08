using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters
{

    public class ApiResponseFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
 
                var response = new
                {
                    success = true,
                    response = objectResult.Value 
                };

                context.Result = new JsonResult(response);
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }

}
