// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Tests.Controllers.Users
{
    using System.Linq;

    using DataGate.Data;
    using DataGate.Web.Controllers;
    using DataGate.Web.Tests.TestData;
    using DataGate.Web.ViewModels.Users;

    using MyTested.AspNetCore.Mvc;

    using Xunit;

    public class UserControllerTests
    {
        [Fact]
        public void UserControllerActions_ShouldBeAllowedOnlyForAuthorizedUsers() =>
          MyController<UserController>
          .Instance()
          .ShouldHave()
               .Attributes(attributes => attributes.RestrictingForAuthorizedRequests());

        [Fact]
        public void Index_WithDataFromDB_ShouldReturnViewWithData()
        {
            var user = TestApplicationUser.GetDefaultUser();
            var shareClasses = ShareClassTestData
                .GenerateShareClasses()
                .ToList();

            MyController<UserController>
            .Instance()
            .WithUser()
            .WithData(data => data.WithEntities<ApplicationDbContext>(shareClasses))
            .Calling(c => c.Index())
            .ShouldReturn()
            .View(result => result
                .WithModelOfType<UserPanelViewModel>()
                    .Passing(model =>
                    {
                        var actual = model.ShareClasses.ToList();

                        Assert.Equal(shareClasses.Count, actual.Count);

                        for (int i = 0; i < shareClasses.Count; i++)
                        {
                            Assert.Equal(shareClasses[i].ScId, actual[i].ScId);
                            Assert.Equal(shareClasses[i].ScOfficialShareClassName, actual[i].ScOfficialShareClassName);
                        }
                    }));
        }
    }
}
