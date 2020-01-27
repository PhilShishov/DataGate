namespace Pharus.App.Controllers
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

    using Pharus.Data;
    using Pharus.Utilities.App;
    using Pharus.App.Utilities;
    using Pharus.Services.Files;
    using Pharus.Services.Funds.Contracts;
    using Pharus.App.Models.BindingModels.Funds;
    using Pharus.App.Models.ViewModels.Entities;
    using Pharus.Services.Agreements.Contracts;

    [Authorize]
    public class FundsController : Controller
    {
        private readonly Pharus_vFinale_Context context;
        private readonly IFundsService fundsService;
        private readonly IFundsSelectListService fundsSelectListService;
        private readonly IAgreementsSelectListService agreementsSelectListService;
        private readonly IEntitiesFileService entitiesFileService;
        private readonly IHostingEnvironment hostingEnvironment;

        public FundsController(
            IFundsService fundsService,
            IFundsSelectListService fundsSelectListService,
            IAgreementsSelectListService agreementsSelectListService,
            IEntitiesFileService entitiesFileService,
            IHostingEnvironment hostingEnvironment,
            Pharus_vFinale_Context context)
        {
            this.context = context;
            this.fundsService = fundsService;
            this.fundsSelectListService = fundsSelectListService;
            this.agreementsSelectListService = agreementsSelectListService;
            this.entitiesFileService = entitiesFileService;
            this.hostingEnvironment = hostingEnvironment;
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
                    .ExtractTableAsPdf(model.Entities, chosenDate, this.hostingEnvironment, typeName, controllerName);
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

            if (file == null || file.Length == 0)
            {
                return this.Content("File not loaded. Please try again");
            }

            FileInfo fileType = new FileInfo(file.FileName);
            var fileExtension = fileType.Extension;

            if (fileExtension != ".pdf")
            {
                return this.Content("Unsupported file format. Please try again");
            }

            string networkFileLocation = @"\\Pha-sql-01\sqlexpress\FileFolder\FundFile\";
            string path = $"{networkFileLocation}{file.FileName}";

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
                stream.Close();
            }

            var startConnection = DateTime.ParseExact(model.StartConnection, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime? endConnection = null;

            if (!string.IsNullOrEmpty(model.EndConnection))
            {
                endConnection = DateTime.ParseExact(model.EndConnection, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

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
                                                prosFileTypeId,
                                                model.ControllerName);

            return this.RedirectToAction("ViewEntitySE", new { EntityId = model.EntityId, ChosenDate = model.ChosenDate});
        }

        [HttpPost]
        public IActionResult UploadAgreement(SpecificEntityViewModel model)
        {
            SetModelValuesForSpecificView(model);



            //if (!ModelState.IsValid)
            //{
            //    return this.PartialView("SpecificEntity/_UploadAgr", model);
            //}


            //if (file == null || file.Length == 0)
            //{
            //    //ViewBag.Message = "File not loaded. Please try again";
            //    return PartialView("SpecificEntity/_UploadAgr", model);
            //}

            //FileInfo fileType = new FileInfo(file.FileName);
            //var fileExtension = fileType.Extension;

            //if (fileExtension != ".pdf")
            //{
            //    //ViewBag.Message = "Unsupported file format. Please try again";
            //    return PartialView("_UploadAgr", model);
            //}

            var file = model.UploadAgreementFileModel.FileToUpload;
            string networkFileLocation = @"\\Pha-sql-01\sqlexpress\FileFolder\AgreementFile\";
            string path = $"{networkFileLocation}{file.FileName}";

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

            var contractDate = model.UploadAgreementFileModel.ContractDate;
            var activationDate = model.UploadAgreementFileModel.ActivationDate;
            var expirationDate = model.UploadAgreementFileModel.ExpirationDate;


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
                                                model.EntityId,
                                                activityTypeId,
                                                contractDate,
                                                activationDate,
                                                expirationDate,
                                                statusId,
                                                companyId,
                                                model.ControllerName);

            this.ModelState.Clear();
            return this.RedirectToAction("All");
        }

        [HttpPost]
        public FileStream ReadPdfFile(SpecificEntityViewModel model)
        {
            FileStream fileStreamResult = null;

            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            var path = this.entitiesFileService.LoadEntityFileToDisplay(model.EntityId, model.ChosenDate, controllerName);

            if (this.HttpContext.Request.Form.ContainsKey("read_Pdf"))
            {
                fileStreamResult = new FileStream(path, FileMode.Open, FileAccess.Read);
            }

            return fileStreamResult;
        }

        [HttpGet]
        public JsonResult DeleteAgreement(string agrName)
        {
            if (!string.IsNullOrEmpty(agrName))
            {
                this.entitiesFileService.DeleteAgreement(agrName);

                return Json(new { data = agrName });
            }
            else
            {
                return Json(new { data = "false" });
            }
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
                    .ExtractTableAsPdf(model.EntitySubEntities, chosenDate, this.hostingEnvironment, typeName, controllerName);
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
            var date = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int entityId = model.EntityId;

            model.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            model.Entity = this.fundsService.GetFundWithDateById(date, entityId);
            model.EntitySubEntities = this.fundsService.GetFund_SubFunds(date, entityId);
            model.EntitiesHeadersForColumnSelection = this.fundsService
                                                                .GetFund_SubFunds(date, entityId)
                                                                .Take(1)
                                                                .ToList();
            model.ProspectusNameToDisplay = GetFileNameFromFilePath
                (entityId, model.ChosenDate, model.ControllerName)
                .Split(".")[0];
            model.DistinctAgreementsNamesToDisplay = this.fundsService.GetDistinctFundAgreements(date, entityId);
            model.AllAgreementsNamesToDisplay = this.fundsService.GetAllFundAgreements(date, entityId);
            model.EntityTimeline = this.fundsService.GetFundTimeline(entityId);
            model.EntityDocuments = this.fundsService.GetAllFundDocuments(entityId);

            model.StartConnection = model.Entity[1][0];
            model.EndConnection = model.Entity[1][1];

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

        private string GetFileNameFromFilePath(int entityId, string chosenDate, string controllerName)
        {
            return this.entitiesFileService.LoadEntityFileToDisplay(entityId, chosenDate, controllerName).Split('\\').Last();
        }
    }
}