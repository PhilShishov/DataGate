namespace Pharus.App.Controllers
{
    using System;
    using System.IO;
    using System.Data;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using OfficeOpenXml;

    using Pharus.Services.Contracts;

    [Authorize]
    public class FundsController : Controller
    {
        private readonly IFundsService fundsService;
        private List<string[]> activeFundsView;

        public FundsController(IFundsService fundsService)
        {
            this.activeFundsView = new List<string[]>();
            this.fundsService = fundsService;
        }

        [HttpGet]
        public IActionResult All()
        {
            this.activeFundsView = this.fundsService.GetAllActiveFunds();

            return this.View(this.activeFundsView);
        }

        [HttpPost]
        public IActionResult All(List<string[]> funds, DateTime? chosenDate, string command, string searchString)
        {
            FileStreamResult fileStreamResult = null;

            if (searchString == null)
            {
                return this.View(funds);
            }

            if (command.Equals("Update Table"))
            {
                if (chosenDate != null)
                {
                    this.activeFundsView = this.fundsService.GetAllActiveFunds(chosenDate);
                }
                else
                {
                    this.activeFundsView = this.fundsService.GetAllActiveFunds();
                }
            }

            else if (command.Equals("Extract Table As Excel"))
            {
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("ActiveFunds");

                    DataSet dataSet = this.fundsService.GetAllActiveFundsWithDataSet(chosenDate);

                    AddColumnNamesAndRecordsToWorkSheet(worksheet, dataSet);

                    package.Save();

                    MemoryStream stream = new MemoryStream();
                    package.SaveAs(stream);
                    stream.Position = 0;

                    fileStreamResult = new FileStreamResult(stream, "application/excel")
                    {
                        FileDownloadName = "ActiveFunds.xlsx"
                    };
                }
            }

            else if (command.Equals("Filter"))
            {
                AddHeadersToView();

                AddTableToView(searchString);
            }

            if (fileStreamResult != null)
            {
                return fileStreamResult;
            }

            if (this.activeFundsView != null)
            {
                return this.View(this.activeFundsView);
            }
            else
            {
                return this.View();
            }
        }

        #region Helpers     
        private void AddTableToView(string searchString)
        {
            var tableFundsWithoutHeaders = this.fundsService.GetAllActiveFunds().Skip(1);

            foreach (var fund in tableFundsWithoutHeaders)
            {
                foreach (var stringValue in fund)
                {
                    if (stringValue != null && stringValue.ToLower().Contains(searchString))
                    {
                        this.activeFundsView.Add(fund);
                        break;
                    }
                }
            }
        }

        private void AddHeadersToView()
        {
            var tableHeaders = this.fundsService.GetAllActiveFunds().Take(1);

            foreach (var tableHeader in tableHeaders)
            {
                this.activeFundsView.Add(tableHeader);
            }
        }
        private static void AddColumnNamesAndRecordsToWorkSheet(ExcelWorksheet worksheet, DataSet dataSet)
        {
            var columnName = dataSet.Tables[0].Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();
            int i = 0;

            foreach (var col in columnName)
            {
                i++;
                worksheet.Cells[1, i].Value = col;
            }

            int j;
            for (i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                for (j = 0; j < dataSet.Tables[0].Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = Convert.ToString(dataSet.Tables[0].Rows[i][j]);
                }
            }
        }
        #endregion
    }
}