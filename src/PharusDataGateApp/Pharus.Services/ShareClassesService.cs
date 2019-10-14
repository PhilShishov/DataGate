namespace Pharus.Services
{
    using System;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Contracts;
    using Pharus.Services.Utilities;
    using Pharus.Domain.Pharus_vFinale;

    public class ShareClassesService : IShareClassesService
    {
        private readonly Pharus_vFinaleContext context;

        public ShareClassesService(
            Pharus_vFinaleContext context)
        {
            this.context = context;
        }

        public List<string[]> GetAllActiveShareClasses()
        {
            using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                var defaultDate = DateTime.Today.ToString("yyyyMMdd");
                command.CommandText = $"select * from fn_active_fund('{defaultDate}')";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            };
        }

        public List<string[]> GetAllActiveShareClasses(DateTime? chosenDate)
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

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<TbHistoryShareClass> GetAllShareClasses()
        {
            var shareClasses = this.context.TbHistoryShareClass.ToList();

            return shareClasses;
        }

        public TbHistoryShareClass GetShareClass(string shareClassName)
        {
            var shareClass = this.context.TbHistoryShareClass.FirstOrDefault(f => f.ScOfficialShareClassName == shareClassName);

            return shareClass;
        }
    }
}
