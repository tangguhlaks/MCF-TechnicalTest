using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Middleware
{
    public class IsNotLoginMiddleware : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isNotAuthenticated = string.IsNullOrEmpty(context.HttpContext.Session.GetString("Username"));
            if (isNotAuthenticated)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
