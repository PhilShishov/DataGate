namespace DataGate.Web.Controllers
{
    using DataGate.Common;
    using DataGate.Data.Models.Enums;
    using Microsoft.AspNetCore.Mvc;

    public partial class BaseController : Controller
    {
        public void ShowInfoAlertify(string infoMessage)
        {
            this.TempData[GlobalConstants.AlertifyKey] = FormatInfoAlertify(infoMessage);
        }

        public IActionResult ShowInfoAlertify(string infoMessage, string route, object routeValues)
        {
            this.TempData[GlobalConstants.AlertifyKey] = FormatInfoAlertify(infoMessage);
            return this.RedirectToRoute(route, routeValues);
        }

        public IActionResult ShowInfoAlertify(string infoMessage, string action, string controller)
        {
            this.TempData[GlobalConstants.AlertifyKey] = FormatInfoAlertify(infoMessage);
            return this.RedirectToAction(action, controller);
        }

        public void ShowErrorAlertify(string errorMessage)
        {
            this.TempData[GlobalConstants.AlertifyKey] = FormatErrorAlertify(errorMessage);
        }

        public IActionResult ShowErrorAlertify(string errorMessage, string route, object routeValues)
        {
            this.TempData[GlobalConstants.AlertifyKey] = FormatErrorAlertify(errorMessage);
            return this.RedirectToRoute(route, routeValues);
        }

        public IActionResult ShowErrorAlertify(string errorMessage, string action, string controller)
        {
            this.TempData[GlobalConstants.AlertifyKey] = FormatErrorAlertify(errorMessage);
            return this.RedirectToAction(action, controller);
        }

        public IActionResult ShowInfo(string infoMessage, string route, object routeValues)
        {
            this.TempData[GlobalConstants.SweetAlertKey] = FormatInfoSweetAlert(infoMessage);
            return this.RedirectToRoute(route, routeValues);
        }

        public IActionResult ShowErrorLocal(string errorMessage, string action)
        {
            this.TempData[GlobalConstants.SweetAlertKey] = FormatErrorSweetAlert(errorMessage);
            return this.LocalRedirect(action);
        }

        public IActionResult ShowInfoLocal(string infoMessage, string action)
        {
            this.TempData[GlobalConstants.SweetAlertKey] = FormatInfoSweetAlert(infoMessage);
            return this.LocalRedirect(action);
        }

        private static string FormatInfoAlertify(string infoMessage)
        {
            return string.Format(GlobalConstants.AlertifyScript, infoMessage, NotificationType.success);
        }

        private static string FormatErrorAlertify(string errorMessage)
        {
            return string.Format(GlobalConstants.AlertifyScript, errorMessage, NotificationType.error);
        }

        private static string FormatInfoSweetAlert(string infoMessage)
        {
            var notificationType = NotificationType.success;
            return string.Format(GlobalConstants.SweetAlertScript, notificationType.ToString().ToUpper(), infoMessage, notificationType);
        }

        private static string FormatErrorSweetAlert(string errorMessage)
        {
            var notificationType = NotificationType.error;
            return string.Format(GlobalConstants.SweetAlertScript, notificationType.ToString().ToUpper(), errorMessage, notificationType);
        }
    }
}
