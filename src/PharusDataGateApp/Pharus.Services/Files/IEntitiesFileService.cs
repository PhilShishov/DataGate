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
                            int entityId,
                            int activityTypeId,
                            string contractDate,
                            string activationDate,
                            string expirationDate,
                            int statusId,
                            int companyId,
                            string controllerName);

        void DeleteDocument(string docName, string controllerName);

        void DeleteAgreement(string fileName);
    }
}