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
                            DateTime startConnection,
                            DateTime? endConnection,
                            int fileTypeId,
                            string controllerName);
        void AddAgreementToSpecificEntity(
                            string fileName,
                            int entityId,
                            int activityTypeId,
                            DateTime contractDate,
                            DateTime activationDate,
                            DateTime? expirationDate,
                            int statusId,
                            int companyId,
                            string controllerName);

        void DeleteAgreement(
                            string fileName,
                            string controllerName);
    }
}