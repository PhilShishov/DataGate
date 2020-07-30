﻿// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
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
    using DataGate.Services.Mapping;
    using DataGate.Web.ViewModels.Search;
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

        public bool IsIsin(string searchTerm)
        {
            var isinList = this.repository.All()
              .Select(sc => sc.ScIsinCode)
              .ToList();

            return isinList.Any(i => i == searchTerm);
        }

        public async Task<ISet<string>> GetNamesAsync(int? id = null)
        {
            var query = await this.repository.All()
                .OrderBy(sc => sc.ScOfficialShareClassName)
                .Select(sc => sc.ScOfficialShareClassName)
                .ToListAsync();

            return query.ToHashSet();
        }

        public IEnumerable<TbHistoryShareClass> ByDate()
            => this.repository.All()
                .OrderByDescending(sc => sc.ScInitialDate)
                .Take(10)
                .ToList();

        public IEnumerable<ResultViewModel> ByName(string searchTerm)
             => this.repository.All()
                .Where(sc => sc.ScOfficialShareClassName.Contains(searchTerm))
                .OrderBy(sc => sc.ScOfficialShareClassName)
                .To<ResultViewModel>()
                .ToList();

        public int ByIsin(string searchTerm)
            => this.repository.All()
               .Where(sc => sc.ScIsinCode == searchTerm)
               .Select(sc => sc.ScId)
               .FirstOrDefault();

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
