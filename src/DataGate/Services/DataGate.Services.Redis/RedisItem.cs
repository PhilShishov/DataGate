namespace DataGate.Services.Redis
{
    using System;
    using System.Threading.Tasks;

    public class RedisItem<T> : RedisObject
    {
        public RedisItem(string keyName) : base(keyName) { }

        public Task<bool> Set(T value, TimeSpan? expiration = null, 
            StackExchange.Redis.When when = StackExchange.Redis.When.Always)
        {
            return Executor.StringSetAsync(KeyName, ToRedisValue(value), expiration, when);
        }
    }
}
