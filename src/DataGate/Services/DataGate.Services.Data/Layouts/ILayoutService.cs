// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Layouts
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Columns;
    using DataGate.Data.Models.Users;

    public interface ILayoutService
    {
        Task<ApplicationUser> UserWithLayouts(ClaimsPrincipal user);

        HashSet<T> ColumnsToDb<T>(IEnumerable<string> selectedColumns, string id)
            where T : IUserColumn, new();

        IEnumerable<string> GetLayout<T>(IUserRepository<T> repository, string id)
            where T : IUserColumn;
    }
}
