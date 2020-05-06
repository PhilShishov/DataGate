namespace DataGate.Web.Areas.Funds.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.FundsAreaName)]
    [Authorize]
    public class FundDetailsController : Controller
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

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Update(SpecificEntityViewModel model)
        {
            if (model.Command == GlobalConstants.CommandUpdateTable)
            {
                this.TempData[GlobalConstants.ParentInfoMessageDisplay] = InfoMessages.SuccessfullyUpdatedTable;
                return this.RedirectToAction(GlobalConstants.ByIdAndDateActionName, new { model.Id, model.Date });
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableModeIsEmpty;
            this.ModelState.Clear();
            return this.View();
        }
    }
}
