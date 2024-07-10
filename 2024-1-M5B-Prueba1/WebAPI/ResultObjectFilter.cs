using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ResponseDTO
{
    public bool Success { get; set; }
    public Object? Value { get; set; }
}

public class ResultObjectFilter : Attribute, IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        // Do something before the result executes.
        ResponseDTO response = new ResponseDTO
        {
            Value = ((ObjectResult)context.Result).Value,
            Success = true
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = 200
        };
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        // Do something after the result executes.
    }
}