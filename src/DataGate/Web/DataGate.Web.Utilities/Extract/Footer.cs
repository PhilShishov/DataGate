// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Utility class for extracting table data
// as PDF and Excel

// Created: 10/2020
// Author:  Philip Shishov
// NugetPackages : itext7 7.1.13, epplus 5.5.0

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.Utilities.Extract
{
    using iText.Kernel.Events;
    using iText.Kernel.Geom;
    using iText.Kernel.Pdf;
    using iText.Kernel.Pdf.Canvas;
    using iText.Kernel.Pdf.Xobject;
    using iText.Layout;
    using iText.Layout.Element;
    using iText.Layout.Properties;

    public partial class GenerateFileTemplate
    {
        // Footer event handler
        protected class Footer : IEventHandler
        {
            private readonly PdfFormXObject placeholder;
            private readonly float side = 20;
            private readonly float x = 1140;
            private readonly float y = 25;
            private readonly float space = 4.5f;
            private readonly float descent = 3;

            public Footer()
            {
                this.placeholder = new PdfFormXObject(new Rectangle(0, 0, this.side, this.side));
            }

            public void HandleEvent(Event ev)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)ev;
                PdfDocument pdf = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();
                int pageNumber = pdf.GetPageNumber(page);
                Rectangle pageSize = page.GetPageSize();

                // Creates drawing canvas
                PdfCanvas pdfCanvas = new PdfCanvas(page);
                Canvas canvas = new Canvas(pdfCanvas, pageSize);

                Paragraph p = new Paragraph()
                        .Add("Page ")
                        .Add(pageNumber.ToString())
                        .Add(" of ");

                canvas.ShowTextAligned(p, this.x, this.y, TextAlignment.RIGHT);
                canvas.Close();

                // Create placeholder object to write number of pages
                pdfCanvas.AddXObjectAt(this.placeholder, this.x + this.space, this.y - this.descent);
                pdfCanvas.Release();
            }

            public void WriteTotal(PdfDocument pdf)
            {
                Canvas canvas = new Canvas(this.placeholder, pdf);
                canvas.ShowTextAligned(
                    pdf.GetNumberOfPages().ToString(),
                    0, this.descent, TextAlignment.LEFT);
                canvas.Close();
            }
        }
    }
}
