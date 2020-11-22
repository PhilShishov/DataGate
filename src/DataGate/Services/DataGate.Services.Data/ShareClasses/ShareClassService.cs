// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Service class for managing share classes

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.ShareClasses
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Mapping;
    using DataGate.Web.ViewModels.Search;

    // _____________________________________________________________
    public class ShareClassService : IShareClassService
    {
        private readonly IRepository<TbPrimeShareClass> repository;

        public ShareClassService(IRepository<TbPrimeShareClass> repository)
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

        public IEnumerable<TbPrimeShareClass> ByDate()
            => this.repository.All()
                .OrderByDescending(sc => sc.ScInitialDate)
                .Take(10)
                .ToList();

        public IEnumerable<SearchViewModel> ByName(string searchTerm)
        {
            var query = this.repository.All()
                .Where(sc =>
               EF.Functions.Contains(sc.ScOfficialShareClassName, searchTerm) ||
               EF.Functions.Contains(sc.ScIsinCode, searchTerm));

            return query
                .OrderBy(sc => sc.ScOfficialShareClassName)
                .To<SearchViewModel>()
                .ToList();
        }

        public int ByIsin(string searchTerm)
            => this.repository.All()
               .Where(sc => sc.ScIsinCode == searchTerm)
               .Select(sc => sc.ScId)
               .FirstOrDefault();

        public bool DoesEntityExist(int id)
        {
            var exists = this.repository.All().Any(x => x.ScId == id);

            if (!exists)
            {
                throw new EntityNotFoundException(nameof(TbHistoryFund));
            }

            return exists;
        }
    }
}
