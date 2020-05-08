namespace DataGate.Web.Controllers.Funds
{
    using System;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Services.DateTime;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.FundsAreaName)]
    [Authorize]
    public class FundSubEntitiesController : BaseController
    {
        private readonly IFundSubEntitiesService service;

        public FundSubEntitiesController(IFundSubEntitiesService fundSubFundsService)
        {
            this.service = fundSubFundsService;
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdateSubEntities(SpecificEntityViewModel model)
        {
            //model = GetOverview.SpecificEntity<SpecificEntityViewModel>(model.Id, model.Date, this.service);

            if (model.Command == "Reset")
            {
                model.SelectTerm = GlobalConstants.DefaultAutocompleteSelectTerm;
                return this.View(GlobalConstants.DetailsActionName, model);
            }

            var date = DateTimeParser.WebFormat(model.Date);
            bool isInSelectionMode = model.SelectedColumns != null ? true : false;

            if (isInSelectionMode)
            {
                this.CallEntitySubEntitiesWithSelectedColumns(model, date);
            }
            else if (!isInSelectionMode)
            {
                model.Values = this.service.GetSubEntities(model.Id, date).ToList();
            }

            if (model.SelectTerm != null)
            {
                model.Values = CreateTableView.AddTableToView(model.Values, model.SelectTerm.ToLower());
            }

            if (model.Entity != null && model.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(model);
            }

            this.TempData[GlobalConstants.ErrorKey] = ErrorMessages.TableIsEmpty;
            return this.RedirectToAction("");
        }

        private void CallEntitySubEntitiesWithSelectedColumns(SpecificEntityViewModel model, DateTime date)
        {
            model.Values = this.service
                .GetSubEntitiesSelected(
                                    model.Id,
                                    model.PreSelectedColumns,
                                    model.SelectedColumns,
                                    date)
                .ToList();

            model.Headers = this.service.GetHeaders(model.Id, date).ToList();
        }

        private void SetUploadFileLists()
        {
            //this.ViewData["DocumentFileTypes"] = this.selectService.GetDocumentsFileTypes();
            //this.ViewData["AgreementsFileTypes"] = this.selectService.GetAgreementsFileTypes();
            //this.ViewData["AgreementsStatus"] = this.selectService.GetAgreementStatus();
            //this.ViewData["Companies"] = this.selectService.GetCompanies();
        }
    }
}
