namespace DataGate.Web.Controllers.Funds
{
    using System;
    using System.Globalization;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class FundDetailsController : BaseController
    {
        private readonly IFundSubFundsService service;

        public FundDetailsController(IFundSubFundsService fundSubFundsService)
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

            this.SetModelValuesForSpecificView(viewModel);

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

        private void SetModelValuesForSpecificView(SpecificEntityViewModel model)
        {
            //ThrowEntityNotFoundExceptionIfLessonDoesNotExist(lessonId);
            //private void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
            //{
            //    if (!this.Exists(id))
            //    {
            //        throw new EntityNotFoundException(nameof(TbHistoryFund));
            //    }
            //}

            //private bool Exists(int id) => this.repository.All().Any(x => x.FId == id);
            //private bool Exists(int id) => this.repository.All().Any(x => x.SFId == id);
            //private bool Exists(int id) => this.repository.All().Any(x => x.SCId == id);

            var date = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
            int entityId = model.EntityId;

            model.Entity = this.service.GetFundWithDateById(date, entityId).ToList();
            model.EntityDistinctDocuments = this.service.
                GetDistinctFundDocuments(date, entityId).ToList();
            model.EntityDistinctAgreements = this.service.GetDistinctFundAgreements(date, entityId).ToList();

            model.EntitySubEntities = this.service.GetFund_SubFunds(date, entityId).ToList();
            model.EntitiesHeadersForColumnSelection = this.service
                                                                .GetFund_SubFunds(date, entityId)
                                                                .Take(1)
                                                                .ToList();
            model.EntityTimeline = this.service.GetFundTimeline(entityId).ToList();
            model.EntityDocuments = this.service.GetAllFundDocuments(entityId).ToList();
            model.EntityAgreements = this.service.GetAllFundAgreements(date, entityId).ToList();

            model.StartConnection = DateTime.ParseExact(model.Entity.ToList()[1][0], GlobalConstants.SqlDateTimeFormatParsing, CultureInfo.InvariantCulture);

            if (model.EndConnection != null)
            {
                model.EndConnection = DateTime.ParseExact(model.Entity.ToList()[1][1], GlobalConstants.SqlDateTimeFormatParsing, CultureInfo.InvariantCulture);
            }

            //this.ViewData["ProspectusFileTypes"] = this.fundsSelectListService.GetAllProspectusFileTypes();
            //this.ViewData["AgreementsFileTypes"] = this.fundsSelectListService.GetAllAgreementsFileTypes();
            //this.ViewData["AgreementsStatus"] = this.agreementsSelectListService.GetAllTbDomAgreementStatus();
            //this.ViewData["Companies"] = this.agreementsSelectListService.GetAllTbCompanies();
        }
    }
}
