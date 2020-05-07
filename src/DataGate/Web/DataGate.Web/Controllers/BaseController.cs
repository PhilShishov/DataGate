namespace DataGate.Web.Controllers
{
    using DataGate.Common;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        public IActionResult ShowError(string errorMessage, string action, string controller)
        {
            this.TempData[GlobalConstants.ErrorKey] = errorMessage;
            return this.RedirectToAction(action, controller);
        }

        public IActionResult ShowError(string errorMessage, string action, string controller, string area)
        {
            this.TempData[GlobalConstants.ErrorKey] = errorMessage;
            return this.RedirectToAction(action, controller, new { area });
        }

        public IActionResult ShowError(string errorMessage, string action, string controller, object routeValues)
        {
            this.TempData[GlobalConstants.ErrorKey] = errorMessage;
            return this.RedirectToAction(action, controller, routeValues);
        }

        public IActionResult ShowInfo(string infoMessage, string action, string controller)
        {
            this.TempData[GlobalConstants.InfoKey] = infoMessage;
            return this.RedirectToAction(action, controller);
        }

        public IActionResult ShowInfo(string infoMessage, string action, object routeValues)
        {
            this.TempData[GlobalConstants.InfoKey] = infoMessage;
            return this.RedirectToAction(action, routeValues);
        }

        public IActionResult ShowInfo(string infoMessage, string action, string controller, object routeValues)
        {
            this.TempData[GlobalConstants.InfoKey] = infoMessage;
            return this.RedirectToAction(action, controller, routeValues);
        }
    }
}
