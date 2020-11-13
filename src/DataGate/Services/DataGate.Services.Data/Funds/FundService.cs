// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Service class for managing funds

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.Funds
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // _____________________________________________________________
    public class FundService : IFundService
    {
        private readonly IRepository<TbHistoryFund> repository;
        private readonly IRepository<TbHistorySubFund> subFundrepository;
        private readonly IRepository<TbFundSubFund> fundSubFundRepository;

        public FundService(
            IRepository<TbHistoryFund> fundRepository,
            IRepository<TbHistorySubFund> subFundrepository,
            IRepository<TbFundSubFund> fundSubFundRepository)
        {
            this.repository = fundRepository;
            this.subFundrepository = subFundrepository;
            this.fundSubFundRepository = fundSubFundRepository;
        }

        public async Task<ISet<string>> GetNamesAsync(int? id)
        {
            var query = new List<string>();
            if (id.HasValue)
            {
                var fundSubfunds = this.fundSubFundRepository.All();
                var subfunds = this.subFundrepository.All();

                query = await (from sf in subfunds
                               join fsf in fundSubfunds on sf.SfId equals fsf.SfId
                               where fsf.FId == id
                               select sf.SfOfficialSubFundName)
                            .ToListAsync();
            }
            else
            {
                query = await this.repository
                    .All()
                    .OrderBy(f => f.FOfficialFundName)
                    .Select(f => f.FOfficialFundName)
                    .ToListAsync();
            }

            return query.ToHashSet();
        }

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
