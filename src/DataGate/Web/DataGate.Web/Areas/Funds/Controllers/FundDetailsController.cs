namespace DataGate.Web.Areas.Funds.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.FundsAreaName)]
    [Authorize]
    public class FundDetailsController : BaseController
    {
        private readonly IFundSubEntitiesService service;

        public FundDetailsController(IFundSubEntitiesService fundSubFundsService)
        {
            this.service = fundSubFundsService;
        }

        [HttpGet]
        [Route("f/{id}/{date}")]
        public IActionResult ByIdAndDate(int id, string date)
        {
            var model = GetOverview.SpecificEntity<SpecificEntityViewModel>(id, date, this.service);

            this.PrepareModel();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Update(SpecificEntityViewModel model)
        {
            if (model.Command == GlobalConstants.CommandUpdateTable)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.RedirectToAction(GlobalConstants.ByIdAndDateActionName, new { model.Id, model.Date });
            }

            this.TempData[GlobalConstants.ErrorKey] = ErrorMessages.UnsuccessfulUpdate;
            return this.RedirectToAction(GlobalConstants.ByIdAndDateActionName, new { model.Id, model.Date });
        }

        private void PrepareModel()
        {
            //this.ViewData["DocumentFileTypes"] = this.fundsSelectListService.GetAllProspectusFileTypes();
            //this.ViewData["AgreementsFileTypes"] = this.fundsSelectListService.GetAllAgreementsFileTypes();
            //this.ViewData["AgreementsStatus"] = this.agreementsSelectListService.GetAllTbDomAgreementStatus();
            //this.ViewData["Companies"] = this.agreementsSelectListService.GetAllTbCompanies();
        }
    }
}
