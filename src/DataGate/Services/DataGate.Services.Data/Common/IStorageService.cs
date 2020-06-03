namespace DataGate.Services.Data.Common
{
    using System.Threading.Tasks;

    public interface IStorageService
    {
        Task<TDestination> GetByIdAndDate<TDestination>(int id, string date);

        Task<bool> DoesExist(string name);
    }
}
