namespace DataGate.Web.Controllers
{
    using System.Collections.Generic;

    using DataGate.Services.Notifications.Contracts;
    using DataGate.Web.ViewModels.Notifications;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    //[ApiController]
    //[Route("api/controller")]
    public class NotificationController : Controller
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        [Route("loadNotifications")]
        public IActionResult All()
        {
            IEnumerable<NotificationViewModel> model = this.notificationService.All();

            return this.PartialView("_UserNotificationPartial", model);
        }

      
        //[HttpPost]
        //public async Task<ActionResult<VoteResponseModel>> Change(VoteInputModel input)
        //{
        //    var userId = this.userManager.GetUserId(this.User);
        //    await this.votesService.VoteAsync(input.PostId, userId, input.IsUpVote);
        //    var votes = this.votesService.GetVotes(input.PostId);
        //    return new VoteResponseModel { VotesCount = votes };
        //}

        //[HttpPost]
        //public async Task<ActionResult<VoteResponseModel>> ChangeAll(VoteInputModel input)
        //{
        //    var userId = this.userManager.GetUserId(this.User);
        //    await this.votesService.VoteAsync(input.PostId, userId, input.IsUpVote);
        //    var votes = this.votesService.GetVotes(input.PostId);
        //    return new VoteResponseModel { VotesCount = votes };
        //}
    }
}
