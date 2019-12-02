namespace Pharus.Services.SubFunds.Contracts
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

        List<string[]> GetSubFund_ShareClasses(int id);

        List<string[]> GetSubFund_FundContainer(int id);

        List<string[]> GetSubFund_FundContainer(DateTime? chosenDate, int id);
    }
}
