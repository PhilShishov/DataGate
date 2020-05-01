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
    using System.Linq;

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
        private const string ActiveFunds = "ActiveFunds";
        private const string ActiveSubFunds = "ActiveSubFunds";
        private const string ActiveShareClasses = "ActiveShareClasses";

        private const string ModelTypeNameToBeChecked = "EntitiesViewModel";

        // ________________________________________________________
        //
        // Extract table data as Excel
        // and preparing for download
        // in controller as filestreamresult
        public static FileStreamResult Excel(
                                                           List<string[]> entities,
                                                           string typeName,
                                                           string controllerName)
        {
            FileStreamResult fileStreamResult;

            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = null;
                string correctTypeName = GetCorrectTypeName(typeName, controllerName);

                worksheet = package.Workbook.Worksheets.Add($"{correctTypeName}");

                var tableHeaders = entities.Take(1);

                int counter = 0;

                foreach (var tableHeader in tableHeaders)
                {
                    foreach (var headerValue in tableHeader)
                    {
                        counter++;
                        worksheet.Cells[1, counter].Value = headerValue;
                    }
                }

                for (int row = 1; row < entities.Count; row++)
                {
                    for (int col = 0; col < entities[row].Length; col++)
                    {
                        worksheet.Cells[row + 1, col + 1].Value = Convert.ToString(entities[row][col]);
                    }
                }

                package.Save();

                MemoryStream stream = new MemoryStream();

                package.SaveAs(stream);
                stream.Position = 0;

                fileStreamResult = new FileStreamResult(stream, GlobalConstants.ExcelStreamMimeType)
                {
                    FileDownloadName = $"{correctTypeName}{GlobalConstants.ExcelFileExtension}",
                };

                return fileStreamResult;
            }
        }

        // ________________________________________________________
        //
        // Extract table data as PDF
        // and preparing for download
        // in controller as filestreamresult
        public static FileStreamResult Pdf(
                                                         List<string[]> entities,
                                                         DateTime? chosenDate,
                                                         string typeName,
                                                         string controllerName)
        {
            string correctTypeName = GetCorrectTypeName(typeName, controllerName);

            int tableLength = entities[0].Length;

            FileStreamResult fileStreamResult;
            Stream stream = new MemoryStream();
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

            for (int row = 0; row < 1; row++)
            {
                for (int col = 0; col < entities[0].Length; col++)
                {
                    string input = entities[row][col];
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
            document.Add(new Paragraph($"List of {correctTypeName} as of " + chosenDate?.ToString(GlobalConstants.PDfDateTimeFormatDisplay)));
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
        // based on controller and
        // view model name
        private static string GetCorrectTypeName(string typeName, string controllerName)
        {
            string correctTypeName = string.Empty;

            if (controllerName == GlobalConstants.FundsControllerName)
            {
                correctTypeName = typeName == ModelTypeNameToBeChecked ? ActiveFunds : ActiveSubFunds;
            }
            else if (controllerName == GlobalConstants.SubFundsControllerName)
            {
                correctTypeName = typeName == ModelTypeNameToBeChecked ? ActiveSubFunds : ActiveShareClasses;
            }
            else if (controllerName == GlobalConstants.ShareClassesControllerName)
            {
                correctTypeName = ActiveShareClasses;
            }

            return correctTypeName;
        }
    }
}
