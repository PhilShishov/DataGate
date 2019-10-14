namespace Pharus.App.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Services.Contracts;

    [Authorize]
    public class FundsController : Controller
    {
        private readonly IFundsService fundsService;

        public FundsController(IFundsService fundsService)
        {
            this.fundsService = fundsService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var activeFundsView = this.fundsService.GetAllActiveFunds();

            return View(activeFundsView);
        }

        [HttpPost]
        public IActionResult All(DateTime? chosenDate)
        {
            List<string[]> activeFundsView;

            if (chosenDate != null)
            {
                activeFundsView = this.fundsService.GetAllActiveFunds(chosenDate);
            }
            else
            {
                activeFundsView = this.fundsService.GetAllActiveFunds();
            }

            return View(activeFundsView);
        }

        #region Helpers        

        #endregion
    }
}