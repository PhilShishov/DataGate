namespace DataGate.Services.Data.Documents
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Domain;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Documents.Contracts;

    public class DocumentsSelectService : IDocumentsSelectService
    {
        private const int FundFileType = 1;
        private readonly IRepository<TbDomFileType> repositoryFileType;
        private readonly IRepository<TbDomActivityType> repositoryActivityType;
        private readonly IRepository<TbDomAgreementStatus> repositoryAgrStatus;
        private readonly IRepository<TbCompanies> repositoryCompanies;

        public DocumentsSelectService(
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

        public IReadOnlyCollection<string> GetDocumentsFileTypes()
        {
            var prosFileTypes = this.repositoryFileType.All()
                .Where(ft => ft.FiletypeEntity == FundFileType)
                .Select(ft => ft.FiletypeDesc)
                .ToList();

            return prosFileTypes;
        }

        public IReadOnlyCollection<string> GetAgreementsFileTypes()
        {
            var agrFileTypes = this.repositoryActivityType.All()
                .Where(at => at.AtEntity == FundFileType)
                .Select(at => at.AtDesc)
                .ToList();

            return agrFileTypes;
        }

        public IReadOnlyCollection<string> GetAgreementStatus()
        {
            var agrStatus = this.repositoryAgrStatus.All()
                .Select(ast => ast.ASDesc)
                .ToList();

            return agrStatus;
        }

        public IReadOnlyCollection<string> GetCompanies()
        {
            var companies = this.repositoryCompanies.All()
               .Select(c => c.CName)
               .ToList();

            return companies;
        }
    }
}
