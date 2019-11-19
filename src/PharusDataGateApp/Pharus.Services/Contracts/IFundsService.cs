
namespace Pharus.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IFundsService
    {
        List<string[]> GetAllActiveFunds();

        List<string[]> GetAllActiveFunds(DateTime? chosenDate);

        List<string[]> GetActiveFundById(int Id);

        List<string[]> GetActiveFundById(DateTime? chosenDate, int Id);

        List<string[]> GetActiveFundWithDateById(int Id);

        List<string[]> GetFundSubFunds(int Id);

        void ExecuteEditFund(List<string[]> fundsProperties, int fStatusId,
            int fLegalFormId, int fLegalTypeId, 
            int fLegalVehicleId, int fCompanyTypeId);
    }
}
