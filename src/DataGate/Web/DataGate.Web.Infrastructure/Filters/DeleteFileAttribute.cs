namespace DataGate.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class DeleteFileAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Body.FlushAsync();

            var result = filterContext.Result as PhysicalFileResult;

            if (result != null)
            {
                string filePath = result.FileName;
                System.IO.File.Delete(filePath);
            }
        }
    }
}
