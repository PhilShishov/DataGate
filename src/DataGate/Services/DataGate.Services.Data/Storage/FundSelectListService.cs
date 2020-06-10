namespace DataGate.Services.Data.Storage
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Domain;
    using DataGate.Services.Data.Storage.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class FundSelectListService : IFundSelectListService
    {
        private readonly IRepository<TbDomCompanyType> repositoryCompanyType;
        private readonly IRepository<TbDomFStatus> repositoryFStatus;
        private readonly IRepository<TbDomLegalForm> repositoryLegalForm;
        private readonly IRepository<TbDomLegalType> repositoryLegalType;
        private readonly IRepository<TbDomLegalVehicle> repositoryLegalVehicle;

        public FundSelectListService(
                          IRepository<TbDomCompanyType> repositoryCompanyType,
                          IRepository<TbDomFStatus> repositoryFStatus,
                          IRepository<TbDomLegalForm> repositoryLegalForm,
                          IRepository<TbDomLegalType> repositoryLegalType,
                          IRepository<TbDomLegalVehicle> repositoryLegalVehicle)
        {
            this.repositoryCompanyType = repositoryCompanyType;
            this.repositoryFStatus = repositoryFStatus;
            this.repositoryLegalForm = repositoryLegalForm;
            this.repositoryLegalType = repositoryLegalType;
            this.repositoryLegalVehicle = repositoryLegalVehicle;
        }

        public IReadOnlyCollection<string> GetAllTbDomCompanyDesc()
            => this.repositoryCompanyType.All()
                .Select(tb => tb.CtDesc + " - " + tb.CtAcronym)
                .ToList();

        public IReadOnlyCollection<string> GetAllTbDomFStatus()
            => this.repositoryFStatus.All()
               .Select(tb => tb.StFDesc)
               .ToList();

        public IReadOnlyCollection<string> GetAllTbDomLegalForm()
            => this.repositoryLegalForm.All()
               .Select(tb => tb.LfAcronym)
               .ToList();

        public IReadOnlyCollection<string> GetAllTbDomLegalType()
            => this.repositoryLegalType.All()
               .Select(tb => tb.LtAcronym)
               .ToList();

        public IReadOnlyCollection<string> GetAllTbDomLegalVehicle()
            => this.repositoryLegalVehicle.All()
              .Select(tb => tb.LvAcronym)
              .ToList();

        public async Task<int?> GetByIdCompanyType(string companyTypeDesc)
        {
            // Split to take only companyTypeDesc for comparing
            string companyTypeDescSplitted = companyTypeDesc.Split(" - ").FirstOrDefault();

            return await this.repositoryCompanyType.All()
                        .Where(ct => ct.CtDesc == companyTypeDescSplitted)
                        .Select(ct => ct.CtId)
                        .FirstOrDefaultAsync();
        }

        public async Task<int?> GetByIdLegalForm(string legalForm)
        {
            return await this.repositoryLegalForm.All()
                         .Where(lf => lf.LfAcronym == legalForm)
                         .Select(lf => lf.LfId)
                         .FirstOrDefaultAsync();
        }

        public async Task<int?> GetByIdLegalType(string legalType)
        {
            return await this.repositoryLegalType.All()
                         .Where(lt => lt.LtAcronym == legalType)
                         .Select(lt => lt.LtId)
                         .FirstOrDefaultAsync();
        }

        public async Task<int?> GetByIdLegalVehicle(string legalVehicle)
        {
            return await this.repositoryLegalVehicle.All()
                        .Where(lv => lv.LvAcronym == legalVehicle)
                        .Select(lv => lv.LvId)
                        .FirstOrDefaultAsync();
        }

        public async Task<int> GetByIdStatus(string status)
        {
            return await this.repositoryFStatus.All()
                        .Where(s => s.StFDesc == status)
                        .Select(s => s.StFId)
                        .FirstOrDefaultAsync();
        }
    }
}
