namespace Pharus.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ISubFundsService
    {
        List<string[]> GetAllActiveSubFunds();

        List<string[]> GetAllActiveSubFunds(DateTime? chosenDate);

        List<string[]> GetActiveSubFundById(int Id);

        List<string[]> GetActiveSubFundById(DateTime? chosenDate, int Id);

        List<string[]> GetActiveSubFundWithDateById(int Id);

        List<string[]> GetSubFundShareClasses(int Id);
    }
}
