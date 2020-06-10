namespace DataGate.Web.Areas.Admin.Controllers
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Web.Controllers;
    using DataGate.Web.InputModels.ShareClasses;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ShareClassStorageController : BaseController
    {
        private readonly IShareClassStorageService service;
        private readonly IShareClassRepository repository;

        public ShareClassStorageController(
                        IShareClassStorageService service,
                        IShareClassRepository repository)
        {
            this.service = service;
            this.repository = repository;
        }

        [Route("sc/edit/{id}/{date}")]
        public IActionResult Edit(int id, string date)
        {
            var model = this.service.GetByIdAndDate<EditShareClassInputModel>(id, date);

            if (model.Hedged == "Yes")
            {
                model.IsHedged = true;
            }

            if (model.Listed == "Yes")
            {
                model.IsListed = true;
            }

            this.SetViewDataValues();
            return this.View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("sc/edit/{id}/{date}")]
        public async Task<IActionResult> Edit(
                    [Bind("Id", "InitialDate", "SubFundName", "CSSFCode", "Status",
                          "FACode", "TACode", "LEICode", "DBCode",
                          "FirstNavDate", "LastNavDate", "CSSFAuthDate", "ExpiryDate",
                          "CesrClass", "GeographicalFocus", "GlobalExposure", "CurrencyCode",
                          "NavFrequency", "ValuationDate", "CalculationDate", "Derivatives",
                          "DerivMarket", "DerivPurpose", "PrincipalAssetClass", "TypeOfMarket",
                          "PrincipalInvestmentStrategy", "ClearingCode", "SfCatMorningStar", "SfCatSix",
                          "SfCatBloomberg", "CommentTitle", "CommentArea", "RecaptchaValue")] EditShareClassInputModel model)
        {
            bool doesExist = await this.service.DoesExist(model.ShareClassName);

            if (!this.ModelState.IsValid || doesExist)
            {
                if (doesExist)
                {
                    this.ShowErrorAlertify(ErrorMessages.ExistingEntityName);
                }

                this.SetViewDataValues();
                return this.View(model);
            }

            var subFundId = await this.service.Edit(model);
            var date = DateTimeParser.ToWebFormat(model.InitialDate);

            return this.ShowInfo(
                InfoMessages.SuccessfulEdit,
                GlobalConstants.ShareClassDetailsRouteName,
                new { area = GlobalConstants.ShareClassAreaName, id = subFundId, date = date });
        }

        [Route("sc/new")]
        public IActionResult Create()
        {
            this.SetViewDataValues();
            return this.View(new CreateShareClassInputModel { InitialDate = DateTime.Today, });
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("sc/new")]
        public async Task<IActionResult> Create(
                   [Bind("InitialDate", "EndDate", "SubFundName", "CSSFCode", "Status",
                          "FACode", "TACode", "LEICode", "DBCode", "FundContainer",
                          "FirstNavDate", "LastNavDate", "CSSFAuthDate", "ExpiryDate",
                          "CesrClass", "GeographicalFocus", "GlobalExposure", "CurrencyCode",
                          "NavFrequency", "ValuationDate", "CalculationDate", "AreDerivatives",
                          "DerivMarket", "DerivPurpose", "PrincipalAssetClass", "TypeOfMarket",
                          "PrincipalInvestmentStrategy", "ClearingCode", "SfCatMorningStar", "SfCatSix",
                          "SfCatBloomberg", "RecaptchaValue")] CreateShareClassInputModel model)
        {
            bool doesExist = await this.service.DoesExist(model.ShareClassName);

            if (!this.ModelState.IsValid || doesExist)
            {
                if (doesExist)
                {
                    this.ShowErrorAlertify(ErrorMessages.ExistingEntityName);
                }

                this.SetViewDataValues();
                return this.View(model);
            }

            var subFundId = await this.service.Create(model);
            var date = DateTimeParser.ToWebFormat(model.InitialDate);

            return this.ShowInfo(
                InfoMessages.SuccessfulCreate,
                GlobalConstants.ShareClassDetailsRouteName,
                new { area = GlobalConstants.ShareClassAreaName, id = subFundId, date = date });
        }

        private void SetViewDataValues()
        {
            this.ViewData["Status"] = this.repository.GetAllTbDomShareStatus();
            this.ViewData["InvestorType"] = this.repository.GetAllTbDomInvestorType();
            this.ViewData["ShareType"] = this.repository.GetAllTbDomShareType();
            this.ViewData["CurrencyCode"] = this.repository.GetAllTbDomCurrencyCode();
            this.ViewData["Country"] = this.repository.GetAllTbDomCountry();

            this.ViewData["SubFundContainer"] = this.repository.GetAllContainers();
        }
    }
}
