namespace DataGate.Services.Redis
{
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;

    using DataGate.Services.Redis.Contracts;
    using StackExchange.Redis;

    public abstract class RedisObject
    {
        private string keyName;
        private RedisContainer container;
        private IProxy RedisMulti;

        public RedisObject(string receivedName) => this.BaseKeyName = receivedName;

        public RedisContainer Container
        {
            get
            {
                if (this.container == null)
                {
                    throw new InvalidOperationException("Must add this object to a RedisContainer first.");
                }
                return this.container;
            }
            internal set
            {
                this.container = value;
            }
        }

        public IDatabaseAsync Executor
        {
            get
            {
                if (this.RedisMulti != null) return this.RedisMulti.DB;
                return this.Container.Database;
            }
        }

        public string BaseKeyName { get; }

        public string KeyName
        {
            get => this.keyName ?? this.BaseKeyName;
            internal set => this.keyName = value;
        }

        public async Task<bool> Expire(int seconds)
        {
            var ts = TimeSpan.FromSeconds(seconds);
            return await Executor.KeyExpireAsync(KeyName, ts);
        }

        public Task<bool> DeleteKey()
        {
            return Executor.KeyDeleteAsync(KeyName);
        }

        public static RedisValue ToRedisValue(object element)
        {
            if (element == null) return RedisValue.Null;
            if (element is byte[] b) return b;
            if (element is RedisValue x) return x;
            if (element is IConvertible _) return ConvertToRedisValue(element);
            return JsonSerializer.Serialize(element);
        }

        public static T ToElement<T>(RedisValue value)
        {
            if (value.HasValue == false) return default;
            if (typeof(byte[]) == typeof(T)) return (T)Convert.ChangeType(value, typeof(T));
            if (typeof(RedisValue) == typeof(T)) return (T)Convert.ChangeType(value, typeof(T));
            if (typeof(IConvertible).IsAssignableFrom(typeof(T))) return (T)ConvertFromRedisValue(typeof(T), value);
            return JsonSerializer.Deserialize<T>(value);
        }

        private static object ConvertFromRedisValue(Type t, RedisValue value)
        {
            switch (Type.GetTypeCode(t))
            {
                case TypeCode.Boolean: return bool.Parse(value);
                case TypeCode.Char: return char.Parse(value);
                case TypeCode.DateTime: return new DateTime(long.Parse(value));
                case TypeCode.Decimal: return decimal.Parse(value);
                case TypeCode.Double: return double.Parse(value);
                case TypeCode.Int16: return short.Parse(value);
                case TypeCode.Int32: return int.Parse(value);
                case TypeCode.Int64: return long.Parse(value);
                case TypeCode.SByte: return sbyte.Parse(value);
                case TypeCode.Single: return float.Parse(value);
                case TypeCode.String: return value.ToString();
                case TypeCode.UInt16: return ushort.Parse(value);
                case TypeCode.UInt32: return uint.Parse(value);
                case TypeCode.UInt64: return ulong.Parse(value);
                default:
                    throw new Exception("Unsupported type");
            }
        }

        private static RedisValue ConvertToRedisValue(object value)
        {
            switch (value)
            {
                case RedisValue b: return b;
                case bool b: return b;
                case char b: return b.ToString();
                case DateTime b: return b.Ticks;
                case decimal b: return (double)b;
                case double b: return b;
                case Int16 b: return b;
                case Int32 b: return b;
                case Int64 b: return b;
                case sbyte b: return b;
                case Single b: return b;
                case string b: return b;
                case UInt16 b: return (uint)b;
                case UInt32 b: return b;
                case UInt64 b: return b;
                default:
                    throw new Exception("Unsupported type");
            }
        }
    }
}
