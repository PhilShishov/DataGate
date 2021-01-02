// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories.AppContext;
    using DataGate.Data.Models.Entities;
    using DataGate.Data.Models.Parameters;
    using DataGate.Services.Data.DataProcessor;
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
        private readonly IAppRepository<TbHistorySubFund> repository;
        private readonly IAppRepository<TbHistoryFund> repositoryContainer;

        public SubFundStorageService(
                        ISqlQueryManager sqlQueryManager,
                        IAppRepository<TbHistorySubFund> repository,
                        ISubFundRepository repositorySelectList,
                        IAppRepository<TbHistoryFund> repositoryContainer)
        {
            this.sqlManager = sqlQueryManager;
            this.repositorySelectList = repositorySelectList;
            this.repositoryContainer = repositoryContainer;
            this.repository = repository;
        }

        public T ByIdAndDate<T>(int id, string date)
        {
            this.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var dateParsed = DateTimeExtensions.FromWebFormat(date);

            var dto = this.sqlManager
                .ExecuteQueryMapping<EditSubFundGetDto>(this.sqlFunctionId, id, dateParsed)
                .FirstOrDefault();

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public async Task<int> Create(CreateSubFundInputModel model)
        {
            SubFundPostDto dto = AutoMapperConfig.MapperInstance.Map<SubFundPostDto>(model);

            SubFundForeignKeysDto dtoForeignKey = AutoMapperConfig.MapperInstance.Map<SubFundForeignKeysDto>(model);

            dto.EndDate = DateTimeExtensions.ToSqlFormat(model.EndDate);
            dto.ContainerId = await this.repositoryContainer.All()
                  .Where(f => f.FOfficialFundName == model.FundContainer)
                  .Select(fc => fc.FId)
                  .FirstOrDefaultAsync();

            await this.SetForeignKeys(dto, dtoForeignKey);

            var parameters = Deserializer.ImportParameters(
                           EndpointsConstants.DisplaySub + EndpointsConstants.FundArea + EndpointsConstants.ActionCreate);

            var procedure = StringExtensions.BuildProcedure(
                SqlProcedureDictionary.CreateSubFund, parameters);

            SqlCommand command = this.AssignBaseParameters(dto, procedure, parameters);

            // Assign particular parameters
            command.Parameters.AddRange(new[]
                   {
                             new SqlParameter(parameters[29].Name, SqlDbType.Int) { Value = dto.ContainerId },
                             new SqlParameter(parameters[30].Name, SqlDbType.NVarChar) { Value = dto.EndDate },
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

            var parameters = Deserializer.ImportParameters(
                EndpointsConstants.DisplaySub + EndpointsConstants.FundArea + EndpointsConstants.ActionEdit);

            var procedure = StringExtensions.BuildProcedure(
                SqlProcedureDictionary.EditSubFund, parameters);

            SqlCommand command = this.AssignBaseParameters(dto, procedure, parameters);

            // Assign particular parameters
            command.Parameters.AddRange(new[]
                   {
                            new SqlParameter(parameters[29].Name, SqlDbType.Int) { Value = dto.Id },
                            new SqlParameter(parameters[30].Name, SqlDbType.NVarChar) { Value = dto.CommentArea },
                            new SqlParameter(parameters[31].Name, SqlDbType.NVarChar) { Value = dto.CommentTitle },
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

        private SqlCommand AssignBaseParameters(SubFundPostDto dto, string procedure, List<Parameter> parameters)
        {
            SqlCommand command = new SqlCommand(procedure);

            command.Parameters.AddRange(new[]
                   {
                        new SqlParameter(parameters[0].Name, SqlDbType.NVarChar) { Value = dto.InitialDate },
                        new SqlParameter(parameters[1].Name, SqlDbType.NVarChar) { Value = dto.SubFundName },
                        new SqlParameter(parameters[2].Name, SqlDbType.NVarChar) { Value = dto.CSSFCode },
                        new SqlParameter(parameters[3].Name, SqlDbType.NVarChar) { Value = dto.FACode },
                        new SqlParameter(parameters[4].Name, SqlDbType.NVarChar) { Value = dto.TACode },
                        new SqlParameter(parameters[5].Name, SqlDbType.NVarChar) { Value = dto.DBCode },
                        new SqlParameter(parameters[6].Name, SqlDbType.NVarChar) { Value = dto.FirstNavDate },
                        new SqlParameter(parameters[7].Name, SqlDbType.NVarChar) { Value = dto.LastNavDate },
                        new SqlParameter(parameters[8].Name, SqlDbType.NVarChar) { Value = dto.CSSFAuthDate },
                        new SqlParameter(parameters[9].Name, SqlDbType.NVarChar) { Value = dto.ExpiryDate },
                        new SqlParameter(parameters[10].Name, SqlDbType.Int) { Value = dto.Status },
                        new SqlParameter(parameters[11].Name, SqlDbType.NVarChar) { Value = dto.LEICode },
                        new SqlParameter(parameters[12].Name, SqlDbType.Int) { Value = dto.CesrClass },
                        new SqlParameter(parameters[13].Name, SqlDbType.Int) { Value = dto.GeographicalFocus },
                        new SqlParameter(parameters[14].Name, SqlDbType.Int) { Value = dto.GlobalExposure },
                        new SqlParameter(parameters[15].Name, SqlDbType.NChar) { Value = dto.CurrencyCode },
                        new SqlParameter(parameters[16].Name, SqlDbType.Int) { Value = dto.NavFrequency },
                        new SqlParameter(parameters[17].Name, SqlDbType.Int) { Value = dto.ValuationDate },
                        new SqlParameter(parameters[18].Name, SqlDbType.Int) { Value = dto.CalculationDate },
                        new SqlParameter(parameters[19].Name, SqlDbType.Bit) { Value = dto.AreDerivatives },
                        new SqlParameter(parameters[20].Name, SqlDbType.Int) { Value = dto.DerivMarket },
                        new SqlParameter(parameters[21].Name, SqlDbType.Int) { Value = dto.DerivPurpose },
                        new SqlParameter(parameters[22].Name, SqlDbType.Int) { Value = dto.PrincipalAssetClass },
                        new SqlParameter(parameters[23].Name, SqlDbType.Int) { Value = dto.TypeOfMarket },
                        new SqlParameter(parameters[24].Name, SqlDbType.Int) { Value = dto.PrincipalInvestmentStrategy },
                        new SqlParameter(parameters[25].Name, SqlDbType.NVarChar) { Value = dto.ClearingCode },
                        new SqlParameter(parameters[26].Name, SqlDbType.Int) { Value = dto.SfCatMorningStar },
                        new SqlParameter(parameters[27].Name, SqlDbType.Int) { Value = dto.SfCatSix },
                        new SqlParameter(parameters[28].Name, SqlDbType.Int) { Value = dto.SfCatBloomberg },
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
