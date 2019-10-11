
namespace Pharus.Services.Contracts
{
    using System.Collections.Generic;

    using Pharus.Domain.Pharus_vFinale;

    public interface IFundsService
    {
        List<TbHistoryFund> GetAllFunds();

        List<string[]> GetAllActiveFunds( );

        TbHistoryFund GetFund(string fundName);
    }
}
