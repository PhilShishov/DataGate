namespace DataGate.Services.Data.Storage
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Domain;
    using DataGate.Services.Data.Storage.Contracts;

    public class FundSelectListService : IFundSelectListService
    {
        private readonly IRepository<TbDomCompanyType> repositoryCompanyType;
        private readonly IRepository<TbDomFStatus> repositoryFStatus;
        private readonly IRepository<TbDomFundAdminType> repositoryFAdmin;
        private readonly IRepository<TbDomLegalForm> repositoryLegalForm;
        private readonly IRepository<TbDomLegalType> repositoryLegalType;
        private readonly IRepository<TbDomLegalVehicle> repositoryLegalVehicle;

        public FundSelectListService(
                          IRepository<TbDomCompanyType> repositoryCompanyType,
                          IRepository<TbDomFStatus> repositoryFStatus,
                          IRepository<TbDomFundAdminType> repositoryFAdmin,
                          IRepository<TbDomLegalForm> repositoryLegalForm,
                          IRepository<TbDomLegalType> repositoryLegalType,
                          IRepository<TbDomLegalVehicle> repositoryLegalVehicle)
        {
            this.repositoryCompanyType = repositoryCompanyType;
            this.repositoryFStatus = repositoryFStatus;
            this.repositoryFAdmin = repositoryFAdmin;
            this.repositoryLegalForm = repositoryLegalForm;
            this.repositoryLegalType = repositoryLegalType;
            this.repositoryLegalVehicle = repositoryLegalVehicle;
        }

        public IReadOnlyCollection<string> AllTbDomCompanyDesc()
            => this.repositoryCompanyType.All()
                .Select(tb => tb.CtDesc + " - " + tb.CtAcronym)
                .ToList();

        public IReadOnlyCollection<string> AllTbDomFStatus()
            => this.repositoryFStatus.All()
               .Select(tb => tb.StFDesc)
               .ToList();

        public IReadOnlyCollection<string> AllTbDomFundAdmin()
           => this.repositoryFAdmin.All()
              .Select(tb => tb.FatDesc)
              .ToList();

        public IReadOnlyCollection<string> AllTbDomLegalForm()
            => this.repositoryLegalForm.All()
               .Select(tb => tb.LfAcronym)
               .ToList();

        public IReadOnlyCollection<string> AllTbDomLegalType()
            => this.repositoryLegalType.All()
               .Select(tb => tb.LtAcronym)
               .ToList();

        public IReadOnlyCollection<string> AllTbDomLegalVehicle()
            => this.repositoryLegalVehicle.All()
              .Select(tb => tb.LvAcronym)
              .ToList();

        public async Task<int?> ByIdCompanyType(string companyTypeDesc)
        {
            // Split to take only companyTypeDesc for comparing
            string companyTypeDescSplitted = companyTypeDesc.Split(" - ").FirstOrDefault();

            return await this.repositoryCompanyType.All()
                        .Where(ct => ct.CtDesc == companyTypeDescSplitted)
                        .Select(ct => ct.CtId)
                        .FirstOrDefaultAsync();
        }

        public async Task<int?> ByIdLegalForm(string legalForm)
        {
            return await this.repositoryLegalForm.All()
                         .Where(lf => lf.LfAcronym == legalForm)
                         .Select(lf => lf.LfId)
                         .FirstOrDefaultAsync();
        }

        public async Task<int?> ByIdLegalType(string legalType)
        {
            return await this.repositoryLegalType.All()
                         .Where(lt => lt.LtAcronym == legalType)
                         .Select(lt => lt.LtId)
                         .FirstOrDefaultAsync();
        }

        public async Task<int?> ByIdLegalVehicle(string legalVehicle)
        {
            return await this.repositoryLegalVehicle.All()
                        .Where(lv => lv.LvAcronym == legalVehicle)
                        .Select(lv => lv.LvId)
                        .FirstOrDefaultAsync();
        }

        public async Task<int> ByIdStatus(string status)
        {
            return await this.repositoryFStatus.All()
                        .Where(s => s.StFDesc == status)
                        .Select(s => s.StFId)
                        .FirstOrDefaultAsync();
        }
    }
}
