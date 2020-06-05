namespace DataGate.Web.Areas.ShareClasses.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.ShareClassAreaName)]
    [Authorize]
    public class ShareClassDetailsController : BaseController
    {
        private readonly IEntityDetailsService service;
        private readonly IShareClassService shareClassService;

        public ShareClassDetailsController(
            IEntityDetailsService service,
            IShareClassService shareClassService)
        {
            this.service = service;
            this.shareClassService = shareClassService;
        }

        [ActionName("Details")]
        [Route("sc/{id}/{date}")]
        public async Task<IActionResult> ByIdAndDate(int id, string date)
        {
            var dto = new QueriesToPassDto()
            {
                SqlFunctionById = FunctionDictionary.SqlFunctionByIdShareClass,
                SqlFunctionDistinctDocuments = FunctionDictionary.SqlFunctionDistinctDocumentsShareClass,
                SqlFunctionDistinctAgreements = FunctionDictionary.SqlFunctionDistinctAgreementsShareClass,
                SqlFunctionContainer = FunctionDictionary.SqlFunctionContainerSubFund,
            };

            var viewModel = await SpecificVMSetup.SetGet<SpecificEntityViewModel>(id, date, this.service, this.shareClassService, dto);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Update([Bind("Command,Date,Id")] SpecificEntityViewModel viewModel)
        {
            if (viewModel.Command == GlobalConstants.CommandUpdateTable)
            {
                return this.ShowInfo(InfoMessages.SuccessfulUpdate, GlobalConstants.ShareClassDetailsRouteName, new { viewModel.Id, viewModel.Date });
            }

            return this.ShowError(ErrorMessages.UnsuccessfulUpdate, GlobalConstants.ShareClassDetailsRouteName, new { viewModel.Id, viewModel.Date });
        }
    }
}
