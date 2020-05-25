namespace DataGate.Services.Data.Funds
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.Data.Files.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.InputModels.Files;

    public class FileSystemService : IFileSystemService
    {
        // ________________________________________________________
        //
        // Stored procedures as in DB
        // Upload
        private readonly string sqlProcedureDocumentFund = "EXEC sp_insert_map_fund";
        private readonly string sqlProcedureDocumentSubFund = "EXEC sp_insert_map_subfund";
        private readonly string sqlProcedureDocumentShareClass = "EXEC sp_insert_map_shareclass";
        private readonly string sqlProcedureDocument = "@file_name, @entity_id, @start_connection, @end_connection, @file_ext, @filetype_id";

        private readonly string sqlProcedureAgreementFund = "EXEC sp_insert_agreement_fund";
        private readonly string sqlProcedureAgreementSubFund = "EXEC sp_insert_agreement_subfund";
        private readonly string sqlProcedureAgreementShareClass = "EXEC sp_insert_agreement_shareclass";
        private readonly string sqlProcedureAgreement = "@file_name, @entity_id, @file_ext, @activity_type_id, @contract_date, " +
                                                        "@activation_date, @expiration_date, @company_id, @status";

        // Delete
        private readonly string sqlProcedureDeleteDocumentFund = "EXEC delete_fund_file_byname @file_name";
        private readonly string sqlProcedureDeleteDocumentSubFund = "EXEC delete_subfund_file_byname @file_name";
        private readonly string sqlProcedureDeleteDocumentShareClass = "EXEC delete_shareclass_file_byname @file_name";

        private readonly string sqlProcedureDeleteAgreementFund = "EXEC delete_agreement_fundfile_byname @file_name";
        private readonly string sqlProcedureDeleteAgreementSubFund = "EXEC delete_agreement_subfundfile_byname @file_name";
        private readonly string sqlProcedureDeleteAgreementShareClass = "EXEC delete_agreement_shareclassfile_byname @file_name";

        private readonly ISqlQueryManager sqlManager;
        private readonly IFundDocumentService fundService;

        public FileSystemService(
                        ISqlQueryManager sqlManager,
                        IFundDocumentService fundService)
        {
            this.sqlManager = sqlManager;
            this.fundService = fundService;
        }

        // ________________________________________________________
        //
        // Documents
        public async Task UploadDocument(UploadDocumentInputModel model)
        {
            string query = string.Empty;

            UploadDocumentDto dto = AutoMapperConfig.MapperInstance.Map<UploadDocumentDto>(model);
            dto.EndConnection = model.EndConnection?.ToString(GlobalConstants.RequiredSqlDateTimeFormat, CultureInfo.InvariantCulture);

            if (model.AreaName == GlobalConstants.FundAreaName)
            {
                query = $"{this.sqlProcedureDocumentFund} {this.sqlProcedureDocument}";
                dto.DocumentType = await this.fundService.GetByIdDocumentType(model.DocumentType);
            }
            else if (model.AreaName == GlobalConstants.SubFundAreaName)
            {
                query = $"{this.sqlProcedureDocumentSubFund} {this.sqlProcedureDocument}";
                //dto.DocumentType = await this.service.GetByIdFileType(model.DocumentType);
            }
            else if (model.AreaName == GlobalConstants.ShareClassAreaName)
            {
                query = $"{this.sqlProcedureDocumentShareClass} {this.sqlProcedureDocument}";
                //dto.DocumentType = await this.service.GetByIdFileType(model.DocumentType);
            }

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

        public async Task DeleteDocument(string docValue, string areaName)
        {
            string query = string.Empty;

            if (areaName == GlobalConstants.FundAreaName)
            {
                query = $"{this.sqlProcedureDeleteDocumentFund}";
            }
            else if (areaName == GlobalConstants.SubFundAreaName)
            {
                query = $"{this.sqlProcedureDeleteDocumentSubFund}";
            }
            else if (areaName == GlobalConstants.ShareClassAreaName)
            {
                query = $"{this.sqlProcedureDeleteDocumentShareClass}";
            }

            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add(new SqlParameter("@file_name", SqlDbType.NVarChar) { Value = docValue });

            await this.sqlManager.ExecuteProcedure(command);
        }

        // ________________________________________________________
        //
        // Agreements
        public async Task UploadAgreement(UploadAgreementInputModel model)
        {
            string query = string.Empty;

            UploadAgreementDto dto = AutoMapperConfig.MapperInstance.Map<UploadAgreementDto>(model);

            if (model.AreaName == GlobalConstants.FundAreaName)
            {
                query = $"{this.sqlProcedureAgreementFund} {this.sqlProcedureAgreement}";
                dto.AgreementType = await this.fundService.GetByIdAgreementType(model.AgrType);
                dto.Status = await this.fundService.GetByIdStatus(model.Status);
                dto.Company = await this.fundService.GetByIdCompany(model.Company);
            }
            else if (model.AreaName == GlobalConstants.SubFundAreaName)
            {
                query = $"{this.sqlProcedureAgreementSubFund} {this.sqlProcedureAgreement}";
                //dto.AgreementType = await this.fundService.GetByIdAgreementType(model.AgrType);
                //dto.Status = await this.fundService.GetByIdStatus(model.Status);
                //dto.Company = await this.fundService.GetByIdCompany(model.Company);
            }
            else if (model.AreaName == GlobalConstants.ShareClassAreaName)
            {
                query = $"{this.sqlProcedureAgreementShareClass} {this.sqlProcedureAgreement}";
                //dto.AgreementType = await this.fundService.GetByIdAgreementType(model.AgrType);
                //dto.Status = await this.fundService.GetByIdStatus(model.Status);
                //dto.Company = await this.fundService.GetByIdCompany(model.Company);
            }

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddRange(new[]
            {
                        new SqlParameter("@file_name", SqlDbType.NVarChar) { Value = dto.FileName},
                        new SqlParameter("@entity_id", SqlDbType.Int) { Value = dto.Id },
                        new SqlParameter("@file_ext", SqlDbType.NVarChar) { Value = dto.FileExt },
                        new SqlParameter("@activity_type_id", SqlDbType.Int) { Value = dto.AgreementType},
                        new SqlParameter("@contract_date", SqlDbType.NVarChar) { Value = dto.ContractDate },
                        new SqlParameter("@activation_date", SqlDbType.NVarChar) { Value = dto.ActivationDate },
                        new SqlParameter("@expiration_date", SqlDbType.NVarChar) { Value = dto.ExpirationDate },
                        new SqlParameter("@company_id", SqlDbType.Int) { Value = dto.Company },
                        new SqlParameter("@status", SqlDbType.Int) { Value = dto.Status },
            });

            await this.sqlManager.ExecuteProcedure(command);
        }

        public async Task DeleteAgreement(string agrValue, string areaName)
        {
            string query = string.Empty;

            if (areaName == GlobalConstants.FundAreaName)
            {
                query = $"{this.sqlProcedureDeleteAgreementFund}";
            }
            else if (areaName == GlobalConstants.SubFundAreaName)
            {
                query = $"{this.sqlProcedureDeleteAgreementSubFund}";
            }
            else if (areaName == GlobalConstants.ShareClassAreaName)
            {
                query = $"{this.sqlProcedureDeleteAgreementShareClass}";
            }

            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add(new SqlParameter("@file_name", SqlDbType.NVarChar) { Value = agrValue });

            await this.sqlManager.ExecuteProcedure(command);
        }
    }
}
