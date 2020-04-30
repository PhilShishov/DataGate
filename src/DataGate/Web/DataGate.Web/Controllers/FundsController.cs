namespace DataGate.Web.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Data;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Web.Utilities;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Authorize]
    public class FundsController : BaseController
    {
        private readonly Pharus_vFinaleDbContext context;
        private readonly IFundsService fundsService;
        //private readonly IFundsSelectListService fundsSelectListService;
        //private readonly IAgreementsSelectListService agreementsSelectListService;

        public FundsController(
            IFundsService fundsService,
            //IFundsSelectListService fundsSelectListService,
            //IAgreementsSelectListService agreementsSelectListService,
            Pharus_vFinaleDbContext context)
        {
            this.context = context;
            this.fundsService = fundsService;
            //this.fundsSelectListService = fundsSelectListService;
            //this.agreementsSelectListService = agreementsSelectListService;
        }

        [HttpGet]
        [Route("f/all")]
        public IActionResult All()
        {
            var model = new EntitiesViewModel
            {
                IsActive = true,
                ChosenDate = DateTime.Today.ToString(GlobalConstants.RequiredWebDateTimeFormat),
                EntitiesHeadersForColumnSelection = this.fundsService
                                                        .GetAllActiveFunds()
                                                        .Take(1)
                                                        .ToList(),
                Entities = this.fundsService.GetAllActiveFunds().ToList(),
            };

            return this.View(model);
        }

        public JsonResult AutoCompleteFundList(string selectTerm)
        {
            var result = this.fundsService
                .GetAllFunds(null)
                .Skip(1)
                .ToList();

            if (selectTerm != null)
            {
                result = result
                    .Where(f => f[GlobalConstants.IndexEntityNameInSQLTable]
                        .ToLower()
                        .Contains(selectTerm.ToLower()))
                    .ToList();
            }

            var modifiedData = result.Select(f => new
            {
                id = f[GlobalConstants.IndexEntityNameInSQLTable],
                text = f[GlobalConstants.IndexEntityNameInSQLTable],
            });

            return this.Json(modifiedData);
        }

        [HttpPost]
        public IActionResult All(EntitiesViewModel model)
        {
            // ---------------------------------------------------------
            //
            // Available header column selection
            model.EntitiesHeadersForColumnSelection = this.fundsService
                                                            .GetAllActiveFunds()
                                                            .Take(1)
                                                            .ToList();

            bool isInSelectionMode = false;

            if (model.SelectedColumns != null && model.SelectedColumns.ToList().Count > 0)
            {
                isInSelectionMode = true;
            }

            DateTime? chosenDate = null;

            if (model.ChosenDate != null)
            {
                chosenDate = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
            }

            if (isInSelectionMode)
            {
                if (model.IsActive)
                {
                    this.CallActiveEntitiesWithSelectedColumns(model, chosenDate);
                }
                else if (!model.IsActive)
                {
                    this.CallAllEntitiesWithSelectedColumns(model, chosenDate);
                }
            }
            else if (!isInSelectionMode)
            {
                if (model.IsActive)
                {
                    model.Entities = this.fundsService.GetAllActiveFunds(chosenDate).ToList();
                }
                else if (!model.IsActive)
                {
                    model.Entities = this.fundsService.GetAllFunds(chosenDate).ToList();
                }
            }

            if (model.SelectTerm != null)
            {
                model.Entities = CreateTableView.AddTableToView(model.Entities.ToList(), model.SelectTerm.ToLower());
            }

            if (model.Entities.Count > GlobalConstants.NumberOfHeadersInTable)
            {
                this.TempData[GlobalConstants.InfoMessageDisplay] = InfoMessages.SuccessfullyUpdatedTable;
                return this.View(model);
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableModelIsEmpty;
            this.ModelState.Clear();
            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        [HttpPost]
        public IActionResult GenerateExcelReport(EntitiesViewModel model)
        {
            int count = model.Entities.Count;
            if (count > GlobalConstants.NumberOfHeadersInTable)
            {
                string typeName = model.GetType().Name;

                return GenerateFileTemplate.ExtractTableAsExcel(model.Entities, typeName, GlobalConstants.FundsControllerName);
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableReportNotGenerated;
            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        [HttpPost]
        public IActionResult GeneratePdfReport(EntitiesViewModel model)
        {
            int count = model.Entities.Count;
            if (count > GlobalConstants.NumberOfHeadersInTable)
            {
                var chosenDate = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
                string typeName = model.GetType().Name;

                return GenerateFileTemplate.ExtractTableAsPdf(model.Entities, chosenDate, typeName, GlobalConstants.FundsControllerName);
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableReportNotGenerated;
            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        private void CallAllEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate)
        {
            model.Entities = this.fundsService
                .GetAllFundsWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate)
                .ToList();
        }

        private void CallActiveEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate)
        {
            model.Entities = this.fundsService
                .GetAllActiveFundsWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate)
                .ToList();
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
