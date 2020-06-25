namespace DataGate.Services.Data.Storage
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Entities;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.InputModels.ShareClasses;
    using Microsoft.EntityFrameworkCore;

    public class ShareClassStorageService : IShareClassStorageService
    {
        private readonly string sqlFunctionId = "[fn_shareclass_id]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistoryShareClass> repository;
        private readonly IShareClassRepository repositorySelectList;
        private readonly IRepository<TbHistorySubFund> repositoryContainer;

        public ShareClassStorageService(
                        ISqlQueryManager sqlManager,
                        IRepository<TbHistoryShareClass> repository,
                        IShareClassRepository repositorySelectList,
                        IRepository<TbHistorySubFund> repositoryContainer)
        {
            this.sqlManager = sqlManager;
            this.repository = repository;
            this.repositorySelectList = repositorySelectList;
            this.repositoryContainer = repositoryContainer;
        }

        public T GetByIdAndDate<T>(int id, string date)
        {
            this.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var dateParsed = DateTimeParser.FromWebFormat(date);

            var dto = this.sqlManager
                .ExecuteQueryMapping<EditShareClassGetDto>(this.sqlFunctionId, id, dateParsed)
                .FirstOrDefault();

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public async Task<int> Create(CreateShareClassInputModel model)
        {
            ShareClassPostDto dto = AutoMapperConfig.MapperInstance.Map<ShareClassPostDto>(model);
            ShareClassForeignKeysDto dtoForeignKey = AutoMapperConfig.MapperInstance.Map<ShareClassForeignKeysDto>(model);

            dto.EndDate = DateTimeParser.ToSqlFormat(model.EndDate);
            dto.ContainerId = await this.repositoryContainer.All()
                  .Where(f => f.SfOfficialSubFundName == model.SubFundContainer)
                  .Select(fc => fc.SfId)
                  .FirstOrDefaultAsync();

            await this.SetForeignKeys(dto, dtoForeignKey);
            SqlCommand command = this.AssignBaseParameters(dto, SqlProcedureDictionary.CreateShareClass);

            // Assign particular parameters
            command.Parameters.AddRange(new[]
                   {
                             new SqlParameter("@subfundcontainer", SqlDbType.Int) { Value = dto.ContainerId },
                             new SqlParameter("@sc_endDate", SqlDbType.NVarChar) { Value = dto.EndDate },
                   });

            await this.sqlManager.ExecuteProcedure(command);

            var subFundId = this.repository.All()
                .Where(sf => sf.ScOfficialShareClassName == dto.ShareClassName)
                .Select(sf => sf.ScId)
                .FirstOrDefault();

            return subFundId;
        }

        public async Task<int> Edit(EditShareClassInputModel model)
        {
            ShareClassPostDto dto = AutoMapperConfig.MapperInstance.Map<ShareClassPostDto>(model);
            ShareClassForeignKeysDto dtoForeignKey = AutoMapperConfig.MapperInstance.Map<ShareClassForeignKeysDto>(model);

            await this.SetForeignKeys(dto, dtoForeignKey);
            SqlCommand command = this.AssignBaseParameters(dto, SqlProcedureDictionary.EditShareClass);

            // Assign particular parameters
            command.Parameters.AddRange(new[]
                   {
                            new SqlParameter("@sc_id", SqlDbType.Int) { Value = dto.Id },
                            new SqlParameter("@comment", SqlDbType.NVarChar) { Value = dto.CommentArea },
                            new SqlParameter("@comment_title", SqlDbType.NVarChar) { Value = dto.CommentTitle },
                            new SqlParameter("@sc_shortShareClassName", SqlDbType.NVarChar) { Value = dto.ShareClassName },
                   });

            await this.sqlManager.ExecuteProcedure(command);

            return dto.Id;
        }

        public async Task<bool> DoesExist(string name)
        {
            return await this.repository.All().AnyAsync(sf => sf.ScOfficialShareClassName == name);
        }

        public async Task<bool> DoesExistAtDate(string name, DateTime initialDate)
        {
            return await this.repository.All().AnyAsync(f => f.ScOfficialShareClassName == name && f.ScInitialDate == initialDate);
        }

        private async Task SetForeignKeys(ShareClassPostDto dto, ShareClassForeignKeysDto dtoForeignKey)
        {
            dto.Status = await this.repositorySelectList.ByIdStatus(dtoForeignKey.Status);
            dto.ShareType = await this.repositorySelectList.ByIdShareType(dtoForeignKey.ShareType);
            dto.InvestorType = await this.repositorySelectList.ByIdInvestorType(dtoForeignKey.InvestorType);
            dto.CountryIssue = await this.repositorySelectList.ByNameCountry(dtoForeignKey.CountryIssue);
            dto.CountryRisk = await this.repositorySelectList.ByNameCountry(dtoForeignKey.CountryRisk);
        }

        private SqlCommand AssignBaseParameters(ShareClassPostDto dto, string procedure)
        {
            SqlCommand command = new SqlCommand(procedure);

            command.Parameters.AddRange(new[]
                   {
                        new SqlParameter("@sc_initialDate", SqlDbType.NVarChar) { Value = dto.InitialDate },
                        new SqlParameter("@sc_officialShareClassName", SqlDbType.NVarChar) { Value = dto.ShareClassName },
                        new SqlParameter("@sc_investorType", SqlDbType.Int) { Value = dto.InvestorType },
                        new SqlParameter("@sc_shareType", SqlDbType.Int) { Value = dto.ShareType },
                        new SqlParameter("@sc_currency", SqlDbType.NChar) { Value = dto.CurrencyCode },
                        new SqlParameter("@sc_countryIssue", SqlDbType.NChar) { Value = dto.CountryIssue },
                        new SqlParameter("@sc_ultimateParentCountryRisk", SqlDbType.NChar) { Value = dto.CountryRisk },
                        new SqlParameter("@sc_emissionDate", SqlDbType.NVarChar) { Value = dto.EmissionDate },
                        new SqlParameter("@sc_inceptionDate", SqlDbType.NVarChar) { Value = dto.InceptionDate },
                        new SqlParameter("@sc_lastNav", SqlDbType.NVarChar) { Value = dto.LastNavDate },
                        new SqlParameter("@sc_expiryDate", SqlDbType.NVarChar) { Value = dto.ExpiryDate },
                        new SqlParameter("@sc_status", SqlDbType.Int) { Value = dto.Status },
                        new SqlParameter("@sc_initialPrice", SqlDbType.Float) { Value = dto.InitialPrice },
                        new SqlParameter("@sc_accountingCode", SqlDbType.NVarChar) { Value = dto.AccountingCode },
                        new SqlParameter("@sc_hedged", SqlDbType.Bit) { Value = dto.IsHedged },
                        new SqlParameter("@sc_listed", SqlDbType.Bit) { Value = dto.IsListed },
                        new SqlParameter("@sc_bloomberMarket", SqlDbType.NVarChar) { Value = dto.BloombergMarket },
                        new SqlParameter("@sc_bloomberCode", SqlDbType.NVarChar) { Value = dto.BloombergCode },
                        new SqlParameter("@sc_bloomberId", SqlDbType.NVarChar) { Value = dto.BloombergId },
                        new SqlParameter("@sc_isinCode", SqlDbType.NChar, 12) { Value = dto.ISINCode },
                        new SqlParameter("@sc_valorCode", SqlDbType.NVarChar) { Value = dto.ValorCode },
                        new SqlParameter("@sc_faCode", SqlDbType.NVarChar) { Value = dto.FACode },
                        new SqlParameter("@sc_taCode", SqlDbType.NVarChar) { Value = dto.TACode },
                        new SqlParameter("@sc_WKN", SqlDbType.NVarChar) { Value = dto.WKN },
                        new SqlParameter("@sc_date_business_year", SqlDbType.NVarChar, 100) { Value = dto.DateBusinessYear },
                        new SqlParameter("@sc_prospectus_code", SqlDbType.NVarChar, 100) { Value = dto.ProspectusCode },
                   });
            return command;
        }

        private void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistoryShareClass));
            }
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.ScId == id);
    }
}
