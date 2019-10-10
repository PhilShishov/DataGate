
namespace Pharus.Services.Contracts
{
    using System.Collections.Generic;

    using Pharus.Domain.Pharus_vFinale;

    public interface IFundsService
    {
        List<TbHistoryFund> GetAllFunds();

        IEnumerable<object[]> GetAllActiveFunds(string chosenDate);

        TbHistoryFund GetFund(string fundName);
    }
}
