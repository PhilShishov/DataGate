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
    using DataGate.Web.InputModels.SubFunds;
    using Microsoft.EntityFrameworkCore;

    public class SubFundStorageService : ISubFundStorageService
    {
        private readonly string sqlFunctionId = "[fn_subfund_id]";

        private readonly ISqlQueryManager sqlManager;
        private readonly ISubFundRepository repositorySelectList;
        private readonly IRepository<TbHistorySubFund> repository;
        private readonly IRepository<TbHistoryFund> repositoryContainer;

        public SubFundStorageService(
                        ISqlQueryManager sqlQueryManager,
                        IRepository<TbHistorySubFund> repository,
                        ISubFundRepository repositorySelectList,
                        IRepository<TbHistoryFund> repositoryContainer)
        {
            this.sqlManager = sqlQueryManager;
            this.repositorySelectList = repositorySelectList;
            this.repositoryContainer = repositoryContainer;
            this.repository = repository;
        }

        public T GetByIdAndDate<T>(int id, string date)
        {
            this.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var dateParsed = DateTimeParser.FromWebFormat(date);

            var dto = this.sqlManager
                .ExecuteQueryMapping<EditSubFundGetDto>(this.sqlFunctionId, id, dateParsed)
                .FirstOrDefault();

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public async Task<int> Create(CreateSubFundInputModel model)
        {
            SubFundPostDto dto = AutoMapperConfig.MapperInstance.Map<SubFundPostDto>(model);

            SubFundForeignKeysDto dtoForeignKey = AutoMapperConfig.MapperInstance.Map<SubFundForeignKeysDto>(model);

            dto.EndDate = DateTimeParser.ToSqlFormat(model.EndDate);
            dto.ContainerId = await this.repositoryContainer.All()
                  .Where(f => f.FOfficialFundName == model.FundContainer)
                  .Select(fc => fc.FId)
                  .FirstOrDefaultAsync();

            await this.SetForeignKeys(dto, dtoForeignKey);
            SqlCommand command = this.AssignBaseParameters(dto, SqlProcedureDictionary.CreateSubFund);

            // Assign particular parameters
            // Assign particular parameters
            command.Parameters.AddRange(new[]
                   {
                             new SqlParameter("@fundcontainer", SqlDbType.Int) { Value = dto.ContainerId },
                             new SqlParameter("@sf_endDate", SqlDbType.NVarChar) { Value = dto.EndDate },
                   });

            await this.sqlManager.ExecuteProcedure(command);

            var subFundId = this.repository.All()
                .Where(sf => sf.SfOfficialSubFundName == dto.SubFundName)
                .Select(sf => sf.SfId)
                .FirstOrDefault();

            return subFundId;
        }

        public async Task<int> Edit(EditSubFundInputModel model)
        {
            SubFundPostDto dto = AutoMapperConfig.MapperInstance.Map<SubFundPostDto>(model);

            SubFundForeignKeysDto dtoForeignKey = AutoMapperConfig.MapperInstance.Map<SubFundForeignKeysDto>(model);

            await this.SetForeignKeys(dto, dtoForeignKey);
            SqlCommand command = this.AssignBaseParameters(dto, SqlProcedureDictionary.EditSubFund);

            // Assign particular parameters
            command.Parameters.AddRange(new[]
                   {
                            new SqlParameter("@sf_id", SqlDbType.Int) { Value = dto.Id },
                            new SqlParameter("@comment", SqlDbType.NVarChar) { Value = dto.CommentArea },
                            new SqlParameter("@comment_title", SqlDbType.NVarChar) { Value = dto.CommentTitle },
                            new SqlParameter("@sf_shortSubFundName ", SqlDbType.NVarChar) { Value = dto.SubFundName },
                   });

            await this.sqlManager.ExecuteProcedure(command);

            return dto.Id;
        }

        public async Task<bool> DoesExist(string name)
        {
            return await this.repository.All().AnyAsync(sf => sf.SfOfficialSubFundName == name);
        }

        public async Task<bool> DoesExistAtDate(string name, DateTime initialDate)
        {
            return await this.repository.All().AnyAsync(f => f.SfOfficialSubFundName == name && f.SfInitialDate == initialDate);
        }

        private async Task SetForeignKeys(SubFundPostDto dto, SubFundForeignKeysDto dtoForeignKey)
        {
            dto.Status = await this.repositorySelectList.ByIdST(dtoForeignKey.Status);
            dto.CesrClass = await this.repositorySelectList.ByIdCC(dtoForeignKey.CesrClass);
            dto.GeographicalFocus = await this.repositorySelectList.ByIdGF(dtoForeignKey.GeographicalFocus);
            dto.GlobalExposure = await this.repositorySelectList.ByIdGE(dtoForeignKey.GlobalExposure);
            dto.NavFrequency = await this.repositorySelectList.ByIdNF(dtoForeignKey.NavFrequency);
            dto.ValuationDate = await this.repositorySelectList.ByIdVD(dtoForeignKey.ValuationDate);
            dto.CalculationDate = await this.repositorySelectList.ByIdCD(dtoForeignKey.CalculationDate);
            dto.DerivMarket = await this.repositorySelectList.ByIdDM(dtoForeignKey.DerivMarket);
            dto.DerivPurpose = await this.repositorySelectList.ByIdDP(dtoForeignKey.DerivPurpose);
            dto.PrincipalAssetClass = await this.repositorySelectList.ByIdPAC(dtoForeignKey.PrincipalAssetClass);
            dto.TypeOfMarket = await this.repositorySelectList.ByIdTM(dtoForeignKey.TypeOfMarket);
            dto.PrincipalInvestmentStrategy = await this.repositorySelectList.ByIdPIS(dtoForeignKey.PrincipalInvestmentStrategy);
            dto.SfCatMorningStar = await this.repositorySelectList.ByIdCM(dtoForeignKey.SfCatMorningStar);
            dto.SfCatSix = await this.repositorySelectList.ByIdCS(dtoForeignKey.SfCatSix);
            dto.SfCatBloomberg = await this.repositorySelectList.ByIdCB(dtoForeignKey.SfCatBloomberg);
        }

        private SqlCommand AssignBaseParameters(SubFundPostDto dto, string procedure)
        {
            SqlCommand command = new SqlCommand(procedure);

            command.Parameters.AddRange(new[]
                   {
                        new SqlParameter("@sf_initialDate", SqlDbType.NVarChar) { Value = dto.InitialDate },
                        new SqlParameter("@sf_officialSubFundName", SqlDbType.NVarChar) { Value = dto.SubFundName },
                        new SqlParameter("@sf_cssfCode", SqlDbType.NVarChar) { Value = dto.CSSFCode },
                        new SqlParameter("@sf_faCode", SqlDbType.NVarChar) { Value = dto.FACode },
                        new SqlParameter("@sf_taCode", SqlDbType.NVarChar) { Value = dto.TACode },
                        new SqlParameter("@sf_depCode", SqlDbType.NVarChar) { Value = dto.DBCode },
                        new SqlParameter("@sf_firstNavDate", SqlDbType.NVarChar) { Value = dto.FirstNavDate },
                        new SqlParameter("@sf_lastNavDate", SqlDbType.NVarChar) { Value = dto.LastNavDate },
                        new SqlParameter("@sf_cssfAuthDate", SqlDbType.NVarChar) { Value = dto.CSSFAuthDate },
                        new SqlParameter("@sf_expDate", SqlDbType.NVarChar) { Value = dto.ExpiryDate },
                        new SqlParameter("@sf_status", SqlDbType.Int) { Value = dto.Status },
                        new SqlParameter("@sf_leiCode", SqlDbType.NVarChar) { Value = dto.LEICode },
                        new SqlParameter("@sf_cesrClass", SqlDbType.Int) { Value = dto.CesrClass },
                        new SqlParameter("@sf_cssf_geographical_focus", SqlDbType.Int) { Value = dto.GeographicalFocus },
                        new SqlParameter("@sf_globalExposure", SqlDbType.Int) { Value = dto.GlobalExposure },
                        new SqlParameter("@sf_currency", SqlDbType.NChar) { Value = dto.CurrencyCode },
                        new SqlParameter("@sf_navFrequency", SqlDbType.Int) { Value = dto.NavFrequency },
                        new SqlParameter("@sf_valutationDate", SqlDbType.Int) { Value = dto.ValuationDate },
                        new SqlParameter("@sf_calculationDate", SqlDbType.Int) { Value = dto.CalculationDate },
                        new SqlParameter("@sf_derivatives", SqlDbType.Bit) { Value = dto.AreDerivatives },
                        new SqlParameter("@sf_derivMarket", SqlDbType.Int) { Value = dto.DerivMarket },
                        new SqlParameter("@sf_derivPurpose", SqlDbType.Int) { Value = dto.DerivPurpose },
                        new SqlParameter("@sf_principal_asset_class", SqlDbType.Int) { Value = dto.PrincipalAssetClass },
                        new SqlParameter("@sf_type_of_market", SqlDbType.Int) { Value = dto.TypeOfMarket },
                        new SqlParameter("@sf_principal_investment_strategy", SqlDbType.Int) { Value = dto.PrincipalInvestmentStrategy },
                        new SqlParameter("@sf_clearing_code", SqlDbType.NVarChar) { Value = dto.ClearingCode },
                        new SqlParameter("@sf_cat_morningstar", SqlDbType.Int) { Value = dto.SfCatMorningStar },
                        new SqlParameter("@sf_category_six", SqlDbType.Int) { Value = dto.SfCatSix },
                        new SqlParameter("@sf_category_bloomberg", SqlDbType.Int) { Value = dto.SfCatBloomberg },
                   });
            return command;
        }

        private void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistorySubFund));
            }
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.SfId == id);
    }
}
