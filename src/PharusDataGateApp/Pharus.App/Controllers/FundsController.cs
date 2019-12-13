namespace Pharus.App.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Data;
    using Pharus.App.Utilities;
    using Pharus.Services.Funds.Contracts;
    using Pharus.App.Models.BindingModels.Funds;
    using Pharus.App.Models.ViewModels.Entities;

    [Authorize]
    public class FundsController : Controller
    {
        private readonly Pharus_vFinale_Context context;
        private readonly IFundsService fundsService;
        private readonly IFundsSelectListService fundsSelectListService;
        private readonly IFundsFileService fundsFileService;
        private readonly IHostingEnvironment hostingEnvironment;

        public FundsController(
            IFundsService fundsService,
            IFundsSelectListService fundsSelectListService,
            IFundsFileService fundsFileService,
            IHostingEnvironment hostingEnvironment,
            Pharus_vFinale_Context context)
        {
            this.context = context;
            this.fundsService = fundsService;
            this.fundsSelectListService = fundsSelectListService;
            this.fundsFileService = fundsFileService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new EntitiesViewModel
            {
                IsActive = true,
                ChosenDate = DateTime.Today.ToString("yyyy-MM-dd"),
            };
            GetAllActiveEntitiesUtility.GetAllActiveFundsWithHeaders(model, this.fundsService);

            this.ModelState.Clear();
            return this.View(model);
        }

        public JsonResult AutoCompleteFundList(string searchTerm)
        {
            var result = this.context.TbHistoryFund.ToList();
            if (searchTerm != null)
            {
                result = this.context.TbHistoryFund.Where(s => s.FOfficialFundName.Contains(searchTerm)).ToList();
            }

            var modifiedData = result.Select(s => new
            {
                id = s.FOfficialFundName,
                text = s.FOfficialFundName,
            });

            return this.Json(modifiedData);
        }

        [HttpPost]
        public IActionResult All(EntitiesViewModel model)
        {
            GetAllActiveEntitiesUtility.GetAllActiveFundsWithHeaders(model, this.fundsService);

            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (model.Command.Equals("Update Table"))
            {
                if (model.ChosenDate != null)
                {
                    if (model.IsActive)
                    {
                        GetAllActiveEntitiesUtility.GetAllActiveFundsWithHeaders(model, this.fundsService);
                    }
                    else
                    {
                        model.Entities = this.fundsService.GetAllFunds(chosenDate);
                    }
                }
            }
            else if (model.Command.Equals("Search"))
            {
                if (model.SearchTerm == null)
                {
                    return this.View(model);
                }

                model.Entities = new List<string[]>();

                var tableHeaders = this.fundsService
                    .GetAllFunds(chosenDate)
                    .Take(1)
                    .ToList();
                List<string[]> tableWithoutHeaders = null;

                if (model.IsActive)
                {
                    tableWithoutHeaders = this.fundsService
                        .GetAllFunds(chosenDate)
                        .Skip(1)
                        .Where(f => f.Contains("Active"))
                        .ToList();
                }
                else
                {
                    tableWithoutHeaders = this.fundsService
                        .GetAllFunds()
                        .Skip(1)
                        .ToList();
                }

                CreateTableView.AddHeadersToView(model.Entities, tableHeaders);

                CreateTableView.AddTableToView(model.Entities, tableWithoutHeaders, model.SearchTerm.ToLower());
            }

            if (model.Entities != null)
            {
                return this.View(model);
            }

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

        public JsonResult AutoCompleteSubFundList(string searchTerm, int entityId)
        {
            var entitiesToSearch = this.fundsService.GetFund_SubFunds(entityId).Skip(1).ToList();

            if (searchTerm != null)
            {
                entitiesToSearch = entitiesToSearch.Where(s => s[3].ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            var modifiedData = entitiesToSearch.Select(s => new
            {
                id = s[3],
                text = s[3],
            });

            return this.Json(modifiedData);
        }

        [HttpGet]
        [Route("Funds/ViewEntitySE/{EntityId}/{ChosenDate}")]
        public IActionResult ViewEntitySE(int entityId, string chosenDate)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                EntityId = entityId,
                Entity = this.fundsService.GetFundById(entityId),
                EntitySubEntities = this.fundsService.GetFund_SubFunds(entityId),
                ChosenDate = chosenDate,
                EntityTimeline = this.fundsService.GetFundTimeline(entityId),
                EntityDocuments = this.fundsService.GetAllFundDocumens(entityId),
            };

            viewModel.StartConnection = viewModel.Entity[1][0];
            viewModel.EndConnection = viewModel.Entity[1][1];

            this.ViewData["FileTypes"] = this.fundsSelectListService.GetAllFundFileTypes();

            HttpContext.Session.SetString("entityId", Convert.ToString(entityId));

            string fileName = GetFileNameFromFilePath(entityId, chosenDate);

            if (string.IsNullOrEmpty(fileName))
            {
                return this.View(viewModel);
            }

            viewModel.FileNameToDisplay = fileName;

            this.ModelState.Clear();
            return this.View(viewModel);
        }

        [HttpPost]
        [Route("Funds/ViewEntitySE/{EntityId}/{ChosenDate}")]
        public IActionResult ViewEntitySE(SpecificEntityViewModel viewModel)
        {
            SetModelValuesForSpecificView(viewModel);

            this.ViewData["FileTypes"] = this.fundsSelectListService.GetAllFundFileTypes();

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    var chosenDate = DateTime.ParseExact(viewModel.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    viewModel.Entity = this.fundsService
                        .GetFundById(chosenDate, viewModel.EntityId);
                    viewModel.EntitySubEntities = this.fundsService
                        .GetFund_SubFunds(chosenDate, viewModel.EntityId);
                }
            }
            else if (viewModel.Command.Equals("Search"))
            {
                if (viewModel.SearchTerm == null)
                {
                    return this.View(viewModel);
                }

                viewModel.EntitySubEntities = new List<string[]>();

                var tableHeaders = this.fundsService
                    .GetFund_SubFunds(viewModel.EntityId)
                    .Take(1)
                    .ToList();
                var tableFundsWithoutHeaders = this.fundsService
                    .GetFund_SubFunds(viewModel.EntityId)
                    .Skip(1)
                    .ToList();

                CreateTableView.AddHeadersToView(viewModel.EntitySubEntities, tableHeaders);

                CreateTableView.AddTableToView(viewModel.EntitySubEntities, tableFundsWithoutHeaders, viewModel.SearchTerm.ToLower());
            }

            if (viewModel.Entity != null && viewModel.EntitySubEntities != null)
            {
                return this.View(viewModel);
            }

            return this.View();
        }       

        [HttpPost]
        public IActionResult UploadFiles(SpecificEntityViewModel model)
        {
            var file = model.UploadFundFileBM.FileToUpload;

            if (!ModelState.IsValid || file == null || file.Length == 0)
            {
                return this.Content("File not loaded");
            }

            string networkFileLocation = @"\\Pha-sql-01\sqlexpress\FileFolder\FundFile\";
            string path = $"{networkFileLocation}{file.FileName}";

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            string streamId = this.fundsFileService.GetStreamIdFromFileName(file.FileName);
            string startConnection = model.StartConnection;
            string endConnection = model.EndConnection;

            var fileTypeDesc = model.UploadFundFileBM.FileType;
            int fileTypeId = this.context.TbDomFileType
                    .Where(s => s.FiletypeDesc == fileTypeDesc)
                    .Select(s => s.FiletypeId)
                    .FirstOrDefault();

            this.fundsFileService.AddFileToSpecificFund(
                                                streamId,
                                                model.EntityId,
                                                startConnection,
                                                endConnection,
                                                fileTypeId);

            return this.RedirectToAction("All");
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

            if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable
                    .ExtractTableAsPdf(model.EntitySubEntities, chosenDate, this.hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStream ReadPdfFile(SpecificEntityViewModel model)
        {
            FileStream fs = null;

            var path = this.fundsFileService.LoadFileToDisplay(model.EntityId, model.ChosenDate);

            if (this.HttpContext.Request.Form.ContainsKey("read_Pdf"))
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            }

            return fs;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Funds/EditFund/{EntityId}")]
        public IActionResult EditFund(int entityId)
        {
            EditFundBindingModel model = new EditFundBindingModel
            {
                EntityProperties = this.fundsService.GetFundWithDateById(entityId),
                InitialDate = DateTime.Today,
                FundId = entityId,
            };

            SetModelValuesForEditView(model);

            SetViewDataValuesForFundSelectLists();

            this.ModelState.Clear();
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditFund(EditFundBindingModel model)
        {
            string returnUrl = "/Funds/All";

            model.EntityProperties = this.fundsService.GetFundWithDateById(model.FundId);
            SetViewDataValuesForFundSelectLists();

            if (!this.ModelState.IsValid)
            {
                return this.View(model ?? new EditFundBindingModel());
            }

            string initialDate = model.InitialDate.ToString("yyyyMMdd");

            if (this.HttpContext.Request.Form.ContainsKey("update_button"))
            {
                int fundId = model.FundId;
                string fundName = model.FundName;
                string cssfCode = model.CSSFCode;
                int fStatusId = this.context.TbDomFStatus
                    .Where(s => s.StFDesc == model.FStatus)
                    .Select(s => s.StFId)
                    .FirstOrDefault();
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
                string faCode = model.FACode;
                string depCode = model.DEPCode;
                string taCode = model.TACode;

                // Split to take only companyTypeDesc for comparing

                string companyTypeDesc = model.CompanyTypeDesc.Split(" - ").FirstOrDefault();
                int fCompanyTypeId = this.context.TbDomCompanyType
                    .Where(ct => ct.CtDesc == companyTypeDesc)
                    .Select(ct => ct.CtId)
                    .FirstOrDefault();
                string tinNumber = model.TinNumber;
                string leiCode = model.LEICode;
                string regNumber = model.RegNumber;

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

            model.ExistingFundNames = this.fundsService.GetAllFundsNames();

            if (!this.ModelState.IsValid || model.ExistingFundNames.Any(f => f == model.FundName))
            {
                return this.View(model ?? new CreateFundBindingModel());
            }

            string initialDate = model.InitialDate.ToString("yyyyMMdd");
            string endDate = model.EndDate?.ToString("yyyyMMdd");

            if (this.HttpContext.Request.Form.ContainsKey("create_button"))
            {
                string fundName = model.FundName;
                string cssfCode = model.CSSFCode;
                int fStatusId = this.context.TbDomFStatus
                    .Where(s => s.StFDesc == model.FStatus)
                    .Select(s => s.StFId)
                    .FirstOrDefault();
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
                string faCode = model.FACode;
                string depCode = model.DEPCode;
                string taCode = model.TACode;

                // Split to take only companyTypeDesc for comparing

                string companyTypeDesc = model.CompanyTypeDesc.Split(" - ").FirstOrDefault();
                int fCompanyTypeId = this.context.TbDomCompanyType
                    .Where(ct => ct.CtDesc == companyTypeDesc)
                    .Select(ct => ct.CtId)
                    .FirstOrDefault();
                string tinNumber = model.TinNumber;
                string leiCode = model.LEICode;
                string regNumber = model.RegNumber;

                this.fundsService.CreateFund(initialDate, endDate, fundName, cssfCode, fStatusId, fLegalFormId,
                                             fLegalTypeId, fLegalVehicleId, faCode, depCode, taCode, fCompanyTypeId,
                                             tinNumber, leiCode, regNumber);
            }


            return this.LocalRedirect(returnUrl);
        }

        private void SetModelValuesForSpecificView(SpecificEntityViewModel model)
        {
            model.Entity = this.fundsService.GetFundById(model.EntityId);
            model.EntitySubEntities = this.fundsService.GetFund_SubFunds(model.EntityId);
            model.FileNameToDisplay = GetFileNameFromFilePath(model.EntityId, model.ChosenDate);
            model.EntityTimeline = this.fundsService.GetFundTimeline(model.EntityId);
            model.EntityDocuments = this.fundsService.GetAllFundDocumens(model.EntityId);
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
            this.ViewData["FStatusList"] = this.fundsSelectListService.GetAllTbDomFStatus();
            this.ViewData["LegalFormList"] = this.fundsSelectListService.GetAllTbDomLegalForm();
            this.ViewData["LegalVehicleList"] = this.fundsSelectListService.GetAllTbDomLegalVehicle();
            this.ViewData["LegalTypeList"] = this.fundsSelectListService.GetAllTbDomLegalType();
            this.ViewData["CompanyTypeDescList"] = this.fundsSelectListService.GetAllTbDomCompanyDesc();
        }

        private string GetFileNameFromFilePath(int entityId, string chosenDate)
        {
            return this.fundsFileService.LoadFileToDisplay(entityId, chosenDate).Split('\\').Last();
        }
    }
}