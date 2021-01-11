// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Common.Repositories.UsersContext
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserRepository<TEntity> : IRepository<TEntity>
    {
        Task SaveLayout(ICollection<TEntity> entitiesToRemove, HashSet<TEntity> entitiesToUpdate);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void DeleteRange(ICollection<TEntity> entities);

        void AddRange(HashSet<TEntity> entities);

        void Update(TEntity entity);

        Task RestoreLayout(ICollection<TEntity> entitiesToRemove);
    }
}
