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
    using iText.Kernel.Geom;
    using iText.Kernel.Pdf;
    using iText.Layout;
    using iText.Layout.Element;
    using iText.Layout.Properties;

    using Microsoft.AspNetCore.Mvc;

    using OfficeOpenXml;

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
                }

                for (int row = 1; row < values.Count; row++)
                {
                    for (int col = 0; col < values[row].Length; col++)
                    {
                        worksheet.Cells[row + 1, col + 1].Value = Convert.ToString(values[row][col]);
                    }
                }

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
        public static FileStreamResult Pdf(
                                            IEnumerable<string> headers,
                                            List<string[]> entities,
                                            DateTime? chosenDate,
                                            string controllerName)
        {
            string correctTypeName = GetCorrectTypeName(controllerName);

            int tableLength = entities[0].Length;

            FileStreamResult fileStreamResult;
            var stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            writer.SetCloseStream(false);

            PdfDocument pdfDoc = new PdfDocument(writer);

            // Funds table format settings
            pdfDoc.SetDefaultPageSize(PageSize.A3.Rotate());

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

            stream.Position = 0;
            fileStreamResult = new FileStreamResult(stream, GlobalConstants.PdfStreamMimeType)
            {
                FileDownloadName = $"{correctTypeName}{GlobalConstants.PdfFileExtension}",
            };

            return fileStreamResult;
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
