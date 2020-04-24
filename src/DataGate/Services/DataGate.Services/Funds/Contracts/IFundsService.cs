﻿namespace DataGate.Services.Funds.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IFundsService
    {
        List<string[]> GetAllFunds(DateTime? chosenDate);

        List<string[]> GetAllActiveFunds();

        List<string[]> GetAllActiveFunds(DateTime? chosenDate);

        List<string[]> GetAllFundsWithSelectedViewAndDate(
                        List<string> preSelectedColumns, 
                        List<string> selectedColumns, 
                        DateTime? chosenDate);

        List<string[]> GetAllActiveFundsWithSelectedViewAndDate(
                        List<string> preSelectedColumns, 
                        List<string> selectedColumns, 
                        DateTime? chosenDate);

        List<string> GetAllFundsNames();

        List<string[]> GetFundWithDateById(DateTime? chosenDate, int id);

        List<string[]> GetFund_SubFunds(DateTime? chosenDate, int id);

        List<string[]> GetFund_SubFundsWithSelectedViewAndDate(
                        List<string> preSelectedColumns, 
                        List<string> selectedColumns, 
                        DateTime? chosenDate, 
                        int id);        

        List<string[]> GetFundTimeline(int id);

        List<string[]> GetDistinctFundDocuments(DateTime? chosenDate, int id);

        List<string[]> GetAllFundDocuments(int id);

        List<string[]> GetDistinctFundAgreements(DateTime? chosenDate, int id);

        List<string[]> GetAllFundAgreements(DateTime? chosenDate, int id);

        List<string[]> PrepareFund_SubFundsForPDFExtract(DateTime? chosenDate);

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