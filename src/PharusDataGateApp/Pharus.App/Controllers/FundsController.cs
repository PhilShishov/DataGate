namespace Pharus.App.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using OfficeOpenXml;

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
            FileStreamResult fileStreamResult = null;

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.ActiveFunds = this.fundsService.GetAllActiveFunds(viewModel.ChosenDate);
                }
                else
                {
                    viewModel.ActiveFunds = this.fundsService.GetAllActiveFunds();
                }                
            }

            else if (viewModel.Command.Equals("Extract Table As Excel"))
            {
                fileStreamResult = ExtractTableAsExcel(viewModel.ActiveFunds);
            }

            //        else if (viewModel.Command.Equals("Extract Table As PDF"))
            //        {
            //            MemoryStream ms = new MemoryStream();

            //            byte[] byteInfo = pdf.Output();
            //            ms.Write(byteInfo, 0, byteInfo.Length);
            //            ms.Position = 0;

            //            HttpContext.Response.Headers.Add("content-disposition",
            //"attachment; filename=form.pdf");

            //            return new FileStreamResult(ms, "application/pdf");
            //        }

            else if (viewModel.Command.Equals("Filter"))
            {
                if (viewModel.SearchString == null)
                {
                    return this.View(viewModel);
                }
                ModelState.Clear();

                viewModel.ActiveFunds = new List<string[]>();

                AddHeadersToView(viewModel.ActiveFunds);

                AddTableToView(viewModel.ActiveFunds, viewModel.SearchString.ToLower());
            }

            if (fileStreamResult != null)
            {
                return fileStreamResult;
            }

            //if (Request.IsAjaxRequest())
            //{
            //    viewModel.Posts = viewModel.Posts
            //        .Where(a => a.Title.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0
            //                 || a.Message.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0
            //        );
            //    return PartialView("_Posts", viewModel.Posts);
            //}

            if (viewModel.ActiveFunds != null)
            {
                return this.View(viewModel);
            }
            else
            {
                return this.View();
            }
        }

        [HttpGet("Funds/View/{fundId}")]
        public IActionResult View(int fundId)
        {
            SpecificFundViewModel viewModel = new SpecificFundViewModel();
            viewModel.FundId = fundId;
            viewModel.ActiveFund = this.fundsService.GetActiveFundById(fundId);
            viewModel.AFSubFunds = this.fundsService.GetFundSubFunds(fundId);

            return this.View(viewModel);
        }

        //[HttpPost]
        //public IActionResult View(SpecificFundViewModel viewModel)
        //{

        //    viewModel.ActiveFund = this.fundsService.GetActiveFundById(viewModel);
        //    viewModel.AFSubFunds = this.fundsService.GetFundSubFunds(fundId);
        //}

        #region Helpers     
        private FileStreamResult ExtractTableAsExcel(List<string[]> funds)
        {
            FileStreamResult fileStreamResult;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("ActiveFunds");

                var tableHeaders = funds.Take(1);

                int counter = 0;

                foreach (var tableHeader in tableHeaders)
                {
                    foreach (var headerValue in tableHeader)
                    {
                        counter++;
                        worksheet.Cells[1, counter].Value = headerValue;
                    }
                }

                for (int row = 1; row < funds.Count; row++)
                {
                    for (int col = 0; col < funds[row].Length; col++)
                    {
                        worksheet.Cells[row + 1, col + 1].Value = Convert.ToString(funds[row][col]);
                    }
                }

                package.Save();

                MemoryStream stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                fileStreamResult = new FileStreamResult(stream, "application/excel")
                {
                    FileDownloadName = "ActiveFunds.xlsx"
                };

                return fileStreamResult;
            }
        }
        private void AddTableToView(List<string[]> activeFunds, string searchString)
        {
            var tableFundsWithoutHeaders = this.fundsService.GetAllActiveFunds().Skip(1);

            foreach (var fund in tableFundsWithoutHeaders)
            {
                foreach (var stringValue in fund)
                {
                    if (stringValue != null && stringValue.ToLower().Contains(searchString.ToLower()))
                    {
                        activeFunds.Add(fund);
                        break;
                    }
                }
            }
        }

        private void AddHeadersToView(List<string[]> activeFunds)
        {
            var tableHeaders = this.fundsService.GetAllActiveFunds().Take(1);

            foreach (var tableHeader in tableHeaders)
            {
                activeFunds.Add(tableHeader);
            }
        }
        //private static void AddColumnNamesAndRecordsToWorkSheet(ExcelWorksheet worksheet, DataSet dataSet)
        //{
        //    var columnName = dataSet.Tables[0].Columns.Cast<DataColumn>()
        //                         .Select(x => x.ColumnName)
        //                         .ToArray();
        //    int i = 0;

        //    foreach (var col in columnName)
        //    {
        //        i++;
        //        worksheet.Cells[1, i].Value = col;
        //    }

        //    int j;
        //    for (i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        //    {
        //        for (j = 0; j < dataSet.Tables[0].Columns.Count; j++)
        //        {
        //            worksheet.Cells[i + 2, j + 1].Value = Convert.ToString(dataSet.Tables[0].Rows[i][j]);
        //        }
        //    }
        //}
        #endregion
    }
}