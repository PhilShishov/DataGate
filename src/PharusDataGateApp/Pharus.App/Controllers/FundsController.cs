namespace Pharus.App.Controllers
{
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Data;
    using Pharus.App.Utilities;
    using Pharus.Services.Contracts;
    using Pharus.App.Models.BindingModels.Funds;
    using Pharus.App.Models.ViewModels.Entities;

    [Authorize]
    public class FundsController : Controller
    {
        private readonly Pharus_vFinaleContext context;
        private readonly IFundsService fundsService;
        private readonly IFundsSelectListService fundsSelectListService;
        private readonly IHostingEnvironment hostingEnvironment;

        public FundsController(
            IFundsService fundsService,
            IFundsSelectListService fundsSelectListService,
            IHostingEnvironment hostingEnvironment,
            Pharus_vFinaleContext context)
        {
            this.context = context;
            this.fundsService = fundsService;
            this.fundsSelectListService = fundsSelectListService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new EntitiesViewModel
            {
                Entities = new List<string[]>(),
                IsActive = true,
                ChosenDate = DateTime.Today.ToString("yyyy-MM-dd"),
            };

            GetAllActiveEntitiesUtility.GetAllActiveFundsWithHeaders(model, this.fundsService);

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
            this.ModelState.Clear();
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
                        model.Entities = this.fundsService.GetAllActiveFunds(chosenDate);
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
                    .GetAllActiveFunds(chosenDate)
                    .Take(1)
                    .ToList();
                List<string[]> tableFundsWithoutHeaders = null;

                if (model.IsActive)
                {
                    tableFundsWithoutHeaders = this.fundsService
                        .GetAllActiveFunds(chosenDate)
                        .Skip(1)
                        .Where(f => f.Contains("Active"))
                        .ToList();
                }
                else
                {
                    tableFundsWithoutHeaders = this.fundsService
                        .GetAllActiveFunds()
                        .Skip(1)
                        .ToList();
                }

                CreateTableView.AddHeadersToView(model.Entities, tableHeaders);

                CreateTableView.AddTableToView(model.Entities, tableFundsWithoutHeaders, model.SearchTerm.ToLower());
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
                Entity = this.fundsService.GetActiveFundById(entityId),
                EntitySubEntities = this.fundsService.GetFund_SubFunds(entityId),
                ChosenDate = chosenDate,
            };

            HttpContext.Session.SetString("entityId", Convert.ToString(entityId));

            return this.View(viewModel);
        }

        [HttpPost]
        [Route("Funds/ViewEntitySE/{EntityId}/{ChosenDate}")]
        public IActionResult ViewEntitySE(SpecificEntityViewModel viewModel)
        {
            viewModel.Entity = this.fundsService.GetActiveFundById(viewModel.EntityId);
            viewModel.EntitySubEntities = this.fundsService.GetFund_SubFunds(viewModel.EntityId);
            var chosenDate = DateTime.ParseExact(viewModel.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);


            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.Entity = this.fundsService
                        .GetActiveFundById(chosenDate, viewModel.EntityId);
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

        //[HttpPost]
        public FileStreamResult DownloadFile(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null; 

            if (this.HttpContext.Request.Form.ContainsKey("download_Pdf"))
            {
                this.fundsService.LoadFile();                    
            }

            return fileStreamResult;
        }

        [HttpGet("Funds/EditFund/{EntityId}")]
        public IActionResult EditFund(int entityId)
        {
            EditFundBindingModel model = new EditFundBindingModel
            {
                EntityProperties = this.fundsService.GetActiveFundWithDateById(entityId),
                ChosenDate = DateTime.Today,
                FId = entityId,
            };

            SetViewDataValuesForFundSelectLists();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult EditFund(EditFundBindingModel model)
        {
            string returnUrl = "/Funds/All";

            if (!ModelState.IsValid)
            {
                return View(model ?? new EditFundBindingModel());
            }

            List<string> entityValues = new List<string>();
            DateTime chosenDate = model.ChosenDate;

            for (int row = 1; row < model.EntityProperties.Count; row++)
            {
                for (int col = 0; col < model.EntityProperties[row].Length; col++)
                {
                    entityValues.Add(model.EntityProperties[row][col]);
                }
            }

            if (this.HttpContext.Request.Form.ContainsKey("update_button"))
            {
                int fundId = model.FId;
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
                int fCompanyTypeId = this.context.TbDomCompanyType
                    .Where(ct => ct.CtAcronym == model.CompanyAcronym)
                    .Select(ct => ct.CtId)
                    .FirstOrDefault();

                this.fundsService.EditFund(entityValues, fundId, chosenDate, fStatusId, fLegalFormId, fLegalTypeId, fLegalVehicleId, fCompanyTypeId);
            }

            return this.LocalRedirect(returnUrl);
        }

        [HttpGet]
        public IActionResult CreateFund()
        {
            this.ModelState.Clear();

            CreateFundBindingModel model = new CreateFundBindingModel
            {
                InitialDate = DateTime.Today,
            };
            SetViewDataValuesForFundSelectLists();

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFund(CreateFundBindingModel model)
        {
            string returnUrl = "/Funds/All";

            SetViewDataValuesForFundSelectLists();

            if (!this.ModelState.IsValid)
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

                int fCompanyTypeId = this.context.TbDomCompanyType
                    .Where(ct => ct.CtAcronym == model.CompanyAcronym)
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

        private void SetViewDataValuesForFundSelectLists()
        {
            this.ViewData["FStatusList"] = this.fundsSelectListService.GetAllTbDomFStatus();
            this.ViewData["LegalFormList"] = this.fundsSelectListService.GetAllTbDomLegalForm();
            this.ViewData["LegalVehicleList"] = this.fundsSelectListService.GetAllTbDomLegalVehicle();
            this.ViewData["LegalTypeList"] = this.fundsSelectListService.GetAllTbDomLegalType();
            this.ViewData["CompanyTypeDescList"] = this.fundsSelectListService.GetAllTbDomCompanyDesc();
            this.ViewData["CompanyAcronymList"] = this.fundsSelectListService.GetAllTbDomCompanyAcronym();
        }
    }
}