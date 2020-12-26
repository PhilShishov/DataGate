// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Reports
{
    using System;
    using System.Collections.Generic;

    public interface IReportsService
    {
        IAsyncEnumerable<string[]> All(string function, DateTime date, int skip = 0);
    }
}
