namespace DataGate.Services.Data.Common
{
    using System;
    using System.Threading.Tasks;

    public interface IContainerService
    {
        Task<string> GetContainer(int id, DateTime? date);
    }
}
