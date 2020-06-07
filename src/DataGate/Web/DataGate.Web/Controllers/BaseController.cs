namespace DataGate.Web.Controllers
{
    using DataGate.Common;
    using DataGate.Data.Models.Enums;
    using Microsoft.AspNetCore.Mvc;

    public partial class BaseController : Controller
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

        public IActionResult ShowErrorLocal(string errorMessage, NotificationType notificationType, string action)
        {
            string result = string.Format(GlobalConstants.SweetAlertScript, notificationType.ToString().ToUpper(), errorMessage, notificationType);
            this.TempData[GlobalConstants.NotifKey] = result;
            return this.LocalRedirect(action);
        }

        public IActionResult ShowInfo(string infoMessage, string route, object routeValues)
        {
            this.TempData[GlobalConstants.InfoKey] = infoMessage;
            return this.RedirectToRoute(route, routeValues);
        }

        public IActionResult ShowInfo(string infoMessage, NotificationType notificationType, string route, object routeValues)
        {
            string result = string.Format(GlobalConstants.SweetAlertScript, notificationType.ToString().ToUpper(), infoMessage, notificationType);
            this.TempData[GlobalConstants.NotifKey] = result;
            return this.RedirectToRoute(route, routeValues);
        }

        public IActionResult ShowInfoLocal(string infoMessage, NotificationType notificationType, string action)
        {
            string result = string.Format(GlobalConstants.SweetAlertScript, notificationType.ToString().ToUpper(), infoMessage, notificationType);
            this.TempData[GlobalConstants.NotifKey] = result;
            return this.LocalRedirect(action);
        }
    }
}
