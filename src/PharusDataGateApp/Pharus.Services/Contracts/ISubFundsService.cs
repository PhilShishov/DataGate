namespace Pharus.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    using Pharus.Domain.Pharus_vFinale;

    public interface ISubFundsService
    {
        List<TbHistorySubFund> GetAllSubFunds();

        List<string[]> GetAllActiveSubFunds();

        List<string[]> GetAllActiveSubFunds(DateTime? chosenDate);

        TbHistorySubFund GetSubFund(string fundName);
    }
}
