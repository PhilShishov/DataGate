namespace Pharus.Services
{
    using System;
    using System.Linq;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Collections.Generic;

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

        public List<string[]> GetAllActiveFunds()
        {
            using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                var defaultDate = DateTime.Today.ToString("yyyyMMdd");
                command.CommandText = $"select * from fn_active_fund('{defaultDate}')";

                using (var reader = command.ExecuteReader())
                {
                    var model = Read(reader).ToList();
                    string[] item = new string[reader.FieldCount];

                    for (int j = 0; j < reader.FieldCount; j++)
                    {
                        item[j] = (reader.GetName(j));
                    }

                    model.Insert(0, item);

                    return model;
                }
            }
        }

        public List<string[]> GetAllActiveFunds(DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    var defaultDate = DateTime.Today.ToString("yyyyMMdd");
                    command.CommandText = $"select * from fn_active_fund('{defaultDate}')";
                }
                else
                {
                    command.CommandText = $"select * from fn_active_fund('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                using (var reader = command.ExecuteReader())
                {
                    var model = Read(reader).ToList();
                    string[] item = new string[reader.FieldCount];

                    for (int j = 0; j < reader.FieldCount; j++)
                    {
                        item[j] = (reader.GetName(j));
                    }

                    model.Insert(0, item);

                    return model;
                }
            }
        }

        public TbHistoryFund GetFund(string fundName)
        {
            var fund = this.context.TbHistoryFund.FirstOrDefault(f => f.FOfficialFundName == fundName);

            return fund;
        }

        private static IEnumerable<string[]> Read(DbDataReader reader)
        {
            while (reader.Read())
            {
                var values = new List<string>();

                for (int j = 0; j < reader.FieldCount; j++)
                {
                    values.Add(Convert.ToString(reader.GetValue(j)));
                }

                yield return values.ToArray();
            }
        }
    }
}
