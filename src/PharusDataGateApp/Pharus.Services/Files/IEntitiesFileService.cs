namespace Pharus.Services.Files
{
    using System;

    public interface IEntitiesFileService
    {
        string LoadEntityFileToDisplay(
                            int entityId, 
                            string chosenDate, 
                            int fileTypeId);

        void AddFileToSpecificEntity(
                            string streamId,
                            int entityId,
                            DateTime startConnection,
                            DateTime? endConnection,
                            int fileTypeId);
    }
}