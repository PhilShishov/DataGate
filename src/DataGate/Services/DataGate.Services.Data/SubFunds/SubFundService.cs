namespace DataGate.Services.Data.SubFunds
{
    using System.Linq;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;

    // _____________________________________________________________
    public class SubFundService : ISubFundService
    {
        private readonly IRepository<TbHistorySubFund> repository;

        public SubFundService(IRepository<TbHistorySubFund> repository)
        {
            this.repository = repository;
        }

        public bool DoesEntityExist(int id)
        {
            var exists = this.repository.All().Any(x => x.SfId == id);

            if (!exists)
            {
                throw new EntityNotFoundException(nameof(TbHistoryFund));
            }

            return exists;
        }
    }
}
