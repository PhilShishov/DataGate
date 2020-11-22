namespace DataGate.Services.Data.Tests.ClassFixtures
{
    using System.Reflection;

    using DataGate.Services.Mapping;
    using DataGate.Web.ViewModels;

    public class MappingsProvider
    {
        public MappingsProvider()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }
    }
}
