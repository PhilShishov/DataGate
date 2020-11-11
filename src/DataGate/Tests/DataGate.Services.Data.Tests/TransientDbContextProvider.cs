namespace DataGate.Services.Data.Tests
{
    using DataGate.Data;
    using DataGate.Services.Data.Tests.ClassFixtures;
    using DataGate.Services.Data.Tests.Factories;

    using Xunit;

    public class TransientDbContextProvider : IClassFixture<MappingsProvider>
    {
        protected readonly ApplicationDbContext context;

        public TransientDbContextProvider()
        {
            context = ApplicationDbContextFactory.CreateInMemoryDatabase();
        }
    }
}
