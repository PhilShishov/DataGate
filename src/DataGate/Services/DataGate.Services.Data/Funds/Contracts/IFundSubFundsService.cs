namespace DataGate.Services.Data.Funds.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IFundSubFundsService
    {
        IEnumerable<string[]> GetFundWithDateById(DateTime? chosenDate, int id);

        IEnumerable<string[]> GetFund_SubFunds(DateTime? chosenDate, int id);

        IEnumerable<string[]> GetFund_SubFundsWithSelectedViewAndDate(
                        List<string> preSelectedColumns,
                        List<string> selectedColumns,
                        DateTime? chosenDate,
                        int id);

        IEnumerable<string[]> GetFundTimeline(int id);

        IEnumerable<string[]> GetDistinctFundDocuments(DateTime? chosenDate, int id);

        IEnumerable<string[]> GetAllFundDocuments(int id);

        IEnumerable<string[]> GetDistinctFundAgreements(DateTime? chosenDate, int id);

        IEnumerable<string[]> GetAllFundAgreements(DateTime? chosenDate, int id);

        IEnumerable<string[]> PrepareFund_SubFundsForPDFExtract(DateTime? chosenDate);
    }
}
