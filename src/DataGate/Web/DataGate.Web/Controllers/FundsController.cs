﻿namespace DataGate.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Globalization;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.AspNetCore.Authorization;

    using DataGate.Data;
    using DataGate.Utilities.Web;
    using DataGate.Web.Utilities;
    using DataGate.Services.Files;
    using DataGate.Services.Funds.Contracts;
    using DataGate.Web.Models.BindingModels.Funds;
    using DataGate.Web.Models.ViewModels.Entities;
    using DataGate.Services.Agreements.Contracts;

    [Authorize]
    public class FundsController : Controller
    {
        private readonly Pharus_vFinale_Context context;
        private readonly IFundsService fundsService;
        private readonly IFundsSelectListService fundsSelectListService;
        private readonly IAgreementsSelectListService agreementsSelectListService;
        private readonly IEntitiesFileService entitiesFileService;
        private readonly IWebHostEnvironment _environment;

        public FundsController(
            IFundsService fundsService,
            IFundsSelectListService fundsSelectListService,
            IAgreementsSelectListService agreementsSelectListService,
            IEntitiesFileService entitiesFileService,
            IWebHostEnvironment hostingEnvironment,
            Pharus_vFinale_Context context)
        {
            this.context = context;
            this.fundsService = fundsService;
            this.fundsSelectListService = fundsSelectListService;
            this.agreementsSelectListService = agreementsSelectListService;
            this.entitiesFileService = entitiesFileService;
            this._environment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new EntitiesViewModel
            {
                IsActive = true,
                ChosenDate = DateTime.Today.ToString("yyyy-MM-dd"),
                EntitiesHeadersForColumnSelection = this.fundsService
                                                        .GetAllActiveFunds()
                                                        .Take(1)
                                                        .ToList(),
                Entities = this.fundsService.GetAllActiveFunds(),
            };

            this.ModelState.Clear();
            return this.View(model);
        }

        public JsonResult AutoCompleteFundList(string selectTerm)
        {
            var result = this.context
                .TbHistoryFund
                .GroupBy(hf => hf.FOfficialFundName)
                .Select(hf => hf.FirstOrDefault())
                .ToList();

            if (selectTerm != null)
            {
                result = this.context
                    .TbHistoryFund
                    .Where(hf => hf.FOfficialFundName.Contains(selectTerm))
                    .GroupBy(hf => hf.FOfficialFundName)
                    .Select(hf => hf.FirstOrDefault())
                    .ToList();
            }

            var modifiedData = result.Select(hf => new
            {
                id = hf.FOfficialFundName,
                text = hf.FOfficialFundName,
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

            if (model.SelectedColumns != null && model.SelectedColumns.Count > 0)
            {
                isInSelectionMode = true;
            }

            DateTime? chosenDate = null;

            if (model.ChosenDate != null)
            {
                chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }

            if (isInSelectionMode)
            {
                if (model.IsActive)
                {
                    CallActiveEntitiesWithSelectedColumns(model, chosenDate);
                }
                else if (!model.IsActive)
                {
                    CallAllEntitiesWithSelectedColumns(model, chosenDate);
                }
            }
            else if (!isInSelectionMode)
            {
                if (model.IsActive)
                {
                    model.Entities = this.fundsService.GetAllActiveFunds(chosenDate);
                }
                else if (!model.IsActive)
                {
                    model.Entities = this.fundsService.GetAllFunds(chosenDate);
                }
            }

            if (model.SelectTerm != null)
            {
                model.Entities = CreateTableView.AddTableToView(model.Entities, model.SelectTerm.ToLower());
            }

            if (model.SearchTerm != null)
            {
                model.Entities = CreateTableView.AddTableToView(model.Entities, model.SearchTerm.ToLower());
            }

            if (model.Entities != null)
            {
                return this.View(model);
            }

            this.ModelState.Clear();
            return this.RedirectToPage("/Funds/All");
        }

        [HttpPost]
        public FileStreamResult ExtractExcelEntities(EntitiesViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (this.HttpContext.Request.Form.ContainsKey("extract_Excel"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(model.Entities, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfEntities(EntitiesViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable
                    .ExtractTableAsPdf(model.Entities, chosenDate, this._environment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpGet]
        [Route("Funds/ViewEntitySE/{EntityId}/{ChosenDate}")]
        public IActionResult ViewEntitySE(int entityId, string chosenDate)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                ChosenDate = chosenDate,
                EntityId = entityId,
            };

            SetModelValuesForSpecificView(viewModel);

            HttpContext.Session.SetString("entityId", Convert.ToString(entityId));

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
                entitiesToSearch = entitiesToSearch.Where(sf => sf[3]
                                                     .ToLower()
                                                     .Contains(selectTerm
                                                     .ToLower()))
                                                   .ToList();
            }

            var modifiedData = entitiesToSearch.Select(sf => new
            {
                id = sf[3],
                text = sf[3],
            });

            return this.Json(modifiedData);
        }

        [HttpPost]
        [Route("Funds/ViewEntitySE/{EntityId}/{ChosenDate}")]
        public IActionResult ViewEntitySE(SpecificEntityViewModel model)
        {
            SetModelValuesForSpecificView(model);

            if (model.Command == "Reset")
            {
                model.SelectTerm = "Quick Select";
                return this.View(model);
            }

            bool isInSelectionMode = false;

            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (model.SelectedColumns != null && model.SelectedColumns.Count > 0)
            {
                isInSelectionMode = true;
            }

            model.Entity = this.fundsService
                   .GetFundWithDateById(chosenDate, model.EntityId);

            if (model.SelectTerm == null)
            {
                if (isInSelectionMode)
                {
                    CallEntitySubEntitiesWithSelectedColumns(model, chosenDate);
                }
                else if (!isInSelectionMode)
                {
                    model.EntitySubEntities = this.fundsService.GetFund_SubFunds(chosenDate, model.EntityId);
                }

                return this.View(model);
            }

            if (isInSelectionMode)
            {
                CallEntitySubEntitiesWithSelectedColumns(model, chosenDate);
            }

            else if (!isInSelectionMode)
            {
                model.EntitySubEntities = this.fundsService
                    .GetFund_SubFunds(chosenDate, model.EntityId);
            }

            if (model.SelectTerm != null)
            {
                model.EntitySubEntities = CreateTableView.AddTableToView(model.EntitySubEntities, model.SelectTerm.ToLower());
            }

            if (model.Entity != null && model.EntitySubEntities != null)
            {
                return this.View(model);
            }

            this.ModelState.Clear();
            return this.View();
        }

        [HttpPost]
        public IActionResult UploadProspectus(SpecificEntityViewModel model)
        {
            SetModelValuesForSpecificView(model);

            var file = model.UploadEntityFileModel.FileToUpload;

            if (file != null || file.FileName != "")
            {
                string fileExt = Path.GetExtension(file.FileName);
                string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Funds\");
                string path = $"{fileLocation}{file.FileName}";

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Close();
                }

                string startConnection = model.StartConnection.ToString("yyyyMMdd");
                string endConnection = model.EndConnection?.ToString("yyyyMMdd");

                var prosFileTypeDesc = model.UploadEntityFileModel.DocumentType;
                int prosFileTypeId = this.context.TbDomFileType
                        .Where(ft => ft.FiletypeDesc == prosFileTypeDesc)
                        .Select(ft => ft.FiletypeId)
                        .FirstOrDefault();

                this.entitiesFileService.AddDocumentToSpecificEntity(
                                                    file.FileName,
                                                    model.EntityId,
                                                    startConnection,
                                                    endConnection,
                                                    fileExt,
                                                    prosFileTypeId,
                                                    model.ControllerName);

            }

            return this.RedirectToAction("ViewEntitySE", new { model.EntityId, model.ChosenDate });
        }

        [HttpPost]
        public IActionResult UploadAgreement(SpecificEntityViewModel model)
        {
            SetModelValuesForSpecificView(model);

            //if (!ModelState.IsValid)
            //{
            //    return this.PartialView("SpecificEntity/_UploadAgr", model);
            //}

            var file = model.UploadAgreementFileModel.FileToUpload;

            if (file != null || file.FileName != "")
            {
                string fileExt = Path.GetExtension(file.FileName);
                string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");
                string path = $"{fileLocation}{file.FileName}";

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Close();
                }

                var activityTypeIdDesc = model.UploadAgreementFileModel.AgrType;
                int activityTypeId = this.context.TbDomActivityType
                        .Where(at => at.AtDesc == activityTypeIdDesc)
                        .Select(at => at.AtId)
                        .FirstOrDefault();

                string contractDate = model.UploadAgreementFileModel.ContractDate.ToString("yyyyMMdd");
                string activationDate = model.UploadAgreementFileModel.ActivationDate.ToString("yyyyMMdd");
                string expirationDate = model.UploadAgreementFileModel.ExpirationDate?.ToString("yyyyMMdd");

                int statusId = this.context.TbDomAgreementStatus
                    .Where(s => s.ASDesc == model.UploadAgreementFileModel.Status)
                    .Select(s => s.ASId)
                    .FirstOrDefault();

                int companyId = this.context.TbCompanies
                    .Where(c => c.CName == model.UploadAgreementFileModel.Company)
                    .Select(c => c.CId)
                    .FirstOrDefault();

                this.entitiesFileService.AddAgreementToSpecificEntity(
                                                    file.FileName,
                                                    fileExt,
                                                    model.EntityId,
                                                    activityTypeId,
                                                    contractDate,
                                                    activationDate,
                                                    expirationDate,
                                                    statusId,
                                                    companyId,
                                                    model.ControllerName);
            }

            this.ModelState.Clear();
            return this.RedirectToAction("ViewEntitySE", new { model.EntityId, model.ChosenDate });
        }

        [HttpPost]
        public IActionResult ReadDocument(string pdfValue)
        {
            FileStreamResult fileStreamResult = null;

            string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Funds\");
            string path = $"{fileLocation}{pdfValue}";

            if (this.HttpContext.Request.Form.ContainsKey("pdfValue"))
            {
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                fileStreamResult = new FileStreamResult(fileStream, "application/pdf");
            }

            if (fileStreamResult != null)
            {
                return fileStreamResult;
            }

            return this.RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult ReadAgreement(string pdfValue)
        {
            FileStreamResult fileStreamResult = null;

            string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");
            string path = $"{fileLocation}{pdfValue}";

            if (this.HttpContext.Request.Form.ContainsKey("pdfValue"))
            {
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                fileStreamResult = new FileStreamResult(fileStream, "application/pdf");
            }

            if (fileStreamResult != null)
            {
                return fileStreamResult;
            }

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public JsonResult DeleteAgreement(string agrName)
        {
            if (!string.IsNullOrEmpty(agrName))
            {
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                this.entitiesFileService.DeleteAgreementMapping(agrName, controllerName);

                string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");
                string path = $"{fileLocation}{agrName}";

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return Json(new { data = Path.GetFileNameWithoutExtension(agrName) });
                }
            }

            return Json(new { data = "false" });
        }

        [HttpPost]
        public FileStreamResult ExtractExcelSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (this.HttpContext.Request.Form.ContainsKey("extract_Excel"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(model.EntitySubEntities, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            var chosenDate = DateTime.Parse(model.ChosenDate);

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (model.EntitySubEntities[0].Length > 16)
            {
                model.EntitySubEntities = this.fundsService.PrepareFund_SubFundsForPDFExtract(chosenDate);
            }

            if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable
                    .ExtractTableAsPdf(model.EntitySubEntities, chosenDate, this._environment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Funds/EditFund/{EntityId}/{ChosenDate}")]
        public IActionResult EditFund(int entityId, string chosenDate)
        {
            var date = DateTime.Parse(chosenDate);

            EditFundBindingModel model = new EditFundBindingModel
            {
                EntityProperties = this.fundsService.GetFundWithDateById(date, entityId),
                InitialDate = DateTime.Today,
                FundId = entityId,
            };

            SetModelValuesForEditView(model);

            SetViewDataValuesForFundSelectLists();

            this.ModelState.Clear();
            return this.View(model);
        }

        [HttpPost("Funds/EditFund/{EntityId}/{ChosenDate}")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditFund(EditFundBindingModel model, int entityId, string chosenDate)
        {
            string returnUrl = "/Funds/All";

            if (!this.ModelState.IsValid)
            {
                if (model.EntityProperties == null)
                {
                    var date = DateTime.Parse(chosenDate);
                    model.EntityProperties = this.fundsService.GetFundWithDateById(date, entityId);
                    SetModelValuesForEditView(model);
                    SetViewDataValuesForFundSelectLists();
                }

                return this.View(model ?? new EditFundBindingModel());
            }


            if (this.HttpContext.Request.Form.ContainsKey("update_button"))
            {
                int fundId = model.FundId;
                string initialDate = model.InitialDate.ToString("yyyyMMdd");

                int fStatusId = this.context.TbDomFStatus
                    .Where(s => s.StFDesc == model.Status)
                    .Select(s => s.StFId)
                    .FirstOrDefault();

                string regNumber = model.RegNumber;
                string fundName = model.FundName;
                string leiCode = model.LEICode;
                string cssfCode = model.CSSFCode;
                string faCode = model.FACode;
                string depCode = model.DEPCode;
                string taCode = model.TACode;

                int fLegalFormId = this.context.TbDomLegalForm
                    .Where(lf => lf.LfAcronym == model.LegalForm)
                    .Select(lf => lf.LfId)
                    .FirstOrDefault();
                int fLegalVehicleId = this.context.TbDomLegalVehicle
                    .Where(lv => lv.LvAcronym == model.LegalVehicle)
                    .Select(lv => lv.LvId)
                    .FirstOrDefault();
                int fLegalTypeId = this.context.TbDomLegalType
                    .Where(lt => lt.LtAcronym == model.LegalType)
                    .Select(lt => lt.LtId)
                    .FirstOrDefault();

                // Split to take only companyTypeDesc for comparing

                string companyTypeDesc = model.CompanyTypeDesc.Split(" - ").FirstOrDefault();
                int fCompanyTypeId = this.context.TbDomCompanyType
                    .Where(ct => ct.CtDesc == companyTypeDesc)
                    .Select(ct => ct.CtId)
                    .FirstOrDefault();

                string tinNumber = model.TinNumber;

                string comment = model.CommentArea;
                string commentTitle = model.CommentTitle;

                this.fundsService.EditFund(fundId, initialDate, fStatusId, regNumber,
                                           fundName, leiCode, cssfCode, faCode, depCode, taCode,
                                           fLegalFormId, fLegalTypeId, fLegalVehicleId, fCompanyTypeId,
                                           tinNumber, comment, commentTitle);
            }

            return this.LocalRedirect(returnUrl);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateFund()
        {
            CreateFundBindingModel model = new CreateFundBindingModel
            {
                InitialDate = DateTime.Today,
            };

            SetViewDataValuesForFundSelectLists();

            this.ModelState.Clear();
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFund(CreateFundBindingModel model)
        {
            string returnUrl = "/Funds/All";

            SetViewDataValuesForFundSelectLists();

            // Compare fund name with existing
            model.ExistingEntitiesNames = this.fundsService.GetAllFundsNames();

            if (!this.ModelState.IsValid || model.ExistingEntitiesNames.Any(f => f == model.FundName))
            {
                return this.View(model ?? new CreateFundBindingModel());
            }

            if (this.HttpContext.Request.Form.ContainsKey("create_button"))
            {
                string initialDate = model.InitialDate.ToString("yyyyMMdd");
                string endDate = model.EndDate?.ToString("yyyyMMdd");

                int fStatusId = this.context.TbDomFStatus
                    .Where(s => s.StFDesc == model.Status)
                    .Select(s => s.StFId)
                    .FirstOrDefault();

                string regNumber = model.RegNumber;
                string fundName = model.FundName;
                string leiCode = model.LEICode;
                string cssfCode = model.CSSFCode;
                string faCode = model.FACode;
                string depCode = model.DEPCode;
                string taCode = model.TACode;

                int fLegalFormId = this.context.TbDomLegalForm
                    .Where(lf => lf.LfAcronym == model.LegalForm)
                    .Select(lf => lf.LfId)
                    .FirstOrDefault();
                int fLegalVehicleId = this.context.TbDomLegalVehicle
                    .Where(lv => lv.LvAcronym == model.LegalVehicle)
                    .Select(lv => lv.LvId)
                    .FirstOrDefault();
                int fLegalTypeId = this.context.TbDomLegalType
                    .Where(lt => lt.LtAcronym == model.LegalType)
                    .Select(lt => lt.LtId)
                    .FirstOrDefault();

                // Split to take only companyTypeDesc for comparing

                string companyTypeDesc = model.CompanyTypeDesc.Split(" - ").FirstOrDefault();
                int fCompanyTypeId = this.context.TbDomCompanyType
                    .Where(ct => ct.CtDesc == companyTypeDesc)
                    .Select(ct => ct.CtId)
                    .FirstOrDefault();

                string tinNumber = model.TinNumber;

                this.fundsService.CreateFund(initialDate, endDate, fundName, cssfCode, fStatusId, fLegalFormId,
                                             fLegalTypeId, fLegalVehicleId, faCode, depCode, taCode, fCompanyTypeId,
                                             tinNumber, leiCode, regNumber);
            }

            return this.LocalRedirect(returnUrl);
        }

        private void CallAllEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate)
        {
            model.Entities = this.fundsService.GetAllFundsWithSelectedViewAndDate(
                                                                        model.PreSelectedColumns,
                                                                        model.SelectedColumns,
                                                                        chosenDate);
        }

        private void CallActiveEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate)
        {
            model.Entities = this.fundsService.GetAllActiveFundsWithSelectedViewAndDate(
                                                                        model.PreSelectedColumns,
                                                                        model.SelectedColumns,
                                                                        chosenDate);
        }

        private void CallEntitySubEntitiesWithSelectedColumns(SpecificEntityViewModel model, DateTime chosenDate)
        {
            model.EntitySubEntities = this.fundsService.GetFund_SubFundsWithSelectedViewAndDate(
                                                                                model.PreSelectedColumns,
                                                                                model.SelectedColumns,
                                                                                chosenDate,
                                                                                model.EntityId);
        }

        private void SetModelValuesForSpecificView(SpecificEntityViewModel model)
        {
            model.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            var date = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int entityId = model.EntityId;

            model.Entity = this.fundsService.GetFundWithDateById(date, entityId);
            model.EntityDistinctDocuments = this.fundsService.
                GetDistinctFundDocuments(date, entityId);
            model.EntityDistinctAgreements = this.fundsService.GetDistinctFundAgreements(date, entityId);

            model.EntitySubEntities = this.fundsService.GetFund_SubFunds(date, entityId);
            model.EntitiesHeadersForColumnSelection = this.fundsService
                                                                .GetFund_SubFunds(date, entityId)
                                                                .Take(1)
                                                                .ToList();
            model.EntityTimeline = this.fundsService.GetFundTimeline(entityId);
            model.EntityDocuments = this.fundsService.GetAllFundDocuments(entityId);
            model.EntityAgreements = this.fundsService.GetAllFundAgreements(date, entityId);

            model.StartConnection = DateTime.ParseExact(model.Entity[1][0], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (model.EndConnection != null)
            {
                model.EndConnection = DateTime.ParseExact(model.Entity[1][1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            this.ViewData["ProspectusFileTypes"] = this.fundsSelectListService.GetAllProspectusFileTypes();
            this.ViewData["AgreementsFileTypes"] = this.fundsSelectListService.GetAllAgreementsFileTypes();
            this.ViewData["AgreementsStatus"] = this.agreementsSelectListService.GetAllTbDomAgreementStatus();
            this.ViewData["Companies"] = this.agreementsSelectListService.GetAllTbCompanies();
        }

        private static void SetModelValuesForEditView(EditFundBindingModel model)
        {
            model.FundName = model.EntityProperties[1][3];
            model.CSSFCode = model.EntityProperties[1][4];
            model.FACode = model.EntityProperties[1][9];
            model.DEPCode = model.EntityProperties[1][10];
            model.TACode = model.EntityProperties[1][11];
            model.TinNumber = model.EntityProperties[1][14];
            model.LEICode = model.EntityProperties[1][15];
            model.RegNumber = model.EntityProperties[1][16];
        }

        private void SetViewDataValuesForFundSelectLists()
        {
            this.ViewData["Status"] = this.fundsSelectListService.GetAllTbDomFStatus();
            this.ViewData["LegalForm"] = this.fundsSelectListService.GetAllTbDomLegalForm();
            this.ViewData["LegalVehicle"] = this.fundsSelectListService.GetAllTbDomLegalVehicle();
            this.ViewData["LegalType"] = this.fundsSelectListService.GetAllTbDomLegalType();
            this.ViewData["CompanyTypeDesc"] = this.fundsSelectListService.GetAllTbDomCompanyDesc();
        }
    }
}