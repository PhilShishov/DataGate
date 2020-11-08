namespace DataGate.Web.Areas.Admin.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Web.Controllers;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.InputModels.ShareClasses;
    using DataGate.Web.Resources;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(EndpointsConstants.AdminAreaName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.LegalRoleName)]
    public class ShareClassStorageController : BaseController
    {
        private readonly IShareClassStorageService service;
        private readonly IShareClassRepository repository;
        private readonly SharedLocalizationService sharedLocalizer;

        public ShareClassStorageController(
                        IShareClassStorageService service,
                        IShareClassRepository repository,
                        SharedLocalizationService sharedLocalizer)
        {
            this.service = service;
            this.repository = repository;
            this.sharedLocalizer = sharedLocalizer;
        }

        [Route("sc/new")]
        public IActionResult Create()
        {
            this.SetViewDataValues();
            return this.View(new CreateShareClassInputModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("sc/new")]
        public async Task<IActionResult> Create(
                   [Bind("EndDate", "InitialDate", "ShareClassName", "CSSFCode", "Status", "FACode",
                         "TACode", "LEICode", "InvestorType", "ShareType ", "CurrencyCode",
                         "CountryIssue", "CountryRisk", "EmissionDate", "InceptionDate", "LastNavDate",
                         "ExpiryDate", "InitialPrice", "AccountingCode", "IsHedged", "IsListed",
                         "BloombergMarket", "BloombergCode", "BloombergId", "ISINCode", "ValorCode",
                         "WKN", "DateBusinessYear", "ProspectusCode", "SubFundContainer",
                         "RecaptchaValue")] CreateShareClassInputModel model)
        {
            bool doesExist = await this.service.DoesExist(model.ShareClassName);

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
                EndpointsConstants.RouteDetails + EndpointsConstants.ShareClassArea,
                new { area = EndpointsConstants.ShareClassArea, id = subFundId, date = date });
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
                    [Bind("Id", "InitialDate", "ShareClassName", "CSSFCode", "Status", "FACode",
                          "TACode", "LEICode", "InvestorType", "ShareType ", "CurrencyCode",
                          "CountryIssue", "CountryRisk", "EmissionDate", "InceptionDate", "LastNavDate",
                          "ExpiryDate", "InitialPrice", "AccountingCode", "IsHedged", "IsListed",
                          "BloombergMarket", "BloombergCode", "BloombergId", "ISINCode", "ValorCode",
                          "WKN", "DateBusinessYear", "ProspectusCode", "CommentTitle", "CommentArea",
                          "RecaptchaValue")] EditShareClassInputModel model)
        {
            bool doesExistAtDate = await this.service.DoesExistAtDate(model.ShareClassName, model.InitialDate);

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
                EndpointsConstants.RouteDetails + EndpointsConstants.ShareClassArea,
                new { area = EndpointsConstants.ShareClassArea, id = subFundId, date = date });
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
