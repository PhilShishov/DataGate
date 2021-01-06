// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

//namespace DataGate.Web.Tests.Controllers
//{
//    using System.Linq;

//    using MyTested.AspNetCore.Mvc;
//    using Xunit;

//    using DataGate.Web.Controllers;
//    using DataGate.Data;
//    using DataGate.Web.ViewModels.TimeSeries;
//    using DataGate.Web.Tests.TestData;

//    public class TimeSeriesControllerTests
//    {
//        [Theory]
//        [InlineData(1, "SubFund")]
//        [InlineData(1, "ShareClass")]
//        public void GetAllTimeSeries_WithValidIdAndArea_ShouldReturnPartialView(int id, string area)
//        {
//            var shareClass = ShareClassTestData
//               .GenerateShareClasses();

//            MyController<TimeSeriesController>
//                .Instance()
//                .WithData(data => data.WithEntities<ApplicationDbContext>(shareClass))
//                .Calling(c => c.GetAllTimeSeries(id, area))
//                .ShouldReturn()
//                .PartialView(result => result
//                    .WithModelOfType<TimeSeriesViewModel>()
//                        .Passing(model =>
//                        {
//                            //var actual = model.ShareClasses.ToList();

//                            //Assert.Equal(shareClasses.Count, actual.Count);

//                            //for (int i = 0; i < shareClasses.Count; i++)
//                            //{
//                            //    Assert.Equal(shareClasses[i].ScId, actual[i].ScId);
//                            //    Assert.Equal(shareClasses[i].ScOfficialShareClassName, actual[i].ScOfficialShareClassName);
//                            //}
//                        }));
//        }
//    }
//}
