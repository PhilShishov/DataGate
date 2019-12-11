namespace Pharus.Services.Funds.Contracts
{

    using System;

    public interface IFundsFileService
    {
        string LoadFileToDisplay(int fundId, string chosenDate);

        Guid GetStreamIdFromFileName(string fileName);

        void InsertFundFile(
                            string streamId,
                            int fundId,
                            string startConnection,
                            string endConnection,
                            int fileTypeId);
    }
}
