
namespace Pharus.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IFundsService
    {
        List<string[]> GetAllActiveFunds();

        List<string[]> GetAllActiveFunds(DateTime? chosenDate);

        List<string[]> GetActiveFundById(int Id);

        List<string[]> GetFundSubFunds(int Id);
    }
}
