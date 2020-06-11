namespace DataGate.Services.Data.Storage.Contracts
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Services.Data.Common;
    using DataGate.Web.InputModels.Funds;

    public interface IFundStorageService : IStorageService
    {
        Task<int> Edit(EditFundInputModel model);

        Task<int> Create(CreateFundInputModel model);
    }
}
