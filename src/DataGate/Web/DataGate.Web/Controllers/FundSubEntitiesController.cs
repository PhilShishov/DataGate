namespace DataGate.Web.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.Data.FundSubFunds.Contracts;
    using DataGate.Web.Utilities;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class FundSubEntitiesController : BaseController
    {
        private readonly IFundSubFundsService fundsService;

        public FundSubEntitiesController(IFundSubFundsService fundSubFundsService)
        {
            this.fundsService = fundSubFundsService;
        }

        [HttpGet]
        [Route("f/{EntityId}/{ChosenDate}")]
        public IActionResult ByIdAndDate(int entityId, string chosenDate)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                ChosenDate = chosenDate,
                EntityId = entityId,
            };

            this.SetModelValuesForSpecificView(viewModel);

            this.ModelState.Clear();
            return this.View(viewModel);
        }

        public JsonResult AutoCompleteSubFundList(string selectTerm, int entityId)
        {
            var entitiesToSearch = this.fundsService
                .GetFund_SubFunds(null, entityId)
                .Skip(1)
                .ToList();

            if (selectTerm != null)
            {
                entitiesToSearch = entitiesToSearch
                    .Where(sf => sf[GlobalConstants.IndexEntityNameInSQLTable]
                        .ToLower()
                        .Contains(selectTerm
                        .ToLower()))
                    .ToList();
            }

            var modifiedData = entitiesToSearch.Select(sf => new
            {
                id = sf[GlobalConstants.IndexEntityNameInSQLTable],
                text = sf[GlobalConstants.IndexEntityNameInSQLTable],
            });

            return this.Json(modifiedData);
        }

        [HttpPost]
        public IActionResult ByIdAndDate(SpecificEntityViewModel model)
        {
            if (model.Command == "Reset")
            {
                model.SelectTerm = GlobalConstants.DefaultAutocompleteSelectTerm;
                return this.View(model);
            }

            this.SetModelValuesForSpecificView(model);

            bool isInSelectionMode = false;

            var chosenDate = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);

            if (model.SelectedColumns != null && model.SelectedColumns.Count > 0)
            {
                isInSelectionMode = true;
            }

            model.Entity = this.fundsService
                   .GetFundWithDateById(chosenDate, model.EntityId)
                   .ToList();

            if (model.SelectTerm == null)
            {
                if (isInSelectionMode)
                {
                    this.CallEntitySubEntitiesWithSelectedColumns(model, chosenDate);
                }
                else if (!isInSelectionMode)
                {
                    model.EntitySubEntities = this.fundsService.GetFund_SubFunds(chosenDate, model.EntityId).ToList();
                }

                return this.RedirectToAction("ByIdAndDate", new { model.EntityId, model.ChosenDate });
            }

            if (isInSelectionMode)
            {
                this.CallEntitySubEntitiesWithSelectedColumns(model, chosenDate);
            }
            else if (!isInSelectionMode)
            {
                model.EntitySubEntities = this.fundsService
                    .GetFund_SubFunds(chosenDate, model.EntityId)
                    .ToList();
            }

            if (model.SelectTerm != null)
            {
                model.EntitySubEntities = CreateTableView.AddTableToView(model.EntitySubEntities, model.SelectTerm.ToLower());
            }

            if (model.Entity != null && model.EntitySubEntities != null)
            {
                return this.RedirectToAction("ByIdAndDate", new { model.EntityId, model.ChosenDate });
            }

            this.ModelState.Clear();
            return this.View();
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

        private void CallEntitySubEntitiesWithSelectedColumns(SpecificEntityViewModel model, DateTime chosenDate)
        {
            model.EntitySubEntities = this.fundsService
                .GetFund_SubFundsWithSelectedViewAndDate(
                                                model.PreSelectedColumns,
                                                model.SelectedColumns,
                                                chosenDate,
                                                model.EntityId)
                .ToList();
        }

        private void SetModelValuesForSpecificView(SpecificEntityViewModel model)
        {
            model.ControllerName = this.ControllerContext.RouteData.Values[GlobalConstants.ControllerRouteDataValue].ToString();
            var date = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
            int entityId = model.EntityId;

            model.Entity = this.fundsService.GetFundWithDateById(date, entityId).ToList();
            model.EntityDistinctDocuments = this.fundsService.
                GetDistinctFundDocuments(date, entityId).ToList();
            model.EntityDistinctAgreements = this.fundsService.GetDistinctFundAgreements(date, entityId).ToList();

            model.EntitySubEntities = this.fundsService.GetFund_SubFunds(date, entityId).ToList();
            model.EntitiesHeadersForColumnSelection = this.fundsService
                                                                .GetFund_SubFunds(date, entityId)
                                                                .Take(1)
                                                                .ToList();
            model.EntityTimeline = this.fundsService.GetFundTimeline(entityId).ToList();
            model.EntityDocuments = this.fundsService.GetAllFundDocuments(entityId).ToList();
            model.EntityAgreements = this.fundsService.GetAllFundAgreements(date, entityId).ToList();

            model.StartConnection = DateTime.ParseExact(model.Entity.ToList()[1][0], GlobalConstants.SqlDateTimeFormatParsing, CultureInfo.InvariantCulture);

            if (model.EndConnection != null)
            {
                model.EndConnection = DateTime.ParseExact(model.Entity.ToList()[1][1], GlobalConstants.SqlDateTimeFormatParsing, CultureInfo.InvariantCulture);
            }

            //this.ViewData["ProspectusFileTypes"] = this.fundsSelectListService.GetAllProspectusFileTypes();
            //this.ViewData["AgreementsFileTypes"] = this.fundsSelectListService.GetAllAgreementsFileTypes();
            //this.ViewData["AgreementsStatus"] = this.agreementsSelectListService.GetAllTbDomAgreementStatus();
            //this.ViewData["Companies"] = this.agreementsSelectListService.GetAllTbCompanies();
        }
    }
}
