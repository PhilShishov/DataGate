namespace DataGate.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class AgreementsRepository : IAgreementsRepository
    {
        public AgreementsRepository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected ApplicationDbContext Context { get; set; }

        public IReadOnlyCollection<string> GetAllAgreementsFileTypes(int fileType)
        => this.Context.TbDomActivityType
                .Where(at => at.AtEntity == fileType)
                .Select(at => at.AtDesc)
                .ToList();

        public IReadOnlyCollection<string> GetAllAgreementStatus()
        => this.Context.TbDomAgreementStatus
                .Select(ast => ast.ASDesc)
                .ToList();

        public IReadOnlyCollection<string> GetAllCompanies()
        => this.Context.TbCompanies
                .Select(c => c.CName)
                .ToList();

        public IReadOnlyCollection<string> GetAllFeeFrequency()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<string> GetAllFees()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<string> GetAllFeeTypes()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetByIdAgreementType(string agrType)
        => this.Context.TbDomActivityType
                        .Where(at => at.AtDesc == agrType)
                        .Select(at => at.AtId)
                        .FirstOrDefaultAsync();

        public Task<int> GetByIdCompany(string company)
        => this.Context.TbCompanies
                        .Where(c => c.CName == company)
                        .Select(c => c.CId)
                        .FirstOrDefaultAsync();

        public Task<int> GetByIdFee(string fee)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetByIdFeeFrequency(string feeFrequency)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetByIdFeeType(string feeType)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetByIdStatus(string status)
        => await this.Context.TbDomAgreementStatus
                        .Where(s => s.ASDesc == status)
                        .Select(s => s.ASId)
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