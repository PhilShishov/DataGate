namespace DataGate.Services.Data.Documents.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IDocumentsService
    {
        IReadOnlyCollection<string> GetDocumentsFileTypes();

        IReadOnlyCollection<string> GetAgreementsFileTypes();

        IReadOnlyCollection<string> GetAgreementStatus();

        IReadOnlyCollection<string> GetCompanies();

        IEnumerable<T> GetAllDocuments<T>(int id);

        IEnumerable<T> GetAllAgreements<T>(int id, DateTime? date);
    }
}
