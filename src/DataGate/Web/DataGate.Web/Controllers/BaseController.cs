// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers
{
    using DataGate.Common;
    using DataGate.Data.Models.Enums;

    using Microsoft.AspNetCore.Mvc;

    public partial class BaseController : Controller
    {
        public void ShowError(string errorMessage)
        {
            this.TempData[GlobalConstants.SweetAlertKey] = FormatErrorSweetAlert(errorMessage);
        }
        public IActionResult ShowError(string errorMessage, string action, string controller)
        {
            this.TempData[GlobalConstants.SweetAlertKey] = FormatErrorSweetAlert(errorMessage);
            return this.RedirectToAction(action, controller);
        }

        public IActionResult ShowError(string errorMessage, string route, object routeValues)
        {
            this.TempData[GlobalConstants.SweetAlertKey] = FormatErrorSweetAlert(errorMessage);
            return this.RedirectToRoute(route, routeValues);
        }

        public IActionResult ShowInfo(string infoMessage, string action, string controller, object routeValues)
        {
            this.TempData[GlobalConstants.SweetAlertKey] = FormatInfoSweetAlert(infoMessage);
            return this.RedirectToAction(action, controller, routeValues);
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
