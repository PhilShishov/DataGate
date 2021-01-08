// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Notifications.Contracts
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface INotificationService
    {
        Task Add(ClaimsPrincipal fromUser, string message, string link);

        Task AddAdmin(ClaimsPrincipal fromUser, string message, string link);

        Task<IEnumerable<T>> All<T>(ClaimsPrincipal user);

        Task<int> Count(ClaimsPrincipal user);

        string GetStatus(ClaimsPrincipal user, string notifId);

        Task StatusAsync(ClaimsPrincipal user, string notifId);

        Task StatusAllAsync(ClaimsPrincipal user);
    }
}
