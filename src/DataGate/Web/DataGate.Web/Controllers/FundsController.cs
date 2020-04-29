namespace DataGate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Data;
    using DataGate.Services.Data.Files;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Web.InputModels.Funds;
    using DataGate.Web.Utilities;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Caching.Memory;

    [Authorize]
    public class FundsController : BaseController
    {
        private IMemoryCache cache;
        private readonly Pharus_vFinaleDbContext context;
        private readonly IFundsService fundsService;
        //private readonly IFundsSelectListService fundsSelectListService;
        //private readonly IAgreementsSelectListService agreementsSelectListService;
        private readonly IFileSystemService entitiesFileService;
        private readonly IWebHostEnvironment _environment;

        public FundsController(
            IFundsService fundsService,
            //IFundsSelectListService fundsSelectListService,
            //IAgreementsSelectListService agreementsSelectListService,
            IFileSystemService entitiesFileService,
            IWebHostEnvironment hostingEnvironment,
            IMemoryCache memoryCache,
            Pharus_vFinaleDbContext context)
        {
            this.context = context;
            this.fundsService = fundsService;
            //this.fundsSelectListService = fundsSelectListService;
            //this.agreementsSelectListService = agreementsSelectListService;
            this.entitiesFileService = entitiesFileService;
            this.cache = memoryCache;
            this._environment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new EntitiesViewModel
            {
                IsActive = true,
                ChosenDate = DateTime.Today.ToString(GlobalConstants.DateTimeFormatDisplay),
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
                chosenDate = DateTime.ParseExact(model.ChosenDate, GlobalConstants.DateTimeFormatDisplay, CultureInfo.InvariantCulture);
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

            if (model.Entities != null)
            {
                return this.View(model);
            }

            this.ModelState.Clear();
            return this.View();
        }

        public FileStreamResult GenerateExcelReport(EntitiesViewModel model)
        {
            string controllerName = this.ControllerContext.RouteData.Values[GlobalConstants.ControllerRouteDataValue].ToString();

            return GenerateFileTemplate.GenerateExcelTemplate(model, controllerName);
        }

        public FileStreamResult GeneratePdfReport(EntitiesViewModel model)
        {
            string controllerName = this.ControllerContext.RouteData.Values[GlobalConstants.ControllerRouteDataValue].ToString();

            return GenerateFileTemplate.GeneratePdfTemplate(model, controllerName);
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

        //[HttpPost]
        //public IActionResult UploadProspectus(SpecificEntityViewModel model)
        //{
        //    SetModelValuesForSpecificView(model);

        //    var file = model.UploadEntityFileModel.FileToUpload;

        //    if (file != null || file.FileName != "")
        //    {
        //        string fileExt = Path.GetExtension(file.FileName);
        //        string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Funds\");
        //        string path = $"{fileLocation}{file.FileName}";

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //            stream.Close();
        //        }

        //        string startConnection = model.StartConnection.ToString("yyyyMMdd");
        //        string endConnection = model.EndConnection?.ToString("yyyyMMdd");

        //        var prosFileTypeDesc = model.UploadEntityFileModel.DocumentType;
        //        int prosFileTypeId = this.context.TbDomFileType
        //                .Where(ft => ft.FiletypeDesc == prosFileTypeDesc)
        //                .Select(ft => ft.FiletypeId)
        //                .FirstOrDefault();

        //        this.entitiesFileService.AddDocumentToSpecificEntity(
        //                                            file.FileName,
        //                                            model.EntityId,
        //                                            startConnection,
        //                                            endConnection,
        //                                            fileExt,
        //                                            prosFileTypeId,
        //                                            model.ControllerName);

        //    }

        //    return this.RedirectToAction("ViewEntitySE", new { model.EntityId, model.ChosenDate });
        //}

        //[HttpPost]
        //public IActionResult UploadAgreement(SpecificEntityViewModel model)
        //{
        //    SetModelValuesForSpecificView(model);

        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return this.PartialView("SpecificEntity/_UploadAgr", model);
        //    //}

        //    var file = model.UploadAgreementFileModel.FileToUpload;

        //    if (file != null || file.FileName != "")
        //    {
        //        string fileExt = Path.GetExtension(file.FileName);
        //        string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");
        //        string path = $"{fileLocation}{file.FileName}";

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //            stream.Close();
        //        }

        //        var activityTypeIdDesc = model.UploadAgreementFileModel.AgrType;
        //        int activityTypeId = this.context.TbDomActivityType
        //                .Where(at => at.AtDesc == activityTypeIdDesc)
        //                .Select(at => at.AtId)
        //                .FirstOrDefault();

        //        string contractDate = model.UploadAgreementFileModel.ContractDate.ToString("yyyyMMdd");
        //        string activationDate = model.UploadAgreementFileModel.ActivationDate.ToString("yyyyMMdd");
        //        string expirationDate = model.UploadAgreementFileModel.ExpirationDate?.ToString("yyyyMMdd");

        //        int statusId = this.context.TbDomAgreementStatus
        //            .Where(s => s.ASDesc == model.UploadAgreementFileModel.Status)
        //            .Select(s => s.ASId)
        //            .FirstOrDefault();

        //        int companyId = this.context.TbCompanies
        //            .Where(c => c.CName == model.UploadAgreementFileModel.Company)
        //            .Select(c => c.CId)
        //            .FirstOrDefault();

        //        this.entitiesFileService.AddAgreementToSpecificEntity(
        //                                            file.FileName,
        //                                            fileExt,
        //                                            model.EntityId,
        //                                            activityTypeId,
        //                                            contractDate,
        //                                            activationDate,
        //                                            expirationDate,
        //                                            statusId,
        //                                            companyId,
        //                                            model.ControllerName);
        //    }

        //    this.ModelState.Clear();
        //    return this.RedirectToAction("ViewEntitySE", new { model.EntityId, model.ChosenDate });
        //}

        //[HttpPost]
        //public IActionResult ReadDocument(string pdfValue)
        //{
        //    FileStreamResult fileStreamResult = null;

        //    string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Funds\");
        //    string path = $"{fileLocation}{pdfValue}";

        //    if (this.HttpContext.Request.Form.ContainsKey("pdfValue"))
        //    {
        //        var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        //        fileStreamResult = new FileStreamResult(fileStream, "application/pdf");
        //    }

        //    if (fileStreamResult != null)
        //    {
        //        return fileStreamResult;
        //    }

        //    return this.RedirectToAction("All");
        //}

        //[HttpPost]
        //public IActionResult ReadAgreement(string pdfValue)
        //{
        //    FileStreamResult fileStreamResult = null;

        //    string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");
        //    string path = $"{fileLocation}{pdfValue}";

        //    if (this.HttpContext.Request.Form.ContainsKey("pdfValue"))
        //    {
        //        var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        //        fileStreamResult = new FileStreamResult(fileStream, "application/pdf");
        //    }

        //    if (fileStreamResult != null)
        //    {
        //        return fileStreamResult;
        //    }

        //    return this.RedirectToAction("All");
        //}

        //[ValidateAntiForgeryToken]

        //[HttpGet]
        //public JsonResult DeleteAgreement(string agrName)
        //{
        //    if (!string.IsNullOrEmpty(agrName))
        //    {
        //        string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
        //        this.entitiesFileService.DeleteAgreementMapping(agrName, controllerName);

        //        string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");
        //        string path = $"{fileLocation}{agrName}";

        //        if (System.IO.File.Exists(path))
        //        {
        //            System.IO.File.Delete(path);
        //            return Json(new { data = Path.GetFileNameWithoutExtension(agrName) });
        //        }
        //    }

        //    return Json(new { data = "false" });
        //}

        //[HttpPost]
        //public FileStreamResult ExtractExcelSubEntities(SpecificEntityViewModel model)
        //{
        //    FileStreamResult fileStreamResult = null;

        //    string typeName = model.GetType().Name;
        //    string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

        //    if (this.HttpContext.Request.Form.ContainsKey("extract_Excel"))
        //    {
        //        fileStreamResult = ExtractTable.ExtractTableAsExcel(model.EntitySubEntities, typeName, controllerName);
        //    }

        //    return fileStreamResult;
        //}

        //[HttpPost]
        //public FileStreamResult ExtractPdfSubEntities(SpecificEntityViewModel model)
        //{
        //    FileStreamResult fileStreamResult = null;

        //    var chosenDate = DateTime.Parse(model.ChosenDate);

        //    string typeName = model.GetType().Name;
        //    string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

        //    if (model.EntitySubEntities[0].Length > 16)
        //    {
        //        model.EntitySubEntities = this.fundsService.PrepareFund_SubFundsForPDFExtract(chosenDate);
        //    }

        //    if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
        //    {
        //        fileStreamResult = ExtractTable
        //            .ExtractTableAsPdf(model.EntitySubEntities, chosenDate, this._environment, typeName, controllerName);
        //    }

        //    return fileStreamResult;
        //}

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
