using Microsoft.AspNetCore.Mvc.Filters;

public class ActionFilter : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("OnActionExecuted");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("OnActionExecuting");
    }
}