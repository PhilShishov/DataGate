namespace DataGate.Services.Data.Common
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStorageService
    {
        Task<TDestination> GetByIdAndDate<TDestination>(int id, string date);

        //IEnumerable<string> GetAllNames();
    }
}
