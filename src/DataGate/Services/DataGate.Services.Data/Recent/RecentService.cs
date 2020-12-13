namespace DataGate.Services.Data.Recent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Http;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Users;

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
                .ToList();
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
            var exists = list.FirstOrDefault(i => i.Link == link && i.UserId == userId);

            if (exists == null)
            {
                var item = new RecentlyViewed
                {
                    UserId = userId,
                    Link = link,
                    DisplayLink = link,
                };
                await this.repository.AddAsync(item);
            }

            while (list.Count() > GlobalConstants.MaxRecentItemsCount)
            {
                this.repository.Delete(list.LastOrDefault());
            }

            await this.repository.SaveChangesAsync();
        }
    }
}
