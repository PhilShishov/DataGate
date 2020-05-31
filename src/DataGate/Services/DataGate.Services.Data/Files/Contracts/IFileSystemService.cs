namespace DataGate.Services.Data.Files.Contracts
{
    using System.Threading.Tasks;

    using DataGate.Web.InputModels.Files;

    public interface IFileSystemService
    {
        Task UploadDocument(UploadDocumentInputModel model);

        Task DeleteDocument(int fileId, string areaName);

        Task UploadAgreement(UploadAgreementInputModel model);

        Task DeleteAgreement(int fileId, string areaName);
    }
}
