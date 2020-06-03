// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Service class for managing funds

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.ShareClasses
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // _____________________________________________________________
    public class ShareClassService : IShareClassService
    {
        private readonly IRepository<TbHistoryShareClass> repository;

        public ShareClassService(
                        IRepository<TbHistoryShareClass> repository)
        {
            this.repository = repository;
        }

        public async Task<ISet<string>> GetNamesAsync(int? id = null)
        {
            var query = await this.repository
                .All()
                .OrderBy(x => x.ScOfficialShareClassName)
                .Select(f => f.ScOfficialShareClassName)
                .ToListAsync();

            return query.ToHashSet();
        }

        public void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistoryShareClass));
            }
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.ScId == id);
    }
}
