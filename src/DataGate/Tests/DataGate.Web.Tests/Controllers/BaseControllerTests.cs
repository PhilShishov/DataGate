using DataGate.Common;
using DataGate.Data.Models.Enums;
using DataGate.Web.Controllers;

using MyTested.AspNetCore.Mvc;
using Xunit;

namespace DataGate.Web.Tests.Controllers
{
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
                              NotificationType.error.ToString().ToUpper(),
                              ErrorMessage,
                              NotificationType.error);
        private const string Action = "Index";
        private const string Controller = "Home";
        private const string Route = "default";
        private const string Area = GlobalConstants.AdministratorRoleName;

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

        //[Fact]
        //public void ShowError_WithErrorMessageActionControllerAndArea_ShouldReturnRedirectResultAndAddErrorToTempData() =>
        //   MyController<BaseController>
        //   .Instance()
        //   .Calling(c => c.ShowError(ErrorMessage, Action, Controller, new { Area }))
        //   .ShouldHave()
        //   .TempData(tempData => tempData.ContainingEntry(GlobalConstants.SweetAlertKey, ErrorMessage))
        //   .AndAlso()
        //   .ShouldReturn()
        //   .RedirectToAction(Action, Controller, new { Area });

        //[Fact]
        //public void ShowError_WithErrorMessageActionControllerAndRouteValues_ShouldReturnRedirectResultAndAddErrorToTempData()
        //{
        //    var routeValues = new { Area, LessonId = 5, ContestId = 45 };
        //    MyController<BaseController>
        //    .Instance()
        //    .Calling(c => c.ShowError(ErrorMessage, Action, Controller, routeValues))
        //    .ShouldHave()
        //    .TempData(tempData => tempData.ContainingEntry(GlobalConstants.SweetAlertKey, ErrorMessage))
        //    .AndAlso()
        //    .ShouldReturn()
        //    .RedirectToAction(Action, Controller, routeValues);
        //}

        //[Fact]
        //public void ShowInfo_WithInfoMessageActionAndController_ShouldReturnRedirectResultAndAddInfoMessageToTempData() =>
        //   MyController<BaseController>
        //   .Instance()
        //   .Calling(c => c.ShowInfo(InfoMessage, Action, Controller))
        //   .ShouldHave()
        //   .TempData(tempData => tempData.ContainingEntry(GlobalConstants.SweetAlertKey, InfoMessage))
        //   .AndAlso()
        //   .ShouldReturn()
        //   .RedirectToAction(Action, Controller);

        //[Fact]
        //public void ShowInfo_WithInfoMessageActionControllerAndRouteValues_ShouldReturnRedirectResultAndAddInfoToTempData()
        //{
        //    var routeValues = new { Area, LessonId = 5, ContestId = 45 };
        //    MyController<BaseController>
        //    .Instance()
        //    .Calling(c => c.ShowInfo(InfoMessage, Action, Controller, routeValues))
        //    .ShouldHave()
        //    .TempData(tempData => tempData.ContainingEntry(GlobalConstants.SweetAlertKey, InfoMessage))
        //    .AndAlso()
        //    .ShouldReturn()
        //    .RedirectToAction(Action, Controller, routeValues);
        //}

        //[Fact]
        //public void ShowInfo_WithInfoMessageActionAndRouteValues_ShouldReturnRedirectResultAndAddInfoToTempData()
        //{
        //    var routeValues = new { Area, LessonId = 5, ContestId = 45 };
        //    MyController<BaseController>
        //    .Instance()
        //    .Calling(c => c.ShowInfo(InfoMessage, Action, routeValues))
        //    .ShouldHave()
        //    .TempData(tempData => tempData.ContainingEntry(GlobalConstants.SweetAlertKey, InfoMessage))
        //    .AndAlso()
        //    .ShouldReturn()
        //    .RedirectToAction(Action, routeValues);
        //}
    }
}
