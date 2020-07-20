namespace DataGate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAgreementsRepository : IDisposable
    {
        IReadOnlyCollection<string> GetAllAgreementsFileTypes(int fileType);
        IReadOnlyCollection<string> GetAllAgreementStatus();
        IReadOnlyCollection<string> GetAllCompanies();
        IReadOnlyCollection<string> GetAllFees();
        IReadOnlyCollection<string> GetAllFeeFrequency();
        IReadOnlyCollection<string> GetAllFeeTypes();

        Task<int> GetByIdAgreementType(string agrType);
        Task<int> GetByIdCompany(string company);
        Task<int> GetByIdFee(string fee);
        Task<int> GetByIdFeeFrequency(string feeFrequency);
        Task<int> GetByIdFeeType(string feeType);
        Task<int> GetByIdStatus(string status);
    }
}
