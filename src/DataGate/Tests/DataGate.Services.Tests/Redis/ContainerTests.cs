namespace DataGate.Services.Tests.Redis
{
    using System;
    using System.Threading.Tasks;

    using Xunit;

    using DataGate.Common;
    using DataGate.Services.Redis;
    using DataGate.Services.Tests.ClassFixtures;
    using DataGate.Web.Infrastructure.Extensions;

    public class ContainerTests : IClassFixture<RedisFixture>, IDisposable
    {
        private readonly RedisContainer container;

        public ContainerTests(RedisFixture fixture)
        {
            this.container = new RedisContainer(fixture.RedisConnection, GlobalConstants.TestContainer);
        }

        public void Dispose()
        {
            this.container.DeleteTrackedKeys().Wait();
        }

        [Fact]
        public async Task DeleteKey_And_KeyExists_WithNonExistantKey_ShouldReturnFalse()
        {
            Assert.False(await container.DeleteKey("not-exists"));
            Assert.False(await container.KeyExists("not-exists"));
        }

        [Theory]
        [InlineData(TypeCode.String, "stringkey")]
        [InlineData(TypeCode.Int32, "intkey")]
        [InlineData(TypeCode.Boolean, "boolkey")]
        [InlineData(TypeCode.Char, "charkey")]
        public async Task Set_WithPrimitiveTypeAndKeyName_ShouldCreateNewKey(TypeCode typeCode, string keyName)
        {
            switch (typeCode)
            {
                case TypeCode.String:
                    var keyString = container.GetKey<RedisItem<string>>(keyName);
                    await keyString.Set("stringkey-value");
                    break;
                case TypeCode.Int32:
                    var keyInt = container.GetKey<RedisItem<int>>(keyName);
                    await keyInt.Set(1);
                    break;
                case TypeCode.Boolean:
                    var keyBool = container.GetKey<RedisItem<bool>>(keyName);
                    await keyBool.Set(true);
                    break;
                case TypeCode.Char:
                    var keyChar = container.GetKey<RedisItem<char>>(keyName);
                    await keyChar.Set('A');
                    break;
            }

            Assert.True(await container.KeyExists(keyName));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void GetKey_WithInvalidKeyName_ShouldThrowException(string keyName)
        {
            Action act = () => container.GetKey<RedisItem<string>>(keyName);

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public async Task DeleteKey_WithExistingKey_ShouldReturnTrue()
        {
            var key = container.GetKey<RedisItem<int>>("intkey");
            await key.Set(1);
            Assert.True(await container.DeleteKey(key.KeyName, false));
        }
    }
}
