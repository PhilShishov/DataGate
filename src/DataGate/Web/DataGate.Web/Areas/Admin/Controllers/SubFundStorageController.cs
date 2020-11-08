namespace DataGate.Web.Areas.Admin.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Web.Controllers;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.InputModels.SubFunds;
    using DataGate.Web.Resources;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(EndpointsConstants.AdminAreaName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.LegalRoleName)]
    public class SubFundStorageController : BaseController
    {
        private readonly ISubFundStorageService service;
        private readonly ISubFundRepository repository;
        private readonly SharedLocalizationService sharedLocalizer;

        public SubFundStorageController(
                        ISubFundStorageService service,
                        ISubFundRepository repository,
                        SharedLocalizationService sharedLocalizer)
        {
            this.service = service;
            this.repository = repository;
            this.sharedLocalizer = sharedLocalizer;
        }

        [Route("sf/new")]
        public IActionResult Create()
        {
            this.SetViewDataValues();
            return this.View(new CreateSubFundInputModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("sf/new")]
        public async Task<IActionResult> Create(
                    [Bind("InitialDate", "EndDate", "SubFundName", "CSSFCode", "Status",
                          "FACode", "TACode", "LEICode", "DBCode", "FundContainer",
                          "FirstNavDate", "LastNavDate", "CSSFAuthDate", "ExpiryDate",
                          "CesrClass", "GeographicalFocus", "GlobalExposure", "CurrencyCode",
                          "NavFrequency", "ValuationDate", "CalculationDate", "AreDerivatives",
                          "DerivMarket", "DerivPurpose", "PrincipalAssetClass", "TypeOfMarket",
                          "PrincipalInvestmentStrategy", "ClearingCode", "SfCatMorningStar", "SfCatSix",
                          "SfCatBloomberg", "RecaptchaValue")] CreateSubFundInputModel model)
        {
            bool doesExist = await this.service.DoesExist(model.SubFundName);

            if (!this.ModelState.IsValid || doesExist)
            {
                if (doesExist)
                {
                    this.ShowError(this.sharedLocalizer.GetHtmlString(ErrorMessages.ExistingEntityName));
                }

                this.SetViewDataValues();
                return this.View(model);
            }

            var subFundId = await this.service.Create(model);
            var date = DateTimeParser.ToWebFormat(model.InitialDate.AddDays(1));

            return this.ShowInfo(
                this.sharedLocalizer.GetHtmlString(InfoMessages.SuccessfulCreate),
                EndpointsConstants.RouteDetails + EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                new { area = EndpointsConstants.DisplaySub + EndpointsConstants.FundArea, id = subFundId, date = date });
        }

        [Route("sf/edit/{id}/{date}")]
        public IActionResult Edit(int id, string date)
        {
            var model = this.service.GetByIdAndDate<EditSubFundInputModel>(id, date);

            if (model.Derivatives == "Yes")
            {
                model.AreDerivatives = true;
            }

            this.SetViewDataValues();
            return this.View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("sf/edit/{id}/{date}")]
        public async Task<IActionResult> Edit(
                    [Bind("Id", "InitialDate", "SubFundName", "CSSFCode", "Status",
                          "FACode", "TACode", "LEICode", "DBCode",
                          "FirstNavDate", "LastNavDate", "CSSFAuthDate", "ExpiryDate",
                          "CesrClass", "GeographicalFocus", "GlobalExposure", "CurrencyCode",
                          "NavFrequency", "ValuationDate", "CalculationDate", "Derivatives",
                          "DerivMarket", "DerivPurpose", "PrincipalAssetClass", "TypeOfMarket",
                          "PrincipalInvestmentStrategy", "ClearingCode", "SfCatMorningStar", "SfCatSix",
                          "SfCatBloomberg", "CommentTitle", "CommentArea", "RecaptchaValue")] EditSubFundInputModel model)
        {
            bool doesExistAtDate = await this.service.DoesExistAtDate(model.SubFundName, model.InitialDate);

            if (!this.ModelState.IsValid || doesExistAtDate)
            {
                if (doesExistAtDate)
                {
                    this.ShowError(this.sharedLocalizer.GetHtmlString(ErrorMessages.ExistingEntityAtDate));
                }

                this.SetViewDataValues();
                return this.View(model);
            }

            var subFundId = await this.service.Edit(model);
            var date = DateTimeParser.ToWebFormat(model.InitialDate.AddDays(1));

            return this.ShowInfo(
                this.sharedLocalizer.GetHtmlString(InfoMessages.SuccessfulEdit),
                EndpointsConstants.RouteDetails + EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                new { area = EndpointsConstants.DisplaySub + EndpointsConstants.FundArea, id = subFundId, date = date });
        }

        private void SetViewDataValues()
        {
            this.ViewData["Status"] = this.repository.GetAllTbDomSFStatus();
            this.ViewData["CesrClass"] = this.repository.GetAllTbDomCesrClass();
            this.ViewData["GeographicalFocus"] = this.repository.GetAllTbDomGeographicalFocus();
            this.ViewData["GlobalExposure"] = this.repository.GetAllTbDomGlobalExposure();
            this.ViewData["CurrencyCode"] = this.repository.GetAllTbDomCurrencyCode();
            this.ViewData["NavFrequency"] = this.repository.GetAllTbDomFrequency();
            this.ViewData["ValuationDate"] = this.repository.GetAllTbDomValuationDate();
            this.ViewData["CalculationDate"] = this.repository.GetAllTbDomCalculationDate();
            this.ViewData["DerivMarket"] = this.repository.GetAllTbDomDerivMarket();
            this.ViewData["DerivPurpose"] = this.repository.GetAllTbDomDerivPurpose();
            this.ViewData["PrincipalAssetClass"] = this.repository.GetAllTbDomPrincipalAssetClass();
            this.ViewData["TypeOfMarket"] = this.repository.GetAllTbDomTypeOfMarket();
            this.ViewData["PrincipalInvestmentStrategy"] = this.repository.GetAllTbDomPrincipalInvestmentStrategy();
            this.ViewData["SfCatMorningStar"] = this.repository.GetAllTbDomSfCatMorningStar();
            this.ViewData["SfCatSix"] = this.repository.GetAllTbDomSfCatSix();
            this.ViewData["SfCatBloomberg"] = this.repository.GetAllTbDomSfCatBloomberg();

            this.ViewData["FundContainer"] = this.repository.GetAllContainers();
        }
    }
}
