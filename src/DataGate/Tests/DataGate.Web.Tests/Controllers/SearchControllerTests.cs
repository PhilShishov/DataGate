// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Tests.Controllers
{
    using System;
    using System.Linq;

    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using DataGate.Common;
    using DataGate.Common.Exceptions;
    using DataGate.Data;
    using DataGate.Web.Controllers;
    using DataGate.Web.Tests.TestData;

    public class SearchControllerTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("        ")]
        public void Result_WithInvalidSearchTerm_ShouldThrowException(string searchTerm) =>
            MyController<SearchController>
            .Instance()
            .Calling(c => c.Result(searchTerm))
            .ShouldThrow()
            .Exception()
            .OfType<BadRequestException>()
            .WithMessage(ErrorMessages.InvalidSearchKeyword);


        // Unit testing not implemented with EF.Functions.Contains
        //[Theory]
        //[InlineData("pharus")]
        //[InlineData("multi")]
        //[InlineData("LU00000000")]
        //[InlineData("empty view")]
        //public void Result_WithValidSearchTermAndNoISIN_ShouldReturnViewWithRelatedOrEmptyData(string searchTerm)
        //{
        //    var shareClasses = ShareClassTestData
        //       .GenerateShareClasses()
        //       .Where(sc => sc.ScOfficialShareClassName.Contains(searchTerm))
        //       .ToList();

        //    MyController<SearchController>
        //    .Instance()
        //    .WithData(data => data.WithEntities<ApplicationDbContext>(shareClasses))
        //    .Calling(c => c.Result(searchTerm))
        //    .ShouldReturn()
        //    .View(result => result
        //        .WithModelOfType<SearchResultsViewModel>()
        //        .Passing(model =>
        //        {
        //            var actual = model.Results.ToList();

        //            //Assert.NotNull(actual);
        //            Assert.Equal(shareClasses.Count, actual.Count);

        //            for (int i = 0; i < shareClasses.Count; i++)
        //            {
        //                Assert.Equal(shareClasses[i].ScId, actual[i].ScId);
        //                Assert.Equal(shareClasses[i].ScOfficialShareClassName, actual[i].ScOfficialShareClassName);
        //            }
        //        }));
        //}

        [Theory]
        [InlineData("LU00001")]
        [InlineData("LU00005")]
        public void Result_WithValidISIN_ShouldRedirectToDetailsView(string searchTerm)
        {
            var shareClass = ShareClassTestData
               .GenerateShareClasses()
               .FirstOrDefault(sc => sc.ScIsinCode == searchTerm);

            var date = DateTime.Today.ToString(GlobalConstants.RequiredWebDateTimeFormat);

            var routeValues = new
            {
                area = EndpointsConstants.ShareClassArea,
                id = shareClass.ScId,
                date = date
            };

            MyController<SearchController>
            .Instance()
            .WithData(data => data.WithEntities<ApplicationDbContext>(shareClass))
            .Calling(c => c.Result(searchTerm))
            .ShouldReturn()
            .RedirectToRoute(
                EndpointsConstants.RouteDetails + EndpointsConstants.ShareClassArea,
                routeValues);
        }
    }
}
