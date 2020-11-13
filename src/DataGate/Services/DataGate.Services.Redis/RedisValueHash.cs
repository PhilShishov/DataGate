namespace DataGate.Services.Redis
{

    using StackExchange.Redis;

    public class RedisValueHash : RedisHash<RedisValue, RedisValue>
    {
        public RedisValueHash(string keyName)
            : base(keyName) { }
    }
}
