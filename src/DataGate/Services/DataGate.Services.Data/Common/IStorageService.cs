namespace DataGate.Services.Data.Common
{
    using System;
    using System.Threading.Tasks;

    public interface IStorageService
    {
        T GetByIdAndDate<T>(int id, string date);

        Task<bool> DoesExist(string name);

        Task<bool> DoesExistAtDate(string fundName, DateTime initialDate);
    }
}
