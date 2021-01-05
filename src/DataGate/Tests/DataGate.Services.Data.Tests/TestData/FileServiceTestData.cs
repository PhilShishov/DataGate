// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.TestData
{
    using System;
    using System.IO;
    using System.Text;

    using DataGate.Data;
    using DataGate.Data.Models.Domain;
    using DataGate.Data.Models.Entities;
    using DataGate.Data.Repositories.AppContext;
    using DataGate.Services.Data.Documents;
    using DataGate.Services.Data.Files;
    using DataGate.Services.SqlClient;
    using DataGate.Web.InputModels.Files;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    public static class FileServiceTestData
    {
        public static FileService Service(ApplicationDbContext context, IConfiguration configuration)
        {
            var sqlManager = new SqlQueryManager(configuration);
            var repositoryFileType = new EfAppRepository<TbDomFileType>(context);
            var serviceDocument = new DocumentService(repositoryFileType);
            var repositoryAgrs = new AgreementsRepository(context);
            var repositoryFile = new EfAppRepository<TbFile>(context);

            var service = new FileService(sqlManager, serviceDocument, repositoryAgrs, repositoryFile);
            return service;
        }

        public static UploadAgreementInputModel Generate(int fundId, string activationDate, string agrType = "Management Company Agreement")
        {
            var file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a test agreement")), 0, 0, "Data", "test.pdf")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            var model = new UploadAgreementInputModel()
            {
                Id = fundId,
                AgrType = agrType,
                ContractDate = activationDate,
                ActivationDate = activationDate,
                Company = "CACEIS Bank Luxembourg",
                Status = "Active",
                FileToUpload = file,
                AreaName = "Fund"
            };

            return model;
        }

        public static UploadDocumentInputModel Generate(int fundId, DateTime startConnection, string docType = "Prospectus")
        {
            var file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a test document")), 0, 0, "Data", "test.pdf")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            UploadDocumentInputModel model = new UploadDocumentInputModel()
            {
                Id = fundId,
                StartConnection = startConnection,
                DocumentType = docType,
                FileToUpload = file,
                AreaName = "Fund",
            };

            return model;
        }
    }
}