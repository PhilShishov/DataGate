namespace DataGate.Services.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Services.Redis;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.ViewModels.Queries;
    using Microsoft.Extensions.Caching.Distributed;

    public class EntityService : IEntityService
    {
        private readonly ISqlQueryManager sqlManager;
        private readonly IDistributedCache distributedCache;

        public EntityService(
            ISqlQueryManager sqlQueryManager,
            IDistributedCache distributedCache)
        {
            this.sqlManager = sqlQueryManager;
            this.distributedCache = distributedCache;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public async IAsyncEnumerable<string[]> All(string function, int? id, DateTime? date, int skip)
        {
            //var query = this.sqlManager
            //    .ExecuteQueryAsync(function, date, id)
            //    .Skip(skip);

            //await foreach (var item in query)
            //{
            //    yield return item;
            //}

            var data = this.distributedCache.Get("CacheRecords");
            var deserialized = new List<string[]>();

            if (data == null)
            {
                //var query = this.sqlManager
                //    .ExecuteQueryAsync(function, date, id)
                //    .Skip(skip);

                //await foreach (var item in query)
                //{
                //    var serialized = Serializer.ObjectToByteArray<string>(item);
                //    this.distributedCache.Set(
                //        $" {item[3]}",
                //        serialized,
                //        new DistributedCacheEntryOptions
                //        {
                //            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(10),
                //        });

                //    deserialized.Add(Deserializer.ByteArrayToObject<string>(serialized).ToArray());
                //}
                //foreach (var item in deserialized)
                //{
                //    yield return item;
                //}

                var query = this.sqlManager
                   .ExecuteQueryAsync(function, date, id);
                //.Skip(skip);

                List<string[]> result = await query.ToListAsync();

                data = Serializer.ObjectToByteArray<string>(result.FirstOrDefault());
                this.distributedCache.Set("CacheRecords", data, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(10),
                });
                deserialized.Add(Deserializer.ByteArrayToObject<string>(data).ToArray());

            }

            yield return Deserializer.ByteArrayToObject<string>(data).ToArray();
        }

        public async IAsyncEnumerable<string[]> AllSelected(
                                                    string function,
                                                    GetWithSelectionDto dto,
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
    }
}
