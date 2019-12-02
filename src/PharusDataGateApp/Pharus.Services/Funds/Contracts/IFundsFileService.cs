
namespace Pharus.Services.Funds.Contracts
{
    using System.Collections.Generic;

    public interface IFundsFileService
    {
        List<string> LoadFilesNames(string chosenDate);

        string LoadFilePath(string fileName);
    }
}
