namespace DataGate.Services.Data.Documents.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDocumentService
    {
        IReadOnlyCollection<string> GetDocumentsFileTypes();

        Task<int> GetByIdFileType(string documentType);

        IAsyncEnumerable<string> GetAgreementsFileTypes();

        IAsyncEnumerable<string> GetAgreementStatus();

        IAsyncEnumerable<string> GetCompanies();

        IEnumerable<T> GetAllDocuments<T>(int id);

        IEnumerable<T> GetAllAgreements<T>(int id, DateTime? date);
    }
}
