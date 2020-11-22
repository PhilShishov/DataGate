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
        private const string ItemNameInt = "numbers";

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

            Assert.True(await this.item.ContainsKey(itemName));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void ToRedisValue_WithInvalidValue_ShouldThrowException(object value)
        {
            Action act = () => RedisObject.ToRedisValue(value);

            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData(null, "emptykey")]
        [InlineData("", "emptykeytext")]
        [InlineData("               ", "largeemptykeytext")]
        public async Task Set_WithInvalidNameAndValidStringValue_ShouldThrowException(string itemName, object value)
        {
            RedisValue redisValue = RedisObject.ToRedisValue(value);

            Func<Task> task = async () => await this.item.Set(itemName, redisValue);

            await Assert.ThrowsAsync<ArgumentException>(task);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        public async Task Increment_WithIncreaseValue_ShouldIncrease(long increase)
        {
            await this.item.Set(ItemNameInt, 100);

            var actual = await this.item.Increment(ItemNameInt, increase);
            var expected = 100 + increase;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        public async Task Decrement_WithDecreaseValue_ShouldDecrease(long decrease)
        {
            await this.item.Set(ItemNameInt, 100);

            var actual = await this.item.Decrement(ItemNameInt, decrease);
            var expected = 100 - decrease;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Remove_ShouldDeleteItemFromContainer()
        {
            var itemName = "todelete";
            await this.item.Set(itemName, "todeletevalue");

            var actual = await this.item.Remove(itemName);
            var expected = true;

            Assert.Equal(expected, actual);
            Assert.False(await item.ContainsKey(itemName));
        }

        //[TestMethod]
        //public async Task RedisHash_Set_ContainsKey_Get_Increment_Decrement_Remove_Count()
        //{
        //    await foreach (var field in item)
        //    {
        //        Console.WriteLine($"{field.Key} = {field.Value}");
        //    }
        //    Assert.IsTrue((await item.Count()) == 4);
        //}
    }
}
