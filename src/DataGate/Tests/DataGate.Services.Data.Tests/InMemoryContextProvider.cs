namespace DataGate.Services.Data.Tests
{
    using Xunit;

    using DataGate.Data;
    using DataGate.Services.Data.Tests.ClassFixtures;
    using DataGate.Services.Data.Tests.Factories;

    public class InMemoryContextProvider : IClassFixture<MappingsProvider>
    {
        protected readonly ApplicationDbContext context;

        public InMemoryContextProvider()
        {
            context = ConnectionFactory.CreateContextForInMemory();
        }
    }
}
