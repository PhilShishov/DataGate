// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Infrastructure.Extensions
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using DataGate.Data.Models.Users;

    public static class UserExtensions
    {
        public static async Task<ApplicationUser> ByUserFundColumns(this UserManager<ApplicationUser> input, ClaimsPrincipal user)
        => await input.Users.Include(u => u.UserFundColumns)
                .SingleOrDefaultAsync(u => u.NormalizedUserName == user.Identity.Name.ToUpper());
    }
}
