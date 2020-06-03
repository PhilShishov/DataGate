namespace DataGate.Services.Data.Documents.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IEntitiesDocumentService
    {
        IEnumerable<T> GetAllDocuments<T>(string function, int id);

        IEnumerable<T> GetAllAgreements<T>(string function, int id, DateTime? date);
    }
}
