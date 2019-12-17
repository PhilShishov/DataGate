namespace Pharus.Services.SubFunds.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ISubFundsService
    {
        List<string[]> GetAllSubFunds();

        List<string[]> GetAllSubFunds(DateTime? chosenDate);

        List<string> GetAllSubFundsNames();

        List<string[]> GetSubFundById(int id);

        List<string[]> GetSubFundById(DateTime? chosenDate, int id);

        List<string[]> GetSubFundWithDateById(int id);

        List<string[]> GetSubFundWithDateById(DateTime? chosenDate, int id);

        List<string[]> GetSubFund_ShareClasses(int id);

        List<string[]> GetSubFund_ShareClasses(DateTime? chosenDate, int id);

        List<string[]> GetSubFund_FundContainer(int id);

        List<string[]> GetSubFund_FundContainer(DateTime? chosenDate, int id);

        List<string[]> GetSubFundTimeline(int id);

        List<string[]> GetAllSubFundDocumens(int id);

        void EditSubFund(
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

        void CreateSubFund(
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
                        int fStatusId,
                        string leiCode,
                        int cesrClassId,
                        int geoFocusId,
                        int glExpId,
                        int currencyId,
                        int frequencyId,
                        int valuationId,
                        int calculationId,
                        bool derivatives,
                        int derivMarketId,
                        int derivPurposeId,
                        int principalAssetId,
                        int typeMarketId,
                        int principalInvStrId,
                        string clearingCode,
                        int catMorningStarId,
                        int catSixId,
                        int catBloombergId
                        );
    }
}
