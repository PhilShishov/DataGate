namespace DataGate.Web.Tests.Controllers
{
    using DataGate.Common;
    using DataGate.Data.Models.Enums;
    using DataGate.Web.Controllers;

    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class BaseControllerTests
    {
        private const string ErrorMessage = "Some error message.";
        private string FormatedErrorMessage = string.Format(
                               GlobalConstants.SweetAlertScript,
                               NotificationType.error.ToString().ToUpper(),
                               ErrorMessage,
                               NotificationType.error);
        private const string InfoMessage = "Some info message.";
        private string FormatedInfoMessage = string.Format(
                              GlobalConstants.SweetAlertScript,
                              NotificationType.success.ToString().ToUpper(),
                              InfoMessage,
                              NotificationType.success);
        private const string Action = "Index";
        private const string Controller = "Home";
        private const string Route = "default";

        [Fact]
        public void ShowError_WithErrorMessage_ShouldAddErrorToTempData() =>
            MyController<BaseController>
            .Instance()
            .Calling(c => c.ShowError(ErrorMessage))
            .ShouldHave()
            .TempData(tempData => tempData
            .ContainingEntry(GlobalConstants.SweetAlertKey, FormatedErrorMessage))
            .AndAlso()
            .ShouldReturn();

        [Fact]
        public void ShowError_WithErrorMessageActionAndController_ShouldReturnRedirectResultAndAddErrorToTempData() =>
            MyController<BaseController>
            .Instance()
            .Calling(c => c.ShowError(ErrorMessage, Action, Controller))
            .ShouldHave()
            .TempData(tempData => tempData
            .ContainingEntry(GlobalConstants.SweetAlertKey, FormatedErrorMessage))
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction(Action, Controller);

        [Fact]
        public void ShowError_WithErrorMessageRouteAndValues_ShouldReturnRedirectResultAndAddErrorToTempData()
        {
            var routeValues = new { id = 1, date = "20200101" };
            MyController<BaseController>
            .Instance()
            .Calling(c => c.ShowError(ErrorMessage, Route, routeValues))
            .ShouldHave()
            .TempData(tempData => tempData
            .ContainingEntry(GlobalConstants.SweetAlertKey, FormatedErrorMessage))
            .AndAlso()
            .ShouldReturn()
            .RedirectToRoute(Route, routeValues);
        }

        [Fact]
        public void ShowErrorLocal_WithErrorMessageAndAction_ShouldReturnLocalRedirectAndAddErrorToTempData() =>
            MyController<BaseController>
            .Instance()
            .Calling(c => c.ShowErrorLocal(ErrorMessage, Action))
            .ShouldHave()
            .TempData(tempData => tempData
            .ContainingEntry(GlobalConstants.SweetAlertKey, FormatedErrorMessage))
            .AndAlso()
            .ShouldReturn()
            .LocalRedirect(Action);

        [Fact]
        public void ShowInfo_WithInfoMessageRouteAndValues_ShouldReturnRedirectResultAndAddInfoToTempData()
        {
            var routeValues = new { id = 1, date = "20200101" };
            MyController<BaseController>
            .Instance()
            .Calling(c => c.ShowInfo(InfoMessage, Route, routeValues))
            .ShouldHave()
            .TempData(tempData => tempData
            .ContainingEntry(GlobalConstants.SweetAlertKey, FormatedInfoMessage))
            .AndAlso()
            .ShouldReturn()
            .RedirectToRoute(Route, routeValues);
        }

        [Fact]
        public void ShowInfoLocal_WithInfoMessageAndAction_ShouldReturnLocalRedirectAndAddInfoToTempData()
        {
            MyController<BaseController>
            .Instance()
            .Calling(c => c.ShowInfoLocal(InfoMessage, Action))
            .ShouldHave()
            .TempData(tempData => tempData
            .ContainingEntry(GlobalConstants.SweetAlertKey, FormatedInfoMessage))
            .AndAlso()
            .ShouldReturn()
            .LocalRedirect(Action);
        }
    }
}
