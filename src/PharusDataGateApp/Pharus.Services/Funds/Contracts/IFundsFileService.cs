namespace Pharus.Services.Funds.Contracts
{
    public interface IFundsFileService
    {
        string LoadFileToDisplay(int fundId, string chosenDate);

        string GetStreamIdFromFileName(string fileName);

        void InsertFundFile(
                            string streamId,
                            int fundId,
                            string startConnection,
                            string endConnection,
                            int fileTypeId);
    }
}