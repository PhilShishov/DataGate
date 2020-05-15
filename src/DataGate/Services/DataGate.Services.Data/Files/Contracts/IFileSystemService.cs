namespace DataGate.Services.Data.Files.Contracts
{
    using System.Threading.Tasks;

    using DataGate.Web.InputModels.Files;

    public interface IFileSystemService
    {
        Task UploadDocument(UploadDocumentInputModel model);

        Task UploadAgreement(UploadAgreementInputModel model);

        void DeleteMapping(string docValue, string agrValue, string controllerName);
    }
}
