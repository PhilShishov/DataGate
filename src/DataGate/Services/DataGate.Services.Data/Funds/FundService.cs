namespace DataGate.Services.Data.Funds
{
    using System.Linq;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;

    // _____________________________________________________________
    public class FundService : IFundService
    {
        private readonly IRepository<TbHistoryFund> repository;

        public FundService(IRepository<TbHistoryFund> fundRepository)
        {
            this.repository = fundRepository;
        }

        public bool DoesEntityExist(int id)
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
