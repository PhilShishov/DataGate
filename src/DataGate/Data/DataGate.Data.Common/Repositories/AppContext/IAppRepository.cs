namespace DataGate.Data.Common.Repositories.AppContext
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAppRepository<TEntity> : IRepository<TEntity>
    {
        IQueryable<TEntity> AllAsNoTracking();

        Task AddAsync(TEntity entity);

        Task<TEntity> FindAsync(object id);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
