namespace DataGate.Services.Data.Recent
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IRecentService
    {
        Task Save(ClaimsPrincipal user, PathString path);

        IEnumerable<string> ByUserId(ClaimsPrincipal user);
    }
}
