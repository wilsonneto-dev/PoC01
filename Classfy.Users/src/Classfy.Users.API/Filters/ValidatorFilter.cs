using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Classfy.Users.API.Filters;
public class ValidatorFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    { }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid) return;
        var messages = context.ModelState
            .SelectMany(ms => ms.Value.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        context.Result = new BadRequestObjectResult(messages);
    }
}