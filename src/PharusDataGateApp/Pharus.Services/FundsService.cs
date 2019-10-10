namespace Pharus.Services
{
    using System.Linq;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using Pharus.Data;
    using Pharus.Services.Contracts;
    using Pharus.Domain.Pharus_vFinale;

    public class FundsService : IFundsService
    {
        private readonly Pharus_vFinaleContext context;

        public FundsService(
            Pharus_vFinaleContext context)
        {
            this.context = context;
        }
        public List<TbHistoryFund> GetAllFunds()
        {
            var funds = this.context.TbHistoryFund.ToList();

            return funds;
        }

        public void GetAllActiveFunds(string chosenDate)
        {
            var date = new SqlParameter("@date", chosenDate);

            var funds = this.context.TbHistoryFund
                .FromSql($"select * from fn_active_fund({date})")
                .ToList();
        }

        public TbHistoryFund GetFund(string fundName)
        {
            var fund = this.context.TbHistoryFund.FirstOrDefault(f => f.FOfficialFundName == fundName);

            return fund;
        }
    }
}
