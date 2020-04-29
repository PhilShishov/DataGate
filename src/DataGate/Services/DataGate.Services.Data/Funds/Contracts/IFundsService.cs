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
                        List<string> preSelectedColumns,
                        IEnumerable<string> selectedColumns,
                        DateTime? chosenDate);

        IEnumerable<string[]> GetAllActiveFundsWithSelectedViewAndDate(
                        List<string> preSelectedColumns,
                        IEnumerable<string> selectedColumns,
                        DateTime? chosenDate);

        IEnumerable<T> GetAllFundsNames<T>();

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
