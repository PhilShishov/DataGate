namespace DataGate.Data.Repositories.UsersContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories.UsersContext;

    public class EfUserRepository<TEntity> : IUserRepository<TEntity>
        where TEntity : class
    {
        public EfUserRepository(UsersDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected UsersDbContext Context { get; set; }

        public virtual IQueryable<TEntity> All() => this.DbSet;

        public virtual Task AddAsync(TEntity entity) => this.DbSet.AddAsync(entity).AsTask();

        public virtual void Delete(TEntity entity) => this.DbSet.Remove(entity);

        public async Task SaveLayout(ICollection<TEntity> entitiesToRemove, HashSet<TEntity> entitiesToUpdate)
        {
            if (entitiesToUpdate.Count > 0)
            {
                this.DeleteRange(entitiesToRemove);
                this.UpdateRange(entitiesToUpdate);
                await this.SaveChangesAsync();
            }
        }

        public void DeleteRange(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.DbSet.Remove(entity);
            }
        }

        public void UpdateRange(HashSet<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                var entry = this.Context.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    this.DbSet.Attach(entity);
                }
            }
        }

        public Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}
