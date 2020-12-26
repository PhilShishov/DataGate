namespace DataGate.Services.Notifications.Contracts
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface INotificationService
    {
        Task Add(ClaimsPrincipal fromUser, string message, string link);

        Task AddAdmin(ClaimsPrincipal fromUser, string message, string link);

        IEnumerable<T> All<T>(ClaimsPrincipal user);

        Task<int> Count(ClaimsPrincipal user);

        Task StatusAsync(ClaimsPrincipal user, string notifId);

        string GetNotificationStatus(ClaimsPrincipal user, string notifId);
    }
}
