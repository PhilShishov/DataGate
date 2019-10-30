
namespace Pharus.App.Utilities
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;

    using OfficeOpenXml;

    using iText.Kernel.Pdf;
    using iText.Kernel.Geom;
    using iText.Layout;
    using iText.IO.Image;
    using iText.Layout.Element;
    using System.Globalization;

    public class ExtractTable
    {
        private const string ActiveFunds = "ActiveFunds";
        private const string ActiveSubFunds = "ActiveSubFunds";
        private const string ActiveShareClasses = "ActiveShareClasses";

        public static FileStreamResult ExtractTableAsExcel(List<string[]> funds, string typeName)
        {
            FileStreamResult fileStreamResult;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = null;

                var correctTypeName = typeName == "ActiveFundsViewModel" ? ActiveFunds : typeName == "SpecificFundViewModel" ?
                                                   ActiveSubFunds : ActiveShareClasses;

                worksheet = package.Workbook.Worksheets.Add($"{correctTypeName}");

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
                    FileDownloadName = $"{correctTypeName}.xlsx"
                };

                return fileStreamResult;
            }
        }

        public static FileStreamResult ExtractTableAsPdf(List<string[]> funds, DateTime? chosenDate, IHostingEnvironment _hostingEnvironment, string typeName)
        {
            var correctTypeName = typeName == "ActiveFundsViewModel" ? 
                                  ActiveFunds : typeName == "SpecificFundViewModel" ?
                                  ActiveSubFunds : ActiveShareClasses;

            FileStreamResult fileStreamResult;
            Stream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            writer.SetCloseStream(false);

            PdfDocument pdfDoc = new PdfDocument(writer);

            pdfDoc.AddNewPage(PageSize.A4.Rotate());
            Document document = new Document(pdfDoc);

            string sfile = _hostingEnvironment.WebRootPath + "/images/Logo_Pharus_small.jpg";
            ImageData data = ImageDataFactory.Create(sfile);

            Image img = new Image(data);

            Table table = new Table(funds[0].Length);
            table.SetFontSize(10);

            for (int row = 0; row < 1; row++)
            {
                for (int col = 0; col < funds[0].Length; col++)
                {
                    string s = funds[row][col];
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

            for (int row = 1; row < funds.Count; row++)
            {
                for (int col = 0; col < funds[0].Length; col++)
                {
                    string s = funds[row][col];
                    if (s == null)
                    {
                        s = " ";
                    }

                    table.AddCell(new Paragraph(s));
                }
            }

            document.Add(img);
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph($"List of {correctTypeName} as of " + chosenDate?.ToString("dd MMMM yyyy")));
            document.Add(new Paragraph(" "));
            document.Add(table);
            document.Close();

            stream.Position = 0;
            fileStreamResult = new FileStreamResult(stream, "application/pdf")
            {
                FileDownloadName = $"{correctTypeName}.pdf"
            };
            return fileStreamResult;
        }
    }
}
