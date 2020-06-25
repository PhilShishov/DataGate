namespace DataGate.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class AllowSameSiteAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            if (response != null)
            {
                response.Headers.Add("Set-Cookie", "HttpOnly;Secure;SameSite=Strict");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
