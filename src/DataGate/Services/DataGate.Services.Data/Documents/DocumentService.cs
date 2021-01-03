// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
        private readonly IAppRepository<TbDomFileType> repository;

        public DocumentService(IAppRepository<TbDomFileType> repository)
        {
            this.repository = repository;
        }

        public IReadOnlyCollection<string> GetDocumentsFileTypes(int fileType)
         => this.repository.All()
                .Where(ft => ft.FiletypeEntity == fileType)
                .Select(ft => ft.FiletypeDesc)
                .ToList();

        public async Task<int> ByIdDocumentType(string documentType)
        => await this.repository.All()
                        .Where(ft => ft.FiletypeDesc == documentType)
                        .Select(ft => ft.FiletypeId)
                        .FirstOrDefaultAsync();
    }
}
