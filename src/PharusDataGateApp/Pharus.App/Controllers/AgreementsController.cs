namespace Pharus.App.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using Pharus.App.Models.ViewModels.Agreements;
    using Pharus.Services.Funds.Contracts;
    using Pharus.Services.SubFunds.Contracts;
    using Pharus.Services.ShareClasses.Contracts;

    //public class AgreementsController : Controller
    //{
    //    private readonly IFundsService fundsService;
    //    private readonly ISubFundsService subFundsService;
    //    private readonly IShareClassesService shareClassesService;

    //    public AgreementsController(
    //        IFundsService fundsService,
    //        ISubFundsService subFundsService,
    //        IShareClassesService shareClassesService)
    //    {
    //        this.fundsService = fundsService;
    //        this.subFundsService = subFundsService;
    //        this.shareClassesService = shareClassesService;
    //    }

    //    public IActionResult All()
    //    {
    //        var model = new AgreementsViewModel
    //        {
    //            ChosenDate = DateTime.Today.ToString("yyyy-MM-dd"),
    //        };

    //        var chosenDate = DateTime.Parse(model.ChosenDate);

    //        //model.EntityDocuments = this.fundsService.GetAllAgreementDocumentsForAllFunds(chosenDate);

    //        return View(model);
    //    }
    //}
}