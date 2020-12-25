namespace DataGate.Services.Notifications.Contracts
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface INotificationService
    {
        //Task<bool> EditStatus(ApplicationUser currentUser, string newStatus, string id);

        //Task<bool> DeleteNotification(string username, string id);

        //Task<int> GetUserNotificationsCount(string userName);

        Task<int> Count(ClaimsPrincipal user);

        Task Add(ClaimsPrincipal fromUser, string message, string link);

        Task AddAdmin(ClaimsPrincipal fromUser, string message, string link);
    }
}
