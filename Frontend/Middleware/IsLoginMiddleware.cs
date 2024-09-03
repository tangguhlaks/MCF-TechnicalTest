using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Frontend.Middleware
{
    public class IsLoginMiddleware : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isAuthenticated = !string.IsNullOrEmpty(context.HttpContext.Session.GetString("Username"));
            if (isAuthenticated)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
