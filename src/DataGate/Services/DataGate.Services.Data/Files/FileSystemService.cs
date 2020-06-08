namespace DataGate.Services.Data.Funds
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Documents;
    using DataGate.Services.Data.Files.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.InputModels.Files;

    public class FileSystemService : IFileSystemService
    {
        private readonly ISqlQueryManager sqlManager;
        private readonly IDocumentService service;

        public FileSystemService(
                        ISqlQueryManager sqlManager,
                        IDocumentService service)
        {
            this.sqlManager = sqlManager;
            this.service = service;
        }

        // ________________________________________________________
        //
        // Documents
        public async Task UploadDocument(UploadDocumentInputModel model)
        {
            UploadDocumentDto dto = AutoMapperConfig.MapperInstance.Map<UploadDocumentDto>(model);
            dto.EndConnection = model.EndConnection?.ToString(GlobalConstants.RequiredSqlDateTimeFormat, CultureInfo.InvariantCulture);
            dto.DocumentType = await this.service.GetByIdDocumentType(model.DocumentType);

            string query = StringSwapper.GetResult(model.AreaName,
                                                  ProcedureDictionary.SqlProcedureDocumentFund,
                                                  ProcedureDictionary.SqlProcedureDocumentSubFund,
                                                  ProcedureDictionary.SqlProcedureDocumentShareClass);

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
            string query = StringSwapper.GetResult(areaName,
                                                  ProcedureDictionary.SqlProcedureDeleteDocumentFund,
                                                  ProcedureDictionary.SqlProcedureDeleteDocumentSubFund,
                                                  ProcedureDictionary.SqlProcedureDeleteDocumentShareClass);

            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add(new SqlParameter("@file_id", SqlDbType.NVarChar) { Value = fileId });

            await this.sqlManager.ExecuteProcedure(command);
        }

        // ________________________________________________________
        //
        // Agreements
        public async Task UploadAgreement(UploadAgreementInputModel model)
        {
            UploadAgreementDto dto = AutoMapperConfig.MapperInstance.Map<UploadAgreementDto>(model);
            dto.AgreementType = await this.service.GetByIdAgreementType(model.AgrType);
            dto.Status = await this.service.GetByIdStatus(model.Status);
            dto.Company = await this.service.GetByIdCompany(model.Company);

            string query = StringSwapper.GetResult(model.AreaName,
                                                 ProcedureDictionary.SqlProcedureAgreementFund,
                                                 ProcedureDictionary.SqlProcedureAgreementSubFund,
                                                 ProcedureDictionary.SqlProcedureAgreementShareClass);

            query += " @file_name, @entity_id, @file_ext, @activity_type_id, @contract_date, @activation_date, @expiration_date, @company_id, @status";

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
            string query = StringSwapper.GetResult(areaName,
                                                  ProcedureDictionary.SqlProcedureDeleteAgreementFund,
                                                  ProcedureDictionary.SqlProcedureDeleteAgreementSubFund,
                                                  ProcedureDictionary.SqlProcedureDeleteAgreementShareClass);

            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add(new SqlParameter("@file_id", SqlDbType.NVarChar) { Value = fileId });

            await this.sqlManager.ExecuteProcedure(command);
        }
    }
}
