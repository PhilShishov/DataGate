namespace Pharus.Services.Files
{
    using System;

    public interface IEntitiesFileService
    {
        string LoadFundFileToDisplay(
                            int entityId, 
                            string chosenDate, 
                            int fileTypeId);

        void AddFileToSpecificFund(
                            string streamId,
                            int entityId,
                            DateTime startConnection,
                            DateTime? endConnection,
                            int fileTypeId);

        string LoadSubFundFileToDisplay(
                            int entityId,
                            string chosenDate,
                            int fileTypeId);

        void AddFileToSpecificSubFund(
                            string streamId,
                            int entityId,
                            DateTime startConnection,
                            DateTime? endConnection,
                            int fileTypeId);

        string LoadShareClassFileToDisplay(
                            int entityId,
                            string chosenDate,
                            int fileTypeId);

        void AddFileToSpecificShareClass(
                            string streamId,
                            int entityId,
                            DateTime startConnection,
                            DateTime? endConnection,
                            int fileTypeId);
    }
}