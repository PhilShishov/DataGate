// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Layouts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Columns;
    using DataGate.Data.Models.Users;
    using DataGate.Web.Infrastructure.Extensions;

    using Microsoft.AspNetCore.Identity;

    public class LayoutService : ILayoutService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public LayoutService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public HashSet<T> ColumnsToDb<T>(IEnumerable<string> selectedColumns, string id)
            where T : IUserColumn, new()
        {
            var columnsToDb = new HashSet<T>();
            if (selectedColumns != null)
            {
                foreach (var column in selectedColumns)
                {
                    T userColumn = new T
                    {
                        Name = column,
                        UserId = id,
                    };

                    columnsToDb.Add(userColumn);
                }
            }

            return columnsToDb;
        }
        public IEnumerable<string> GetLayout<T>(IUserRepository<T> repository, string id)
            where T : IUserColumn
            => repository.All()
                .Where(uc => uc.UserId == id)
                .Select(uc => uc.Name)
                .ToList();

        public async Task<ApplicationUser> UserWithLayouts(ClaimsPrincipal user)
            => await UserExtensions.ByUserFundColumns(this.userManager, user);
    }
}