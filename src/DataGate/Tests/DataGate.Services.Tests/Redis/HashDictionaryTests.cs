// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.Redis
{
    using System;
    using System.Collections;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Redis;
    using DataGate.Services.Tests.ClassFixtures;
    using DataGate.Web.Tests.TestData;

    using Xunit;

    public class HashDictionaryTests : IClassFixture<RedisFixture>, IDisposable
    {
        private readonly RedisContainer container;
        private readonly RedisHash<string, int> hashDictionary;

        public HashDictionaryTests(RedisFixture fixture)
        {
            this.container = new RedisContainer(fixture.RedisConnection, GlobalConstants.TestHashContainer);
            this.hashDictionary = new RedisHash<string, int>("hashdictkey");
            this.container.AddToContainer(this.hashDictionary);
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
        public async Task SetRange_ShouldAddDataToHashDictionary()
        {
            var data = HashTestData.GenerateKeyValuePairs();
            await this.hashDictionary.SetRange(data);

            Assert.True((await this.hashDictionary.ContainsKey("2")));
            Assert.True((await this.hashDictionary.Count()) == 10);
        }

        [Fact, Trait("Category", "A")]
        public async Task KeysAndValues_ShouldReturnSameCount()
        {
            var data = HashTestData.GenerateKeyValuePairs();
            await this.hashDictionary.SetRange(data);

            var keys = await this.hashDictionary.Keys();
            var values = await this.hashDictionary.Values();

            var expectedCount = 10;

            Assert.Equal(expectedCount, keys.Count);
            Assert.Equal(expectedCount, values.Count);
            Assert.True(keys.Count == values.Count);
        }

        [Fact, Trait("Category", "A")]
        public async Task GetRange_ShouldReturnSameCollection()
        {
            var data = HashTestData.GenerateKeyValuePairs();
            await this.hashDictionary.SetRange(data);

            var actual = await this.hashDictionary.GetRange(new[] { "2", "4" });
            Assert.Equal(new[] { 2, 4 }, (ICollection)actual);
        }

        [Fact, Trait("Category", "A")]
        public async Task RemoveRange_ShouldDeleteCollectionFromDictionary()
        {
            var data = HashTestData.GenerateKeyValuePairs();
            await this.hashDictionary.SetRange(data);

            var originalCount = await this.hashDictionary.Count();
            var deleted = await this.hashDictionary.RemoveRange(new[] { "2", "4" });

            var actual = await this.hashDictionary.Count();
            var expected = originalCount - deleted;

            Assert.Equal(expected, actual);

        }
    }
}
