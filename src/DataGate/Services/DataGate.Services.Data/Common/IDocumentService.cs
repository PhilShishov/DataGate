namespace DataGate.Services.Data.Documents.Common
{
    using System;
    using System.Collections.Generic;

    public interface IDocumentService
    {
        IReadOnlyCollection<string> GetDocumentsFileTypes();

        IAsyncEnumerable<string> GetAgreementsFileTypes();

        IAsyncEnumerable<string> GetAgreementStatus();

        IAsyncEnumerable<string> GetCompanies();

        IEnumerable<T> GetAllDocuments<T>(int id);

        IEnumerable<T> GetAllAgreements<T>(int id, DateTime? date);
    }
}
