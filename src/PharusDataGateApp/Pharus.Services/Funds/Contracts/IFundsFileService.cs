namespace Pharus.Services.Funds.Contracts
{
    using System;

    public interface IFundsFileService
    {
        string LoadFundFileToDisplay(int fundId, string chosenDate);

        string GetStreamIdFromFileName(string fileName);

        void AddFileToSpecificFund(
                            string streamId,
                            int fundId,
                            DateTime startConnection,
                            DateTime? endConnection,
                            int fileTypeId);
    }
}