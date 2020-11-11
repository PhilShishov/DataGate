namespace DataGate.Services.Redis.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Services.Redis.Contracts;
    using StackExchange.Redis;

    public class RedisContainer : IProxy
    {
        private readonly RedisConnection connection;
        private Dictionary<string, RedisObject> trackedObjects = new Dictionary<string, RedisObject>();

        public RedisContainer(
            RedisConnection connection,
            string keyNameSpace = "")
        {
            this.connection = connection;
            this.Database = this.connection.Connection().GetDatabase();
            this.KeyNameSpace = keyNameSpace ?? "";
        }

        public IDatabase Database { get; private set; }

        IDatabaseAsync IProxy.DB => Database;

        public string KeyNameSpace { get; }

        public T AddToContainer<T>(T obj)
            where T : RedisObject
        {
            obj.Container = this;
            obj.KeyName = string.IsNullOrWhiteSpace(this.KeyNameSpace) ?
                $"{obj.BaseKeyName}" :
                $"{this.KeyNameSpace}:{obj.BaseKeyName}";

            if (!TrackedKeys.Contains(obj.KeyName))
                this.trackedObjects.Add(obj.KeyName, obj);

            return obj;
        }

        public T GetKey<T>(string keyName)
            where T : RedisObject
        {
            return this.GetKey(typeof(T), keyName) as T;
        }

        public RedisObject GetKey(Type keyType, string keyName)
        {
            RedisObject obj;
            var fullKeyName = $"{this.KeyNameSpace}:{keyName}";

            if (this.trackedObjects.TryGetValue(fullKeyName, out obj))
            {
                return obj;
            }

            var instance = Activator.CreateInstance(keyType, keyName) as RedisObject;
            this.AddToContainer(instance);
            return instance;
        }

        public IList<string> TrackedKeys
        {
            get => this.trackedObjects.Select(p => p.Key).ToList();
        }
    }
}