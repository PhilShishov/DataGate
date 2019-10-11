namespace Pharus.App.Infrastructure.Filters
{
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class AdminActivityLoggerFilter : IActionFilter
    {
        private readonly ILogger<AdminActivityLoggerFilter> logger;

        public AdminActivityLoggerFilter(ILogger<AdminActivityLoggerFilter> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ActionDescriptor.DisplayName.Contains("EventsController") && context.ActionDescriptor.DisplayName.Contains("Create"))
            {
                this.logger.LogInformation("OK");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
