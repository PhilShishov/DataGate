// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Common.Repositories.UsersContext
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserRepository<TEntity> : IRepository<TEntity>
    {
        Task SaveLayout(ICollection<TEntity> entitiesToRemove, HashSet<TEntity> entitiesToUpdate);

        void DeleteRange(ICollection<TEntity> entities);

        void UpdateRange(HashSet<TEntity> entities);
    }
}
