namespace DataGate.Web.Tests.Controllers
{
    using DataGate.Common;
    using DataGate.Common.Exceptions;
    using DataGate.Data;
    using DataGate.Web.Controllers;
    using DataGate.Web.Tests.TestData;
    using DataGate.Web.ViewModels.Search;
    using MyTested.AspNetCore.Mvc;
    using System.Linq;
    using Xunit;

    public class SearchControllerTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData("\0")]
        public void Result_WithInvalidSearchTerm_ShouldThrowException(string searchTerm) =>
            MyController<SearchController>
            .Instance()
            .Calling(c => c.Result(searchTerm))
            .ShouldThrow()
            .Exception()
            .OfType<BadRequestException>()
            .WithMessage(ErrorMessages.InvalidSearchKeyword);

        [Theory]
        [InlineData("pharus")]
        [InlineData("multi")]
        [InlineData("LU00000000")]
        [InlineData("empty view")]
        public void Result_WithValidSearchTermAndNoISIN_ShouldReturnViewWithRelatedOrEmptyData(string searchTerm)
        {
            var shareClasses = ShareClassTestData
               .GenerateShareClasses()
               .Where(sc => sc.ScOfficialShareClassName.Contains(searchTerm))
               .ToList();

            MyController<SearchController>
            .Instance()
            .WithData(data => data.WithEntities<ApplicationDbContext>(shareClasses))
            .Calling(c => c.Result(searchTerm))
            .ShouldReturn()
            .View(result => result
                .WithModelOfType<SearchListAllViewModel>()
                .Passing(model =>
                {
                    var actual = model.Results.ToList();

                    //Assert.NotNull(actual);
                    Assert.Equal(actual.Count, shareClasses.Count);

                    for (int i = 0; i < shareClasses.Count; i++)
                    {
                        Assert.Equal(shareClasses[i].ScId, actual[i].ScId);
                        Assert.Equal(shareClasses[i].ScOfficialShareClassName, actual[i].ScOfficialShareClassName);
                    }
                }));
        }

        [Theory]
        [InlineData("LU00000000")]
        public void Result_WithValidISIN_ShouldReturnViewWithData(string searchTerm)
        {
            var shareClasses = ShareClassTestData
               .GenerateShareClasses()
               .Where(sc => sc.ScOfficialShareClassName.Contains(searchTerm))
               .ToList();

            MyController<SearchController>
            .Instance()
            .WithData(data => data.WithEntities<ApplicationDbContext>(shareClasses))
            .Calling(c => c.Result(searchTerm))
            .ShouldReturn()
            .View(result => result
                .WithModelOfType<SearchListAllViewModel>()
                .Passing(model =>
                {
                    var actual = model.Results.ToList();

                    //Assert.NotNull(actual);
                    Assert.Equal(actual.Count, shareClasses.Count);

                    for (int i = 0; i < shareClasses.Count; i++)
                    {
                        Assert.Equal(shareClasses[i].ScId, actual[i].ScId);
                        Assert.Equal(shareClasses[i].ScOfficialShareClassName, actual[i].ScOfficialShareClassName);
                    }
                }));
        }
    }
}
