namespace DataGate.Services.SqlClient
{
    public class SqlProcedureDictionary
    {
        // ________________________________________________________
        //
        // Stored procedures as in DB
        // Upload
        public const string DocumentFund = "EXEC sp_insert_document_fund";
        public const string DocumentSubFund = "EXEC sp_insert_document_subfund";
        public const string DocumentShareClass = "EXEC sp_insert_document_shareclass";

        public const string AgreementFund = "EXEC sp_insert_agreement_fund";
        public const string AgreementSubFund = "EXEC sp_insert_agreement_subfund";
        public const string AgreementShareClass = "EXEC sp_insert_agreement_shareclass";

        // Delete
        public const string DeleteDocumentFund = "EXEC delete_fund_file_byid @file_id";
        public const string DeleteDocumentSubFund = "EXEC delete_subfund_file_byid @file_id";
        public const string DeleteDocumentShareClass = "EXEC delete_shareclass_file_byid @file_id";

        public const string DeleteAgreementFund = "EXEC delete_agreement_fundfile_byid @file_id";
        public const string DeleteAgreementSubFund = "EXEC delete_agreement_subfundfile_byid @file_id";
        public const string DeleteAgreementShareClass = "EXEC delete_agreement_shareclassfile_byid @file_id";

        // Create/edit fund
        public const string EditFund = "EXEC sp_modify_fund " +
                "@f_id, @f_initialDate, @f_status, " +
                "@f_registrationNumber, @f_officialFundName, @f_shortFundName, " +
                "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
                "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber, " +
                "@comment, @comment_title";

        public const string CreateFund = "EXEC sp_new_fund " +
                "@f_initialDate, @f_endDate, @f_status, " +
                "@f_registrationNumber, @f_officialFundName, " +
                "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
                "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber";

        // Create/edit sub fund
        public const string EditSubFund = "EXEC sp_modify_subfund " +
               "@sf_id, @sf_initialDate, @sf_officialSubFundName, @sf_shortSubFundName," +
               "@sf_cssfCode, @sf_faCode, @sf_depCode, @sf_taCode, @sf_firstNavDate, " +
               "@sf_lastNavDate, @sf_cssfAuthDate, @sf_expDate, @sf_status, @sf_leiCode, " +
               "@sf_cesrClass, @sf_cssf_geographical_focus, @sf_globalExposure, " +
               "@sf_currency, @sf_navFrequency, @sf_valutationDate, @sf_calculationDate, " +
               "@sf_derivatives, @sf_derivMarket, @sf_derivPurpose, @sf_principal_asset_class, " +
               "@sf_type_of_market, @sf_principal_investment_strategy, @sf_clearing_code, " +
               "@sf_cat_morningstar, @sf_category_six, @sf_category_bloomberg, @comment, " +
               "@comment_title";

        public const string CreateSubFund = "EXEC sp_new_subfund " +
                "@sf_initialDate, @sf_endDate, @sf_officialSubFundName, " +
                "@sf_cssfCode, @sf_faCode, @sf_depCode, @sf_taCode, @sf_firstNavDate, " +
                "@sf_lastNavDate, @sf_cssfAuthDate, @sf_expDate, @sf_status, @sf_leiCode, " +
                "@sf_cesrClass, @sf_cssf_geographical_focus, @sf_globalExposure, " +
                "@sf_currency, @sf_navFrequency, @sf_valutationDate, @sf_calculationDate, " +
                "@sf_derivatives, @sf_derivMarket, @sf_derivPurpose, @sf_principal_asset_class, " +
                "@sf_type_of_market, @sf_principal_investment_strategy, @sf_clearing_code, " +
                "@sf_cat_morningstar, @sf_category_six, @sf_category_bloomberg, @fundcontainer";

        // Create/edit share class
        public const string EditShareClass = "EXEC sp_modify_shareclass " +
                    "@sc_id, @sc_initialDate, @sc_officialShareClassName, " +
                    "@sc_shortShareClassName, @sc_investorType, @sc_shareType, @sc_currency, " +
                    "@sc_countryIssue, @sc_ultimateParentCountryRisk, @sc_emissionDate, @sc_inceptionDate, " +
                    "@sc_lastNav, @sc_expiryDate, @sc_status, @sc_initialPrice, " +
                    "@sc_accountingCode, @sc_hedged, @sc_listed, @sc_bloomberMarket, " +
                    "@sc_bloomberCode, @sc_bloomberId, @sc_isinCode, @sc_valorCode, " +
                    "@sc_faCode, @sc_taCode, @sc_WKN, @sc_date_business_year, " +
                    "@sc_prospectus_code, @comment, @comment_title";

        public const string CreateShareClass = "EXEC sp_new_shareclass " +
                "@sc_initialDate, @sc_endDate, @sc_officialShareClassName, " +
                "@sc_investorType, @sc_shareType, @sc_currency, " +
                "@sc_countryIssue, @sc_ultimateParentCountryRisk, @sc_emissionDate, @sc_inceptionDate, " +
                "@sc_lastNav, @sc_expiryDate, @sc_status, @sc_initialPrice, " +
                "@sc_accountingCode, @sc_hedged, @sc_listed, @sc_bloomberMarket, " +
                "@sc_bloomberCode, @sc_bloomberId, @sc_isinCode, @sc_valorCode, " +
                "@sc_faCode, @sc_taCode, @sc_WKN, @sc_date_business_year, " +
                "@sc_prospectus_code, @subfundcontainer";
    }
}
