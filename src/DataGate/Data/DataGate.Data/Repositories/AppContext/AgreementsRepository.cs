// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Repositories.AppContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using DataGate.Data.Common.Repositories.AppContext;

    public class AgreementsRepository : IAgreementsRepository
    {
        public AgreementsRepository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected ApplicationDbContext Context { get; set; }

        public IReadOnlyCollection<string> AllAgreementsFileTypes(int fileType)
        => this.Context.TbDomActivityType
                .Where(at => at.AtEntity == fileType)
                .Select(at => at.AtDesc)
                .ToList();

        public IReadOnlyCollection<string> AllAgreementStatus()
        => this.Context.TbDomAgreementStatus
                .Select(ast => ast.ASDesc)
                .ToList();

        public IReadOnlyCollection<string> AllCompanies()
        => this.Context.TbCompanies
                .Select(c => c.CName)
                .ToList();

        public IReadOnlyCollection<string> AllFeeFrequency()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<string> AllFees()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<string> AllFeeTypes()
        {
            throw new NotImplementedException();
        }

        public Task<int> ByIdAgreementType(string agrType)
        => this.Context.TbDomActivityType
                        .Where(at => at.AtDesc == agrType)
                        .Select(at => at.AtId)
                        .FirstOrDefaultAsync();

        public Task<int> ByIdCompany(string company)
        => this.Context.TbCompanies
                        .Where(c => c.CName == company)
                        .Select(c => c.CId)
                        .FirstOrDefaultAsync();

        public Task<int> ByIdFee(string fee)
        {
            throw new NotImplementedException();
        }

        public Task<int> ByIdFeeFrequency(string feeFrequency)
        {
            throw new NotImplementedException();
        }

        public Task<int> ByIdFeeType(string feeType)
        {
            throw new NotImplementedException();
        }

        public async Task<int> ByIdStatus(string status)
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