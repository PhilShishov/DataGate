namespace DataGate.Web.Filters
{
    using DataGate.Common;
    using DataGate.Common.Exceptions;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class EndpointExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            string errorMessage = ErrorMessages.EndpointErrorMessage;
            if (context.Exception is EntityNotFoundException entityNotFoundException)
            {
                errorMessage = entityNotFoundException.Message;
            }
            else if (context.Exception is BadRequestException badRequestException)
            {
                errorMessage = badRequestException.Message;
            }

            context.Result = new BadRequestObjectResult(errorMessage);
        }
    }
}
