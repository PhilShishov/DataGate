namespace DataGate.Data.Repositories.AppContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories.AppContext;

    public class EfAppRepository<TEntity> : IAppRepository<TEntity>
        where TEntity : class
    {
        public EfAppRepository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected ApplicationDbContext Context { get; set; }

        public virtual IQueryable<TEntity> All() => this.DbSet;

        public virtual IQueryable<TEntity> AllAsNoTracking() => this.DbSet.AsNoTracking();

        public virtual Task AddAsync(TEntity entity) => this.DbSet.AddAsync(entity).AsTask();

        public virtual async Task<TEntity> FindAsync(object id)
        {
            TEntity model = await this.DbSet.FindAsync(id);

            if (model == null)
            {
                throw new EntityNotFoundException(typeof(TEntity).Name);
            }

            return model;
        }

        public virtual void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity) => this.DbSet.Remove(entity);

        public async Task SaveLayout(ICollection<TEntity> entitiesToRemove, HashSet<TEntity> entitiesToUpdate)
        {
            if (entitiesToUpdate.Count > 0)
            {
                this.DeleteRange(entitiesToRemove);
                this.UpdateRange(entitiesToUpdate);
                await this.SaveChangesContext();
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

        public Task<int> SaveChangesContext() => this.Context.SaveChangesAsync();

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
