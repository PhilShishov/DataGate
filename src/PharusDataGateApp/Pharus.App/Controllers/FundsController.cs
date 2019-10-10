namespace Pharus.App.Controllers
{
    using System.Linq;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Data;
    using Pharus.Services.Contracts;

    [Authorize]
    public class FundsController : Controller
    {
        private readonly IFundsService fundsService;

        public FundsController(IFundsService fundsService)
        {
            this.fundsService = fundsService;
        }

        public IActionResult All()
        {
            using (var ctx = new Pharus_vFinaleContext())
            {
                using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "select * from fn_active_fund('20191009')";
                    using (var reader = command.ExecuteReader())
                    {
                        var model = Read(reader).ToList();
                        return View(model);
                    }
                }
            }
        }

        #region Helpers

        private static IEnumerable<object[]> Read(DbDataReader reader)
        {
            while (reader.Read())
            {
                var values = new List<object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    values.Add(reader.GetValue(i));
                }
                yield return values.ToArray();
            }
        }

        #endregion
    }
}