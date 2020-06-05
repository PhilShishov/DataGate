namespace DataGate.Services.Data.Documents.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IEntitiesDocumentService
    {
        IEnumerable<T> GetDocuments<T>(string function, int id);

        IEnumerable<T> GetAgreements<T>(string function, int id, DateTime? date);
    }
}
