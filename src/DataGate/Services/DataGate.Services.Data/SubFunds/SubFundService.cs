// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Service class for managing funds

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.SubFunds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // _____________________________________________________________
    public class SubFundService : ISubFundService
    {
        private readonly IRepository<TbHistorySubFund> repository;
        private readonly IRepository<TbHistoryShareClass> shareClassrepository;
        private readonly IRepository<TbSubFundShareClass> subFundShareClassRepository;

        public SubFundService(
                        IRepository<TbHistorySubFund> repository,
                        IRepository<TbHistoryShareClass> shareClassrepository,
                        IRepository<TbSubFundShareClass> subFundShareClassRepository)
        {
            this.repository = repository;
            this.shareClassrepository = shareClassrepository;
            this.subFundShareClassRepository = subFundShareClassRepository;
        }

        public async Task<ISet<string>> GetNamesAsync(int? id)
        {
            var query = new List<string>();
            if (id.HasValue)
            {
                var subfundShareClasses = this.subFundShareClassRepository.All();
                var shareclasses = this.shareClassrepository.All();

                query = await (from sc in shareclasses
                                   join sfsc in subfundShareClasses on sc.ScId equals sfsc.ScId
                                   where sfsc.SfId == id
                                   select sc.ScOfficialShareClassName)
                            .ToListAsync();
            }
            else
            {
                query = await this.repository
                .All()
                .OrderBy(sf => sf.SfOfficialSubFundName)
                .Select(sf => sf.SfOfficialSubFundName)
                .ToListAsync();
            }

            return query.ToHashSet();
        }

        public void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistorySubFund));
            }
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.SfId == id);
    }
}
