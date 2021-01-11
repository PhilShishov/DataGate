// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Recent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Users;
    using DataGate.Web.Infrastructure.Extensions;

    using Microsoft.AspNetCore.Identity;

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

            var ok = this.repository.All().OrderByDescending(r => r.VisitedOn).ToList();

            return this.repository.All()
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.VisitedOn)
                .ToList()
                .Take(8);
        }

        public async Task Save(ClaimsPrincipal user, string link)
        {
            Validator.ArgumentNullException(user);

            var userId = this.userManager.GetUserId(user);
            var list = this.repository.All().ToList();
            var exists = list.FirstOrDefault(r => r.LinkUrl == link && r.UserId == userId);

            if (exists == null)
            {
                var item = new RecentlyViewed
                {
                    UserId = userId,
                    LinkUrl = link,
                    VisitedOn = DateTime.UtcNow,
                    DisplayLink = link.BuildDisplayLink(),
                };
                await this.repository.AddAsync(item);
            }
            else
            {
                exists.VisitedOn = DateTime.UtcNow;               
                this.repository.Update(exists);
            }

            await this.repository.SaveChangesAsync();
        }
    }
}
