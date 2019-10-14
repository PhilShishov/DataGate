
namespace Pharus.App.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Services.Contracts;

    [Authorize]
    public class ShareClassesController : Controller
    {
        private readonly IShareClassesService shareClassesService;

        public ShareClassesController(IShareClassesService shareClassesService)
        {
            this.shareClassesService = shareClassesService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var activeSubFundsView = this.shareClassesService.GetAllActiveShareClasses();

            return View(activeSubFundsView);
        }

        [HttpPost]
        public IActionResult All(DateTime? chosenDate)
        {
            List<string[]> activeSubFundsView;

            if (chosenDate != null)
            {
                activeSubFundsView = this.shareClassesService.GetAllActiveShareClasses(chosenDate);
            }
            else
            {
                activeSubFundsView = this.shareClassesService.GetAllActiveShareClasses();
            }

            return View(activeSubFundsView);
        }

        #region Helpers        

        #endregion
    }
}