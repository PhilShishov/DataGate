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

    using iText.Kernel.Pdf;
    using iText.Layout;
    using iText.Layout.Element;
    using iText.Kernel.Geom;
    using System;
    using iText.IO.Image;
    using Microsoft.AspNetCore.Hosting;

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
                //fileStreamResult = ExtractTable.ExtractTableAsPdf(model.ActiveFunds);
                //return new ViewAsPdf("All", model);  

                string dest = "C:/scans/sample.pdf";
                PdfWriter writer = new PdfWriter(dest);

                PdfDocument pdfDoc = new PdfDocument(writer);

                pdfDoc.AddNewPage(PageSize.A4.Rotate());
                Document document = new Document(pdfDoc);
                string sfile = _hostingEnvironment.WebRootPath + "/images/Logo_Pharus_small.jpg";
                ImageData data = ImageDataFactory.Create(sfile);

                Image img = new Image(data);
             
                //float[] pointColumnWidths = { 150F, 150F};
                Table table = new Table(model.ActiveFunds[0].Length);
                table.SetFontSize(10);

                for (int row = 0; row < 1; row++)
                {
                    for (int col = 0; col < model.ActiveFunds[0].Length; col++)
                    {
                        string s = model.ActiveFunds[row][col];
                        if (s == null)
                        {
                            s = " ";
                        }
                        Cell c1 = new Cell();
                        c1.Add(new Paragraph(s));
                        c1.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        c1.SetBold();
                        table.AddHeaderCell(c1);
                    }
                }
                
                for (int row = 1; row < model.ActiveFunds.Count; row++)
                {
                    for (int col = 0; col < model.ActiveFunds[0].Length; col++)
                    {
                        string s = model.ActiveFunds[row][col];
                        if (s == null)
                        {
                            s = " ";
                        }
                        
                        table.AddCell(new Paragraph(s));
                    }
                }          

                document.Add(img);
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph("LIST OF ACTIVE FUNDS AS OF " + model.ChosenDate.ToString()));
                document.Add(new Paragraph(" "));
                document.Add(table);

                document.Close();
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