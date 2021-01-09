// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Files;
    using DataGate.Web.Infrastructure.Attributes.Validation;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.Infrastructure.Filters;
    using DataGate.Web.InputModels.Files;
    using DataGate.Web.Utilities.Extract;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class MediaController : BaseController
    {
        private readonly IWebHostEnvironment environment;
        private readonly IFileService service;

        public MediaController(
                    IWebHostEnvironment environment,
                    IFileService fileService)
        {
            this.environment = environment;
            this.service = fileService;
        }

        [HttpPost, AjaxOnly]
        [ValidateAntiForgeryToken]
        public JsonResult GenerateReport(DownloadInputModel model)
        {
            if (model.TableValues != null && model.TableValues.Count > 0)
            {
                string fileName = string.Empty;
                IEnumerable<string> tableHeaders = model.TableValues.FirstOrDefault();

                if (model.Command == GlobalConstants.CommandExtractExcel)
                {
                    fileName = GenerateFileTemplate.Excel(tableHeaders, model.TableValues, model.ControllerName);
                }
                else if (model.Command == GlobalConstants.CommandExtractPdf)
                {
                    if (tableHeaders.ToList().Count > GlobalConstants.AllowedColumnsInPdfView)
                    {
                        var tableValues = new List<string[]>();
                        foreach (var row in model.TableValues)
                        {
                            var tableRow = row.Take(GlobalConstants.AllowedColumnsInPdfView).ToArray();
                            tableValues.Add(tableRow);
                        }

                        model.TableValues = tableValues;
                        tableHeaders = model.TableValues.FirstOrDefault();
                    }

                    var date = DateTimeExtensions.FromWebFormat(model.Date);
                    fileName = GenerateFileTemplate.Pdf(tableHeaders, model.TableValues, date, model.ControllerName);
                }

                return this.Json(new { success = true, fileName = fileName });
            }

            return this.Json(new { success = false });
        }

        [HttpGet, AjaxOnly]
        [DeleteFileAttribute]
        public IActionResult Download(string fileName)
        {
            string fullPath = Path.Combine(Path.GetTempPath(), fileName);

            string streamMimeType = Path.GetExtension(fileName) == GlobalConstants.ExcelFileExtension ?
                                    GlobalConstants.ExcelStreamMimeType : GlobalConstants.PdfStreamMimeType;

            return this.PhysicalFile(fullPath, streamMimeType, fileName);
        }

        [HttpPost]
        [Route("media/{name}")]
        public IActionResult Read(string docValue, string agrValue, string areaName)
        {
            if (!string.IsNullOrEmpty(areaName))
            {
                string path = this.GetTargetPath(ref docValue, agrValue, areaName);
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                FileStreamResult fileStreamResult = new FileStreamResult(fileStream, $"{GlobalConstants.PdfStreamMimeType}");

                if (fileStreamResult != null)
                {
                    return fileStreamResult;
                }
            }

            return this.RedirectToRoute(EndpointsConstants.RouteAll + EndpointsConstants.FundsController);
        }

        [ValidateAntiForgeryToken]
        [Route("media/delete")]
        [AjaxOnly]
        public async Task<JsonResult> Delete(int fileId, string docValue, string agrValue, string areaName)
        {
            if (!string.IsNullOrEmpty(areaName))
            {
                string path = this.GetTargetPath(ref docValue, agrValue, areaName);

                if (System.IO.File.Exists(path))
                {
                    if (string.IsNullOrEmpty(agrValue))
                    {
                        await this.service.DeleteDocument(fileId, areaName);
                    }
                    else
                    {
                        await this.service.DeleteAgreement(fileId, areaName);
                    }

                    System.IO.File.Delete(path);
                    return this.Json(new { fileId = fileId });
                }
            }

            return this.Json(new { fileId = "false" });
        }

        private string GetTargetPath(ref string docValue, string agrValue, string areaName)
        {
            string targetLocation;
            if (string.IsNullOrEmpty(docValue))
            {
                targetLocation = "Agreement";
                docValue = agrValue;
            }
            else
            {
                targetLocation = areaName;
            }

            string fileLocation = Path.Combine(this.environment.WebRootPath, @$"FileFolder\{targetLocation}\");
            string path = $"{fileLocation}{docValue}";
            return path;
        }
    }
}
