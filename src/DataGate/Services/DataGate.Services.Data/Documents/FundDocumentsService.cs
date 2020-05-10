namespace DataGate.Services.Data.Documents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Domain;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;

    public class FundDocumentsService : IDocumentService
    {
        private const int FundFileType = 1;
        private readonly string sqlFunctionAllDocuments = "[fn_view_documents_fund]";
        private readonly string sqlFunctionAllAgreements = "[fn_view_agreements_fund]";

        private readonly IRepository<TbDomFileType> repositoryFileType;
        private readonly IRepository<TbDomActivityType> repositoryActivityType;
        private readonly IRepository<TbDomAgreementStatus> repositoryAgrStatus;
        private readonly IRepository<TbCompanies> repositoryCompanies;
        private readonly ISqlQueryManager sqlManager;

        public FundDocumentsService(
                            ISqlQueryManager sqlQueryManager,
                            IRepository<TbDomFileType> repositoryFileType,
                            IRepository<TbDomActivityType> repositoryActivityType,
                            IRepository<TbDomAgreementStatus> repositoryAgrStatus,
                            IRepository<TbCompanies> repositoryCompanies)
        {
            this.sqlManager = sqlQueryManager;
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

        public IEnumerable<T> GetAllAgreements<T>(int id, DateTime? date)
        {
            IEnumerable<AllAgrDto> dto = this.sqlManager.ExecuteQueryMapping<AllAgrDto>(this.sqlFunctionAllAgreements, id, date);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IEnumerable<T> GetAllDocuments<T>(int id)
        {
            IEnumerable<AllDocDto> dto = this.sqlManager.ExecuteQueryMapping<AllDocDto>(this.sqlFunctionAllDocuments, id);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }
    }
}
