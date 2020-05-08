namespace DataGate.Services.Data.Files
{
    using System;

    public interface IFileSystemService
    {
        void AddDocumentToSpecificEntity(
                            string fileName,
                            int entityId,
                            string startConnection,
                            string endConnection,
                            string fileExt,
                            int fileTypeId,
                            string controllerName);

        void AddAgreementToSpecificEntity(
                            string fileName,
                            string fileExt,
                            int entityId,
                            int activityTypeId,
                            string contractDate,
                            string activationDate,
                            string expirationDate,
                            int statusId,
                            int companyId,
                            string controllerName);

        void DeleteMapping(string docValue, string agrValue, string controllerName);
    }
}
