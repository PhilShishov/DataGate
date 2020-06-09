namespace DataGate.Services.Data.Storage
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Web.InputModels.ShareClasses;

    public class ShareClassStorageService : IShareClassStorageService
    {
        public Task<int> Create(CreateShareClassInputModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesExist(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> Edit(EditShareClassInputModel model)
        {
            throw new NotImplementedException();
        }

        public T GetByIdAndDate<T>(int id, string date)
        {
            throw new NotImplementedException();
        }
    }
}
