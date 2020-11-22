namespace DataGate.Services.Tests.Redis
{
    using System;
    using System.Threading.Tasks;

    using StackExchange.Redis;
    using Xunit;

    using DataGate.Common;
    using DataGate.Services.Redis;
    using DataGate.Services.Tests.ClassFixtures;
    using DataGate.Services.Tests.TestData;

    public class RedisHashTests : IClassFixture<RedisFixture>, IDisposable
    {
        private readonly RedisContainer container;
        private readonly RedisValueHash item;

        public RedisHashTests(RedisFixture fixture)
        {
            this.container = new RedisContainer(fixture.RedisConnection, GlobalConstants.TestHashContainer);
            this.item = new RedisValueHash("hashkey");
            this.container.AddToContainer(this.item);
        }

        public void Dispose()
        {
            this.container.DeleteTrackedKeys().Wait();
        }

        [Theory]
        [ClassData(typeof(HashDataGenerator))]
        public async Task Set_WithKeyNameAndValueOfDifferentType_ShouldCreateHashKey(string itemName, object value)
        {
            RedisValue redisValue = RedisObject.ToRedisValue(value);
            await this.item.Set(itemName, redisValue);

            var actual = this.item.Get(itemName).Result;
            var expected = redisValue;

            Assert.True(await item.ContainsKey(itemName));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Set_WithInvalidValue_ShouldThrowException(object value)
        {
            Action act = () => RedisObject.ToRedisValue(value);

            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData(null, "emptykey")]
        [InlineData("", "emptykeytext")]
        public async Task Set_WithInvalidName_ShouldThrowException(string itemName, object value)
        {
            RedisValue redisValue = RedisObject.ToRedisValue(value);

            Func<Task> task = async () => await this.item.Set(itemName, redisValue);

            await Assert.ThrowsAsync<ArgumentException>(task);
        }

        //[TestMethod]
        //public async Task RedisHash_Set_ContainsKey_Get_Increment_Decrement_Remove_Count()
        //{

        //    Assert.IsTrue((await item.ContainsKey("poster")));
        //    Assert.IsTrue((await item.Get("votes")) == 122);

        //    Assert.IsTrue((await item.Increment("votes")) == 123);
        //    Assert.IsTrue((await item.Decrement("votes", 5)) == 118);

        //    await item.Remove("link");
        //    await foreach (var field in item)
        //    {
        //        Console.WriteLine($"{field.Key} = {field.Value}");
        //    }
        //    Assert.IsTrue((await item.Count()) == 4);
        //}
    }
}
