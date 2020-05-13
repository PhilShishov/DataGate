namespace DataGate.Services.Data.Storage
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Domain;
    using DataGate.Services.Data.Storage.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class FundsSelectListService : IFundsSelectListService
    {
        private readonly IRepository<TbDomCompanyType> repositoryCompanyType;
        private readonly IRepository<TbDomFStatus> repositoryFStatus;
        private readonly IRepository<TbDomLegalForm> repositoryLegalForm;
        private readonly IRepository<TbDomLegalType> repositoryLegalType;
        private readonly IRepository<TbDomLegalVehicle> repositoryLegalVehicle;

        public FundsSelectListService(
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
    }
}
