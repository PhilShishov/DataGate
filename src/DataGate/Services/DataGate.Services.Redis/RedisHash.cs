namespace DataGate.Services.Redis
{
    using System.Collections.Generic;
    using System.Linq;

    using StackExchange.Redis;
    using System.Threading.Tasks;
    using System.Threading;

    public class RedisValueHash : RedisHash<RedisValue, RedisValue>
    {
        public RedisValueHash(string keyName)
            : base(keyName) { }
    }

    public class RedisHash<TKey, TValue>
        : RedisObject, IAsyncEnumerable<KeyValuePair<TKey, TValue>>
    {
        public RedisHash(string keyName)
            : base(keyName) { }

        public Task<ICollection<TKey>> Keys()
        {
            return base.Executor.HashKeysAsync(base.KeyName)
                  .ContinueWith<ICollection<TKey>>(r => r.Result.Select(k => ToElement<TKey>(k)).ToList(),
                  TaskContinuationOptions.ExecuteSynchronously | 
                  TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public Task<ICollection<TValue>> Values()
        {
            return Executor.HashValuesAsync(base.KeyName)
                   .ContinueWith<ICollection<TValue>>(r => r.Result.Select(v => ToElement<TValue>(v)).ToList(),
                  TaskContinuationOptions.ExecuteSynchronously | 
                  TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public Task<bool> Set(TKey key, TValue value, When when = When.Always)
        {
            var rfield = ToRedisValue(key);
            var rval = ToRedisValue(value);
            return Executor.HashSetAsync(base.KeyName, rfield, rval, when);
        }

        public async IAsyncEnumerator<KeyValuePair<TKey, TValue>> GetAsyncEnumerator()
        {
            await foreach (var entry in Executor.HashScanAsync(base.KeyName))
            {
                yield return new KeyValuePair<TKey, TValue>(ToElement<TKey>(entry.Name), ToElement<TValue>(entry.Value));
            }
        }

        IAsyncEnumerator<KeyValuePair<TKey, TValue>> IAsyncEnumerable<KeyValuePair<TKey, TValue>>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAsyncEnumerator();
        }
    }
}
