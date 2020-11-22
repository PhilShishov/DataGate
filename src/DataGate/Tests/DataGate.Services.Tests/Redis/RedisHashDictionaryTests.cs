namespace DataGate.Services.Tests.Redis
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RedisHashDictionaryTests
    {

        //[TestMethod]
        //public async Task RedisHash_AsDictionary()
        //{
        //    var numbers = new RedisHash<string, int>("hashkey");
        //    container.AddToContainer(numbers);

        //    var list = new List<KeyValuePair<string, int>>();
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        list.Add(new KeyValuePair<string, int>(i.ToString(), i));
        //    }
        //    await numbers.SetRange(list);

        //    var values = await numbers.Values();
        //    var keys = await numbers.Keys();
        //    Assert.IsTrue(values.Count == keys.Count);
        //    Assert.IsTrue((await numbers.ContainsKey("2")));
        //    Assert.IsTrue((await numbers.Count()) == 10);

        //    await foreach (var kvp in numbers)
        //    {
        //        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        //    }

        //    var results = await numbers.GetRange(new[] { "2", "4" });
        //    CollectionAssert.AreEquivalent((ICollection)results, new[] { 2, 4 });

        //    Assert.IsTrue((await numbers.Increment("1", 4)) == 5);
        //}
    }
}
