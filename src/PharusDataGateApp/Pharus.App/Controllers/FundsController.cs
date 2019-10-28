namespace Pharus.App.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.App.Utilities;
    using Pharus.Services.Contracts;
    using Pharus.App.Models.ViewModels.Funds;
    using Pharus.App.Models.BindingModels.Funds;

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

        [HttpGet("Funds/ViewFundSF/{fundId}")]
        public IActionResult ViewFundSF(int fundId)
        {
            SpecificFundViewModel viewModel = new SpecificFundViewModel
            {
                FundID = fundId,
                ActiveFund = this.fundsService.GetActiveFundById(fundId),
                AFSubFunds = this.fundsService.GetFundSubFunds(fundId)
            };

            return this.View(viewModel);
        }

        [HttpPost("Funds/ViewFundSF/{fundId}")]
        public IActionResult ViewFundSF(SpecificFundViewModel viewModel)
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

            else if (viewModel.Command.Equals("Filter"))
            {
                if (viewModel.SearchString == null)
                {
                    return this.View(viewModel);
                }

                viewModel.AFSubFunds = new List<string[]>();

                var tableHeaders = this.fundsService.GetFundSubFunds(viewModel.FundID).Take(1).ToList();
                var tableFundsWithoutHeaders = this.fundsService.GetFundSubFunds(viewModel.FundID).Skip(1).ToList();

                CreateTableView.AddHeadersToView(viewModel.AFSubFunds, tableHeaders);

                CreateTableView.AddTableToView(viewModel.AFSubFunds, tableFundsWithoutHeaders, viewModel.SearchString.ToLower());
            }

            if (viewModel.ActiveFund != null && viewModel.AFSubFunds != null)
            {
                return this.View(viewModel);
            }

            return this.View();
        }

        [HttpGet("Funds/EditFund/{fundId}")]
        public IActionResult EditFund(int fundId)
        {
            EditFundBindingModel model = new EditFundBindingModel
            {
                FundProperties = this.fundsService.GetActiveFundWithDateById(fundId)
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult EditFund(EditFundBindingModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model ?? new EditFundBindingModel());
            //}

            int fundId = int.Parse(model.FundProperties[1][0]);
            string returnUrl = $"/Funds/ViewFundSF/{fundId}";

            var fund = this.fundsService.GetActiveFundById(fundId);

            if (HttpContext.Request.Form.ContainsKey("modify_button"))
            {
                for (int row = 1; row < fund.Count; row++)
                {
                    for (int col = 0; col < fund[row].Length; col++)
                    {
                        fund[row][col] = model.FundProperties[row][col];
                    }
                }

                return LocalRedirect(returnUrl);
            }

            return this.LocalRedirect(returnUrl);
        }
    }
}