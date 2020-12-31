// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Storage
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using DataGate.Data.Common.Repositories.AppContext;
    using DataGate.Data.Models.Domain;
    using DataGate.Services.Data.Storage.Contracts;

    public class FundSelectListService : IFundSelectListService
    {
        private readonly IAppRepository<TbDomCompanyType> repositoryCompanyType;
        private readonly IAppRepository<TbDomFStatus> repositoryFStatus;
        private readonly IAppRepository<TbDomLegalForm> repositoryLegalForm;
        private readonly IAppRepository<TbDomLegalType> repositoryLegalType;
        private readonly IAppRepository<TbDomLegalVehicle> repositoryLegalVehicle;

        public FundSelectListService(
                          IAppRepository<TbDomCompanyType> repositoryCompanyType,
                          IAppRepository<TbDomFStatus> repositoryFStatus,
                          IAppRepository<TbDomLegalForm> repositoryLegalForm,
                          IAppRepository<TbDomLegalType> repositoryLegalType,
                          IAppRepository<TbDomLegalVehicle> repositoryLegalVehicle)
        {
            this.repositoryCompanyType = repositoryCompanyType;
            this.repositoryFStatus = repositoryFStatus;
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
