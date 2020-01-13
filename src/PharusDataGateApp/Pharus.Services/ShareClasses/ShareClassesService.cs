// Service class for managing shareclasses

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.Services.ShareClasses
{
    using System;
    using System.Linq;
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

        public List<string[]> GetAllActiveShareClassesWithSelectedViewAndDate(List<string> preSelectedColumns, List<string> selectedColumns, DateTime? chosenDate)
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
                    command.CommandText = $"select * from fn_SubfundForShareclassAtDate('{this.defaultDate}', {id})";
                }

                else
                {
                    command.CommandText = $"select * from fn_SubfundForShareclassAtDate('{chosenDate?.ToString("yyyyMMdd")}', {id})";
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

        public List<string[]> GetShareClassTimeSeries(int id)
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
                                      $"where id_shareclass = 70";

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
                                      $"where id_shareclass = 70 order by date_ts asc";

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
                    $"where id_shareclass= 70";

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

        public void EditShareClass(int scId, string initialDate, string subFundName, string cssfCode, string faCode, string depCode, string taCode, string firstNavDate, string lastNavDate, string cssfAuthDate, string expiryDate, int sfStatusId, string leiCode, int? cesrClassId, int? geoFocusId, int? glExpId, string currency, int? frequencyId, int? valuationId, int? calculationId, bool isDerivative, int? derivMarketId, int? derivPurposeId, int? principalAssetId, int? typeMarketId, int? principalInvStrId, string clearingCode, int? catMorningStarId, int? catSixId, int? catBloombergId, string comment, string commentTitle)
        {
            throw new NotImplementedException();
        }

        public void CreateShareClass(string initialDate, string endDate, string subFundName, string cssfCode, string faCode, string depCode, string taCode, string firstNavDate, string lastNavDate, string cssfAuthDate, string expiryDate, int sfStatusId, string leiCode, int? cesrClassId, int? geoFocusId, int? glExpId, string currency, int? frequencyId, int? valuationId, int? calculationId, bool isDerivative, int? derivMarketId, int? derivPurposeId, int? principalAssetId, int? typeMarketId, int? principalInvStrId, string clearingCode, int? catMorningStarId, int? catSixId, int? catBloombergId, int subFundContainerId)
        {
            throw new NotImplementedException();
        }
    }
}