// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Utility class for extracting table data
// as PDF and Excel

// Created: 10/2019
// Author:  Philip Shishov
// NugetPackages : itext7 7.1.8, epplus.core 1.5.4

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using DataGate.Common;

    using iText.IO.Image;
    using iText.Kernel.Colors;
    using iText.Kernel.Events;
    using iText.Kernel.Geom;
    using iText.Kernel.Pdf;
    using iText.Kernel.Pdf.Canvas;
    using iText.Kernel.Pdf.Xobject;
    using iText.Layout;
    using iText.Layout.Element;
    using iText.Layout.Properties;

    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    // _____________________________________________________________
    public class GenerateFileTemplate
    {
        // ---------------------------------------------------------
        //
        // Names for files when created
        private const string FundsNameDisplay = "Funds";
        private const string SubFundsNameDisplay = "Sub Funds";
        private const string ShareClassesNameDisplay = "Share Classes";

        // ________________________________________________________
        //
        // Extract table data as Excel
        // and preparing for download
        // in controller as filestreamresult
        public static string Excel(
                                            IEnumerable<string> headers,
                                            List<string[]> values,
                                            string controllerName)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = null;
                string correctTypeName = GetCorrectTypeName(controllerName);

                worksheet = package.Workbook.Worksheets.Add($"{correctTypeName}");

                int counter = 0;

                foreach (var header in headers)
                {
                    counter++;
                    worksheet.Cells[1, counter].Value = header;
                    worksheet.Cells[1, counter].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, counter].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(68, 114, 196));
                    worksheet.Cells[1, counter].Style.Font.Color.SetColor(System.Drawing.Color.White);
                }

                worksheet.Cells[1, 1, 1, counter].AutoFilter = true;

                for (int row = 1; row < values.Count; row++)
                {
                    for (int col = 0; col < values[row].Length; col++)
                    {
                        worksheet.Cells[row + 1, col + 1].Value = Convert.ToString(values[row][col]);
                    }
                }

                worksheet.Cells.AutoFitColumns();
                //worksheet.Cells["A1:S1"].AutoFilter = true;
                package.Save();

                string fileName = $"{correctTypeName}{GlobalConstants.ExcelFileExtension}";
                using (var stream = new MemoryStream())
                {
                    package.SaveAs(stream);
                    string temp = System.IO.Path.GetTempPath();

                    string fullPath = System.IO.Path.Combine(temp, fileName);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    stream.WriteTo(file);
                    file.Close();
                }

                return fileName;
            }
        }

        // ________________________________________________________
        //
        // Extract table data as PDF
        // and preparing for download
        // in controller as filestreamresult
        public static string Pdf(
                                            IEnumerable<string> headers,
                                            List<string[]> entities,
                                            DateTime? chosenDate,
                                            string controllerName)
        {
            string correctTypeName = GetCorrectTypeName(controllerName);
            int tableLength = entities[0].Length;
            string fileName = string.Empty;

            using (var stream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(stream);
                writer.SetCloseStream(false);

                PdfDocument pdfDoc = new PdfDocument(writer);

                // Funds table format settings
                pdfDoc.SetDefaultPageSize(PageSize.A3.Rotate());
                Footer footerHandler = new Footer();
                pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, footerHandler);

                // SubFunds table format settings
                // ShareClasses table format settings
                Document document = new Document(pdfDoc);

                string imageFilePath = @".\wwwroot\images\Logo_Pharus_small.jpg";
                ImageData data = ImageDataFactory.Create(imageFilePath);

                Image img = new Image(data);

                Table table = new Table(tableLength);

                table.SetWidth(UnitValue.CreatePercentValue(100));
                table.SetFontSize(10);

                foreach (var header in headers)
                {
                    string input = header;
                    if (input == null)
                    {
                        input = " ";
                    }

                    Cell cell = new Cell();
                    cell.Add(new Paragraph(input));
                    cell.SetTextAlignment(TextAlignment.CENTER);
                    cell.SetBold();

                    table.AddHeaderCell(cell);
                }

                for (int row = 1; row < entities.Count; row++)
                {
                    for (int col = 0; col < entities[0].Length; col++)
                    {
                        string input = entities[row][col];
                        if (input == null)
                        {
                            input = " ";
                        }

                        table.AddCell(new Paragraph(input));
                    }
                }

                document.Add(img);
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph($"List of {correctTypeName} as of " + chosenDate?.ToString(GlobalConstants.PdfDateTimeFormatDisplay)));
                document.Add(new Paragraph(" "));
                document.Add(table);
                document.Close();

                fileName = $"{correctTypeName}{GlobalConstants.PdfFileExtension}";
                string temp = System.IO.Path.GetTempPath();

                string fullPath = System.IO.Path.Combine(temp, fileName);
                FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                stream.WriteTo(file);
                file.Close();
            }

            return fileName;
        }

        // Footer event handler
        protected class Footer : IEventHandler
        {
            protected PdfFormXObject placeholder;
            protected float side = 20;
            protected float x = 1150;
            protected float y = 25;
            protected float space = 4.5f;
            protected float descent = 3;

            public Footer()
            {
                placeholder = new PdfFormXObject(new Rectangle(0, 0, side, side));
            }

            public void HandleEvent(Event ev)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)ev;
                PdfDocument pdf = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();
                int pageNumber = pdf.GetPageNumber(page);
                int pageCount = pdf.GetNumberOfPages();
                Rectangle pageSize = page.GetPageSize();

                // Creates drawing canvas
                PdfCanvas pdfCanvas = new PdfCanvas(page);
                Canvas canvas = new Canvas(pdfCanvas, pageSize);

                Paragraph p = new Paragraph()
                        .Add("Page ")
                        .Add(pageNumber.ToString())
                        .Add(" of ")
                        .Add(pageCount.ToString());

                canvas.ShowTextAligned(p, x, y, TextAlignment.RIGHT);
                canvas.Close();

                // Create placeholder object to write number of pages
                pdfCanvas.AddXObject(placeholder, x + space, y - descent);
                pdfCanvas.Release();
            }

            public void WriteTotal(PdfDocument pdf)
            {
                Canvas canvas = new Canvas(placeholder, pdf);
                canvas.ShowTextAligned(pdf.GetNumberOfPages().ToString(),
                        0, descent, TextAlignment.LEFT);
                canvas.Close();
            }
        }

        // ________________________________________________________
        //
        // Method for choosing the correct name
        // for file to be downloaded
        // based on controller name
        private static string GetCorrectTypeName(string controllerName)
        {
            string typeName = string.Empty;

            switch (controllerName)
            {
                case GlobalConstants.FundsControllerName:
                    typeName = FundsNameDisplay;
                    break;
                case GlobalConstants.SubFundsControllerName:
                case GlobalConstants.FundSubFundsControllerName:
                    typeName = SubFundsNameDisplay;
                    break;
                case GlobalConstants.ShareClassesControllerName:
                case GlobalConstants.SubFundShareClassesControllerName:
                    typeName = ShareClassesNameDisplay;
                    break;
            }

            return typeName;
        }
    }
}
