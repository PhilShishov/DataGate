// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Redis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using StackExchange.Redis;

    using DataGate.Common;
    using DataGate.Services.Redis.Configuration;
    using DataGate.Services.Redis.Contracts;

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
    }
}