// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Funds
{
    using System.Linq;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories.AppContext;
    using DataGate.Data.Models.Entities;

    // _____________________________________________________________
    public class FundService : IFundService
    {
        private readonly IAppRepository<TbHistoryFund> repository;

        public FundService(IAppRepository<TbHistoryFund> fundRepository)
        {
            this.repository = fundRepository;
        }

        public bool DoesExist(int id)
        {
            var exists = this.repository.All().Any(x => x.FId == id);

            if (!exists)
            {
                throw new EntityNotFoundException(nameof(TbHistoryFund));
            }

            return exists;
        }
    }
}
