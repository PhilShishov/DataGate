namespace DataGate.Services.Data.Storage.Contracts
{
    using System.Threading.Tasks;

    using DataGate.Services.Data.Common;
    using DataGate.Web.InputModels.SubFunds;

    public interface ISubFundStorageService : IStorageService
    {
        Task<int> Edit(EditSubFundInputModel model);

        Task<int> Create(CreateSubFundInputModel model);
    }
}
