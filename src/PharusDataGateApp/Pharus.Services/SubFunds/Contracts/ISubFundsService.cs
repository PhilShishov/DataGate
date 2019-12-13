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
