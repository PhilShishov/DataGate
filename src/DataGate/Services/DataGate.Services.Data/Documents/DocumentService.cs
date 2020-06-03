namespace DataGate.Services.Data.Documents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Domain;
    using DataGate.Data.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DocumentService : IDocumentService
    {
        private readonly IRepository<TbDomFileType> repositoryFileType;
        private readonly IRepository<TbDomActivityType> repositoryActivityType;
        private readonly IRepository<TbDomAgreementStatus> repositoryAgrStatus;
        private readonly IRepository<TbCompanies> repositoryCompanies;

        public DocumentService(
                            IRepository<TbDomFileType> repositoryFileType,
                            IRepository<TbDomActivityType> repositoryActivityType,
                            IRepository<TbDomAgreementStatus> repositoryAgrStatus,
                            IRepository<TbCompanies> repositoryCompanies)
        {
            this.repositoryFileType = repositoryFileType;
            this.repositoryActivityType = repositoryActivityType;
            this.repositoryAgrStatus = repositoryAgrStatus;
            this.repositoryCompanies = repositoryCompanies;
        }

        public IReadOnlyCollection<string> GetDocumentsFileTypes(int fileType)
        {
            var prosFileTypes = this.repositoryFileType.All()
                .Where(ft => ft.FiletypeEntity == fileType)
                .Select(ft => ft.FiletypeDesc)
                .ToList();

            return prosFileTypes;
        }

        public async Task<int> GetByIdDocumentType(string documentType)
        {
            return await this.repositoryFileType.All()
                        .Where(ft => ft.FiletypeDesc == documentType)
                        .Select(ft => ft.FiletypeId)
                        .FirstOrDefaultAsync();
        }

        public async IAsyncEnumerable<string> GetAgreementsFileTypes(int fileType)
        {
            var agrFileTypes = await this.repositoryActivityType.All()
                .Where(at => at.AtEntity == fileType)
                .Select(at => at.AtDesc)
                .ToListAsync();

            foreach (var item in agrFileTypes)
            {
                yield return item;
            }
        }

        public async Task<int> GetByIdAgreementType(string agrType)
        {
            return await this.repositoryActivityType.All()
                        .Where(at => at.AtDesc == agrType)
                        .Select(at => at.AtId)
                        .FirstOrDefaultAsync();
        }

        public async IAsyncEnumerable<string> GetAgreementStatus()
        {
            var agrStatus = await this.repositoryAgrStatus.All()
                .Select(ast => ast.ASDesc)
                .ToListAsync();

            foreach (var item in agrStatus)
            {
                yield return item;
            }
        }

        public async Task<int> GetByIdStatus(string status)
        {
            return await this.repositoryAgrStatus.All()
                        .Where(s => s.ASDesc == status)
                        .Select(s => s.ASId)
                        .FirstOrDefaultAsync();
        }

        public async IAsyncEnumerable<string> GetCompanies()
        {
            var companies = await this.repositoryCompanies.All()
               .Select(c => c.CName)
               .ToListAsync();

            foreach (var item in companies)
            {
                yield return item;
            }
        }

        public async Task<int> GetByIdCompany(string company)
        {
            return await this.repositoryCompanies.All()
                        .Where(c => c.CName == company)
                        .Select(c => c.CId)
                        .FirstOrDefaultAsync();
        }
    }
}
