namespace DataGate.Services.Tests.TestData
{
    using System;
    using Xunit;

    public class HashDataGenerator : TheoryData<string, object>
    {
        public HashDataGenerator()
        {
            this.Add("link", "https://github.com");
            this.Add("numbers", 88);
            this.Add("time", DateTime.Now.Ticks);
        }
    }
}
