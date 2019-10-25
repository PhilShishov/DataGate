namespace Pharus.App.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Services.Contracts;

    [Authorize]
    public class SubFundsController : Controller
    {
        private readonly ISubFundsService subFundsService;

        public SubFundsController(ISubFundsService subFundsService)
        {
            this.subFundsService = subFundsService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var activeSubFundsView = this.subFundsService.GetAllActiveSubFunds();

            return View(activeSubFundsView);
        }

        [HttpPost]
        public IActionResult All(DateTime? chosenDate)
        {
            List<string[]> activeSubFundsView;

            if (chosenDate != null)
            {
                activeSubFundsView = this.subFundsService.GetAllActiveSubFunds(chosenDate);
            }
            else
            {
                activeSubFundsView = this.subFundsService.GetAllActiveSubFunds();
            }

            return View(activeSubFundsView);
        }
    }
}