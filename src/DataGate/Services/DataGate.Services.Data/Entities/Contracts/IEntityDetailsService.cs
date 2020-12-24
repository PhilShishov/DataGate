// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Entities
{
    using System;
    using System.Collections.Generic;

    using DataGate.Web.Dtos.Queries;

    public interface IEntityDetailsService
    {
        IAsyncEnumerable<string[]> ByIdAndDate(string function, int id, DateTime? date);

        ContainerDto GetContainer(string function, int id, DateTime? date);

        IAsyncEnumerable<string[]> GetSubEntities(
                                   string function,
                                   int? id = null,
                                   DateTime? date = null,
                                   int skip = 0);
    }
}
