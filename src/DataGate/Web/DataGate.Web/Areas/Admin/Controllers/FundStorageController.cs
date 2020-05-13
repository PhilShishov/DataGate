namespace DataGate.Web.Controllers.Funds
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
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
            var model = await this.service.GetByIdAndDateWithoutHeaders<EditFundInputModel>(id, date);

            await this.SetViewDataValuesForFundSelectLists();

            return this.View(model);
        }

        private async Task SetViewDataValuesForFundSelectLists()
        {
            this.ViewData["Status"] = await this.serviceSelect.GetAllTbDomFStatus().ToListAsync();
            this.ViewData["LegalForm"] = await this.serviceSelect.GetAllTbDomLegalForm().ToListAsync();
            this.ViewData["LegalVehicle"] = await this.serviceSelect.GetAllTbDomLegalVehicle().ToListAsync();
            this.ViewData["LegalType"] = await this.serviceSelect.GetAllTbDomLegalType().ToListAsync();
            this.ViewData["CompanyTypeDesc"] = await this.serviceSelect.GetAllTbDomCompanyDesc().ToListAsync();
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost("Funds/EditFund/{EntityId}/{ChosenDate}")]
        //public IActionResult Edit(EditFundInputModel model, int entityId, string chosenDate)
        //{
        //    string returnUrl = "/Funds/All";

        //    if (!this.ModelState.IsValid)
        //    {
        //        if (model.EntityProperties == null)
        //        {
        //            var date = DateTime.Parse(chosenDate);
        //            model.EntityProperties = this.fundsService.GetFundWithDateById(date, entityId);
        //            SetModelValuesForEditView(model);
        //            SetViewDataValuesForFundSelectLists();
        //        }

        //        return this.View(model ?? new EditFundInputModel());
        //    }


        //    if (this.HttpContext.Request.Form.ContainsKey("update_button"))
        //    {
        //        int fundId = model.FundId;
        //        string initialDate = model.InitialDate.ToString("yyyyMMdd");

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

        //        string comment = model.CommentArea;
        //        string commentTitle = model.CommentTitle;

        //        this.fundsService.EditFund(fundId, initialDate, fStatusId, regNumber,
        //                                   fundName, leiCode, cssfCode, faCode, depCode, taCode,
        //                                   fLegalFormId, fLegalTypeId, fLegalVehicleId, fCompanyTypeId,
        //                                   tinNumber, comment, commentTitle);
        //    }

        //    return this.LocalRedirect(returnUrl);
        //}

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
