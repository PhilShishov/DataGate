// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.TestData
{
    public static class SqlFunctionDictionary
    {
        // ________________________________________________________
        //
        // Table functions names as in DB

        public const string AllFund = "[fn_all_fund]";        
        public const string ByIdFund = "[fn_fund_id]";
        public const string TimelineFund = "[fn_timeline_fund]";

        public const string AllSubFund = "[fn_all_subfund]";       
        public const string ByIdSubFund = "[fn_subfund_id]";        

        public const string AllShareClass = "[fn_all_shareclass]";    
        public const string ByIdShareClass = "[fn_shareclass_id]";

        public const string ReportFunds = "[getAuM_fund_test]";
        public const string ReportSubFunds = "[fn_AuM_subfund_EOM]";
        public const string CountryDistShareClass = "[fn_view_country_distibution_shareclass]";

        public const string AllAgreementsFunds = "[fn_view_agreements_all_funds]";
    }
}
