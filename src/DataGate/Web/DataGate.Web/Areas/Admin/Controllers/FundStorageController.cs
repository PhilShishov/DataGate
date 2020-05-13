namespace DataGate.Web.Controllers.Funds
{
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
        private readonly IFundsSelectListService serviceSelect;

        public FundStorageController(
                        IFundStorageService fundService,
                        IFundsSelectListService fundServiceSelect)
        {
            this.service = fundService;
            this.serviceSelect = fundServiceSelect;
        }

        [Route("f/edit/{id}/{date}")]
        public async Task<IActionResult> Edit(int id, string date)
        {
            var model = await this.service.GetByIdAndDate<EditFundInputModel>(id, date);

            await this.SetViewDataValuesForFundSelectLists();

            return this.View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("f/edit/{id}/{date}")]
        public async Task<IActionResult> Edit([Bind("Id", "InitialDate", "FundName", "CSSFCode", "Status",
                                                    "LegalForm", "LegalVehicle", "LegalType", "FACode",
                                                    "DEPCode", "TACode", "CompanyTypeDesc", "TinNumber",
                                                    "LEICode", "RegNumber", "CommentTitle", "CommentArea")] EditFundInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                await this.SetViewDataValuesForFundSelectLists();
                return this.View(model);
            }

            var date = model.InitialDate.ToString(GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
            await this.service.Edit(model);

            return this.ShowInfo(InfoMessages.SuccessfulUpdate, GlobalConstants.FundDetailsRouteName, new
            {
                area = GlobalConstants.FundsAreaName,
                model.Id,
                date,
            });
        }

        private async Task SetViewDataValuesForFundSelectLists()
        {
            this.ViewData["Status"] = await this.serviceSelect.GetAllTbDomFStatus().ToListAsync();
            this.ViewData["LegalForm"] = await this.serviceSelect.GetAllTbDomLegalForm().ToListAsync();
            this.ViewData["LegalVehicle"] = await this.serviceSelect.GetAllTbDomLegalVehicle().ToListAsync();
            this.ViewData["LegalType"] = await this.serviceSelect.GetAllTbDomLegalType().ToListAsync();
            this.ViewData["CompanyTypeDesc"] = await this.serviceSelect.GetAllTbDomCompanyDesc().ToListAsync();
        }

        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //public IActionResult CreateFund()
        //{
        //    CreateFundInputModel model = new CreateFundInputModel
        //    {
        //        InitialDate = DateTime.Today,
        //    };

        //    SetViewDataValuesForFundSelectLists();

        //    this.ModelState.Clear();
        //    return this.View(model);
        //}

        //[ValidateAntiForgeryToken]

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateFund(CreateFundInputModel model)
        //{
        //    string returnUrl = "/Funds/All";

        //    SetViewDataValuesForFundSelectLists();

        //    // Compare fund name with existing
        //    //model.ExistingEntitiesNames = this.fundsService.GetAllFundsNames();

        //    if (!this.ModelState.IsValid || model.ExistingEntitiesNames.Any(f => f == model.FundName))
        //    {
        //        return this.View(model ?? new CreateFundInputModel());
        //    }

        //    if (this.HttpContext.Request.Form.ContainsKey("create_button"))
        //    {
        //        string initialDate = model.InitialDate.ToString("yyyyMMdd");
        //        string endDate = model.EndDate?.ToString("yyyyMMdd");

        //        int fStatusId = this.context.TbDomFStatus
        //            .Where(s => s.StFDesc == model.Status)
        //            .Select(s => s.StFId)
        //            .FirstOrDefault();

        //        string regNumber = model.RegNumber;
        //        string fundName = model.FundName;
        //        string leiCode = model.LEICode;
        //        string cssfCode = model.CSSFCode;
        //        string faCode = model.FACode;
        //        string depCode = model.DEPCode;
        //        string taCode = model.TACode;

        //        int fLegalFormId = this.context.TbDomLegalForm
        //            .Where(lf => lf.LfAcronym == model.LegalForm)
        //            .Select(lf => lf.LfId)
        //            .FirstOrDefault();
        //        int fLegalVehicleId = this.context.TbDomLegalVehicle
        //            .Where(lv => lv.LvAcronym == model.LegalVehicle)
        //            .Select(lv => lv.LvId)
        //            .FirstOrDefault();
        //        int fLegalTypeId = this.context.TbDomLegalType
        //            .Where(lt => lt.LtAcronym == model.LegalType)
        //            .Select(lt => lt.LtId)
        //            .FirstOrDefault();

        //        // Split to take only companyTypeDesc for comparing

        //        string companyTypeDesc = model.CompanyTypeDesc.Split(" - ").FirstOrDefault();
        //        int fCompanyTypeId = this.context.TbDomCompanyType
        //            .Where(ct => ct.CtDesc == companyTypeDesc)
        //            .Select(ct => ct.CtId)
        //            .FirstOrDefault();

        //        string tinNumber = model.TinNumber;

        //        this.fundsService.CreateFund(initialDate, endDate, fundName, cssfCode, fStatusId, fLegalFormId,
        //                                     fLegalTypeId, fLegalVehicleId, faCode, depCode, taCode, fCompanyTypeId,
        //                                     tinNumber, leiCode, regNumber);
        //    }

        //    return this.LocalRedirect(returnUrl);
        //}
    }
}
