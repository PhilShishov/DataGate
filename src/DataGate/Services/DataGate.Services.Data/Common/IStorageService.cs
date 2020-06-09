namespace DataGate.Services.Data.Common
{
    using System.Threading.Tasks;

    public interface IStorageService
    {
        T GetByIdAndDate<T>(int id, string date);

        Task<bool> DoesExist(string name);
    }
}
