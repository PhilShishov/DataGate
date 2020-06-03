// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Service class for managing funds

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.Funds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // _____________________________________________________________
    public class FundService : IFundService
    {
        private readonly IRepository<TbHistoryFund> repository;
        //private readonly IRepository<TbHistorySubFund> repository;
        //private readonly IRepository<TbFundSubFund> subsRepository;

        public FundService(IRepository<TbHistoryFund> fundRepository)
        {
            this.repository = fundRepository;
        }

        public async Task<ISet<string>> GetNamesAsync(int? id)
        {
            var query = await this.repository
                .All()
                .OrderBy(x => x.FOfficialFundName)
                .Select(f => f.FOfficialFundName)
                .ToListAsync();

            return query.ToHashSet();
        }

        //public async Task<ISet<string>> GetNamesAsync(int? id)
        //{
        //    var fundSubfunds = this.subsRepository.All();
        //    var subfunds = this.repository.All();

        //    var query = await (from sf in subfunds
        //                       join fsf in fundSubfunds on sf.SfId equals fsf.SfId
        //                       where fsf.FId == id
        //                       select sf.SfOfficialSubFundName)
        //                .ToListAsync();

        //    return query.ToHashSet();
        //}

        public void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistoryFund));
            }
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.FId == id);
    }
}
