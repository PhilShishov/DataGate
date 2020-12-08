namespace DataGate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IUserColumnRepository<TEntity> : IDisposable
        //where TEntity : class
    {
        IQueryable<TEntity> All();

        Task SaveLayout(ICollection<TEntity> entitiesToRemove, HashSet<TEntity> entitiesToUpdate);

        void DeleteRange(ICollection<TEntity> entities);

        void UpdateRange(HashSet<TEntity> entities);

        Task<int> SaveChangesAsync();
    }
}
