namespace Pharus.App.Controllers
{

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
        public IActionResult All(string chosenDate)
        {
            var activeFundsView = this.fundsService.GetAllActiveFunds(chosenDate);
          
            return View(activeFundsView);
        }

        #region Helpers        

        #endregion
    }
}