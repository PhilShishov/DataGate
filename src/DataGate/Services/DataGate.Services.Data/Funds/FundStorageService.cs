namespace DataGate.Services.Data.Funds
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FundStorageService
    {
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
