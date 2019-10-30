namespace Pharus.App.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.App.Utilities;
    using Pharus.Services.Contracts;
    using Pharus.App.Models.ViewModels.Funds;
    using Pharus.App.Models.BindingModels.Funds;


    [Authorize]
    public class FundsController : Controller
    {
        private readonly IFundsService fundsService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FundsController(IFundsService fundsService,
            IHostingEnvironment hostingEnvironment)
        {
            this.fundsService = fundsService;
            this._hostingEnvironment = hostingEnvironment;
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
        public IActionResult All(ActiveFundsViewModel model)
        {
            model.ActiveFunds = this.fundsService.GetAllActiveFunds();

            if (model.Command.Equals("Update Table"))
            {
                if (model.ChosenDate != null)
                {
                    model.ActiveFunds = this.fundsService.GetAllActiveFunds(model.ChosenDate);
                }
            }

            else if (model.Command.Equals("Filter"))
            {
                if (model.SearchString == null)
                {
                    return this.View(model);
                }

                model.ActiveFunds = new List<string[]>();

                var tableHeaders = this.fundsService.GetAllActiveFunds().Take(1).ToList();
                var tableFundsWithoutHeaders = this.fundsService.GetAllActiveFunds().Skip(1).ToList();

                CreateTableView.AddHeadersToView(model.ActiveFunds, tableHeaders);

                CreateTableView.AddTableToView(model.ActiveFunds, tableFundsWithoutHeaders, model.SearchString.ToLower());
            }

            if (model.ActiveFunds != null)
            {
                return this.View(model);
            }

            return this.View();
        }

        [HttpPost]
        public FileStreamResult ExtractExcel(ActiveFundsViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            if (HttpContext.Request.Form.ContainsKey("extract_Excel"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(model.ActiveFunds);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdf(ActiveFundsViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            if (HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model, _hostingEnvironment);
            }

            return fileStreamResult;
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