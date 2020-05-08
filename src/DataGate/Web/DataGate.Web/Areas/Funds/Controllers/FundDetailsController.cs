namespace DataGate.Web.Areas.Funds.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.FundsAreaName)]
    //[Authorize]
    public class FundDetailsController : BaseController
    {
        private readonly IFundSubEntitiesService service;
        private readonly IDocumentsSelectService selectService;

        public FundDetailsController(
            IFundSubEntitiesService fundSubFundsService,
            IDocumentsSelectService documentsSelectService)
        {
            this.service = fundSubFundsService;
            this.selectService = documentsSelectService;
        }

        [HttpGet]
        [ActionName("Details")]
        [Route("f/{id}/{date}")]
        public IActionResult ByIdAndDate(int id, string date)
        {
            var model = GetOverview.SpecificEntity<SpecificEntityViewModel>(id, date, this.service);

            this.SetUploadFileLists();

            return this.View(model);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdateEntity(SpecificEntityViewModel model)
        {
            if (model.Command == GlobalConstants.CommandUpdateTable)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.RedirectToAction(GlobalConstants.DetailsActionName, new { model.Id, model.Date });
            }

            this.TempData[GlobalConstants.ErrorKey] = ErrorMessages.UnsuccessfulUpdate;
            return this.RedirectToAction(GlobalConstants.DetailsActionName, new { model.Id, model.Date });
        }

        private void SetUploadFileLists()
        {
            this.ViewData["DocumentFileTypes"] = this.selectService.GetDocumentsFileTypes();
            this.ViewData["AgreementsFileTypes"] = this.selectService.GetAgreementsFileTypes();
            this.ViewData["AgreementsStatus"] = this.selectService.GetAgreementStatus();
            this.ViewData["Companies"] = this.selectService.GetCompanies();
        }
    }
}
