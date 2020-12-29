// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Entities
{
    using System;
    using System.Collections.Generic;

    using DataGate.Web.ViewModels.Queries;

    public interface IEntityService
    {
        IAsyncEnumerable<string[]> All(
                                    string function,
                                    int? id = null,
                                    DateTime? date = null,
                                    int skip = 0);

        IAsyncEnumerable<string[]> AllSelected(
                                        string function,
                                        AllSelectedDto dto,
                                        int skip = 0);
    }
}
