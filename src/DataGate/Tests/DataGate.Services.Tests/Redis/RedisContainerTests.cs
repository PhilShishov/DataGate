namespace DataGate.Services.Tests.Redis
{
    using System;
    using System.Threading.Tasks;

    using Xunit;

    using DataGate.Common;
    using DataGate.Services.Redis;
    using DataGate.Services.Tests.ClassFixtures;

    public class RedisContainerTests : IClassFixture<RedisFixture>, IDisposable
    {
        public readonly RedisContainer container;

        public RedisContainerTests(RedisFixture fixture)
        {
            container = new RedisContainer(fixture.RedisConnection, GlobalConstants.TestContainer);
        }

        public void Dispose()
        {
            container.DeleteTrackedKeys().Wait();
        }

        [Fact]
        public async Task DeleteKey_And_KeyExists_WithNonExistantKey_ShouldReturnFalse()
        {
            Assert.False(await container.DeleteKey("not-exists"));
            Assert.False(await container.KeyExists("not-exists"));
        }

        //[TestMethod]
        //public async Task SetKey_WithIntType_ShouldReturnTrue()
        //{
        //    var key = container.GetKey<RedisItem<int>>("intkey");
        //    await key.Set(1);
        //    Assert.IsTrue(await container.KeyExists("intkey"));
        //}

        [Theory]
        [InlineData(null, "stringkey")]
        [InlineData("intkey")]
        public async Task SetKey_WithPrimitiveTypeAndKeyName_ShouldReturnTrue(string keyName)
        {
            //Type type = value.GetType();


            var key = container.GetKey<RedisItem<string>>(keyName);
            await key.Set("stringkey-value");
            Assert.True(await container.KeyExists(keyName));
        }

        [Fact]
        public async Task KeyMethods()
        {
            var key = container.GetKey<RedisItem<int>>("intkey");
            await key.Set(1);
            Assert.True(await container.KeyExists("intkey"));
            Assert.True(await container.DeleteKey(key.KeyName, false));
        }
    }
}
