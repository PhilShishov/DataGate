namespace Pharus.App.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Data;
    using Pharus.Services.Contracts;
    using Pharus.App.Utilities;
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

        [HttpGet]
        public IActionResult All()
        {
            var model = new EntitiesViewModel
            {
                Entities = new List<string[]>(),
                IsActive = true,
            };

            GetAllEntitiesWithHeaders.GetAllActiveFundsWithHeaders(model, this.fundsService);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All(EntitiesViewModel model)
        {
            this.ModelState.Clear();
            GetAllEntitiesWithHeaders.GetAllActiveFundsWithHeaders(model, this.fundsService);

            if (model.Command.Equals("Update Table"))
            {
                if (model.ChosenDate != null)
                {
                    if (model.IsActive)
                    {
                        GetAllEntitiesWithHeaders.GetAllActiveFundsWithHeaders(model, this.fundsService);
                    }
                    else
                    {
                        model.Entities = this.fundsService.GetAllActiveFunds(model.ChosenDate);
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
                    .GetAllActiveFunds(model.ChosenDate)
                    .Take(1)
                    .ToList();
                List<string[]> tableFundsWithoutHeaders = null;

                if (model.IsActive)
                {
                    tableFundsWithoutHeaders = this.fundsService
                        .GetAllActiveFunds(model.ChosenDate)
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
        public FileStreamResult ExtractPdfEntities(EntitiesViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable
                    .ExtractTableAsPdf(model.Entities, model.ChosenDate, this.hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable
                    .ExtractTableAsPdf(model.EntitySubEntities, model.ChosenDate, this.hostingEnvironment, typeName, controllerName);
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

        [HttpGet("Funds/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(int entityId)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                EntityId = entityId,
                Entity = this.fundsService.GetActiveFundById(entityId),
                EntitySubEntities = this.fundsService.GetFund_SubFunds(entityId),
            };

            HttpContext.Session.SetString("entityId", Convert.ToString(entityId));

            return this.View(viewModel);
        }

        [HttpPost("Funds/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(SpecificEntityViewModel viewModel)
        {
            viewModel.Entity = this.fundsService.GetActiveFundById(viewModel.EntityId);
            viewModel.EntitySubEntities = this.fundsService.GetFund_SubFunds(viewModel.EntityId);

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.Entity = this.fundsService
                        .GetActiveFundById(viewModel.ChosenDate, viewModel.EntityId);
                    viewModel.EntitySubEntities = this.fundsService
                        .GetFund_SubFunds(viewModel.ChosenDate, viewModel.EntityId);
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

        [HttpGet("Funds/EditFund/{EntityId}")]
        public IActionResult EditFund(int entityId)
        {
            FundBindingModel model = new FundBindingModel
            {
                EntityProperties = this.fundsService.GetActiveFundWithDateById(entityId),
                ChosenDate = DateTime.Today,
                FId = entityId,
            };

            this.ViewData["FStatusList"] = this.fundsSelectListService.GetAllTbDomFStatus();
            this.ViewData["LegalFormList"] = this.fundsSelectListService.GetAllTbDomLegalForm();
            this.ViewData["LegalVehicleList"] = this.fundsSelectListService.GetAllTbDomLegalVehicle();
            this.ViewData["LegalTypeList"] = this.fundsSelectListService.GetAllTbDomLegalType();
            this.ViewData["CompanyTypeDescList"] = this.fundsSelectListService.GetAllTbDomCompanyDesc();
            this.ViewData["CompanyAcronymList"] = this.fundsSelectListService.GetAllTbDomCompanyAcronym();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult EditFund(FundBindingModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //    return View(model ?? new EditFundBindingModel());
            // }
            string returnUrl = $"/Funds/All";
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

                this.fundsService.ExecuteEditFund(entityValues, fundId, chosenDate, fStatusId, fLegalFormId, fLegalTypeId, fLegalVehicleId, fCompanyTypeId);
            }

            return this.LocalRedirect(returnUrl);
        }

        [HttpGet]
        public IActionResult CreateFund()
        {
            FundBindingModel model = new FundBindingModel
            {
                EntityProperties = this.fundsService.GetAllActiveFunds(),
                ChosenDate = DateTime.Today,
            };

            this.ViewData["FStatusList"] = this.fundsSelectListService.GetAllTbDomFStatus();
            this.ViewData["LegalFormList"] = this.fundsSelectListService.GetAllTbDomLegalForm();
            this.ViewData["LegalVehicleList"] = this.fundsSelectListService.GetAllTbDomLegalVehicle();
            this.ViewData["LegalTypeList"] = this.fundsSelectListService.GetAllTbDomLegalType();
            this.ViewData["CompanyTypeDescList"] = this.fundsSelectListService.GetAllTbDomCompanyDesc();
            this.ViewData["CompanyAcronymList"] = this.fundsSelectListService.GetAllTbDomCompanyAcronym();

            return this.View(model);
        }
    }
}