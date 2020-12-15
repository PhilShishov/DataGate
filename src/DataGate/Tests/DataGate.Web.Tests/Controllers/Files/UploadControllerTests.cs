//namespace DataGate.Web.Tests.Controllers.Files
//{
//    using MyTested.AspNetCore.Mvc;
//    using Xunit;

//    using DataGate.Web.Controllers.Files;
//    using DataGate.Web.InputModels.Files;

//    public class UploadControllerTests
//    {
//        [Theory]
//        [InlineData()]
//        [InlineData()]
//        [InlineData()]
//        [InlineData()]
//        public void OnPostUploadDocumentAsync_WithInvalidModelState_ShouldReturnPartialView()
//        {
//            var model = new UploadDocumentInputModel()
//            {
//                DocumentType = "DocumentType",
//                //FileToUpload = 
//            };

//            MyController<UploadController>
//                .Instance()
//                //.WithData(data => data.WithEntities<ApplicationDbContext>(shareClass))
//                .Calling(c => c.OnPostUploadDocumentAsync(model))
//                .ShouldReturn()
//                .PartialView("Upload/_UploadDocument");
//        }
//    }
//}
