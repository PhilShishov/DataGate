namespace DataGate.Services.Redis.Tests
{
    using System.Threading.Tasks;

    using DataGate.Services.Redis.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RedisContainerTests
    {
        public static RedisConnection redisConnection;
        public RedisContainer container;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            redisConnection = new RedisConnection("127.0.0.1:4455,abortConnect=false");
        }

        [TestInitialize]
        public void Init()
        {
            container = new RedisContainer(redisConnection, "test-container");
        }

        [TestCleanup()]
        public void Cleanup()
        {
            container.DeleteTrackedKeys().Wait();
        }

        [TestMethod]
        public async Task KeyMethods()
        {
            Assert.IsFalse(await container.DeleteKey("not-exists"));
            Assert.IsFalse(await container.KeyExists("not-exists"));
            var key = container.GetKey<RedisItem<int>>("intkey");
            await key.Set(1);
            Assert.IsTrue(await container.KeyExists("intkey"));
            Assert.IsTrue(await container.DeleteKey(key.KeyName, false));
        }
    }
}
