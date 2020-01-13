namespace Pharus.Services.ShareClasses.Contracts
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

        List<string[]> GetShareClassTimeSeries(int id);

        List<string[]> GetShareClassTimeSeriesDates(int id);

        List<string[]> GetShareClassesTimeline(int id);

        List<string[]> GetAllShareClassesDocumens(int id);

        List<string[]> PrepareShareClassesForPDFExtract(DateTime? chosenDate);

        void EditShareClass(
                        int scId,
                        string initialDate,
                        string subFundName,
                        string cssfCode,
                        string faCode,
                        string depCode,
                        string taCode,
                        string firstNavDate,
                        string lastNavDate,
                        string cssfAuthDate,
                        string expiryDate,
                        int sfStatusId,
                        string leiCode,
                        int? cesrClassId,
                        int? geoFocusId,
                        int? glExpId,
                        string currency,
                        int? frequencyId,
                        int? valuationId,
                        int? calculationId,
                        bool isDerivative,
                        int? derivMarketId,
                        int? derivPurposeId,
                        int? principalAssetId,
                        int? typeMarketId,
                        int? principalInvStrId,
                        string clearingCode,
                        int? catMorningStarId,
                        int? catSixId,
                        int? catBloombergId,
                        string comment,
                        string commentTitle
                        );

        void CreateShareClass(
                        string initialDate,
                        string endDate,
                        string subFundName,
                        string cssfCode,
                        string faCode,
                        string depCode,
                        string taCode,
                        string firstNavDate,
                        string lastNavDate,
                        string cssfAuthDate,
                        string expiryDate,
                        int sfStatusId,
                        string leiCode,
                        int? cesrClassId,
                        int? geoFocusId,
                        int? glExpId,
                        string currency,
                        int? frequencyId,
                        int? valuationId,
                        int? calculationId,
                        bool isDerivative,
                        int? derivMarketId,
                        int? derivPurposeId,
                        int? principalAssetId,
                        int? typeMarketId,
                        int? principalInvStrId,
                        string clearingCode,
                        int? catMorningStarId,
                        int? catSixId,
                        int? catBloombergId,
                        int subFundContainerId
                        );
    }
}
