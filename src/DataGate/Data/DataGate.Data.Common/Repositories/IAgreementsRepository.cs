namespace DataGate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAgreementsRepository : IDisposable
    {
        IReadOnlyCollection<string> AllAgreementsFileTypes(int fileType);
        IReadOnlyCollection<string> AllAgreementStatus();
        IReadOnlyCollection<string> AllCompanies();
        IReadOnlyCollection<string> AllFees();
        IReadOnlyCollection<string> AllFeeFrequency();
        IReadOnlyCollection<string> AllFeeTypes();

        Task<int> ByIdAgreementType(string agrType);
        Task<int> ByIdCompany(string company);
        Task<int> ByIdFee(string fee);
        Task<int> ByIdFeeFrequency(string feeFrequency);
        Task<int> ByIdFeeType(string feeType);
        Task<int> ByIdStatus(string status);
    }
}
