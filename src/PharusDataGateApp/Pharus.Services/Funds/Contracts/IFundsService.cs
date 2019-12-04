namespace Pharus.Services.Funds.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IFundsService
    {
        List<string[]> GetAllFunds();

        List<string[]> GetAllFunds(DateTime? chosenDate);

        List<string[]> GetFundById(int id);

        List<string[]> GetFundById(DateTime? chosenDate, int id);

        List<string[]> GetFundWithDateById(int id);

        List<string[]> GetFundWithDateById(DateTime? chosenDate, int id);

        List<string[]> GetFund_SubFunds(int id);

        List<string[]> GetFund_SubFunds(DateTime? chosenDate, int id);

        void EditFund(
                             List<string> fundsProperties,
                             int fundId,
                             DateTime chosenDate,
                             int fStatusId,
                             int fLegalFormId,
                             int fLegalTypeId,
                             int fLegalVehicleId,
                             int fCompanyTypeId);

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
