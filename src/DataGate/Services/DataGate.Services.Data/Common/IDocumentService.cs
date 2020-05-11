namespace DataGate.Services.Data.Documents.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDocumentService
    {
        IReadOnlyCollection<string> GetDocumentsFileTypes();

        Task<IReadOnlyCollection<string>> GetAgreementsFileTypes();

        Task<IReadOnlyCollection<string>> GetAgreementStatus();

        Task<IReadOnlyCollection<string>> GetCompanies();

        IEnumerable<T> GetAllDocuments<T>(int id);

        IEnumerable<T> GetAllAgreements<T>(int id, DateTime? date);
    }
}
