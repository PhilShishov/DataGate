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

        //public static async Task<ApplicationUser> ByUserSubFundColumns(this UserManager<ApplicationUser> input, ClaimsPrincipal user)
        //=> await input.Users.Include(u => u.UserSubFundColumns)
        //        .SingleOrDefaultAsync(u => u.NormalizedUserName == user.Identity.Name.ToUpper());

        //public static async Task<ApplicationUser> ByUserFundSubFundColumns(this UserManager<ApplicationUser> input, ClaimsPrincipal user)
        //=> await input.Users.Include(u => u.UserFundSubFundsColumns)
        //        .SingleOrDefaultAsync(u => u.NormalizedUserName == user.Identity.Name.ToUpper());

        //public static async Task<ApplicationUser> ByUserShareClassColumns(this UserManager<ApplicationUser> input, ClaimsPrincipal user)
        //=> await input.Users.Include(u => u.UserShareClassColumns)
        //        .SingleOrDefaultAsync(u => u.NormalizedUserName == user.Identity.Name.ToUpper());

        //public static async Task<ApplicationUser> ByUserSubFundShareClassColumns(this UserManager<ApplicationUser> input, ClaimsPrincipal user)
        //=> await input.Users.Include(u => u.UserSubFundShareClassesColumns)
        //        .SingleOrDefaultAsync(u => u.NormalizedUserName == user.Identity.Name.ToUpper());
    }
}
