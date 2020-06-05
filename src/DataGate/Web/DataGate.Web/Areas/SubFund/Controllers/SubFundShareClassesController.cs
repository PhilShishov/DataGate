namespace DataGate.Web.Areas.SubFunds.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.SubFunds;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Dtos.Overviews;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.SubFundAreaName)]
    [Authorize]
    public class SubFundShareClassesController : BaseController
    {
        private readonly IEntityService service;
        private readonly ISubFundService subFundService;

        public SubFundShareClassesController(IEntityService service, ISubFundService subFundService)
        {
            this.service = service;
            this.subFundService = subFundService;
        }

        [HttpGet]
        [Route("loadShareClasses")]
        public async Task<IActionResult> LoadedShareClasses(int id, string date, string container)
        {
            var dto = new EntitySubEntitiesGetDto()
            {
                Id = id,
                Date = date,
                Container = container,
            };

            var viewModel = await SubEntitiesVMSetup
                .SetLoadedGet<EntitySubEntitiesViewModel>(this.service, this.subFundService, dto, QueryDictionary.SqlFunctionSubFundShareClasses);

            return this.PartialView("SubEntities/_ViewLoadedTable", viewModel);
        }

        [HttpGet]
        [Route("sf/{id}/sc")]
        public async Task<IActionResult> ShareClasses(int id, string date, string container)
        {
            var dto = new SubEntitiesGetDto()
            {
                Id = id,
                Date = date,
                Container = container,
            };

            var viewModel = await SubEntitiesVMSetup
                .SetGet<SubEntitiesViewModel>(this.service, this.subFundService, dto, QueryDictionary.SqlFunctionSubFundShareClasses);

            return this.View(viewModel);
        }

        [HttpPost]
        [Route("sf/{id}/sc")]
        public async Task<IActionResult> ShareClasses([Bind("Id, Command, Container, Date,Values,Headers,PreSelectedColumns,SelectedColumns,SelectTerm")]
                                                   SubEntitiesViewModel viewModel)
        {
            if (viewModel.Command == GlobalConstants.CommandUpdateTable)
            {
                return this.ShowInfo(InfoMessages.SuccessfulUpdate, GlobalConstants.SubFundShareClassesRouteName, new { viewModel.Id, viewModel.Date, viewModel.Container });
            }

            await SubEntitiesVMSetup.SetPost(viewModel, this.service, QueryDictionary.SqlFunctionSubFundShareClasses);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(viewModel);
            }

            this.TempData[GlobalConstants.ErrorKey] = ErrorMessages.TableIsEmpty;
            return this.View(viewModel);
        }
    }
}
