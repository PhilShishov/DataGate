namespace DataGate.Data.Common.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> : IDisposable
    {
        IQueryable<TEntity> All();

        Task<int> SaveChangesContext();
    }
}
