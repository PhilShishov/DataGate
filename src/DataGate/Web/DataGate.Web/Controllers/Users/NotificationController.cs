// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Services.Notifications.Contracts;
    using DataGate.Web.Hubs.Contracts;
    using DataGate.Web.Infrastructure.Attributes.Validation;
    using DataGate.Web.ViewModels.Notifications;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly IHubNotificationHelper notificationHelper;
        private readonly INotificationService notificationService;

        public NotificationController(
            IHubNotificationHelper notificationHelper,
            INotificationService notificationService)
        {
            this.notificationHelper = notificationHelper;
            this.notificationService = notificationService;
        }

        [Route("loadNotifications")]
        [AjaxOnly]
        public async Task<IActionResult> All()
        {
            var model = await this.notificationService.All<NotificationViewModel>(this.User);

            int count = await this.notificationService.Count(this.User);
            await this.notificationHelper.HubToAll(count);

            return this.PartialView("_UserNotificationPartial", model);
        }

        [HttpGet, AjaxOnly]
        [Route("api/notifications")]
        public async Task<ActionResult<NotificationResponseModel>> Status(string notifId)
        {
            await this.notificationService.StatusAsync(this.User, notifId);
            var status = this.notificationService.GetStatus(this.User, notifId);

            return new NotificationResponseModel { Status = status, NotifId = notifId };
        }

        [HttpGet, AjaxOnly]
        [Route("api/notifications/all")]
        public async Task<ActionResult<NotificationResponseModel>> StatusAll()
        {
            await this.notificationService.StatusAllAsync(this.User);

            return new NotificationResponseModel();
        }
    }
}
