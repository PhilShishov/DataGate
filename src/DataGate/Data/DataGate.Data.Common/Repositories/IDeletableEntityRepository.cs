namespace DataGate.Data.Common.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Models;
    using DataGate.Data.Common.Repositories.AppContext;

    public interface IDeletableEntityRepository<TEntity> : IAppRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        Task<TEntity> ByIdWithDeletedAsync(params object[] id);

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
