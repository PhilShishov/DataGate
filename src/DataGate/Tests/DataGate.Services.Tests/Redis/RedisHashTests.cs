namespace DataGate.Services.Tests.Redis
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataGate.Services.Redis;
    using DataGate.Services.Redis.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RedisHashTests
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
            container = new RedisContainer(redisConnection, "hash-container");
        }

        [TestCleanup()]
        public void Cleanup()
        {
            container.DeleteTrackedKeys().Wait();
        }

        [TestMethod]
        public async Task HashMethods()
        {
            var item = new RedisValueHash("hashkey");
            container.AddToContainer(item);

            await item.Set("title", "goto statement considered harmful");
            await item.Set("link", "http:go.bz");
            await item.Set("poster", "user:123");
            await item.Set("time", DateTime.Now.Ticks);
            await item.Set("votes", 122);

            Assert.IsTrue((await item.ContainsKey("poster")));
            Assert.IsTrue((await item.Get("votes")) == 122);
            await foreach (var field in item) Console.WriteLine($"{field.Key} = {field.Value}");


            Assert.IsTrue((await item.Increment("votes")) == 123);
            Assert.IsTrue((await item.Decrement("votes", 5)) == 118);

            await item.Remove("link");
            Assert.IsTrue((await item.Count()) == 4);
        }

        [TestMethod]
        public async Task HashAsDictionary()
        {
            var numbers = new RedisHash<string, int>("hashkey");
            container.AddToContainer(numbers);

            var list = new List<KeyValuePair<string, int>>();
            for (int i = 1; i <= 10; i++) list.Add(new KeyValuePair<string, int>(i.ToString(), i));
            await numbers.SetRange(list);

            var values = await numbers.Values();
            var keys = await numbers.Keys();
            Assert.IsTrue(values.Count == keys.Count);
            Assert.IsTrue((await numbers.ContainsKey("2")));
            Assert.IsTrue((await numbers.Count()) == 10);

            await foreach (var kvp in numbers) Console.WriteLine($"{kvp.Key} - {kvp.Value}");

            var results = await numbers.GetRange(new[] { "2", "4" });
            CollectionAssert.AreEquivalent((ICollection)results, new[] { 2, 4 });

            Assert.IsTrue((await numbers.Increment("1", 4)) == 5);
        }
    }
}
