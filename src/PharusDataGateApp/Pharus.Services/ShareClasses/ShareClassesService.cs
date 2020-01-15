// Service class for managing shareclasses

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.Services.ShareClasses
{
    using System;
    using System.Linq;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;

    using Pharus.Data;
    using Pharus.Utilities.Services;
    using Pharus.Services.ShareClasses.Contracts;

    // _____________________________________________________________
    public class ShareClassesService : IShareClassesService
    {
        private readonly string defaultDate = DateTime.Today.ToString("yyyyMMdd");
        private readonly IConfiguration configuration;
        private readonly Pharus_vFinale_Context context;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public ShareClassesService(
            IConfiguration config,
             Pharus_vFinale_Context context)
        {
            this.configuration = config;
            this.context = context;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions

        public List<string[]> GetAllShareClasses(DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_all_shareclass('{this.defaultDate}')";
                }
                else
                {
                    command.CommandText = $"select * from fn_all_shareclass('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllActiveShareClasses()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_shareclass('{this.defaultDate}')";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllActiveShareClasses(DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_shareclass('{this.defaultDate}')";
                }
                else
                {
                    command.CommandText = $"select * from fn_active_shareclass('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllShareClassesWithSelectedViewAndDate(
                                                List<string> preSelectedColumns,
                                                List<string> selectedColumns,
                                                DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                // Prepare items for DB query with []

                preSelectedColumns.AddRange(selectedColumns);
                preSelectedColumns = preSelectedColumns.Select(c => String.Format("[{0}]", c)).ToList();

                if (chosenDate == null)
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} " +
                        $"from fn_all_shareclass('{this.defaultDate}')";
                }
                else
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} " +
                        $"from fn_all_shareclass('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllActiveShareClassesWithSelectedViewAndDate(
                                                        List<string> preSelectedColumns,
                                                        List<string> selectedColumns,
                                                        DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                // Prepare items for DB query with []

                preSelectedColumns.AddRange(selectedColumns);
                preSelectedColumns = preSelectedColumns.Select(c => String.Format("[{0}]", c)).ToList();

                if (chosenDate == null)
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} " +
                        $"from fn_active_shareclass('{this.defaultDate}')";
                }
                else
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} " +
                        $"from fn_active_shareclass('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string> GetAllShareClassesNames()
        {
            return this.context.TbHistoryShareClass
              .Select(f => f.ScOfficialShareClassName)
              .ToList();
        }

        public List<string[]> GetShareClassWithDateById(DateTime? chosenDate, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_all_shareclass('{this.defaultDate}') where [ID] = {id}";
                }
                else
                {
                    command.CommandText = $"select * from fn_all_shareclass('{chosenDate?.ToString("yyyyMMdd")}') where [ID] = {id}";
                }


                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetShareClass_SubFundContainer(DateTime? chosenDate, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                Dictionary<int, string> funds = new Dictionary<int, string>();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_SubfundContainerForShareclassAtDate('{this.defaultDate}', {id})";
                }

                else
                {
                    command.CommandText = $"select * from fn_SubfundContainerForShareclassAtDate('{chosenDate?.ToString("yyyyMMdd")}', {id})";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> PrepareShareClassesForPDFExtract(DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_shareclass_pdf('{chosenDate?.ToString("yyyyMMdd")}')";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetShareClassTimeSeriesData(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"SELECT convert(varchar, date_ts, 103)date_ts , value_ts [type], " +
                                      $"concat(tsp.desc_provider,' ',currency_ts) " +
                                      $"providerccy FROM [tb_timeseries_shareclass] " +
                                      $"join tb_dom_timeseries_provider tsp on tsp.id_provider = provider_ts " +
                                      $"where id_shareclass = {id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetShareClassTimeSeriesDates(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"SELECT distinct  date_ts, convert(varchar,date_ts , 103) " +
                                      $"datechart  FROM [tb_timeseries_shareclass] " +
                                      $"join tb_dom_timeseries_provider tsp on tsp.id_provider = provider_ts " +
                                      $"where id_shareclass = {id} order by date_ts asc";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetTimeseriesTypeProviders(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"SELECT distinct " +
                    $"concat(tsp.desc_provider,' ',currency_ts) " +
                    $"[Timeseries Provider] FROM [tb_timeseries_shareclass] " +
                    $"join tb_dom_timeseries_provider tsp on tsp.id_provider=provider_ts " +
                    $"where id_shareclass= {id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetShareClassesTimeline(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from dbo.fn_timeline_shareclass({id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllShareClassesDocumens(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from [dbo].[fn_viewdocuments_shareclass]({id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public void CreateShareClass(
                        string initialDate,
                        string endDate,
                        string shareClassName,
                        int? investorTypeId,
                        int? shareTypeId,
                        string currency,
                        string countryIssue,
                        string countryRisk,
                        string emissionDate,
                        string inceptionDate,
                        string lastNavDate,
                        string expiryDate,
                        int scStatusId,
                        double initialPrice,
                        string accountingCode,
                        bool isHedged,
                        bool isListed,
                        string bloombergMarket,
                        string bloombergCode,
                        string bloombergId,
                        string isinCode,
                        string valorCode,
                        string faCode,
                        string taCode,
                        string wKN,
                        string businessYearDate,
                        string prospectusCode,
                        int subFundContainerId)
        {
            string query = "EXEC sp_new_shareclass " +
                "@sc_initialDate, @sc_endDate, @sc_officialShareClassName, " +
                "@sc_shortShareClassName, @sc_investorType, @sc_shareType, @sc_currency, " +
                "@sc_countryIssue, @sc_ultimateParentCountryRisk, @sc_emissionDate, @sc_inceptionDate, " +
                "@sc_lastNav, @sc_expiryDate, @sc_status, @sc_initialPrice, " +
                "@sc_accountingCode, @sc_hedged, @sc_listed, @sc_bloomberMarket, " +
                "@sc_bloomberCode, @sc_bloomberId, @sc_isinCode, @sc_valorCode, " +
                "@sc_faCode, @sc_taCode, @sc_WKN, @sc_date_business_year, " +
                "@sc_prospectus_code, @subfundcontainer";

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@sc_initialDate", SqlDbType.NVarChar, 100) { Value = initialDate},
                        new SqlParameter("@sc_endDate", SqlDbType.NVarChar, 100) { Value = endDate},
                        new SqlParameter("@sc_officialShareClassName", SqlDbType.NVarChar, 100) { Value = shareClassName },
                        new SqlParameter("@sc_shortShareClassName", SqlDbType.NVarChar, 100) { Value = shareClassName },
                        new SqlParameter("@sc_investorType", SqlDbType.Int) { Value = investorTypeId },
                        new SqlParameter("@sc_shareType", SqlDbType.Int) { Value = shareTypeId },
                        new SqlParameter("@sc_currency", SqlDbType.NChar, 3) { Value = currency },
                        new SqlParameter("@sc_countryIssue", SqlDbType.NChar, 2) { Value = countryIssue },
                        new SqlParameter("@sc_ultimateParentCountryRisk", SqlDbType.NChar, 3) { Value = countryRisk },
                        new SqlParameter("@sc_emissionDate", SqlDbType.NVarChar, 100) { Value = emissionDate},
                        new SqlParameter("@sc_inceptionDate", SqlDbType.NVarChar, 100) { Value = inceptionDate},
                        new SqlParameter("@sc_lastNav", SqlDbType.NVarChar, 100) { Value = lastNavDate},
                        new SqlParameter("@sc_expiryDate", SqlDbType.NVarChar, 100) { Value = expiryDate},
                        new SqlParameter("@sc_status", SqlDbType.Int) { Value = scStatusId },
                        new SqlParameter("@sc_initialPrice", SqlDbType.Float) { Value = initialPrice },
                        new SqlParameter("@sc_accountingCode", SqlDbType.NVarChar, 100) { Value = accountingCode},
                        new SqlParameter("@sc_hedged", SqlDbType.Bit) { Value = isHedged },
                        new SqlParameter("@sc_listed", SqlDbType.Bit) { Value = isListed },
                        new SqlParameter("@sc_bloomberMarket", SqlDbType.NVarChar, 100) { Value = bloombergMarket},
                        new SqlParameter("@sc_bloomberCode", SqlDbType.NVarChar, 100) { Value = bloombergCode},
                        new SqlParameter("@sc_bloomberId", SqlDbType.NVarChar, 100) { Value = bloombergId},
                        new SqlParameter("@sc_isinCode", SqlDbType.NChar, 12) { Value = isinCode},
                        new SqlParameter("@sc_valorCode", SqlDbType.NVarChar, 100) { Value = valorCode},
                        new SqlParameter("@sc_faCode", SqlDbType.NVarChar, 100) { Value = faCode },
                        new SqlParameter("@sc_taCode", SqlDbType.NVarChar, 100) { Value = taCode },
                        new SqlParameter("@sc_WKN", SqlDbType.NVarChar, 100) { Value = wKN},
                        new SqlParameter("@sc_date_business_year", SqlDbType.NVarChar, 100) { Value = businessYearDate},
                        new SqlParameter("@sc_prospectus_code", SqlDbType.NVarChar, 100) { Value = prospectusCode},
                        new SqlParameter("@subfundcontainer", SqlDbType.Int) { Value = subFundContainerId },
                    });

                    foreach (SqlParameter parameter in command.Parameters)
                    {
                        if (parameter.Value == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                    }

                    command.Connection = connection;

                    try
                    {
                        command.Connection.Open();
                        command.ExecuteScalar();
                    }
                    catch (SqlException sx)
                    {
                        Console.WriteLine(sx.Message);
                    }
                }
            }
        }
    }
}