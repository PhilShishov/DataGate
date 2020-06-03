namespace DataGate.Web.Areas.Funds.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Funds;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.FundAreaName)]
    [Authorize]
    public class FundSubFundsController : BaseController
    {
        private readonly IEntityService service;
        private readonly IFundService fundService;

        public FundSubFundsController(IEntityService service, IFundService fundService)
        {
            this.service = service;
            this.fundService = fundService;
        }

        [HttpGet]
        [Route("loadSubFunds")]
        public async Task<IActionResult> LoadedSubFunds(int id, string date, string container)
        {
            var dto = new EntitySubEntitiesGetDto()
            {
                Id = id,
                Date = date,
                Container = container,
            };

            var viewModel = await SubEntitiesVMSetup
                .SetLoadedGet<EntitySubEntitiesViewModel>(this.service, this.fundService, dto, QueryDictionary.SqlFunctionFundSubFunds);

            return this.PartialView("SubEntities/_ViewLoadedTable", viewModel);
        }

        [HttpGet]
        [Route("f/{id}/sf")]
        public async Task<IActionResult> SubFunds(int id, string date, string container)
        {
            var dto = new SubEntitiesGetDto()
            {
                Id = id,
                Date = date,
                Container = container,
            };

            var viewModel = await SubEntitiesVMSetup
                .SetGet<SubEntitiesViewModel>(this.service, this.fundService, dto, QueryDictionary.SqlFunctionFundSubFunds);

            return this.View(viewModel);
        }

        [HttpPost]
        [Route("f/{id}/sf")]
        public async Task<IActionResult> SubFunds([Bind("Id, Command, Container, Date,Values,Headers," +
            "                                            PreSelectedColumns,SelectedColumns,SelectTerm")]
                                                   SubEntitiesViewModel viewModel)
        {
            if (viewModel.Command == GlobalConstants.CommandUpdateTable)
            {
                return this.ShowInfo(InfoMessages.SuccessfulUpdate, GlobalConstants.FundSubFundsRouteName, new { viewModel.Id, viewModel.Date, viewModel.Container });
            }

            await SubEntitiesVMSetup.SetPost(viewModel, this.service, QueryDictionary.SqlFunctionFundSubFunds);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(viewModel);
            }

            this.TempData[GlobalConstants.ErrorKey] = ErrorMessages.UnsuccessfulUpdate;
            return this.View(viewModel);
        }
    }
}
