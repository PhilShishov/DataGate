namespace Pharus.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ISubFundsService
    {
        List<string[]> GetAllActiveSubFunds();

        List<string[]> GetAllActiveSubFunds(DateTime? chosenDate);

        List<string[]> GetActiveSubFundById(int id);

        List<string[]> GetActiveSubFundById(DateTime? chosenDate, int id);

        List<string[]> GetActiveSubFundWithDateById(int id);

        List<string[]> GetSubFundShareClasses(int id);
    }
}
