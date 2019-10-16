namespace Pharus.App.Controllers
{
    using System;
    using System.IO;
    using System.Data;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Authorization;

    using OfficeOpenXml;
    using Pharus.Services.Contracts;

    [Authorize]
    public class FundsController : Controller
    {
        private readonly IFundsService fundsService;
        private IHostingEnvironment _hostingEnvironment;

        public FundsController(IFundsService fundsService, IHostingEnvironment hostingEnvironment)
        {
            this.fundsService = fundsService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var activeFundsView = this.fundsService.GetAllActiveFunds();

            return View(activeFundsView);
        }

        [HttpPost]
        public IActionResult All(DateTime? chosenDate)
        {
            List<string[]> activeFundsView;

            if (chosenDate != null)
            {
                activeFundsView = this.fundsService.GetAllActiveFunds(chosenDate);
            }
            else
            {
                activeFundsView = this.fundsService.GetAllActiveFunds();
            }

            return View(activeFundsView);
        }

        [HttpPost]
        public IActionResult Export(DateTime? chosenDate)
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

                FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/excel");
                fileStreamResult.FileDownloadName = "ActiveFunds.xlsx";
                return fileStreamResult;
            }
        }

        #region Helpers     
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