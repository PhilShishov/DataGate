namespace DataGate.Services.Data.Tests.ClassFixtures
{
    using System.Reflection;

    using DataGate.Services.Mapping;
    using DataGate.Web.InputModels.Funds;
    using DataGate.Web.ViewModels;
    public class MappingsProvider
    {
        public MappingsProvider()
        {
            //Register all mappings in the app
            AutoMapperConfig.RegisterMappings(
                typeof(ErrorViewModel).GetTypeInfo().Assembly,
                typeof(EditFundInputModel).GetTypeInfo().Assembly);
        }
    }
}
