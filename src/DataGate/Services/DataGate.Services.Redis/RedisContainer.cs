// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Redis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Common.Settings;
    using DataGate.Services.Redis.Configuration;
    using DataGate.Services.Redis.Contracts;

    using Microsoft.Extensions.Configuration;

    using StackExchange.Redis;

    public class RedisContainer : IProxy
    {
        private readonly RedisConnection connection;
        private readonly Dictionary<string, RedisObject> trackedObjects =
            new Dictionary<string, RedisObject>();

        public RedisContainer(RedisConnection redisConnection, string keyNameSpace = "")
        {
            this.connection = redisConnection;
            this.Database = redisConnection.Connection().GetDatabase();
            this.KeyNameSpace = keyNameSpace ?? "";
        }

        public IDatabase Database { get; private set; }

        IDatabaseAsync IProxy.ProxyDatabase => this.Database;

        public string KeyNameSpace { get; }

        public T AddToContainer<T>(T instance)
            where T : RedisObject
        {
            instance.Container = this;
            instance.KeyName = string.IsNullOrWhiteSpace(this.KeyNameSpace) ?
                $"{instance.BaseKeyName}" :
                $"{this.KeyNameSpace}:{instance.BaseKeyName}";

            if (!this.TrackedKeys.Contains(instance.KeyName))
            {
                this.trackedObjects.Add(instance.KeyName, instance);
            }

            return instance;
        }

        public T GetKey<T>(string keyName) 
            where T : RedisObject
        {
            Validator.ArgumentNullExceptionString(keyName, ErrorMessages.InvalidKeyName);

            return GetKey(typeof(T), keyName) as T;
        }

        public RedisObject GetKey(Type keyType, string keyName)
        {
            var fullKeyName = $"{this.KeyNameSpace}:{keyName}";

            if (this.trackedObjects.TryGetValue(fullKeyName, out RedisObject obj))
            {
                return obj;
            }

            var instance = Activator.CreateInstance(keyType, keyName) as RedisObject;
            this.AddToContainer(instance);
            return instance;
        }

        public async Task DeleteTrackedKeys()
        {
            var keys = this.TrackedKeys.Select(k => (RedisKey)k).ToArray();
            await this.Database.KeyDeleteAsync(keys);
            this.trackedObjects.Clear();
        }

        public IList<string> TrackedKeys
        {
            get { return this.trackedObjects.Select(x => x.Key).ToList(); }
        }


        public async static Task<RedisHash<string, string[]>> Setup(IConfiguration configuration, string dirPath, string function)
        {
            var optionsRedis = configuration
                .GetSection(AppSettingsSections.RedisSection)
                .Get<RedisOptions>();

            var connection = new RedisConnection($"{optionsRedis.Host}:{optionsRedis.Port}, {GlobalConstants.AbortConnect}", dirPath);
            var container = new RedisContainer(connection, optionsRedis.InstanceName);

            var data = container.GetKey<RedisHash<string, string[]>>(GlobalConstants.RedisCacheRecords + function);

            await data.Expire(GlobalConstants.RedisCacheExpirationTimeInSeconds);

            return data;
        }
    }
}