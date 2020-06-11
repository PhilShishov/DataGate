namespace DataGate.Services.Data.Documents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Domain;
    using Microsoft.EntityFrameworkCore;

    public class DocumentService : IDocumentService
    {
        private readonly IRepository<TbDomFileType> repositoryFileType;

        public DocumentService(IRepository<TbDomFileType> repositoryFileType)
        {
            this.repositoryFileType = repositoryFileType;
        }

        public IReadOnlyCollection<string> GetDocumentsFileTypes(int fileType)
         => this.repositoryFileType.All()
                .Where(ft => ft.FiletypeEntity == fileType)
                .Select(ft => ft.FiletypeDesc)
                .ToList();

        public async Task<int> GetByIdDocumentType(string documentType)
        => await this.repositoryFileType.All()
                        .Where(ft => ft.FiletypeDesc == documentType)
                        .Select(ft => ft.FiletypeId)
                        .FirstOrDefaultAsync();
    }
}
