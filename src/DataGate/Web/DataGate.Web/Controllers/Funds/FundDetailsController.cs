//namespace DataGate.Web.Controllers.Funds
//{
//    using DataGate.Common;
//    using DataGate.Services.Data.Funds.Contracts;
//    using DataGate.Services.Data.ViewSetups;
//    using DataGate.Web.ViewModels.Entities;

//    using Microsoft.AspNetCore.Authorization;
//    using Microsoft.AspNetCore.Mvc;

//    [Authorize]
//    public class FundDetailsController : BaseController
//    {
//        private readonly IFundSubEntitiesService service;

//        public FundDetailsController(IFundSubEntitiesService fundSubFundsService)
//        {
//            this.service = fundSubFundsService;
//        }

//        [HttpGet]
//        [Route("f/{id}/{date}")]
//        public IActionResult ByIdAndDate(int id, string date)
//        {
//            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
//            {
//                Date = date,
//                Id = id,
//            };

//            SpecificViewModelSetup.PrepareModel(viewModel, this.service);

//            this.ModelState.Clear();
//            return this.View(viewModel);
//        }

//        [HttpPost]
//        public IActionResult ByIdAndDate(SpecificEntityViewModel model)
//        {
//            if (model.Command == GlobalConstants.CommandUpdateTable)
//            {
//                this.TempData[GlobalConstants.ParentInfoMessageDisplay] = InfoMessages.SuccessfullyUpdatedTable;
//                return this.RedirectToAction(GlobalConstants.ByIdAndDateActionName, new { model.Id, model.Date });
//            }

//            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableModeIsEmpty;
//            this.ModelState.Clear();
//            return this.View();
//        }
//    }
//}
