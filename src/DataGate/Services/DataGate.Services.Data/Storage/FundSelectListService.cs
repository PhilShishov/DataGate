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

        public async IAsyncEnumerable<string> GetAllTbDomCompanyDesc()
        {
            var companyDesc = await this.repositoryCompanyType.All()
                .Select(tb => tb.CtDesc + " - " + tb.CtAcronym)
                .ToListAsync();

            foreach (var item in companyDesc)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<string> GetAllTbDomFStatus()
        {
            var status = await this.repositoryFStatus.All()
               .Select(tb => tb.StFDesc)
               .ToListAsync();

            foreach (var item in status)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<string> GetAllTbDomLegalForm()
        {
            var legalForms = await this.repositoryLegalForm.All()
               .Select(tb => tb.LfAcronym)
               .ToListAsync();

            foreach (var item in legalForms)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<string> GetAllTbDomLegalType()
        {
            var legalTypes = await this.repositoryLegalType.All()
               .Select(tb => tb.LtAcronym)
               .ToListAsync();

            foreach (var item in legalTypes)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<string> GetAllTbDomLegalVehicle()
        {
            var legalVehicles = await this.repositoryLegalVehicle.All()
              .Select(tb => tb.LvAcronym)
              .ToListAsync();

            foreach (var item in legalVehicles)
            {
                yield return item;
            }
        }

        public async Task<int> GetByIdCompanyType(string companyTypeDesc)
        {
            // Split to take only companyTypeDesc for comparing
            string companyTypeDescSplitted = companyTypeDesc.Split(" - ").FirstOrDefault();

            return await this.repositoryCompanyType.All()
                        .Where(ct => ct.CtDesc == companyTypeDescSplitted)
                        .Select(ct => ct.CtId)
                        .FirstOrDefaultAsync();
        }

        public async Task<int> GetByIdLegalForm(string legalForm)
        {
           return await this.repositoryLegalForm.All()
                        .Where(lf => lf.LfAcronym == legalForm)
                        .Select(lf => lf.LfId)
                        .FirstOrDefaultAsync();
        }

        public async Task<int> GetByIdLegalType(string legalType)
        {
           return await this.repositoryLegalType.All()
                        .Where(lt => lt.LtAcronym == legalType)
                        .Select(lt => lt.LtId)
                        .FirstOrDefaultAsync();
        }

        public async Task<int> GetByIdLegalVehicle(string legalVehicle)
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
