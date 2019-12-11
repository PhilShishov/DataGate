namespace Pharus.Services.Funds.Contracts
{
    public interface IFundsFileService
    {
        string LoadFileToDisplay(int fundId, string chosenDate);

        int GetStreamIdFromFileName(string fileName);

        void InsertFundFile(
                            int streamId, 
                            int fundId, 
                            string startConnection, 
                            string endConnection, 
                            int fileTypeId);
    }
}
