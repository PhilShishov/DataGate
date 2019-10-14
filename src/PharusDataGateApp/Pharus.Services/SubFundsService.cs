namespace Pharus.Services
{
    using System;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Utilities;
    using Pharus.Services.Contracts;
    using Pharus.Domain.Pharus_vFinale;

    public class SubFundsService : ISubFundsService
    {
        private string defaultDate = DateTime.Today.ToString("yyyyMMdd");
        private readonly Pharus_vFinaleContext context;

        public SubFundsService(
            Pharus_vFinaleContext context)
        {
            this.context = context;
        }

        public List<string[]> GetAllActiveSubFunds()
        {
            using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_subfund('{defaultDate}')";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllActiveSubFunds(DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_subfund('{defaultDate}')";
                }

                else
                {
                    command.CommandText = $"select * from fn_active_subfund('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
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
