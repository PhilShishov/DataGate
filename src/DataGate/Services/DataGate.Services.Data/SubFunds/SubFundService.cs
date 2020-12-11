namespace DataGate.Services.Data.SubFunds
{
    using System.Linq;

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
