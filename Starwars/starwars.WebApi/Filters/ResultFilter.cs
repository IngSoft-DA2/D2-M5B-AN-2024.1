using System;
using Microsoft.AspNetCore.Mvc.Filters;
public class ResultFilter : Attribute, IResultFilter
{
    public void OnResultExecuted(ResultExecutedContext context)
    {
        Console.WriteLine("OnResultExecuted");
    }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        Console.WriteLine("OnResultExecuting");
    }
}