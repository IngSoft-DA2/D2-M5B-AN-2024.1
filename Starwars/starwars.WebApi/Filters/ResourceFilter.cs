using Microsoft.AspNetCore.Mvc.Filters;

public class ResourceFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        Console.WriteLine("OnResourceExecuted");
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        Console.WriteLine("OnResourceExecuting");
    }
}