namespace Pharus.Services.Files
{
    using System;

    public interface IEntitiesFileService
    {
        string LoadFundFileToDisplay(
                            int entityId, 
                            string chosenDate);

        void AddFileToSpecificFund(
                            string fileName,
                            int entityId,
                            DateTime startConnection,
                            DateTime? endConnection,
                            int fileTypeId);

        string LoadSubFundFileToDisplay(
                            int entityId,
                            string chosenDate);

        void AddFileToSpecificSubFund(
                            string fileName,
                            int entityId,
                            DateTime startConnection,
                            DateTime? endConnection,
                            int fileTypeId);

        string LoadShareClassFileToDisplay(
                            int entityId,
                            string chosenDate);

        void AddFileToSpecificShareClass(
                            string fileName,
                            int entityId,
                            DateTime startConnection,
                            DateTime? endConnection,
                            int fileTypeId);
    }
}