namespace DataGate.Web.Controllers
{
    using DataGate.Common;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        public IActionResult ShowError(string errorMessage, string route)
        {
            this.TempData[GlobalConstants.ErrorKey] = errorMessage;
            return this.RedirectToRoute(route);
        }

        public IActionResult ShowError(string errorMessage, string route, object routeValues)
        {
            this.TempData[GlobalConstants.ErrorKey] = errorMessage;
            return this.RedirectToRoute(route, routeValues);
        }

        public IActionResult ShowError(string errorMessage, string action, string controller)
        {
            this.TempData[GlobalConstants.ErrorKey] = errorMessage;
            return this.RedirectToAction(action, controller);
        }

        public IActionResult ShowErrorLocal(string errorMessage, string action)
        {
            this.TempData[GlobalConstants.ErrorKey] = errorMessage;
            return this.LocalRedirect(action);
        }

        public IActionResult ShowInfo(string infoMessage, string route, object routeValues)
        {
            this.TempData[GlobalConstants.InfoKey] = infoMessage;
            return this.RedirectToRoute(route, routeValues);
        }

        public IActionResult ShowInfoLocal(string infoMessage, string action)
        {
            this.TempData[GlobalConstants.InfoKey] = infoMessage;
            return this.LocalRedirect(action);
        }
    }
}
