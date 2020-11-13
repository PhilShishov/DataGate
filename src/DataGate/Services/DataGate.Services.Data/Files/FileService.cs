namespace DataGate.Services.Data.Funds
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Repositories;
    using DataGate.Services.Data.Documents;
    using DataGate.Services.Data.Files.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.InputModels.Files;

    public class FileService : IFileSystemService
    {
        private readonly ISqlQueryManager sqlManager;
        private readonly IDocumentService service;
        private readonly IAgreementsRepository repository;

        public FileService(
                        ISqlQueryManager sqlManager,
                        IDocumentService service,
                        IAgreementsRepository repository)
        {
            this.sqlManager = sqlManager;
            this.service = service;
            this.repository = repository;
        }

        // ________________________________________________________
        //
        // Documents
        public async Task UploadDocument(UploadDocumentInputModel model)
        {
            UploadDocumentDto dto = AutoMapperConfig.MapperInstance.Map<UploadDocumentDto>(model);
            dto.EndConnection = DateTimeParser.ToSqlFormat(model.EndConnection);
            dto.DocumentType = await this.service.GetByIdDocumentType(model.DocumentType);

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
            dto.AgreementType = await this.repository.GetByIdAgreementType(model.AgrType);
            dto.Status = await this.repository.GetByIdStatus(model.Status);
            dto.Company = await this.repository.GetByIdCompany(model.Company);

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
            string query = StringSwapper.ByArea(areaName,
                                                  SqlProcedureDictionary.DeleteAgreementFund,
                                                  SqlProcedureDictionary.DeleteAgreementSubFund,
                                                  SqlProcedureDictionary.DeleteAgreementShareClass);

            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add(new SqlParameter("@file_id", SqlDbType.Int) { Value = fileId });

            await this.sqlManager.ExecuteProcedure(command);
        }
    }
}
