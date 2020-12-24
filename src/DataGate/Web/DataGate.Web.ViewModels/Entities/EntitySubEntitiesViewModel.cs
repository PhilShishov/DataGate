// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Entities
{
    using System.Collections.Generic;

    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Overviews;

    public class EntitySubEntitiesViewModel : IMapFrom<EntitySubEntitiesGetDto>
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Container { get; set; }

        public List<string[]> Entities { get; set; }
    }
}
