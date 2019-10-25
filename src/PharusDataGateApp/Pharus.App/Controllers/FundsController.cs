namespace Pharus.App.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.App.Utilities;
    using Pharus.Services.Contracts;
    using Pharus.App.Models.ViewModels.Funds;

    [Authorize]
    public class FundsController : Controller
    {
        private readonly IFundsService fundsService;

        public FundsController(IFundsService fundsService)
        {
            this.fundsService = fundsService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new ActiveFundsViewModel
            {
                ActiveFunds = this.fundsService.GetAllActiveFunds()
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All(ActiveFundsViewModel viewModel)
        {
            viewModel.ActiveFunds = this.fundsService.GetAllActiveFunds();

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.ActiveFunds = this.fundsService.GetAllActiveFunds(viewModel.ChosenDate);
                }
            }

            else if (viewModel.Command.Equals("Filter"))
            {
                if (viewModel.SearchString == null)
                {
                    return this.View(viewModel);
                }

                viewModel.ActiveFunds = new List<string[]>();

                var tableHeaders = this.fundsService.GetAllActiveFunds().Take(1).ToList();
                var tableFundsWithoutHeaders = this.fundsService.GetAllActiveFunds().Skip(1).ToList();

                CreateTableView.AddHeadersToView(viewModel.ActiveFunds, tableHeaders);

                CreateTableView.AddTableToView(viewModel.ActiveFunds, tableFundsWithoutHeaders, viewModel.SearchString.ToLower());
            }

            if (viewModel.ActiveFunds != null)
            {
                return this.View(viewModel);
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult ExtractUpload(ActiveFundsViewModel viewModel)
        {
            FileStreamResult fileStreamResult = null;

            if (HttpContext.Request.Form.ContainsKey("excel_button"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(viewModel.ActiveFunds);
            }

            else if (HttpContext.Request.Form.ContainsKey("command_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(viewModel.ActiveFunds);               
            }

            if (fileStreamResult != null)
            {
                return fileStreamResult;
            }
            return this.View();
        }

        [HttpGet("Funds/View/{fundId}")]
        public IActionResult View(int fundId)
        {
            SpecificFundViewModel viewModel = new SpecificFundViewModel
            {
                FundID = fundId,
                ActiveFund = this.fundsService.GetActiveFundById(fundId),
                AFSubFunds = this.fundsService.GetFundSubFunds(fundId)
            };

            return this.View(viewModel);
        }

        [HttpPost("Funds/View/{fundId}")]
        public IActionResult Update(SpecificFundViewModel viewModel)
        {
            viewModel.ActiveFund = this.fundsService.GetActiveFundById(viewModel.FundID);
            viewModel.AFSubFunds = this.fundsService.GetFundSubFunds(viewModel.FundID);

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.ActiveFund = this.fundsService.GetActiveFundById(viewModel.ChosenDate, viewModel.FundID);
                }
            }

            //else if (viewModel.Command.Equals("Filter"))
            //{
            //    if (viewModel.SearchString == null)
            //    {
            //        return this.View(viewModel);
            //    }

            //    viewModel.ActiveFunds = new List<string[]>();

            //    AddHeadersToView(viewModel.ActiveFunds);

            //    AddTableToView(viewModel.ActiveFunds, viewModel.SearchString.ToLower());
            //}

            if (viewModel.ActiveFund != null && viewModel.AFSubFunds != null)
            {
                return this.View(viewModel);
            }

            return this.View();
        }
    }
}