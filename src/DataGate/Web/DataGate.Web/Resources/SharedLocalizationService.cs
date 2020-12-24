// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
