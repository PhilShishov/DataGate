namespace DataGate.Services.Data.Documents.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDocumentService
    {
        IReadOnlyCollection<string> GetDocumentsFileTypes();

        Task<int> GetByIdDocumentType(string documentType);

        IAsyncEnumerable<string> GetAgreementsFileTypes();

        Task<int> GetByIdAgreementType(string agrType);

        IAsyncEnumerable<string> GetAgreementStatus();

        Task<int> GetByIdStatus(string status);

        IAsyncEnumerable<string> GetCompanies();

        Task<int> GetByIdCompany(string company);

        IEnumerable<T> GetAllDocuments<T>(int id);

        IEnumerable<T> GetAllAgreements<T>(int id, DateTime? date);
    }
}
