namespace DataGate.Services.Data.Funds.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IFundsService
    {
        IEnumerable<string[]> GetAllFunds(DateTime? chosenDate);

        IEnumerable<string[]> GetAllActiveFunds();

        IEnumerable<string[]> GetAllActiveFunds(DateTime? chosenDate);

        IEnumerable<string[]> GetAllFundsWithSelectedViewAndDate(
                        IEnumerable<string> preSelectedColumns,
                        IEnumerable<string> selectedColumns,
                        DateTime? chosenDate);

        IEnumerable<string[]> GetAllActiveFundsWithSelectedViewAndDate(
                        IEnumerable<string> preSelectedColumns,
                        IEnumerable<string> selectedColumns,
                        DateTime? chosenDate);

        IEnumerable<T> GetAllFundsNames<T>();

        IEnumerable<string[]> GetFundWithDateById(DateTime? chosenDate, int id);

        IEnumerable<string[]> GetFund_SubFunds(DateTime? chosenDate, int id);

        IEnumerable<string[]> GetFund_SubFundsWithSelectedViewAndDate(
                        IEnumerable<string> preSelectedColumns,
                        IEnumerable<string> selectedColumns,
                        DateTime? chosenDate,
                        int id);

        IEnumerable<string[]> GetFundTimeline(int id);

        IEnumerable<string[]> GetDistinctFundDocuments(DateTime? chosenDate, int id);

        IEnumerable<string[]> GetAllFundDocuments(int id);

        IEnumerable<string[]> GetDistinctFundAgreements(DateTime? chosenDate, int id);

        IEnumerable<string[]> GetAllFundAgreements(DateTime? chosenDate, int id);

        IEnumerable<string[]> PrepareFund_SubFundsForPDFExtract(DateTime? chosenDate);

        void EditFund(
                        int fundId,
                        string initialDate,
                        int fStatusId,
                        string regNumber,
                        string fundName,
                        string leiCode,
                        string cssfCode,
                        string faCode,
                        string depCode,
                        string taCode,
                        int fLegalFormId,
                        int fLegalTypeId,
                        int fLegalVehicleId,
                        int fCompanyTypeId,
                        string tinNumber,
                        string comment,
                        string commentTitle);

        void CreateFund(
                        string initialDate,
                        string endDate,
                        string fundName,
                        string cssfCode,
                        int fStatusId,
                        int fLegalFormId,
                        int fLegalTypeId,
                        int fLegalVehicleId,
                        string faCode,
                        string depCode,
                        string taCode,
                        int fCompanyTypeId,
                        string tinNumber,
                        string leiCode,
                        string regNumber);
    }
}
