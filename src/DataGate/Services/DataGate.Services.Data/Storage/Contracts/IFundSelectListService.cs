namespace DataGate.Services.Data.Storage.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFundSelectListService
    {
        IReadOnlyCollection<string> AllTbDomCompanyDesc();

        IReadOnlyCollection<string> AllTbDomFStatus();

        IReadOnlyCollection<string> AllTbDomFundAdmin();

        IReadOnlyCollection<string> AllTbDomLegalForm();

        IReadOnlyCollection<string> AllTbDomLegalType();

        IReadOnlyCollection<string> AllTbDomLegalVehicle();

        Task<int> ByIdStatus(string status);

        Task<int?> ByIdLegalForm(string legalForm);

        Task<int?> ByIdLegalVehicle(string legalVehicle);

        Task<int?> ByIdLegalType(string legalType);

        Task<int?> ByIdCompanyType(string companyTypeDesc);
    }
}
