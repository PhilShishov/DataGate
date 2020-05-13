namespace DataGate.Services.Data.Storage.Contracts
{
    using System.Collections.Generic;

    public interface IFundsSelectListService
    {
        IAsyncEnumerable<string> GetAllTbDomCompanyDesc();

        IAsyncEnumerable<string> GetAllTbDomFStatus();

        IAsyncEnumerable<string> GetAllTbDomLegalForm();

        IAsyncEnumerable<string> GetAllTbDomLegalType();

        IAsyncEnumerable<string> GetAllTbDomLegalVehicle();
    }
}
