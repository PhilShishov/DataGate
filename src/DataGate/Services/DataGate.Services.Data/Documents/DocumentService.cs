namespace DataGate.Services.Data.Documents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using DataGate.Data.Common.Repositories.AppContext;
    using DataGate.Data.Models.Domain;

    public class DocumentService : IDocumentService
    {
        private readonly IAppRepository<TbDomFileType> repositoryFileType;

        public DocumentService(IAppRepository<TbDomFileType> repositoryFileType)
        {
            this.repositoryFileType = repositoryFileType;
        }

        public IReadOnlyCollection<string> GetDocumentsFileTypes(int fileType)
         => this.repositoryFileType.All()
                .Where(ft => ft.FiletypeEntity == fileType)
                .Select(ft => ft.FiletypeDesc)
                .ToList();

        public async Task<int> ByIdDocumentType(string documentType)
        => await this.repositoryFileType.All()
                        .Where(ft => ft.FiletypeDesc == documentType)
                        .Select(ft => ft.FiletypeId)
                        .FirstOrDefaultAsync();
    }
}
