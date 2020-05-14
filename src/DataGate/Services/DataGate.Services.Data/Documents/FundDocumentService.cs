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

    using Microsoft.EntityFrameworkCore;

    public class FundDocumentService : IFundDocumentService
    {
        private const int FundFileType = 1;
        private readonly string sqlFunctionAllDocuments = "[fn_view_documents_fund]";
        private readonly string sqlFunctionAllAgreements = "[fn_view_agreements_fund]";

        private readonly IRepository<TbDomFileType> repositoryFileType;
        private readonly IRepository<TbDomActivityType> repositoryActivityType;
        private readonly IRepository<TbDomAgreementStatus> repositoryAgrStatus;
        private readonly IRepository<TbCompanies> repositoryCompanies;
        private readonly ISqlQueryManager sqlManager;

        public FundDocumentService(
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

        public async IAsyncEnumerable<string> GetAgreementsFileTypes()
        {
            var agrFileTypes = await this.repositoryActivityType.All()
                .Where(at => at.AtEntity == FundFileType)
                .Select(at => at.AtDesc)
                .ToListAsync();

            foreach (var item in agrFileTypes)
            {
                yield return item;
            }
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

        public IEnumerable<T> GetAllAgreements<T>(int id, DateTime? date)
        {
            IEnumerable<AgreementDto> dto = this.sqlManager.ExecuteQueryMapping<AgreementDto>(this.sqlFunctionAllAgreements, id, date);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IEnumerable<T> GetAllDocuments<T>(int id)
        {
            IEnumerable<DocumentDto> dto = this.sqlManager.ExecuteQueryMapping<DocumentDto>(this.sqlFunctionAllDocuments, id);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }
    }
}
