namespace DataGate.Services.Redis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Services.Redis.Configuration;
    using DataGate.Services.Redis.Contracts;
    using StackExchange.Redis;

    public class RedisContainer : IProxy
    {
        private readonly RedisConnection connection;
        private Dictionary<string, RedisObject> trackedObjects = 
            new Dictionary<string, RedisObject>();

        public RedisContainer(RedisConnection redisConnection, string keyNameSpace = "")
        {
            this.connection = redisConnection;
            this.Database = redisConnection.Connection().GetDatabase();
            this.KeyNameSpace = keyNameSpace ?? "";
        }

        public IDatabase Database { get; private set; }

        IDatabaseAsync IProxy.DB => this.Database;

        public string KeyNameSpace { get; }

        public T AddToContainer<T>(T obj) 
            where T : RedisObject
        {
            obj.Container = this;
            obj.KeyName = string.IsNullOrWhiteSpace(this.KeyNameSpace) ? 
                $"{obj.BaseKeyName}" : 
                $"{this.KeyNameSpace}:{obj.BaseKeyName}";

            if (!this.TrackedKeys.Contains(obj.KeyName))
                this.trackedObjects.Add(obj.KeyName, obj);

            return obj;
        }

        public T GetKey<T>(string keyName) where T : RedisObject
        {
            return GetKey(typeof(T), keyName) as T;
        }

        public RedisObject GetKey(Type keyType, string keyName)
        {
            RedisObject obj;
            var fullKeyName = $"{this.KeyNameSpace}:{keyName}";

            if (this.trackedObjects.TryGetValue(fullKeyName, out obj)) return obj;

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
            get { return this.trackedObjects.Select(p => p.Key).ToList(); }
        }
    }
}