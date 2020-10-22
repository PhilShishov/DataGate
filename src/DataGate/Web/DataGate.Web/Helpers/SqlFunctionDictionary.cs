namespace DataGate.Web.Helpers
{
    public static class SqlFunctionDictionary
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        // Funds
        public const string AllFund = "[fn_all_fund]";
        public const string AllActiveFund = "[fn_active_fund]";
        public const string ByIdFund = "[fn_fund_id]";
        public const string FundSubFunds = "[fn_active_fund_subfunds]";
        public const string FundActiveSubFunds = "[fn_active_fund_active_subfunds]";
        public const string TimelineFund = "[fn_timeline_fund]";

        // Sub Funds
        public const string AllSubFund = "[fn_all_subfund]";
        public const string AllActiveSubFund = "[fn_active_subfund]";
        public const string ByIdSubFund = "[fn_subfund_id]";
        public const string ContainerFund = "[fn_subfund_fund_container]";
        public const string SubFundShareClasses = "[fn_active_subfund_shareclasses]";
        public const string SubFundActiveShareClasses = "[fn_active_subfund_active_shareclasses]";
        public const string TimelineSubFund = "[fn_timeline_subfund]";

        // Share Classes
        public const string AllShareClass = "[fn_all_shareclass]";
        public const string AllActiveShareClass = "[fn_active_shareclass]";
        public const string ByIdShareClass = "[fn_shareclass_id]";
        public const string ContainerSubFund = "[fn_shareclass_subfund_container]";
        public const string TimelineShareClass = "[fn_timeline_shareclass]";

        // Documents
        public const int FundFileType = 1;
        public const int SubFundFileType = 2;
        public const int ShareClassFileType = 3;
        public const string DistinctDocumentsFund = "[fn_view_distinct_documents_fund]";
        public const string DistinctAgreementsFund = "[fn_view_distinct_agreements_fund]";
        public const string DocumentsFund = "[fn_view_documents_fund]";
        public const string AgreementsFund = "[fn_view_agreements_fund]";
        public const string DistinctDocumentsSubFund = "[fn_view_distinct_documents_subfund]";
        public const string DistinctAgreementsSubFund = "[fn_view_distinct_agreements_subfund]";
        public const string DocumentsSubFund = "[fn_view_documents_subfund]";
        public const string AgreementsSubFund = "[fn_view_agreements_subfund]";
        public const string DistinctDocumentsShareClass = "[fn_view_distinct_documents_shareclass]";
        public const string DistinctAgreementsShareClass = "[fn_view_distinct_agreements_shareclass]";
        public const string DocumentsShareClass = "[fn_view_documents_shareclass]";
        public const string AgreementsShareClass = "[fn_view_agreements_shareclass]";

        // Agreements
        public const string AllAgreementsFunds = "[fn_view_agreements_all_funds]";
        public const string AllAgreementsSubFunds = "[fn_view_agreements_all_subfunds]";
        public const string AllAgreementsShareClasses = "[fn_view_agreements_all_shareclasses]";

        // Reports
        public const string ReportFunds = "[dbo].[getAuM_fund_test]";
        public const string ReportSubFunds = "[fn_AuM_subfund_EOM]";
        public const string ReportsShareClasses = "[fn_AuM_shareclass_EOM]";
    }
}
