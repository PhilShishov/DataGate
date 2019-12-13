namespace Pharus.Services.SubFunds.Contracts
{
    public interface ISubFundsFileService
    {
        string LoadSubFundFileToDisplay(int fundId, string chosenDate);

        string GetStreamIdFromFileName(string fileName);

        void AddFileToSpecificSubFund(
                            string streamId,
                            int fundId,
                            string startConnection,
                            string endConnection,
                            int fileTypeId);
    }
}