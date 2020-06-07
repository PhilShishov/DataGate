namespace DataGate.Web.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public static class FileHelpers
    {
        // private static readonly byte[] AllowedChars = { };
        private static readonly Dictionary<string, List<byte[]>> FileSignature = new Dictionary<string, List<byte[]>>
        {
             { ".pdf", new List<byte[]> { new byte[] { 0x25, 0x50, 0x44, 0x46 } } },
        };

        public static async Task<string> ProcessFormFile(IFormFile formFile, ModelStateDictionary modelState,
                                                         string[] permittedExtensions, long sizeLimit, string webRootPath,
                                                         string area, bool isAgreement)
        {
            var trustedFileNameForDisplay = WebUtility.HtmlEncode(formFile.FileName);

            if (formFile.Length == 0)
            {
                modelState.AddModelError(formFile.Name, $"{trustedFileNameForDisplay} is empty.");

                return string.Empty;
            }

            if (formFile.Length > sizeLimit)
            {
                var megabyteSizeLimit = sizeLimit / 1048576;
                modelState.AddModelError(formFile.Name, $"{trustedFileNameForDisplay} exceeds {megabyteSizeLimit:N1} MB.");

                return string.Empty;
            }

            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);

                if (!IsValidFileExtensionAndSignature(formFile.FileName, memoryStream, permittedExtensions))
                {
                    modelState.AddModelError(formFile.Name, $"{trustedFileNameForDisplay} file type/signature doesn't match.");
                    return string.Empty;
                }
            }

            string targetLocation = GetTargetPath(isAgreement, area);

            string fileLocation = Path.Combine(webRootPath, @$"FileFolder\{targetLocation}\");
            string path = $"{fileLocation}{formFile.FileName}";
            if (File.Exists(path))
            {
                modelState.AddModelError(formFile.Name, $"{trustedFileNameForDisplay} already exists!");
                return string.Empty;
            }

            return path;
        }

        private static string GetTargetPath(bool isAgreement, string area)
        {
            string targetLocation;
            if (isAgreement)
            {
                targetLocation = "Agreement";
            }
            else
            {
                targetLocation = area;
            }

            return targetLocation;
        }

        private static bool IsValidFileExtensionAndSignature(string fileName, Stream data, string[] permittedExtensions)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }

            var ext = Path.GetExtension(fileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                return false;
            }

            data.Position = 0;

            using (var reader = new BinaryReader(data))
            {
                // File signature check
                // --------------------
                var signatures = FileSignature[ext];
                var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

                return signatures.Any(signature =>
                    headerBytes.Take(signature.Length).SequenceEqual(signature));
            }
        }
    }
}
