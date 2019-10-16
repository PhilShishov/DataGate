namespace Pharus.App.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Office.Interop.Excel;

    using Pharus.Services.Contracts;
    using System.Data;
    using System.Linq;
    using System.Data.SqlClient;
    using Pharus.Data;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using System.Threading.Tasks;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using OfficeOpenXml;

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



        //public IActionResult ExtractDocument()
        //{
        //    //Initialize ExcelEngine.
        //    ExcelEngine excelEngine = new ExcelEngine();

        //    //Initialize Application.
        //    IApplication application = excelEngine.Excel;

        //    //Set default version for application.
        //    application.DefaultVersion = ExcelVersion.Excel2016;

        //    //Create a new workbook.
        //    IWorkbook workbook = application.Workbooks.Create(1);

        //    //Accessing first worksheet in the workbook.
        //    Worksheet worksheet = workbook.Worksheets[0];
        //    worksheet.Name = "ActiveFunds";

        //    DataSet dataSet = GetRecordsFromDatabase();

        //    //Adding text to a cell

        //    //LINQ to get Column of dataset table
        //    var columnName = dataSet.Tables[0].Columns.Cast<DataColumn>()
        //                         .Select(x => x.ColumnName)
        //                         .ToArray();
        //    int i = 0;
        //    //Adding column name to worksheet
        //    foreach (var col in columnName)
        //    {
        //        i++;
        //        worksheet.Cells[1, i] = col;
        //    }

        //    //Adding records to worksheet
        //    int j;
        //    for (i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        //    {
        //        for (j = 0; j < dataSet.Tables[0].Columns.Count; j++)
        //        {
        //            worksheet.Cells[i + 2, j + 1] = Convert.ToString(dataSet.Tables[0].Rows[i][j]);
        //        }
        //    }

        //    //Saving the file to the MemoryStream
        //    MemoryStream stream = new MemoryStream();

        //    workbook.SaveAs(stream);

        //    //If the position is not set to '0' then the file will be empty.
        //    stream.Position = 0;

        //    //Download the document in the browser.
        //    FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/excel");
        //    fileStreamResult.FileDownloadName = "ActiveFunds.xlsx";
        //    return fileStreamResult;
        //}

        [HttpPost]
        public IActionResult Export()
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"ActiveFunds.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));

            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            }
            using (ExcelPackage package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("ActiveFunds");

                DataSet dataSet = GetRecordsFromDatabase();

                //LINQ to get Column of dataset table
                var columnName = dataSet.Tables[0].Columns.Cast<DataColumn>()
                                     .Select(x => x.ColumnName)
                                     .ToArray();
                int i = 0;

                //Adding column name to worksheet
                foreach (var col in columnName)
                {
                    i++;
                    worksheet.Cells[1, i].Value = col;
                }

                //Adding records to worksheet
                int j;
                for (i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (j = 0; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = Convert.ToString(dataSet.Tables[0].Rows[i][j]);
                    }
                }

                package.Save();
            }
            return RedirectToAction("All");
        }

        //[HttpPost]
        //public IActionResult Interop()
        //{
        //    DataSet dataSet = GetRecordsFromDatabase();

        //    //Creating Object of Microsoft.Office.Interop.Excel and creating a Workbook
        //    var excelApp = new Application();
        //    excelApp.Visible = true;
        //    excelApp.Workbooks.Add();

        //    Worksheet workSheet = (Worksheet)excelApp.ActiveSheet; //creating excel worksheet
        //    workSheet.Name = "Funds"; //name of excel file

        //    //LINQ to get Column of dataset table
        //    var columnName = dataSet.Tables[0].Columns.Cast<DataColumn>()
        //                         .Select(x => x.ColumnName)
        //                         .ToArray();
        //    int i = 0;
        //    //Adding column name to worksheet
        //    foreach (var col in columnName)
        //    {
        //        i++;
        //        workSheet.Cells[1, i] = col;
        //    }

        //    //Adding records to worksheet
        //    int j;
        //    for (i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        //    {
        //        for (j = 0; j < dataSet.Tables[0].Columns.Count; j++)
        //        {
        //            workSheet.Cells[i + 2, j + 1] = Convert.ToString(dataSet.Tables[0].Rows[i][j]);
        //        }
        //    }

        //    //Saving the excel file to “e” directory
        //    workSheet.SaveAs("c:\\Funds.xlsx");
        //    return RedirectToAction("Index");
        //}

        #region Helpers     

        DataSet GetRecordsFromDatabase()
        {
            DataSet dataSet = new DataSet();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = DbConfiguration.ConnectionStringPharus_vFinale;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from fn_active_fund('20191009')";
            cmd.Connection = conn;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = cmd;
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }
        #endregion
    }
}