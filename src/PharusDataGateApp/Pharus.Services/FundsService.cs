namespace Pharus.Services
{
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

        public IEnumerable<object[]> GetAllActiveFunds()
        {
            using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
            {
                //var date = new SqlParameter("@date", chosenDate);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"select * from fn_active_fund('20191009')";
                using (var reader = command.ExecuteReader())
                {
                    var model = Read(reader).ToList();
                    object[] item = new object[reader.FieldCount];

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

        private static IEnumerable<object[]> Read(DbDataReader reader)
        {
            while (reader.Read())
            {
                var values = new List<object>();

                for (int j = 0; j < reader.FieldCount; j++)
                {
                    values.Add(reader.GetValue(j));
                }

                yield return values.ToArray();
            }
        }
    }
}
