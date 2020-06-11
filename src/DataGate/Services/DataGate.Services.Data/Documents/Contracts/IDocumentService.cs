namespace DataGate.Services.Data.Documents
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDocumentService
    {
        IReadOnlyCollection<string> GetDocumentsFileTypes(int fileType);

        Task<int> GetByIdDocumentType(string documentType);
    }
}
