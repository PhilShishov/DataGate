namespace DataGate.Services.Redis.Configuration
{
    using System;

    using StackExchange.Redis;

    using DataGate.Workers.BatchPrograms;
    using DataGate.Workers.BatchPrograms.Contracts;

    public class RedisConnection
    {
        private static Lazy<ConnectionMultiplexer> connection;
        private readonly IExecutor executor;

        public RedisConnection(string configuration, string dirPath)
        {
            this.executor = new RedisServer();

            connection = new Lazy<ConnectionMultiplexer>(() =>
            {
                var connMultiplexer = ConnectionMultiplexer.Connect(configuration);

                if (!connMultiplexer.IsConnected)
                {
                    // Running in Windows

                    this.executor.Execute(dirPath);
                }

                return connMultiplexer;
            });
        }

        public ConnectionMultiplexer Connection() => connection.Value;
    }
}