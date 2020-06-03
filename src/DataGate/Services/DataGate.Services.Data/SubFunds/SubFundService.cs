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
        //private readonly IRepository<TbHistoryShareClass> repository;
        //private readonly IRepository<TbSubFundShareClass> subsRepository;

        public SubFundService(
                        IRepository<TbHistorySubFund> repository)
        {
            this.repository = repository;
        }

        public async Task<ISet<string>> GetNamesAsync(int? id)
        {
            var query = await this.repository
                .All()
                .OrderBy(x => x.SfOfficialSubFundName)
                .Select(f => f.SfOfficialSubFundName)
                .ToListAsync();

            return query.ToHashSet();
        }

        //public async Task<ISet<string>> GetNamesAsync(int? id)
        //{
        //    var subfundShareClasses = this.subsRepository.All();
        //    var shareclasses = this.repository.All();

        //    var query = await (from sc in shareclasses
        //                       join sfsc in subfundShareClasses on sc.ScId equals sfsc.ScId
        //                       where sfsc.ScId == id
        //                       select sc.ScOfficialShareClassName)
        //                .ToListAsync();

        //    return query.ToHashSet();
        //}

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
