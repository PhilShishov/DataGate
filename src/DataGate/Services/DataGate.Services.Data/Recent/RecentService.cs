// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Recent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Http;

    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Users;
    using DataGate.Web.Infrastructure.Extensions;

    public class RecentService : IRecentService
    {
        private readonly IUserRepository<RecentlyViewed> repository;
        private readonly UserManager<ApplicationUser> userManager;

        public RecentService(
            IUserRepository<RecentlyViewed> repository,
            UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        public IEnumerable<RecentlyViewed> ByUserId(ClaimsPrincipal user)
        {
            var userId = this.userManager.GetUserId(user);

            return this.repository.All()
                .Where(r => r.UserId == userId)
                .ToList()
                .TakeLast(10);
        }

        public async Task Save(ClaimsPrincipal user, PathString path, QueryString? queryString = null)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userId = this.userManager.GetUserId(user);
            var list = this.repository.All().ToList();
            var link = path + queryString;
            var exists = list.FirstOrDefault(i => i.LinkUrl == link && i.UserId == userId);

            if (exists == null)
            {
                var item = new RecentlyViewed
                {
                    UserId = userId,
                    LinkUrl = link,
                    DisplayLink = StringExtensions.BuildDisplayLink(link),
                };
                await this.repository.AddAsync(item);
            }

            await this.repository.SaveChangesAsync();
        }
    }
}
