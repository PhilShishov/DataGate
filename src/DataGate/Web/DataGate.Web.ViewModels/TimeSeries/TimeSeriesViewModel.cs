// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Model Timeseries
// Created: 12/2019
// Author:  Philip Shishov
// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.ViewModels.TimeSeries
{
    using System.Collections.Generic;

    public class TimeSeriesViewModel
    {
        public IEnumerable<string[]> TSAllPriceValues { get; set; }

        public IEnumerable<string> TSPriceDates { get; set; }

        public IEnumerable<string> TSTypeProviders { get; set; }

        public string AreaName { get; set; }

        public int Id { get; set; }
    }
}
