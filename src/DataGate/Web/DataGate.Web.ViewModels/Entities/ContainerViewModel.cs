// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Entities
{
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class ContainerViewModel : IMapFrom<ContainerDto>
    {
        public int ContainerId { get; set; }

        public string ContainerName { get; set; }
    }
}
