namespace Pharus.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Contracts;
    using Pharus.Domain.Pharus_vFinale;

    public class SubFundsService : ISubFundsService
    {
        private readonly Pharus_vFinaleContext context;

        public SubFundsService(
            Pharus_vFinaleContext context)
        {
            this.context = context;
        }

        public List<string[]> GetAllActiveSubFunds()
        {
            throw new NotImplementedException();
        }

        public List<string[]> GetAllActiveSubFunds(DateTime? chosenDate)
        {
            throw new NotImplementedException();
        }

        public List<TbHistorySubFund> GetAllSubFunds()
        {
            var subFunds = this.context.TbHistorySubFund.ToList();

            return subFunds;
        }

        public TbHistorySubFund GetSubFund(string subFundName)
        {
            var subFund = this.context.TbHistorySubFund.FirstOrDefault(f => f.SfOfficialSubFundName == subFundName);

            return subFund;
        }
    }
}
