// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Recent
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using DataGate.Data.Models.Users;

    public interface IRecentService
    {
        Task Save(ClaimsPrincipal user, PathString path, QueryString? queryString = null);

        IEnumerable<RecentlyViewed> ByUserId(ClaimsPrincipal user);
    }
}
