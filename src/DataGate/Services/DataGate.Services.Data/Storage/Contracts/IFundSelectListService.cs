namespace DataGate.Services.Data.Storage.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFundSelectListService
    {
        IReadOnlyCollection<string> GetAllTbDomCompanyDesc();

        IReadOnlyCollection<string> GetAllTbDomFStatus();

        IReadOnlyCollection<string> GetAllTbDomLegalForm();

        IReadOnlyCollection<string> GetAllTbDomLegalType();

        IReadOnlyCollection<string> GetAllTbDomLegalVehicle();

        Task<int> GetByIdStatus(string status);

        Task<int?> GetByIdLegalForm(string legalForm);

        Task<int?> GetByIdLegalVehicle(string legalVehicle);

        Task<int?> GetByIdLegalType(string legalType);

        Task<int?> GetByIdCompanyType(string companyTypeDesc);
    }
}
