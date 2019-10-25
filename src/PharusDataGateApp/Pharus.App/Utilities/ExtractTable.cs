
namespace Pharus.App.Utilities
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using OfficeOpenXml;

    public class ExtractTable
    {
        public static FileStreamResult ExtractTableAsExcel(List<string[]> funds)
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

        public static FileStreamResult ExtractTableAsPdf(List<string[]> funds)
        {
            throw new NotImplementedException();

            //            MemoryStream ms = new MemoryStream();

            //            byte[] byteInfo = pdf.Output();
            //            ms.Write(byteInfo, 0, byteInfo.Length);
            //            ms.Position = 0;

            //            HttpContext.Response.Headers.Add("content-disposition",
            //"attachment; filename=form.pdf");

            //            return new FileStreamResult(ms, "application/pdf");
        }
    }
}
