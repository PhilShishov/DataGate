namespace DataGate.Services.Data.Storage
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Entities;
    using DataGate.Web.InputModels.Funds;

    using Microsoft.EntityFrameworkCore;

    public class FundStorageService : IFundStorageService
    {
        private readonly string sqlFunctionId = "[fn_fund_id]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistoryFund> repository;
        private readonly IFundSelectListService service;

        public FundStorageService(
                        ISqlQueryManager sqlQueryManager,
                        IRepository<TbHistoryFund> repository,
                        IFundSelectListService service)
        {
            this.sqlManager = sqlQueryManager;
            this.repository = repository;
            this.service = service;
        }

        public T GetByIdAndDate<T>(int id, string date)
        {
            this.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var dateParsed = DateTimeParser.FromWebFormat(date);
            var dto = this.sqlManager
                .ExecuteQueryMapping<EditFundGetDto>(this.sqlFunctionId, id, dateParsed)
                .FirstOrDefault();

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public async Task<int> Edit(EditFundInputModel model)
        {
            FundPostDto dto = AutoMapperConfig.MapperInstance.Map<FundPostDto>(model);

            dto.Status = await this.service.GetByIdStatus(model.Status);
            dto.LegalForm = await this.service.GetByIdLegalForm(model.LegalForm);
            dto.LegalVehicle = await this.service.GetByIdLegalVehicle(model.LegalVehicle);
            dto.LegalType = await this.service.GetByIdLegalType(model.LegalType);
            dto.CompanyTypeDesc = await this.service.GetByIdCompanyType(model.CompanyTypeDesc);

            SqlCommand command = this.AssignBaseParameters(dto, ProcedureDictionary.SqlProcedureEditFund);

            // Assign particular parameters
            command.Parameters.AddRange(new[]
                   {
                            new SqlParameter("@f_id", SqlDbType.Int) { Value = dto.Id },
                            new SqlParameter("@comment", SqlDbType.NVarChar) { Value = dto.CommentArea },
                            new SqlParameter("@commentTitle", SqlDbType.NVarChar) { Value = dto.CommentTitle },
                   });

            await this.sqlManager.ExecuteProcedure(command);

            return dto.Id;
        }

        public async Task<int> Create(CreateFundInputModel model)
        {
            FundPostDto dto = AutoMapperConfig.MapperInstance.Map<FundPostDto>(model);

            dto.EndDate = model.EndDate?.ToString(GlobalConstants.RequiredSqlDateTimeFormat);
            dto.Status = await this.service.GetByIdStatus(model.Status);
            dto.LegalForm = await this.service.GetByIdLegalForm(model.LegalForm);
            dto.LegalVehicle = await this.service.GetByIdLegalVehicle(model.LegalVehicle);
            dto.LegalType = await this.service.GetByIdLegalType(model.LegalType);
            dto.CompanyTypeDesc = await this.service.GetByIdCompanyType(model.CompanyTypeDesc);

            SqlCommand command = this.AssignBaseParameters(dto, ProcedureDictionary.SqlProcedureCreateFund);

            // Assign particular parameters
            command.Parameters.Add(new SqlParameter("@f_endDate", SqlDbType.NVarChar) { Value = dto.EndDate });

            await this.sqlManager.ExecuteProcedure(command);

            var fundId = this.repository.All().Where(f => f.FOfficialFundName == dto.FundName).Select(f => f.FId).FirstOrDefault();

            return fundId;
        }

        public async Task<bool> DoesExist(string name)
        {
            return await this.repository.All().AnyAsync(f => f.FOfficialFundName == name);
        }

        private SqlCommand AssignBaseParameters(FundPostDto dto, string procedure)
        {
            SqlCommand command = new SqlCommand(procedure);

            command.Parameters.AddRange(new[]
                   {
                            new SqlParameter("@f_initialDate", SqlDbType.NVarChar) { Value = dto.InitialDate },
                            new SqlParameter("@f_status", SqlDbType.Int) { Value = dto.Status },
                            new SqlParameter("@f_registrationNumber", SqlDbType.NVarChar) { Value = dto.RegNumber },
                            new SqlParameter("@f_officialFundName", SqlDbType.NVarChar) { Value = dto.FundName },
                            new SqlParameter("@f_shortFundName", SqlDbType.NVarChar) { Value = dto.FundName },
                            new SqlParameter("@f_leiCode", SqlDbType.NVarChar) { Value = dto.LEICode },
                            new SqlParameter("@f_cssfCode", SqlDbType.NVarChar) { Value = dto.CSSFCode },
                            new SqlParameter("@f_faCode", SqlDbType.NVarChar) { Value = dto.FACode },
                            new SqlParameter("@f_depCode", SqlDbType.NVarChar) { Value = dto.DEPCode },
                            new SqlParameter("@f_taCode", SqlDbType.NVarChar) { Value = dto.TACode },
                            new SqlParameter("@f_legalForm", SqlDbType.Int) { Value = dto.LegalForm },
                            new SqlParameter("@f_legalType", SqlDbType.Int) { Value = dto.LegalType },
                            new SqlParameter("@f_legal_vehicle", SqlDbType.Int) { Value = dto.LegalVehicle },
                            new SqlParameter("@f_companyType", SqlDbType.Int) { Value = dto.CompanyTypeDesc },
                            new SqlParameter("@f_tinNumber", SqlDbType.NVarChar) { Value = dto.TinNumber },
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
