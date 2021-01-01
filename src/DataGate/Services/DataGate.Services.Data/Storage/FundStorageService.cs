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
    using DataGate.Web.InputModels.Funds;

    using Microsoft.EntityFrameworkCore;

    public class FundStorageService : IFundStorageService
    {
        private const string SqlFunctionId = "[fn_fund_id]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IAppRepository<TbHistoryFund> repository;
        private readonly IFundSelectListService service;

        public FundStorageService(
                        ISqlQueryManager sqlQueryManager,
                        IAppRepository<TbHistoryFund> repository,
                        IFundSelectListService service)
        {
            this.sqlManager = sqlQueryManager;
            this.repository = repository;
            this.service = service;
        }

        public T ByIdAndDate<T>(int id, string date)
        {
            this.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var dateParsed = DateTimeExtensions.FromWebFormat(date);
            var dto = this.sqlManager
                .ExecuteQueryMapping<EditFundGetDto>(SqlFunctionId, id, dateParsed)
                .FirstOrDefault();

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public async Task<int> Create(CreateFundInputModel model)
        {
            FundPostDto dto = AutoMapperConfig.MapperInstance.Map<FundPostDto>(model);
            dto.EndDate = DateTimeExtensions.ToSqlFormat(model.EndDate);

            await this.SetForeignKeys(dto, model.Status, model.LegalForm, model.LegalVehicle,
                                      model.LegalType, model.CompanyTypeDesc);

            var parameters = Deserializer.ImportParameters(EndpointsConstants.FundArea + EndpointsConstants.ActionCreate);

            var procedure = StringExtensions.BuildProcedure(
                SqlProcedureDictionary.CreateFund, parameters);

            SqlCommand command = this.AssignBaseParameters(dto, procedure, parameters);

            // Assign particular parameters
            command.Parameters.Add(new SqlParameter(parameters[17].Name, SqlDbType.NVarChar) { Value = dto.EndDate });

            await this.sqlManager.ExecuteProcedure(command);

            var fundId = this.repository.All()
                .Where(f => f.FOfficialFundName == dto.FundName)
                .Select(f => f.FId)
                .FirstOrDefault();

            return fundId;
        }

        public async Task<int> Edit(EditFundInputModel model)
        {
            FundPostDto dto = AutoMapperConfig.MapperInstance.Map<FundPostDto>(model);

            await this.SetForeignKeys(dto, model.Status, model.LegalForm, model.LegalVehicle,
                                      model.LegalType, model.CompanyTypeDesc);

            var parameters = Deserializer.ImportParameters(EndpointsConstants.FundArea + EndpointsConstants.ActionEdit);

            var procedure = StringExtensions.BuildProcedure(
                SqlProcedureDictionary.EditFund, parameters);

            SqlCommand command = this.AssignBaseParameters(dto, procedure, parameters);

            // Assign particular parameters
            command.Parameters.AddRange(new[]
                   {
                            new SqlParameter(parameters[17].Name, SqlDbType.Int) { Value = dto.Id },
                            new SqlParameter(parameters[18].Name, SqlDbType.NVarChar) { Value = dto.CommentArea },
                            new SqlParameter(parameters[19].Name, SqlDbType.NVarChar) { Value = dto.CommentTitle },
                   });

            await this.sqlManager.ExecuteProcedure(command);

            return dto.Id;
        }

        public async Task<bool> DoesExist(string name)
            => await this.repository.All().AnyAsync(f => f.FOfficialFundName == name);


        public async Task<bool> DoesExistAtDate(string name, DateTime initialDate)
            => await this.repository.All().AnyAsync(f => f.FOfficialFundName == name && f.FInitialDate == initialDate);

        private async Task SetForeignKeys(FundPostDto dto, string status,
                                          string legalform, string legalVehicle,
                                          string legalType, string companyType)
        {
            dto.Status = await this.service.ByIdStatus(status);
            dto.LegalForm = await this.service.ByIdLegalForm(legalform);
            dto.LegalVehicle = await this.service.ByIdLegalVehicle(legalVehicle);
            dto.LegalType = await this.service.ByIdLegalType(legalType);
            dto.CompanyTypeDesc = await this.service.ByIdCompanyType(companyType);
        }

        private SqlCommand AssignBaseParameters(FundPostDto dto, string procedure, List<Parameter> parameters)
        {
            SqlCommand command = new SqlCommand(procedure);

            command.Parameters.AddRange(new[]
                   {
                            new SqlParameter(parameters[0].Name, SqlDbType.NVarChar) { Value = dto.InitialDate },
                            new SqlParameter(parameters[1].Name, SqlDbType.Int) { Value = dto.Status },
                            new SqlParameter(parameters[2].Name, SqlDbType.NVarChar) { Value = dto.RegNumber },
                            new SqlParameter(parameters[3].Name, SqlDbType.NVarChar) { Value = dto.FundName },
                            new SqlParameter(parameters[4].Name, SqlDbType.NVarChar) { Value = dto.LEICode },
                            new SqlParameter(parameters[5].Name, SqlDbType.NVarChar) { Value = dto.CSSFCode },
                            new SqlParameter(parameters[6].Name, SqlDbType.NVarChar) { Value = dto.FACode },
                            new SqlParameter(parameters[7].Name, SqlDbType.NVarChar) { Value = dto.DEPCode },
                            new SqlParameter(parameters[8].Name, SqlDbType.NVarChar) { Value = dto.TACode },
                            new SqlParameter(parameters[9].Name, SqlDbType.Int) { Value = dto.LegalForm },
                            new SqlParameter(parameters[10].Name, SqlDbType.Int) { Value = dto.LegalType },
                            new SqlParameter(parameters[11].Name, SqlDbType.Int) { Value = dto.LegalVehicle },
                            new SqlParameter(parameters[12].Name, SqlDbType.Int) { Value = dto.CompanyTypeDesc },
                            new SqlParameter(parameters[13].Name, SqlDbType.NVarChar) { Value = dto.TinNumber },
                            new SqlParameter(parameters[14].Name, SqlDbType.NVarChar) { Value = dto.VATRegNumber },
                            new SqlParameter(parameters[15].Name, SqlDbType.NVarChar) { Value = dto.VATIdentificationNumber },
                            new SqlParameter(parameters[16].Name, SqlDbType.NVarChar) { Value = dto.IBICNumber },
                   });
            return command;
        }

        private void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistoryFund));
            }
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.FId == id);
    }
}
