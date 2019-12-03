namespace Pharus.Services.Funds.Contracts
{
    public interface IFundsFileService
    {
        string LoadFileToDisplay(int fundId, string chosenDate);
    }
}
