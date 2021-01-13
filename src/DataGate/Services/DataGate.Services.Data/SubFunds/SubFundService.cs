// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.SubFunds
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories.AppContext;
    using DataGate.Data.Models.Entities;

    // _____________________________________________________________
    public class SubFundService : ISubFundService
    {
        private readonly IAppRepository<TbHistorySubFund> repository;

        public SubFundService(IAppRepository<TbHistorySubFund> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> DoesExist(int id)
        {
            var exists = this.repository.All().Any(x => x.SfId == id);

            if (!exists)
            {
                throw new EntityNotFoundException(nameof(TbHistoryFund));
            }

           return await Task.FromResult(exists);
        }
    }
}
