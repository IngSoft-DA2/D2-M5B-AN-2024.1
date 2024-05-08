using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters;

public class CommonResponseFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ContentResult contentResult && contentResult.StatusCode == 401)
        {
            var errorResponse = new ObjectResult(new
            {
                success = false,
                response = contentResult.Content
            })
            {
                StatusCode = 401 
            };

            context.Result = errorResponse;
        }
        else
        {
            var originalResult = context.Result as ObjectResult;

            var formattedResult = new ObjectResult(new
            {
                success = originalResult != null && (originalResult.StatusCode >= 200 && originalResult.StatusCode < 300),
                response = originalResult?.Value ?? "Operación no completada correctamente"
            })
            {
                StatusCode = originalResult?.StatusCode
            };

            context.Result = formattedResult;
        }

        await next();
    }
}
