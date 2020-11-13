namespace DataGate.Services.Redis
{
    using System.Collections.Generic;
    using System.Linq;

    using StackExchange.Redis;
    using System.Threading.Tasks;
    using System.Threading;

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

        public Task<long> Count()
        {
            return Executor.HashLengthAsync(KeyName);
        }

        public Task<TValue> Get(TKey key)
        {
            return Executor.HashGetAsync(KeyName, ToRedisValue(key))
              .ContinueWith<TValue>(r => ToElement<TValue>(r.Result),
              TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public Task<IList<TValue>> GetRange(ICollection<TKey> keys)
        {
            var fields = keys.Select(k => (RedisValue)ToRedisValue(k)).ToArray();
            return Executor.HashGetAsync(KeyName, fields)
                   .ContinueWith<IList<TValue>>(r => r.Result.Select(v => ToElement<TValue>(v)).ToList(),
                    TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public Task<bool> Set(TKey key, TValue value, When when = When.Always)
        {
            var rfield = ToRedisValue(key);
            var rval = ToRedisValue(value);
            return Executor.HashSetAsync(base.KeyName, rfield, rval, when);
        }

        public Task SetRange(ICollection<KeyValuePair<TKey, TValue>> items)
        {
            var entries = items.Select(p => new HashEntry(ToRedisValue(p.Key), ToRedisValue(p.Value))).ToArray();
            return Executor.HashSetAsync(KeyName, entries);
        }

        public Task<bool> Remove(TKey key)
        {
            var rkey = ToRedisValue(key);
            return Executor.HashDeleteAsync(KeyName, rkey);
        }

        public Task<long> RemoveRange(ICollection<TKey> keys)
        {
            var fields = keys.Select(k => (RedisValue)ToRedisValue(k)).ToArray();
            return Executor.HashDeleteAsync(KeyName, fields);
        }

        public Task<bool> ContainsKey(TKey key)
        {
            return Executor.HashExistsAsync(KeyName, ToRedisValue(key));
        }

        public Task<long> Increment(TKey key, long value = 1)
        {
            return Executor.HashIncrementAsync(KeyName, ToRedisValue(key), value);
        }

        public Task<long> Decrement(TKey key, long value = 1)
        {
            return Executor.HashDecrementAsync(KeyName, ToRedisValue(key), value);
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
