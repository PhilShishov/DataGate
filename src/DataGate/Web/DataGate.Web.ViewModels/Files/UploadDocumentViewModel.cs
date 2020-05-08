namespace DataGate.Web.ViewModels.Files
{
    using Microsoft.AspNetCore.Http;

    public class UploadDocumentViewModel
    {
        public string DocumentType { get; set; }

        public IFormFile FileToUpload { get; set; }
    }
}
