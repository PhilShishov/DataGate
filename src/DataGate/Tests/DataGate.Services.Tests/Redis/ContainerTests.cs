// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.Redis
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Redis;
    using DataGate.Services.Tests.ClassFixtures;
    using DataGate.Web.Infrastructure.Extensions;

    using Xunit;

    public class ContainerTests : IClassFixture<RedisFixture>, IDisposable
    {
        private readonly RedisContainer container;

        public ContainerTests(RedisFixture fixture)
        {
            this.container = new RedisContainer(fixture.RedisConnection, GlobalConstants.TestContainer);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.container.DeleteTrackedKeys().Wait();
            }
        }

        [Fact, Trait("Category", "A")]
        public async Task DeleteKey_And_KeyExists_WithNonExistantKey_ShouldReturnFalse()
        {
            Assert.False(await container.DeleteKey("not-exists"));
            Assert.False(await container.KeyExists("not-exists"));
        }

        [Theory, Trait("Category", "A")]
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

        [Theory, Trait("Category", "A")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void GetKey_WithInvalidKeyName_ShouldThrowException(string keyName)
        {
            Action act = () => container.GetKey<RedisItem<string>>(keyName);

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact, Trait("Category", "A")]
        public async Task DeleteKey_WithExistingKey_ShouldReturnTrue()
        {
            var key = container.GetKey<RedisItem<int>>("intkey");
            await key.Set(1);
            Assert.True(await container.DeleteKey(key.KeyName, false));
        }
    }
}
