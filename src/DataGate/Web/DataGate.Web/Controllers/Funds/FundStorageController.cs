namespace DataGate.Web.Controllers.Funds
{
    using Microsoft.AspNetCore.Mvc;

    public class FundStorageController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        //[HttpGet("Funds/EditFund/{EntityId}/{ChosenDate}")]
        //public IActionResult EditFund(int entityId, string chosenDate)
        //{
        //    var date = DateTime.Parse(chosenDate);

        //    EditFundInputModel model = new EditFundInputModel
        //    {
        //        EntityProperties = this.fundsService.GetFundWithDateById(date, entityId),
        //        InitialDate = DateTime.Today,
        //        FundId = entityId,
        //    };

        //    SetModelValuesForEditView(model);

        //    SetViewDataValuesForFundSelectLists();

        //    this.ModelState.Clear();
        //    return this.View(model);
        //}

        //[ValidateAntiForgeryToken]

        //[HttpPost("Funds/EditFund/{EntityId}/{ChosenDate}")]
        //[Authorize(Roles = "Admin")]
        //public IActionResult EditFund(EditFundInputModel model, int entityId, string chosenDate)
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

        //private static void SetModelValuesForEditView(EditFundInputModel model)
        //{
        //    model.FundName = model.EntityProperties[1][3];
        //    model.CSSFCode = model.EntityProperties[1][4];
        //    model.FACode = model.EntityProperties[1][9];
        //    model.DEPCode = model.EntityProperties[1][10];
        //    model.TACode = model.EntityProperties[1][11];
        //    model.TinNumber = model.EntityProperties[1][14];
        //    model.LEICode = model.EntityProperties[1][15];
        //    model.RegNumber = model.EntityProperties[1][16];
        //}

        //private void SetViewDataValuesForFundSelectLists()
        //{
        //    //this.ViewData["Status"] = this.fundsSelectListService.GetAllTbDomFStatus();
        //    //this.ViewData["LegalForm"] = this.fundsSelectListService.GetAllTbDomLegalForm();
        //    //this.ViewData["LegalVehicle"] = this.fundsSelectListService.GetAllTbDomLegalVehicle();
        //    //this.ViewData["LegalType"] = this.fundsSelectListService.GetAllTbDomLegalType();
        //    //this.ViewData["CompanyTypeDesc"] = this.fundsSelectListService.GetAllTbDomCompanyDesc();
        //}
    }
}
