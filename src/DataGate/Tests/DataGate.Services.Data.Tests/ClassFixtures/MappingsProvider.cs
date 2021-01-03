// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
            AutoMapperConfig.RegisterMappings(
                typeof(ErrorViewModel).GetTypeInfo().Assembly,
                typeof(EditFundInputModel).GetTypeInfo().Assembly);
        }
    }
}
