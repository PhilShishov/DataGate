namespace DataGate.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class ShareClassRepository : IShareClassRepository
    {
        public ShareClassRepository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected ApplicationDbContext Context { get; set; }

        public ISet<string> GetAllContainers()
        => this.Context.TbHistorySubFund.Select(f => f.SfOfficialSubFundName).ToHashSet();

        public IReadOnlyCollection<string> GetAllTbDomCountry()
        => this.Context.TbDomIsoCountry.Select(tb => tb.IsoCountryIso2 + " - " + tb.IsoCountryDesc).ToList();

        public IReadOnlyCollection<string> GetAllTbDomCurrencyCode()
        => this.Context.TbDomIsoCurrency.Select(tb => tb.IsoCcyCode).ToList();

        public IReadOnlyCollection<string> GetAllTbDomInvestorType()
        => this.Context.TbDomInvestorType.Select(tb => tb.ItDesc).ToList();

        public IReadOnlyCollection<string> GetAllTbDomShareStatus()
        => this.Context.TbDomShareStatus.Select(tb => tb.ScSDesc).ToList();

        public IReadOnlyCollection<string> GetAllTbDomShareType()
        => this.Context.TbDomShareType.Select(tb => tb.StDesc).ToList();

        public async Task<string> ByNameCountry(string countryToFormat)
        {
            // Split to take only companyTypeDesc for comparing
            string result = string.Empty;

            if (!string.IsNullOrEmpty(countryToFormat))
            {
                string countryIssueDesc = countryToFormat.Split(" - ").LastOrDefault();
                result = await this.Context.TbDomIsoCountry
                    .Where(c => c.IsoCountryDesc == countryIssueDesc)
                    .Select(c => c.IsoCountry3)
                    .FirstOrDefaultAsync();
            }
            return result;
        }

        public async Task<int?> ByIdInvestorType(string investorType)
            => await this.Context.TbDomInvestorType
                        .Where(it => it.ItDesc == investorType)
                        .Select(it => it.ItId)
                        .FirstOrDefaultAsync();

        public async Task<int?> ByIdShareType(string shareType)
        => await this.Context.TbDomShareType
                  .Where(it => it.StDesc == shareType)
                  .Select(it => it.StId)
                  .FirstOrDefaultAsync();

        public async Task<int> ByIdStatus(string status)
        => await this.Context.TbDomShareStatus
                    .Where(s => s.ScSDesc == status)
                    .Select(s => s.ScSId)
                    .FirstOrDefaultAsync();

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}