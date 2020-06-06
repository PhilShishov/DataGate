namespace DataGate.Web.Helpers
{
    public static class FunctionDictionary
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        // Funds
        public const string SqlFunctionAllFund = "[fn_all_fund]";
        public const string SqlFunctionAllActiveFund = "[fn_active_fund]";
        public const string SqlFunctionByIdFund = "[fn_fund_id]";
        public const string SqlFunctionFundSubFunds = "[fn_active_fund_subfunds]";
        public const string SqlFunctionTimelineFund = "[fn_timeline_fund]";

        // Sub Funds
        public const string SqlFunctionAllSubFund = "[fn_all_subfund]";
        public const string SqlFunctionAllActiveSubFund = "[fn_active_subfund]";
        public const string SqlFunctionByIdSubFund = "[fn_subfund_id]";
        public const string SqlFunctionContainerFund = "[fn_subfund_fund_container]";
        public const string SqlFunctionSubFundShareClasses = "[fn_active_subfund_shareclasses]";
        public const string SqlFunctionTimelineSubFund = "[fn_timeline_subfund]";

        // Share Classes
        public const string SqlFunctionAllShareClass = "[fn_all_shareclass]";
        public const string SqlFunctionAllActiveShareClass = "[fn_active_shareclass]";
        public const string SqlFunctionByIdShareClass = "[fn_shareclass_id]";
        public const string SqlFunctionContainerSubFund = "[fn_shareclass_subfund_container]";
        public const string SqlFunctionTimelineShareClass = "[fn_timeline_shareclass]";

        // Documents
        public const int FundFileType = 1;
        public const int SubFundFileType = 2;
        public const int ShareClassFileType = 3;
        public const string SqlFunctionDistinctDocumentsFund = "[fn_view_distinct_documents_fund]";
        public const string SqlFunctionDistinctAgreementsFund = "[fn_view_distinct_agreements_fund]";
        public const string SqlFunctionDocumentsFund = "[fn_view_documents_fund]";
        public const string SqlFunctionAgreementsFund = "[fn_view_agreements_fund]";
        public const string SqlFunctionDistinctDocumentsSubFund = "[fn_view_distinct_documents_subfund]";
        public const string SqlFunctionDistinctAgreementsSubFund = "[fn_view_distinct_agreements_subfund]";
        public const string SqlFunctionDocumentsSubFund = "[fn_view_documents_subfund]";
        public const string SqlFunctionAgreementsSubFund = "[fn_view_agreements_subfund]";
        public const string SqlFunctionDistinctDocumentsShareClass = "[fn_view_distinct_documents_shareclass]";
        public const string SqlFunctionDistinctAgreementsShareClass = "[fn_view_distinct_agreements_shareclass]";
        public const string SqlFunctionDocumentsShareClass = "[fn_view_documents_shareclass]";
        public const string SqlFunctionAgreementsShareClass = "[fn_view_agreements_shareclass]";

        // Agreements
        public const string SqlFunctionAllAgreementsFunds = "[fn_view_agreements_all_funds]";
        public const string SqlFunctionAllAgreementsSubFunds = "[fn_view_agreements_all_subfunds]";
        public const string SqlFunctionAllAgreementsShareClasses = "[fn_view_agreements_all_shareclasses]";
    }
}
