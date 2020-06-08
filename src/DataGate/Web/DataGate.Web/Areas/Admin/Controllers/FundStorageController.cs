namespace DataGate.Web.Controllers.Funds
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Web.InputModels.Funds;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class FundStorageController : BaseController
    {
        private readonly IFundStorageService service;
        private readonly IFundSelectListService serviceSelect;

        public FundStorageController(
                        IFundStorageService fundService,
                        IFundSelectListService fundServiceSelect)
        {
            this.service = fundService;
            this.serviceSelect = fundServiceSelect;
        }

        [Route("f/edit/{id}/{date}")]
        public async Task<IActionResult> Edit(int id, string date)
        {
            var model = await this.service.GetByIdAndDate<EditFundInputModel>(id, date);

            await this.SetViewDataValues();

            return this.View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("f/edit/{id}/{date}")]
        public async Task<IActionResult> Edit(
                     [Bind("Id", "InitialDate", "FundName", "CSSFCode", "Status",
                          "LegalForm", "LegalVehicle", "LegalType", "FACode",
                          "DEPCode", "TACode", "CompanyTypeDesc", "TinNumber",
                          "LEICode", "RegNumber", "CommentTitle", "CommentArea", "RecaptchaValue")] EditFundInputModel model)
        {
            bool doesExist = await this.service.DoesExist(model.FundName);

            if (!this.ModelState.IsValid || doesExist)
            {
                if (doesExist)
                {
                    this.ShowErrorAlertify(ErrorMessages.ExistingEntityName);
                }

                await this.SetViewDataValues();
                return this.View(model);
            }

            var fundId = await this.service.Edit(model);
            var date = model.InitialDate.ToString(GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);

            return this.ShowInfo(
                InfoMessages.SuccessfulEdit,
                GlobalConstants.FundDetailsRouteName,
                new { area = GlobalConstants.FundAreaName, id = fundId, date = date });
        }

        [Route("f/new")]
        public async Task<IActionResult> Create()
        {
            await this.SetViewDataValues();
            return this.View(new CreateFundInputModel { InitialDate = DateTime.Today, });
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("f/new")]
        public async Task<IActionResult> Create(
                     [Bind("InitialDate", "EndDate", "FundName", "CSSFCode", "Status",
                          "LegalForm", "LegalVehicle", "LegalType", "FACode", "DEPCode",
                          "TACode", "CompanyTypeDesc", "TinNumber", "LEICode", "RegNumber", "RecaptchaValue")] CreateFundInputModel model)
        {
            bool doesExist = await this.service.DoesExist(model.FundName);

            if (!this.ModelState.IsValid || doesExist)
            {
                if (doesExist)
                {
                    this.ShowErrorAlertify(ErrorMessages.ExistingEntityName);
                }

                await this.SetViewDataValues();
                return this.View(model);
            }

            var fundId = await this.service.Create(model);
            var date = model.InitialDate.ToString(GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);

            return this.ShowInfo(
                InfoMessages.SuccessfulCreate,
                GlobalConstants.FundDetailsRouteName,
                new { area = GlobalConstants.FundAreaName, id = fundId, date = date });
        }

        private async Task SetViewDataValues()
        {
            this.ViewData["Status"] = await this.serviceSelect.GetAllTbDomFStatus().ToListAsync();
            this.ViewData["LegalForm"] = await this.serviceSelect.GetAllTbDomLegalForm().ToListAsync();
            this.ViewData["LegalVehicle"] = await this.serviceSelect.GetAllTbDomLegalVehicle().ToListAsync();
            this.ViewData["LegalType"] = await this.serviceSelect.GetAllTbDomLegalType().ToListAsync();
            this.ViewData["CompanyTypeDesc"] = await this.serviceSelect.GetAllTbDomCompanyDesc().ToListAsync();
        }
    }
}
