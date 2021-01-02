// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.SqlClient
{
    public class SqlProcedureDictionary
    {
        // ________________________________________________________
        //
        // Stored procedures as in DB
        // Upload
        public const string DocumentFund = "EXEC sp_insert_document_fund";
        public const string DocumentSubFund = "EXEC sp_insert_document_subfund";
        public const string DocumentShareClass = "EXEC sp_insert_document_shareclass";

        public const string AgreementFund = "EXEC sp_insert_agreement_fund";
        public const string AgreementSubFund = "EXEC sp_insert_agreement_subfund";
        public const string AgreementShareClass = "EXEC sp_insert_agreement_shareclass";

        // Delete
        public const string DeleteDocumentFund = "EXEC delete_fund_file_byid @file_id";
        public const string DeleteDocumentSubFund = "EXEC delete_subfund_file_byid @file_id";
        public const string DeleteDocumentShareClass = "EXEC delete_shareclass_file_byid @file_id";

        public const string DeleteAgreementFund = "EXEC delete_agreement_fundfile_byid @file_id";
        public const string DeleteAgreementSubFund = "EXEC delete_agreement_subfundfile_byid @file_id";
        public const string DeleteAgreementShareClass = "EXEC delete_agreement_shareclassfile_byid @file_id";

        // Fund Storage
        public const string CreateFund = "EXEC sp_new_fund "; 
        public const string EditFund = "EXEC sp_modify_fund ";

        // Sub Fund Storage
        public const string CreateSubFund = "EXEC sp_new_subfund ";
        public const string EditSubFund = "EXEC sp_modify_subfund ";

        // Create/edit share class
        public const string CreateShareClass = "EXEC sp_new_shareclass ";
        public const string EditShareClass = "EXEC sp_modify_shareclass ";
    }
}
