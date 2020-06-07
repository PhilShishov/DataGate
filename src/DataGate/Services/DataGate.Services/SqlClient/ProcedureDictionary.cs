namespace DataGate.Services.SqlClient
{
    public class ProcedureDictionary
    {
        // ________________________________________________________
        //
        // Stored procedures as in DB
        // Upload
        public const string SqlProcedureDocumentFund = "EXEC sp_insert_map_fund";
        public const string SqlProcedureDocumentSubFund = "EXEC sp_insert_map_subfund";
        public const string SqlProcedureDocumentShareClass = "EXEC sp_insert_map_shareclass";

        public const string SqlProcedureAgreementFund = "EXEC sp_insert_agreement_fund";
        public const string SqlProcedureAgreementSubFund = "EXEC sp_insert_agreement_subfund";
        public const string SqlProcedureAgreementShareClass = "EXEC sp_insert_agreement_shareclass";

        // Delete
        public const string SqlProcedureDeleteDocumentFund = "EXEC delete_fund_file_byid @file_id";
        public const string SqlProcedureDeleteDocumentSubFund = "EXEC delete_subfund_file_byid @file_id";
        public const string SqlProcedureDeleteDocumentShareClass = "EXEC delete_shareclass_file_byid @file_id";

        public const string SqlProcedureDeleteAgreementFund = "EXEC delete_agreement_fundfile_byid @file_id";
        public const string SqlProcedureDeleteAgreementSubFund = "EXEC delete_agreement_subfundfile_byid @file_id";
        public const string SqlProcedureDeleteAgreementShareClass = "EXEC delete_agreement_shareclassfile_byid @file_id";

        // Create/edit fund
        public const string SqlProcedureEditFund = "EXEC sp_modify_fund " +
                "@f_id, @f_initialDate, @f_status, " +
                "@f_registrationNumber, @f_officialFundName, @f_shortFundName, " +
                "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
                "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber, " +
                "@comment, @commentTitle";

        public const string SqlProcedureCreateFund = "EXEC sp_new_fund " +
                "@f_initialDate, @f_endDate, @f_status, " +
                "@f_registrationNumber, @f_officialFundName, " +
                "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
                "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber";

        //// Create/edit sub fund
        // private readonly string sqlFunctionFundId = "[fn_fund_id]";

        // private readonly string sqlProcedureEditFund = "EXEC sp_modify_fund " +
        //        "@f_id, @f_initialDate, @f_status, " +
        //        "@f_registrationNumber, @f_officialFundName, @f_shortFundName, " +
        //        "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
        //        "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber, " +
        //        "@comment, @commentTitle";

        // private readonly string sqlProcedureCreateFund = "EXEC sp_new_fund " +
        //        "@f_initialDate, @f_endDate, @f_status, " +
        //        "@f_registrationNumber, @f_officialFundName, " +
        //        "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
        //        "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber";

        //// Create/edit share class
        // private readonly string sqlFunctionFundId = "[fn_fund_id]";

        // private readonly string sqlProcedureEditFund = "EXEC sp_modify_fund " +
        //        "@f_id, @f_initialDate, @f_status, " +
        //        "@f_registrationNumber, @f_officialFundName, @f_shortFundName, " +
        //        "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
        //        "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber, " +
        //        "@comment, @commentTitle";

        // private readonly string sqlProcedureCreateFund = "EXEC sp_new_fund " +
        //        "@f_initialDate, @f_endDate, @f_status, " +
        //        "@f_registrationNumber, @f_officialFundName, " +
        //        "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
        //        "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber";
    }
}
