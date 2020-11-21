namespace DataGate.Services.Tests.ClassFixtures
{
    using DataGate.Common;
    using DataGate.Services.Redis.Configuration;

    public class RedisFixture
    {
        public readonly RedisConnection RedisConnection;

        public RedisFixture()
        {
            // How to setup Redis for testing:
            //   1.Download redis server from here: 
            //https://github.com/microsoftarchive/redis/releases/tag/win-3.0.504

            //   2.Change your wwrootpath
            this.RedisConnection = new RedisConnection(
                GlobalConstants.RedisConnectionString, 
                GlobalConstants.WwwRootPath);
        }
    }
}
