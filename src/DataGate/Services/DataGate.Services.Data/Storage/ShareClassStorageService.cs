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
    using DataGate.Web.InputModels.ShareClasses;

    using Microsoft.EntityFrameworkCore;

    public class ShareClassStorageService : IShareClassStorageService
    {
        private readonly string sqlFunctionId = "[fn_shareclass_id]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IAppRepository<TbHistoryShareClass> repository;
        private readonly IShareClassRepository repositorySelectList;
        private readonly IAppRepository<TbHistorySubFund> repositoryContainer;

        public ShareClassStorageService(
                        ISqlQueryManager sqlManager,
                        IAppRepository<TbHistoryShareClass> repository,
                        IShareClassRepository repositorySelectList,
                        IAppRepository<TbHistorySubFund> repositoryContainer)
        {
            this.sqlManager = sqlManager;
            this.repository = repository;
            this.repositorySelectList = repositorySelectList;
            this.repositoryContainer = repositoryContainer;
        }

        public T ByIdAndDate<T>(int id, string date)
        {
            this.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var dateParsed = DateTimeExtensions.FromWebFormat(date);

            var dto = this.sqlManager
                .ExecuteQueryMapping<EditShareClassGetDto>(this.sqlFunctionId, id, dateParsed)
                .FirstOrDefault();

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public async Task<int> Create(CreateShareClassInputModel model)
        {
            ShareClassPostDto dto = AutoMapperConfig.MapperInstance.Map<ShareClassPostDto>(model);
            ShareClassForeignKeysDto dtoForeignKey = AutoMapperConfig.MapperInstance.Map<ShareClassForeignKeysDto>(model);

            dto.EndDate = DateTimeExtensions.ToSqlFormat(model.EndDate);
            dto.ContainerId = await this.repositoryContainer.All()
                  .Where(f => f.SfOfficialSubFundName == model.SubFundContainer)
                  .Select(fc => fc.SfId)
                  .FirstOrDefaultAsync();

            await this.SetForeignKeys(dto, dtoForeignKey);
            var parameters = Deserializer.ImportParameters(EndpointsConstants.ShareClassArea + EndpointsConstants.ActionCreate);

            var procedure = StringExtensions.BuildProcedure(
                SqlProcedureDictionary.CreateShareClass, parameters);

            SqlCommand command = this.AssignBaseParameters(dto, procedure, parameters);

            // Assign particular parameters
            command.Parameters.AddRange(new[]
                   {
                             new SqlParameter(parameters[26].Name, SqlDbType.Int) { Value = dto.ContainerId },
                             new SqlParameter(parameters[27].Name, SqlDbType.NVarChar) { Value = dto.EndDate },
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

            var parameters = Deserializer.ImportParameters(EndpointsConstants.ShareClassArea + EndpointsConstants.ActionEdit);

            var procedure = StringExtensions.BuildProcedure(
                SqlProcedureDictionary.EditShareClass, parameters);

            SqlCommand command = this.AssignBaseParameters(dto, procedure, parameters);

            // Assign particular parameters
            command.Parameters.AddRange(new[]
                   {
                            new SqlParameter(parameters[26].Name, SqlDbType.Int) { Value = dto.Id },
                            new SqlParameter(parameters[27].Name, SqlDbType.NVarChar) { Value = dto.CommentArea },
                            new SqlParameter(parameters[28].Name, SqlDbType.NVarChar) { Value = dto.CommentTitle },
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

        private SqlCommand AssignBaseParameters(ShareClassPostDto dto, string procedure, List<Parameter> parameters)
        {
            SqlCommand command = new SqlCommand(procedure);

            command.Parameters.AddRange(new[]
                   {
                        new SqlParameter(parameters[0].Name, SqlDbType.NVarChar) { Value = dto.InitialDate },
                        new SqlParameter(parameters[1].Name, SqlDbType.NVarChar) { Value = dto.ShareClassName },
                        new SqlParameter(parameters[2].Name, SqlDbType.Int) { Value = dto.InvestorType },
                        new SqlParameter(parameters[3].Name, SqlDbType.Int) { Value = dto.ShareType },
                        new SqlParameter(parameters[4].Name, SqlDbType.NChar) { Value = dto.CurrencyCode },
                        new SqlParameter(parameters[5].Name, SqlDbType.NChar) { Value = dto.CountryIssue },
                        new SqlParameter(parameters[6].Name, SqlDbType.NChar) { Value = dto.CountryRisk },
                        new SqlParameter(parameters[7].Name, SqlDbType.NVarChar) { Value = dto.EmissionDate },
                        new SqlParameter(parameters[8].Name, SqlDbType.NVarChar) { Value = dto.InceptionDate },
                        new SqlParameter(parameters[9].Name, SqlDbType.NVarChar) { Value = dto.LastNavDate },
                        new SqlParameter(parameters[10].Name, SqlDbType.NVarChar) { Value = dto.ExpiryDate },
                        new SqlParameter(parameters[11].Name, SqlDbType.Int) { Value = dto.Status },
                        new SqlParameter(parameters[12].Name, SqlDbType.Float) { Value = dto.InitialPrice },
                        new SqlParameter(parameters[13].Name, SqlDbType.NVarChar) { Value = dto.AccountingCode },
                        new SqlParameter(parameters[14].Name, SqlDbType.Bit) { Value = dto.IsHedged },
                        new SqlParameter(parameters[15].Name, SqlDbType.Bit) { Value = dto.IsListed },
                        new SqlParameter(parameters[16].Name, SqlDbType.NVarChar) { Value = dto.BloombergMarket },
                        new SqlParameter(parameters[17].Name, SqlDbType.NVarChar) { Value = dto.BloombergCode },
                        new SqlParameter(parameters[18].Name, SqlDbType.NVarChar) { Value = dto.BloombergId },
                        new SqlParameter(parameters[19].Name, SqlDbType.NChar, 12) { Value = dto.ISINCode },
                        new SqlParameter(parameters[20].Name, SqlDbType.NVarChar) { Value = dto.ValorCode },
                        new SqlParameter(parameters[21].Name, SqlDbType.NVarChar) { Value = dto.FACode },
                        new SqlParameter(parameters[22].Name, SqlDbType.NVarChar) { Value = dto.TACode },
                        new SqlParameter(parameters[23].Name, SqlDbType.NVarChar) { Value = dto.WKN },
                        new SqlParameter(parameters[24].Name, SqlDbType.NVarChar, 100) { Value = dto.DateBusinessYear },
                        new SqlParameter(parameters[25].Name, SqlDbType.NVarChar, 100) { Value = dto.ProspectusCode },
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
