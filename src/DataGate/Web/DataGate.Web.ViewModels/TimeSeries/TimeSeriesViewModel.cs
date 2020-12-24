// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.TimeSeries
{
    using System.Collections.Generic;

    public class TimeSeriesViewModel
    {
        public IEnumerable<string[]> TSAllPriceValues { get; set; }

        public IEnumerable<string> TSPriceDates { get; set; }

        public string TSTypeProvider { get; set; }

        public string AreaName { get; set; }

        public int Id { get; set; }
    }
}
