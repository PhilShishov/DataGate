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
        public List<string[]> TSAllPriceValues { get; set; }

        public List<string> TSPriceDates { get; set; }

        public List<string> TSTypeProviders { get; set; }
    }
}
