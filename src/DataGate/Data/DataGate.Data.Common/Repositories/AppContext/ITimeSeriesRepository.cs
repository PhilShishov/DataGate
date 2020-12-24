// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Common.Repositories.AppContext
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITimeSeriesRepository : IDisposable
    {
        ISet<string> All(string area);

        IReadOnlyCollection<string> AllTbDomTimeSeriesType(int type);

        Task<string> ByName(string area, int? id);
    }
}
