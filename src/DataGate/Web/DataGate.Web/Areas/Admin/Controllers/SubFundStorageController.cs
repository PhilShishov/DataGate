// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Areas.Admin.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories.AppContext;
    using DataGate.Services.Data.Recent;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Web.Controllers;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.InputModels.SubFunds;
    using DataGate.Web.Resources;

    [Area(EndpointsConstants.AdminAreaName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.LegalRoleName)]
    public class SubFundStorageController : BaseController
    {
        private readonly IRecentService recentService;
        private readonly ISubFundStorageService service;
        private readonly ISubFundRepository repository;
        private readonly SharedLocalizationService sharedLocalizer;

        public SubFundStorageController(
                        IRecentService recentService,
                        ISubFundStorageService service,
                        ISubFundRepository repository,
                        SharedLocalizationService sharedLocalizer)
        {
            this.recentService = recentService;
            this.service = service;
            this.repository = repository;
            this.sharedLocalizer = sharedLocalizer;
        }

        [Route("sf/new")]
        public async Task<IActionResult> Create()
        {
            await this.recentService.Save(this.User, this.Request.Path);

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
            var date = DateTimeExtensions.ToWebFormat(model.InitialDate.AddDays(1));

            return this.ShowInfo(
                this.sharedLocalizer.GetHtmlString(InfoMessages.SuccessfulCreate),
                EndpointsConstants.RouteDetails + EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                new { area = EndpointsConstants.DisplaySub + EndpointsConstants.FundArea, id = subFundId, date = date });
        }

        [Route("sf/edit/{id}/{date}")]
        public async Task<IActionResult> Edit(int id, string date)
        {
            await this.recentService.Save(this.User, this.Request.Path);

            var model = this.service.ByIdAndDate<EditSubFundInputModel>(id, date);

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
            var date = DateTimeExtensions.ToWebFormat(model.InitialDate.AddDays(1));

            return this.ShowInfo(
                this.sharedLocalizer.GetHtmlString(InfoMessages.SuccessfulEdit),
                EndpointsConstants.RouteDetails + EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                new { area = EndpointsConstants.DisplaySub + EndpointsConstants.FundArea, id = subFundId, date = date });
        }

        private void SetViewDataValues()
        {
            this.ViewData["Status"] = this.repository.AllTbDomSFStatus();
            this.ViewData["CesrClass"] = this.repository.AllTbDomCesrClass();
            this.ViewData["GeographicalFocus"] = this.repository.AllTbDomGeographicalFocus();
            this.ViewData["GlobalExposure"] = this.repository.AllTbDomGlobalExposure();
            this.ViewData["CurrencyCode"] = this.repository.AllTbDomCurrencyCode();
            this.ViewData["NavFrequency"] = this.repository.AllTbDomFrequency();
            this.ViewData["ValuationDate"] = this.repository.AllTbDomValuationDate();
            this.ViewData["CalculationDate"] = this.repository.AllTbDomCalculationDate();
            this.ViewData["DerivMarket"] = this.repository.AllTbDomDerivMarket();
            this.ViewData["DerivPurpose"] = this.repository.AllTbDomDerivPurpose();
            this.ViewData["PrincipalAssetClass"] = this.repository.AllTbDomPrincipalAssetClass();
            this.ViewData["TypeOfMarket"] = this.repository.AllTbDomTypeOfMarket();
            this.ViewData["PrincipalInvestmentStrategy"] = this.repository.AllTbDomPrincipalInvestmentStrategy();
            this.ViewData["SfCatMorningStar"] = this.repository.AllTbDomSfCatMorningStar();
            this.ViewData["SfCatSix"] = this.repository.AllTbDomSfCatSix();
            this.ViewData["SfCatBloomberg"] = this.repository.AllTbDomSfCatBloomberg();

            this.ViewData["FundContainer"] = this.repository.GetAllContainers();
        }
    }
}
