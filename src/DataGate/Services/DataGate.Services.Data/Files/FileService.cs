// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Files
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories.AppContext;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Documents;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.InputModels.Files;

    public class FileService : IFileService
    {
        private readonly ISqlQueryManager sqlManager;
        private readonly IDocumentService service;
        private readonly IAgreementsRepository repository;
        private readonly IAppRepository<TbFile> fileRepository;

        public FileService(
                        ISqlQueryManager sqlManager,
                        IDocumentService service,
                        IAgreementsRepository repository,
                        IAppRepository<TbFile> fileRepository)
        {
            this.sqlManager = sqlManager;
            this.service = service;
            this.repository = repository;
            this.fileRepository = fileRepository;
        }

        // ________________________________________________________
        //
        // Documents
        public async Task UploadDocument(UploadDocumentInputModel model)
        {
            UploadDocumentDto dto = AutoMapperConfig.MapperInstance.Map<UploadDocumentDto>(model);
            dto.EndConnection = DateTimeExtensions.ToSqlFormat(model.EndConnection);
            dto.DocumentType = await this.service.ByIdDocumentType(model.DocumentType);
            Validator.ArgumentNullExceptionInt(dto.DocumentType, ErrorMessages.InvalidDocType);

            string query = StringSwapper.ByArea(model.AreaName,
                                                  SqlProcedureDictionary.DocumentFund,
                                                  SqlProcedureDictionary.DocumentSubFund,
                                                  SqlProcedureDictionary.DocumentShareClass);

            query += " @file_name, @entity_id, @start_connection, @end_connection, @file_ext, @filetype_id";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@file_name", SqlDbType.NVarChar) { Value = dto.FileName },
                        new SqlParameter("@entity_id", SqlDbType.Int) { Value = dto.Id },
                        new SqlParameter("@file_ext", SqlDbType.NVarChar) { Value = dto.FileExt },
                        new SqlParameter("@start_connection", SqlDbType.NVarChar) { Value = dto.StartConnection },
                        new SqlParameter("@end_connection", SqlDbType.NVarChar) { Value = dto.EndConnection },
                        new SqlParameter("@filetype_id", SqlDbType.Int) { Value = dto.DocumentType },
                    });

            await this.sqlManager.ExecuteProcedure(command);
        }

        public async Task DeleteDocument(int fileId, string areaName)
        {
            this.DoesExist(fileId);

            string query = StringSwapper.ByArea(areaName,
                                                  SqlProcedureDictionary.DeleteDocumentFund,
                                                  SqlProcedureDictionary.DeleteDocumentSubFund,
                                                  SqlProcedureDictionary.DeleteDocumentShareClass);

            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add(new SqlParameter("@file_id", SqlDbType.Int) { Value = fileId });

            await this.sqlManager.ExecuteProcedure(command);
        }

        // ________________________________________________________
        //
        // Agreements
        public async Task UploadAgreement(UploadAgreementInputModel model)
        {
            UploadAgreementDto dto = AutoMapperConfig.MapperInstance.Map<UploadAgreementDto>(model);
            dto.AgreementType = await this.repository.ByIdAgreementType(model.AgrType);
            dto.Status = await this.repository.ByIdStatus(model.Status);
            dto.Company = await this.repository.ByIdCompany(model.Company);

            Validator.ArgumentNullExceptionInt(dto.AgreementType, ErrorMessages.InvalidAgrType);
            Validator.ArgumentNullExceptionInt(dto.Status, ErrorMessages.InvalidStatus);
            Validator.ArgumentNullExceptionInt(dto.Company, ErrorMessages.InvalidStatus);

            string query = StringSwapper.ByArea(model.AreaName,
                                                 SqlProcedureDictionary.AgreementFund,
                                                 SqlProcedureDictionary.AgreementSubFund,
                                                 SqlProcedureDictionary.AgreementShareClass);

            query += " @file_name, @entity_id, @file_ext, @activity_type_id, @contract_date,@activation_date, " +
                      "@expiration_date, @company_id, @status";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddRange(new[]
            {
                        new SqlParameter("@file_name", SqlDbType.NVarChar) { Value = dto.FileName },
                        new SqlParameter("@entity_id", SqlDbType.Int) { Value = dto.Id },
                        new SqlParameter("@file_ext", SqlDbType.NVarChar) { Value = dto.FileExt },
                        new SqlParameter("@activity_type_id", SqlDbType.Int) { Value = dto.AgreementType },
                        new SqlParameter("@contract_date", SqlDbType.NVarChar) { Value = dto.ContractDate },
                        new SqlParameter("@activation_date", SqlDbType.NVarChar) { Value = dto.ActivationDate },
                        new SqlParameter("@expiration_date", SqlDbType.NVarChar) { Value = dto.ExpirationDate },
                        new SqlParameter("@company_id", SqlDbType.Int) { Value = dto.Company },
                        new SqlParameter("@status", SqlDbType.Int) { Value = dto.Status },
            });

            await this.sqlManager.ExecuteProcedure(command);
        }

        public async Task DeleteAgreement(int fileId, string areaName)
        {
            this.DoesExist(fileId);

            string query = StringSwapper.ByArea(areaName,
                                                  SqlProcedureDictionary.DeleteAgreementFund,
                                                  SqlProcedureDictionary.DeleteAgreementSubFund,
                                                  SqlProcedureDictionary.DeleteAgreementShareClass);

            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add(new SqlParameter("@file_id", SqlDbType.Int) { Value = fileId });

            await this.sqlManager.ExecuteProcedure(command);
        }

        private bool DoesExist(int id)
        {
            var exists = this.fileRepository.All().Any(x => x.FileId == id);

            if (!exists)
            {
                throw new EntityNotFoundException(nameof(TbFile));
            }

            return exists;
        }
    }
}
