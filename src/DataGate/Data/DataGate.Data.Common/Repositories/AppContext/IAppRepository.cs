// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Common.Repositories.AppContext
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAppRepository<TEntity> : IRepository<TEntity>
    {
        IQueryable<TEntity> AllAsNoTracking();

        Task<TEntity> FindAsync(object id);

        void Update(TEntity entity);
    }
}
