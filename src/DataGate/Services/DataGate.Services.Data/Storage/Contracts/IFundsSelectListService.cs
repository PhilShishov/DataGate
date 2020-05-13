namespace DataGate.Services.Data.Storage.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFundsSelectListService
    {
        IAsyncEnumerable<string> GetAllTbDomCompanyDesc();

        IAsyncEnumerable<string> GetAllTbDomFStatus();

        IAsyncEnumerable<string> GetAllTbDomLegalForm();

        IAsyncEnumerable<string> GetAllTbDomLegalType();

        IAsyncEnumerable<string> GetAllTbDomLegalVehicle();

        Task<int> GetByIdStatus(string status);

        Task<int> GetByIdLegalForm(string legalForm);

        Task<int> GetByIdLegalVehicle(string legalVehicle);

        Task<int> GetByIdLegalType(string legalType);

        Task<int> GetByIdCompanyType(string companyTypeDesc);
    }
}
