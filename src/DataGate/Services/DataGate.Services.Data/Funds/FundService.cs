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
