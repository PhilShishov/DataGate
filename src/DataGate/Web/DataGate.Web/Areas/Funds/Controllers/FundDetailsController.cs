namespace DataGate.Web.Areas.Funds.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Services.DateTime;
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

        [ActionName("Details")]
        [Route("f/{id}/{date}")]
        public IActionResult ByIdAndDate(int id, string date)
        {
            var model = SpecificViewModelSetup.SetGet<SpecificEntityViewModel>(id, date, this.service);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult UpdateEntity(SpecificEntityViewModel model)
        {
            if (model.Command == GlobalConstants.CommandUpdateTable)
            {
                return this.ShowInfo(InfoMessages.SuccessfulUpdate, GlobalConstants.FundDetailsRouteName, new { model.Id, model.Date });
            }

            return this.ShowError(ErrorMessages.UnsuccessfulUpdate, GlobalConstants.FundDetailsRouteName, new { model.Id, model.Date });
        }

        [HttpPost]
        [ActionName("Details")]
        public IActionResult UpdateSubEntities(SpecificEntityViewModel model)
        {
            var date = DateTimeParser.WebFormat(model.Date);
            model.Entity = this.service.GetByIdAndDate(model.Id, date);
            model.DistinctDocuments = this.service.GetDistinctDocuments<DistinctDocViewModel>(model.Id, date);
            model.DistinctAgreements = this.service.GetDistinctAgreements<DistinctDocViewModel>(model.Id, date);

            if (model.Command == GlobalConstants.CommandResetTable)
            {
                model.SelectTerm = GlobalConstants.DefaultAutocompleteSelectTerm;
                return this.View(model);
            }

            SpecificViewModelSetup.SetPost(model, this.service);

            if (model.Entity != null && model.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(model);
            }

            return this.ShowError(ErrorMessages.UnsuccessfulUpdate, GlobalConstants.FundDetailsRouteName, new { model.Id, model.Date });
        }
    }
}
