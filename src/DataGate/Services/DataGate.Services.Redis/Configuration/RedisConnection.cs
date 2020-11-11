namespace DataGate.Services.Redis.Configuration
{
    using System;

    using StackExchange.Redis;

    public class RedisConnection
    {
        private static Lazy<ConnectionMultiplexer> connection;

        public RedisConnection(string configuration)
        {
            connection = new Lazy<ConnectionMultiplexer>(() =>
            {
                var connMultiplexer = ConnectionMultiplexer.Connect(configuration);
                return connMultiplexer;
            });
        }

        public ConnectionMultiplexer Connection()
        => connection.Value;
    }
}
