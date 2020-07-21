namespace DataGate.Web.Controllers.Funds
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.InputModels.Funds;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.LegalRoleName)]
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

        [Route("f/new")]
        public IActionResult Create()
        {
            this.SetViewDataValues();
            return this.View(new CreateFundInputModel());
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

                this.SetViewDataValues();
                return this.View(model);
            }

            var fundId = await this.service.Create(model);
            var date = DateTimeParser.ToWebFormat(model.InitialDate.AddDays(1));

            return this.ShowInfo(
                InfoMessages.SuccessfulCreate,
                GlobalConstants.FundDetailsRouteName,
                new { area = GlobalConstants.FundAreaName, id = fundId, date = date });
        }

        [Route("f/edit/{id}/{date}")]
        public IActionResult Edit(int id, string date)
        {
            var model = this.service.GetByIdAndDate<EditFundInputModel>(id, date);
            model.InitialDate = model.InitialDate.AddDays(1);

            this.SetViewDataValues();

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
            bool doesExistAtDate = await this.service.DoesExistAtDate(model.FundName, model.InitialDate);

            if (!this.ModelState.IsValid || doesExistAtDate)
            {
                if (doesExistAtDate)
                {
                    this.ShowErrorAlertify(ErrorMessages.ExistingEntityAtDate);
                }

                this.SetViewDataValues();
                return this.View(model);
            }

            var fundId = await this.service.Edit(model);
            var date = DateTimeParser.ToWebFormat(model.InitialDate.AddDays(1));

            return this.ShowInfo(
                InfoMessages.SuccessfulEdit,
                GlobalConstants.FundDetailsRouteName,
                new { area = GlobalConstants.FundAreaName, id = fundId, date = date });
        }

        private void SetViewDataValues()
        {
            this.ViewData["Status"] = this.serviceSelect.GetAllTbDomFStatus();
            this.ViewData["LegalForm"] = this.serviceSelect.GetAllTbDomLegalForm();
            this.ViewData["LegalVehicle"] = this.serviceSelect.GetAllTbDomLegalVehicle();
            this.ViewData["LegalType"] = this.serviceSelect.GetAllTbDomLegalType();
            this.ViewData["CompanyTypeDesc"] = this.serviceSelect.GetAllTbDomCompanyDesc();
        }
    }
}
