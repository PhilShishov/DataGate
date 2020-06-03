namespace DataGate.Services.Data.Documents
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDocumentService
    {
        IReadOnlyCollection<string> GetDocumentsFileTypes(int fileType);

        Task<int> GetByIdDocumentType(string documentType);

        IAsyncEnumerable<string> GetAgreementsFileTypes(int fileType);

        Task<int> GetByIdAgreementType(string agrType);

        IAsyncEnumerable<string> GetAgreementStatus();

        Task<int> GetByIdStatus(string status);

        IAsyncEnumerable<string> GetCompanies();

        Task<int> GetByIdCompany(string company);
    }
}
