namespace DataGate.Services.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Services.Redis;
    using DataGate.Services.Redis.Configuration;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.ViewModels.Queries;

    public class EntityService : IEntityService
    {
        private readonly ISqlQueryManager sqlManager;
        private const int IndexEntityId = 0;

        public EntityService(ISqlQueryManager sqlQueryManager)
        {
            this.sqlManager = sqlQueryManager;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public async IAsyncEnumerable<string[]> All(string function, int? id, DateTime? date, int skip)
        {
            var data = SetupRedis();

            if (data.Values().Result.Count == 0 || data.Keys().Result.Count == 0)
            {
                var query = this.sqlManager
                   .ExecuteQueryAsync(function, date, id)
                   .Skip(skip);

                await foreach (var item in query)
                {
                    await data.Set(item[IndexEntityId], item);
                }
            }

            var ordered = data.OrderBy(d => int.TryParse(d.Key, out var x) ? x : -1);

            await foreach (var item in ordered)
            {
                yield return item.Value;
            }

            //var query = this.sqlManager
            //    .ExecuteQueryAsync(function, date, id)
            //    .Skip(skip);

            //await foreach (var item in query)
            //{
            //    yield return item;
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

        private static RedisHash<string, string[]> SetupRedis()
        {
            //var cacheType = StringSwapper.ByArea(area, )
            //var optionsRedis = 

            var connection = new RedisConnection("127.0.0.1:6379,abortConnect=false");
            var container = new RedisContainer(connection, "DataGate_Cache_Container");

            var data = container.GetKey<RedisHash<string, string[]>>("FundCacheRecords");
            return data;
        }
    }
}
