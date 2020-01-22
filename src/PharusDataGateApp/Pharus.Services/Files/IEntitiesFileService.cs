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
                            int entityId,
                            int agrFileTypeId,
                            DateTime contractDate,
                            DateTime activationDate,
                            DateTime? expirationDate,
                            int statusId,
                            int companyId,
                            string fileName,
                            string controllerName);
    }
}