// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.TimeSeries
{
    using System.Collections.Generic;

    public interface ITimeSeriesService
    {
        IAsyncEnumerable<string> GetDates(string function, int skip = 0);

        IAsyncEnumerable<string> GetProviders(string function, int skip = 0, bool isMainProvider = false);

        IAsyncEnumerable<string[]> GetPrices(string function, int skip = 0);


        //IAsyncEnumerable<TimeSerieReport> GetAllTSReports(string type, int? id, string timeSeriesType)
    }
}
