namespace DataGate.Data.Repositories.UsersContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Repositories.UsersContext;

    using Microsoft.EntityFrameworkCore;

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

        public async Task SaveLayout(ICollection<TEntity> entitiesToRemove, HashSet<TEntity> entitiesToAdd)
        {
            if (entitiesToAdd.Count > 0)
            {
                this.DeleteRange(entitiesToRemove);
                this.AddRange(entitiesToAdd);
                await this.SaveChangesAsync();
            }
        }

        public async Task RestoreLayout(ICollection<TEntity> entitiesToRemove)
        {
            if (entitiesToRemove.Count > 0)
            {
                this.DeleteRange(entitiesToRemove);
                await this.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this.Context.AddRangeAsync(entities);
            await this.Context.SaveChangesAsync();
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

        public void DeleteRange(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.DbSet.Remove(entity);
            }
        }

        public void AddRange(HashSet<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.DbSet.Add(entity);
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
