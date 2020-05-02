namespace DataGate.Web.Controllers.Funds
{
    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class FundDetailsController : BaseController
    {
        private readonly IFundSubEntitiesService service;

        public FundDetailsController(IFundSubEntitiesService fundSubFundsService)
        {
            this.service = fundSubFundsService;
        }

        [HttpGet]
        [Route("f/{EntityId}/{ChosenDate}")]
        public IActionResult ByIdAndDate(int entityId, string chosenDate)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                ChosenDate = chosenDate,
                EntityId = entityId,
            };

            SpecificViewModelSetup.PrepareModel(viewModel, this.service);

            this.ModelState.Clear();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult ByIdAndDate(SpecificEntityViewModel model)
        {
            if (model.Command == GlobalConstants.CommandUpdateTable)
            {
                this.TempData[GlobalConstants.ParentInfoMessageDisplay] = InfoMessages.SuccessfullyUpdatedTable;
                return this.RedirectToAction(GlobalConstants.ByIdAndDateActionName, new { model.EntityId, model.ChosenDate });
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableModeIsEmpty;
            this.ModelState.Clear();
            return this.View();
        }
    }
}
