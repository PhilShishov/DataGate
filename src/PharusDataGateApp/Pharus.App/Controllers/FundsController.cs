﻿namespace Pharus.App.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Data;
    using Pharus.App.Utilities;
    using Pharus.Services.Contracts;
    using Pharus.App.Models.ViewModels.Entities;
    using Pharus.App.Models.BindingModels.Funds;

    [Authorize]
    public class FundsController : Controller
    {
        private readonly Pharus_vFinaleContext _context;
        private readonly IFundsService fundsService;
        private readonly IFundsSelectListService fundsSelectListService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FundsController(IFundsService fundsService,
            IFundsSelectListService fundsSelectListService,
            IHostingEnvironment hostingEnvironment,
            Pharus_vFinaleContext context)
        {
            this._context = context;
            this.fundsService = fundsService;
            this.fundsSelectListService = fundsSelectListService;
            this._hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new ActiveEntitiesViewModel
            {
                ActiveEntities = this.fundsService
                                    .GetAllActiveFunds()
                                    .Where(f => f.Contains("Active"))
                                    .ToList()
            };

            return this.View(model);
        }    

        [HttpPost]
        public IActionResult All(ActiveEntitiesViewModel model)
        {
            ModelState.Clear();
            model.ActiveEntities = this.fundsService.GetAllActiveFunds()
                                                    .Where(f => f.Contains("Active"))
                                                    .ToList(); ;

            if (model.Command.Equals("Update Table"))
            {
                if (model.ChosenDate != null)
                {
                    model.ActiveEntities = this.fundsService.GetAllActiveFunds(model.ChosenDate)
                                                        .Where(f => f.Contains("Active"))
                                                        .ToList();
                }
            }

            else if (model.Command.Equals("Search"))
            {
                if (model.SearchString == null)
                {
                    return this.View(model);
                }

                model.ActiveEntities = new List<string[]>();

                var tableHeaders = this.fundsService.GetAllActiveFunds().Take(1).ToList();
                var tableFundsWithoutHeaders = this.fundsService.GetAllActiveFunds()
                                                    .Skip(1)
                                                    .ToList()
                                                    .Where(f => f.Contains("Active"))
                                                    .ToList();

                CreateTableView.AddHeadersToView(model.ActiveEntities, tableHeaders);

                CreateTableView.AddTableToView(model.ActiveEntities, tableFundsWithoutHeaders, model.SearchString.ToLower());
            }

            if (model.ActiveEntities != null)
            {
                return this.View(model);
            }

            return this.View();
        }

        [HttpPost]
        public FileStreamResult ExtractExcelEntities(ActiveEntitiesViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (HttpContext.Request.Form.ContainsKey("extract_Excel"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(model.ActiveEntities, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractExcelSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (HttpContext.Request.Form.ContainsKey("extract_Excel"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(model.AESubEntities, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfEntities(ActiveEntitiesViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.ActiveEntities, model.ChosenDate, _hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.AESubEntities, model.ChosenDate, _hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpGet("Funds/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(int entityId)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                EntityId = entityId,
                ActiveEntity = this.fundsService.GetActiveFundById(entityId),
                AESubEntities = this.fundsService.GetFundSubFunds(entityId)
            };

            return this.View(viewModel);
        }

        [HttpPost("Funds/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(SpecificEntityViewModel viewModel)
        {
            viewModel.ActiveEntity = this.fundsService.GetActiveFundById(viewModel.EntityId);
            viewModel.AESubEntities = this.fundsService.GetFundSubFunds(viewModel.EntityId);

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.ActiveEntity = this.fundsService.GetActiveFundById(viewModel.ChosenDate, viewModel.EntityId);
                }
            }

            else if (viewModel.Command.Equals("Filter"))
            {
                if (viewModel.SearchString == null)
                {
                    return this.View(viewModel);
                }

                viewModel.AESubEntities = new List<string[]>();

                var tableHeaders = this.fundsService.GetFundSubFunds(viewModel.EntityId).Take(1).ToList();
                var tableFundsWithoutHeaders = this.fundsService.GetFundSubFunds(viewModel.EntityId).Skip(1).ToList();

                CreateTableView.AddHeadersToView(viewModel.AESubEntities, tableHeaders);

                CreateTableView.AddTableToView(viewModel.AESubEntities, tableFundsWithoutHeaders, viewModel.SearchString.ToLower());
            }

            if (viewModel.ActiveEntity != null && viewModel.AESubEntities != null)
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
                FId = entityId
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
            //if (!ModelState.IsValid)
            //{
            //    return View(model ?? new EditFundBindingModel());
            //}

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

            if (HttpContext.Request.Form.ContainsKey("update_button"))
            {
                int fundId = model.FId;
                int fStatusId = this._context.TbDomFStatus.Where(s => s.StFDesc == model.FStatus).Select(s => s.StFId).FirstOrDefault();
                int fLegalFormId = this._context.TbDomLegalForm.Where(lf => lf.LfAcronym == model.LegalForm).Select(lf => lf.LfId).FirstOrDefault();
                int fLegalVehicleId = this._context.TbDomLegalVehicle.Where(lv => lv.LvAcronym == model.LegalVehicle).Select(lv => lv.LvId).FirstOrDefault();
                int fLegalTypeId = this._context.TbDomLegalType.Where(lt => lt.LtAcronym == model.LegalType).Select(lt => lt.LtId).FirstOrDefault();
                int fCompanyTypeId = this._context.TbDomCompanyType.Where(ct => ct.CtAcronym == model.CompanyAcronym).Select(ct => ct.CtId).FirstOrDefault();

                this.fundsService.ExecuteEditFund(entityValues, fundId, chosenDate, fStatusId, fLegalFormId, fLegalTypeId, fLegalVehicleId, fCompanyTypeId);

                return LocalRedirect(returnUrl);
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