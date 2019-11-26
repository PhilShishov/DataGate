namespace Pharus.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IFundsService
    {
        List<string[]> GetAllActiveFunds();

        List<string[]> GetAllActiveFunds(DateTime? chosenDate);

        List<string[]> GetActiveFundById(int id);

        List<string[]> GetActiveFundById(DateTime? chosenDate, int id);

        List<string[]> GetActiveFundWithDateById(int id);

        List<string[]> GetFundSubFunds(int id);

        void ExecuteEditFund(
                             List<string> fundsProperties,
                             int fundId,
                             DateTime chosenDate,
                             int fStatusId,
                             int fLegalFormId,
                             int fLegalTypeId,
                             int fLegalVehicleId,
                             int fCompanyTypeId);
    }
}
