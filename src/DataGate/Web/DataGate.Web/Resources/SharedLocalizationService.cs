namespace DataGate.Web.Resources
{
    using System.Reflection;

    using Microsoft.Extensions.Localization;

    public class SharedLocalizationService
    {
        private readonly IStringLocalizer localizer;

        public SharedLocalizationService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            this.localizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString GetHtmlString(string key)
        {
            return this.localizer[key];
        }
    }
}
