namespace DataGate.Services.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Common.Settings;
    using DataGate.Services.Redis;
    using DataGate.Services.Redis.Configuration;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Queries;
    using Microsoft.Extensions.Configuration;

    public class EntityService : IEntityService
    {
        private readonly ISqlQueryManager sqlManager;
        private readonly IConfiguration configuration;

        public EntityService(
            ISqlQueryManager sqlQueryManager,
            IConfiguration configuration)
        {
            this.sqlManager = sqlQueryManager;
            this.configuration = configuration;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public async IAsyncEnumerable<string[]> All(string function, int? id, DateTime? date, int skip)
        {
            var query = this.sqlManager
                .ExecuteQueryAsync(function, date, id)
                .Skip(skip);

            await foreach (var item in query)
            {
                yield return item;
            }

            // ________________________________________________________
            //
            // Working Redis code on localhost and dedicated server, not working in shared server
            //var data = SetupRedis(this.configuration, function);
            //await data.Expire(GlobalConstants.RedisCacheExpirationTimeInSeconds);

            //if (data.Values().Result.Count == 0 || data.Keys().Result.Count == 0)
            //{
            //    var query = this.sqlManager
            //       .ExecuteQueryAsync(function, date, id)
            //       .Skip(skip);

            //    await foreach (var item in query)
            //    {
            //        await data.Set(item[IndexEntityId], item);
            //    }
            //}

            //var ordered = data.OrderBy(d => int.TryParse(d.Key, out var x) ? x : -1);

            //await foreach (var item in ordered)
            //{
            //    yield return item.Value;
            //}
        }

        public async IAsyncEnumerable<string[]> AllSelected(
                                                    string function,
                                                    AllSelectedDto dto,
                                                    int skip)
        {
            // Create new collection to store
            // selected without change
            List<string> resultColumns = FormatSql.FormatColumns(dto.PreSelectedColumns, dto.SelectedColumns);

            var query = this.sqlManager
                .ExecuteQueryAsync(function, dto.Date, dto.Id, resultColumns)
                .Skip(skip);

            await foreach (var item in query)
            {
                yield return item;
            }
        }

        private static RedisHash<string, string[]> SetupRedis(IConfiguration configuration, string function)
        {
            var optionsRedis = configuration
                .GetSection(AppSettingsSections.RedisSection)
                .Get<RedisOptions>();

            //RedisServer.Run();

            var connection = new RedisConnection($"{optionsRedis.Host}:{optionsRedis.Port}, {GlobalConstants.AbortConnect}");
            var container = new RedisContainer(connection, optionsRedis.InstanceName);

            var data = container.GetKey<RedisHash<string, string[]>>(GlobalConstants.RedisCacheRecords + function);
            return data;
        }
    }
}
