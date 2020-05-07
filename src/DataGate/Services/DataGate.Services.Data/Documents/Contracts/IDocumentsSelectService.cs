namespace DataGate.Services.Data.Documents.Contracts
{
    using System.Collections.Generic;

    public interface IDocumentsSelectService
    {
        IReadOnlyCollection<string> GetDocumentsFileTypes();

        IReadOnlyCollection<string> GetAgreementsFileTypes();

        IReadOnlyCollection<string> GetAgreementStatus();

        IReadOnlyCollection<string> GetCompanies();
    }
}
