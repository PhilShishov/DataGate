// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.TestData
{
    using System;
    using System.IO;
    using System.Text;

    using DataGate.Web.InputModels.Files;

    using Microsoft.AspNetCore.Http;

    public static class FileServiceTestData
    {
        public static UploadAgreementInputModel GenerateAgreement()
        {
            var file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a test file")), 0, 0, "Data", "test.pdf")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            var model = new UploadAgreementInputModel()
            {
                Id = 100,
                AgrType = null,
                ContractDate = DateTime.Now.ToString(),
                ActivationDate = DateTime.Now.ToString(),
                ExpirationDate = DateTime.Now.ToString(),
                Company = "Test",
                Status = "InProgress",
                FileToUpload = file,
                Date = DateTime.Now.ToString(),
                RouteName = "",
                AreaName = "Fund"
            };

            return model;
        }

        public static UploadDocumentInputModel GenerateDocument()
        {
            var file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a test file")), 0, 0, "Data", "dummy.pdf")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            UploadDocumentInputModel model = new UploadDocumentInputModel()
            {
                Id = 100,
                StartConnection = DateTime.Now,
                EndConnection = DateTime.Now,
                DocumentType = ".pdf",
                FileToUpload = file,
                Date = "",
                AreaName = "",
                RouteName = ""
            };

            return model;
        }
    }
}