namespace DataGate.Services.Data.Funds
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Funds;
    using DataGate.Web.InputModels.Funds;

    public class FundStorageService : IFundStorageService
    {
        private const int SkipHeaders = 1;
        private const int IndexFundName = 3;
        private const int IndexCSSFCode = 4;
        private const int IndexStatus = 5;
        private const int IndexLegalForm = 6;
        private const int IndexLegalVehicle = 7;
        private const int IndexLegalType = 8;
        private const int IndexFACode = 9;
        private const int IndexDEPCode = 10;
        private const int IndexTACode = 11;
        private const int IndexCompanyTypeDesc = 12;
        private const int IndexTinNumber = 14;
        private const int IndexLEICode = 15;
        private const int IndexRegNumber = 16;

        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionFundId = "[fn_fund_id]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistoryFund> repository;

        public FundStorageService(
                        ISqlQueryManager sqlQueryManager,
                        IRepository<TbHistoryFund> repository)
        {
            this.sqlManager = sqlQueryManager;
            this.repository = repository;
        }

        public async Task<TDestination> GetByIdAndDate<TDestination>(int id, string date)
        {
            this.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var dateParsed = DateTimeParser.WebFormat(date);
            var query = await this.sqlManager
                .ExecuteQueryAsync(this.sqlFunctionFundId, dateParsed, id)
                .Skip(SkipHeaders)
                .FirstOrDefaultAsync();

            var dto = new EditFundGetDto
            {
                InitialDate = dateParsed,
                FundId = id,
                FundName = query[IndexFundName],
                CSSFCode = query[IndexCSSFCode],
                Status = query[IndexStatus],
                LegalForm = query[IndexLegalForm],
                LegalVehicle = query[IndexLegalVehicle],
                LegalType = query[IndexLegalType],
                FACode = query[IndexFACode],
                DEPCode = query[IndexDEPCode],
                TACode = query[IndexTACode],
                CompanyTypeDesc = query[IndexCompanyTypeDesc],
                TinNumber = query[IndexTinNumber],
                LEICode = query[IndexLEICode],
                RegNumber = query[IndexRegNumber],
            };

            return AutoMapperConfig.MapperInstance.Map<TDestination>(dto);
        }

        public async Task<EditFundPostDto> Edit(EditFundInputModel model)
        {

            return null;

            //    int fundId = model.FundId;
            //    string initialDate = model.InitialDate.ToString("yyyyMMdd");

            //    int fStatusId = this.context.TbDomFStatus
            //        .Where(s => s.StFDesc == model.Status)
            //        .Select(s => s.StFId)
            //        .FirstOrDefault();

            //    string regNumber = model.RegNumber;
            //    string fundName = model.FundName;
            //    string leiCode = model.LEICode;
            //    string cssfCode = model.CSSFCode;
            //    string faCode = model.FACode;
            //    string depCode = model.DEPCode;
            //    string taCode = model.TACode;

            //    int fLegalFormId = this.context.TbDomLegalForm
            //        .Where(lf => lf.LfAcronym == model.LegalForm)
            //        .Select(lf => lf.LfId)
            //        .FirstOrDefault();
            //    int fLegalVehicleId = this.context.TbDomLegalVehicle
            //        .Where(lv => lv.LvAcronym == model.LegalVehicle)
            //        .Select(lv => lv.LvId)
            //        .FirstOrDefault();
            //    int fLegalTypeId = this.context.TbDomLegalType
            //        .Where(lt => lt.LtAcronym == model.LegalType)
            //        .Select(lt => lt.LtId)
            //        .FirstOrDefault();

            //    // Split to take only companyTypeDesc for comparing

            //    string companyTypeDesc = model.CompanyTypeDesc.Split(" - ").FirstOrDefault();
            //    int fCompanyTypeId = this.context.TbDomCompanyType
            //        .Where(ct => ct.CtDesc == companyTypeDesc)
            //        .Select(ct => ct.CtId)
            //        .FirstOrDefault();

            //    string tinNumber = model.TinNumber;

            //    string comment = model.CommentArea;
            //    string commentTitle = model.CommentTitle;

            //    this.fundsService.EditFund(fundId, initialDate, fStatusId, regNumber,
            //                               fundName, leiCode, cssfCode, faCode, depCode, taCode,
            //                               fLegalFormId, fLegalTypeId, fLegalVehicleId, fCompanyTypeId,
            //                               tinNumber, comment, commentTitle);
        }

        ////public IEnumerable<T> GetAllNames<T>()
        ////{
        ////    return this.fundsRepository
        ////        .All()
        ////        .Select(f => f.FOfficialFundName)
        ////        .To<T>()
        ////        .ToList();

        ////    // return this.context.TbHistoryFund
        ////    //   .Select(f => f.FOfficialFundName)
        ////    //   .ToList();
        ////}

        //// ________________________________________________________
        ////
        //// Execute query table DB based stored procedure
        //// with fixed parameters
        // public void EditFund(
        //                        int fundId,
        //                        string initialDate,
        //                        int fStatusId,
        //                        string regNumber,
        //                        string fundName,
        //                        string leiCode,
        //                        string cssfCode,
        //                        string faCode,
        //                        string depCode,
        //                        string taCode,
        //                        int fLegalFormId,
        //                        int fLegalTypeId,
        //                        int fLegalVehicleId,
        //                        int fCompanyTypeId,
        //                        string tinNumber,
        //                        string comment,
        //                        string commentTitle)
        //{
        //    string query = "EXEC sp_modify_fund " +
        //        "@f_id, @f_initialDate, @f_status, " +
        //        "@f_registrationNumber, @f_officialFundName, @f_shortFundName, " +
        //        "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
        //        "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber, " +
        //        "@comment, @commentTitle";

        //    using (SqlConnection connection = new SqlConnection())
        //    {
        //        connection.ConnectionString = this.configuration.GetConnectionString(GlobalConstants.DataGatevFinaleConnection);
        //        using (SqlCommand command = new SqlCommand(query))
        //        {
        //            command.Parameters.AddRange(new[]
        //            {
        //                new SqlParameter("@f_id", SqlDbType.Int) { Value = fundId },
        //                new SqlParameter("@comment", SqlDbType.NVarChar) { Value = comment },
        //                new SqlParameter("@commentTitle", SqlDbType.NVarChar) { Value = commentTitle },
        //            });

        //            command.Parameters.AddRange(new[]
        //            {
        //                new SqlParameter("@f_initialDate", SqlDbType.NVarChar) { Value = initialDate },
        //                new SqlParameter("@f_status", SqlDbType.Int) { Value = fStatusId },
        //                new SqlParameter("@f_registrationNumber", SqlDbType.NVarChar) { Value = regNumber },
        //                new SqlParameter("@f_officialFundName", SqlDbType.NVarChar) { Value = fundName },
        //                new SqlParameter("@f_shortFundName", SqlDbType.NVarChar) { Value = fundName },
        //                new SqlParameter("@f_leiCode", SqlDbType.NVarChar) { Value = leiCode },
        //                new SqlParameter("@f_cssfCode", SqlDbType.NVarChar) { Value = cssfCode },
        //                new SqlParameter("@f_faCode", SqlDbType.NVarChar) { Value = faCode },
        //                new SqlParameter("@f_depCode", SqlDbType.NVarChar) { Value = depCode },
        //                new SqlParameter("@f_taCode", SqlDbType.NVarChar) { Value = taCode },
        //                new SqlParameter("@f_legalForm", SqlDbType.Int) { Value = fLegalFormId },
        //                new SqlParameter("@f_legalType", SqlDbType.Int) { Value = fLegalTypeId },
        //                new SqlParameter("@f_legal_vehicle", SqlDbType.Int) { Value = fLegalVehicleId },
        //                new SqlParameter("@f_companyType", SqlDbType.Int) { Value = fCompanyTypeId },
        //                new SqlParameter("@f_tinNumber", SqlDbType.NVarChar) { Value = tinNumber },
        //            });

        //            this.sqlManager.ExecuteScalarSqlConnectionCommand(connection, command);
        //        }
        //    }
        //}

        private void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistoryFund));
            }
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.FId == id);

        //public void CreateFund(
        //                        string initialDate,
        //                        string endDate,
        //                        string fundName,
        //                        string cssfCode,
        //                        int fStatusId,
        //                        int fLegalFormId,
        //                        int fLegalTypeId,
        //                        int fLegalVehicleId,
        //                        string faCode,
        //                        string depCode,
        //                        string taCode,
        //                        int fCompanyTypeId,
        //                        string tinNumber,
        //                        string leiCode,
        //                        string regNumber)
        //{
        //    string query = "EXEC sp_new_fund " +
        //        "@f_initialDate, @f_endDate, @f_status, " +
        //        "@f_registrationNumber, @f_officialFundName, " +
        //        "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
        //        "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber";

        //    using (SqlConnection connection = new SqlConnection())
        //    {
        //        connection.ConnectionString = this.configuration.GetConnectionString(GlobalConstants.DataGatevFinaleConnection);
        //        using (SqlCommand command = new SqlCommand(query))
        //        {
        //            command.Parameters.Add(new SqlParameter("@f_endDate", SqlDbType.NVarChar) { Value = endDate });

        //            command.Parameters.AddRange(new[]
        //            {
        //                new SqlParameter("@f_initialDate", SqlDbType.NVarChar) { Value = initialDate },
        //                new SqlParameter("@f_status", SqlDbType.Int) { Value = fStatusId },
        //                new SqlParameter("@f_registrationNumber", SqlDbType.NVarChar) { Value = regNumber },
        //                new SqlParameter("@f_officialFundName", SqlDbType.NVarChar) { Value = fundName },
        //                new SqlParameter("@f_leiCode", SqlDbType.NVarChar) { Value = leiCode },
        //                new SqlParameter("@f_cssfCode", SqlDbType.NVarChar) { Value = cssfCode },
        //                new SqlParameter("@f_faCode", SqlDbType.NVarChar) { Value = faCode },
        //                new SqlParameter("@f_depCode", SqlDbType.NVarChar) { Value = depCode },
        //                new SqlParameter("@f_taCode", SqlDbType.NVarChar) { Value = taCode },
        //                new SqlParameter("@f_legalForm", SqlDbType.Int) { Value = fLegalFormId },
        //                new SqlParameter("@f_legalType", SqlDbType.Int) { Value = fLegalTypeId },
        //                new SqlParameter("@f_legal_vehicle", SqlDbType.Int) { Value = fLegalVehicleId },
        //                new SqlParameter("@f_companyType", SqlDbType.Int) { Value = fCompanyTypeId },
        //                new SqlParameter("@f_tinNumber", SqlDbType.NVarChar) { Value = tinNumber },
        //            });

        //            this.sqlManager.ExecuteScalarSqlConnectionCommand(connection, command);
        //        }
        //    }
        //}
    }
}
