namespace Pharus.Services.Files
{
    using System;

    public interface IEntitiesFileService
    {
        string LoadEntityFileToDisplay(
                            int entityId, 
                            string chosenDate,
                            string controllerName);

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

        void DeleteDocumentMapping(string docName, string controllerName);

        void DeleteAgreementMapping(string fileName);
    }
}