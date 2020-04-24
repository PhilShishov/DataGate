namespace DataGate.Services.ShareClasses.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IShareClassesService
    {
        List<string[]> GetAllShareClasses(DateTime? chosenDate);

        List<string[]> GetAllActiveShareClasses();

        List<string[]> GetAllActiveShareClasses(DateTime? chosenDate);

        List<string[]> GetAllShareClassesWithSelectedViewAndDate(
                        List<string> preSelectedColumns,
                        List<string> selectedColumns,
                        DateTime? chosenDate);

        List<string[]> GetAllActiveShareClassesWithSelectedViewAndDate(
                        List<string> preSelectedColumns,
                        List<string> selectedColumns,
                        DateTime? chosenDate);

        List<string> GetAllShareClassesNames();

        List<string[]> GetShareClassWithDateById(DateTime? chosenDate, int id);

        List<string[]> GetShareClass_SubFundContainer(DateTime? chosenDate, int id);

        List<string[]> GetTimeseriesTypeProviders(int id);

        List<string[]> GetShareClassTimeSeriesData(int id);

        List<string[]> GetShareClassTimeSeriesDates(int id);

        List<string[]> GetShareClassesTimeline(int id);

        List<string[]> GetDistinctShareClassDocuments(DateTime? chosenDate, int id);

        List<string[]> GetDistinctShareClassAgreements(DateTime? chosenDate, int id);

        List<string[]> GetAllShareClassDocuments(int id);

        List<string[]> GetAllShareClassAgreements(DateTime? chosenDate, int id);

        List<string[]> PrepareShareClassesForPDFExtract(DateTime? chosenDate);

        void EditShareClass(
                        int scId,
                        string initialDate,
                        string shareClassName,
                        int? investorTypeId,
                        int? shareTypeId,
                        string currency,
                        string countryIssue,
                        string countryRisk,
                        string emissionDate,
                        string inceptionDate,
                        string lastNavDate,
                        string expiryDate,
                        int scStatusId,
                        double initialPrice,
                        string accountingCode,
                        bool isHedged,
                        bool isListed,
                        string bloombergMarket,
                        string bloombergCode,
                        string bloombergId,
                        string isinCode,
                        string valorCode,
                        string faCode,
                        string taCode,
                        string wKN,
                        string businessYearDate,
                        string prospectusCode,
                        string comment,
                        string commentTitle);

        void CreateShareClass(
                        string initialDate, 
                        string endDate, 
                        string shareClassName, 
                        int? investorTypeId, 
                        int? shareTypeId, 
                        string currency, 
                        string countryIssue, 
                        string countryRisk, 
                        string emissionDate, 
                        string inceptionDate, 
                        string lastNavDate, 
                        string expiryDate, 
                        int scStatusId, 
                        double initialPrice,
                        string accountingCode,
                        bool isHedged, 
                        bool isListed, 
                        string bloombergMarket, 
                        string bloombergCode, 
                        string bloombergId, 
                        string isinCode, 
                        string valorCode, 
                        string faCode, 
                        string taCode, 
                        string wKN, 
                        string businessYearDate, 
                        string prospectusCode, 
                        int subFundContainerId);
    }
}
