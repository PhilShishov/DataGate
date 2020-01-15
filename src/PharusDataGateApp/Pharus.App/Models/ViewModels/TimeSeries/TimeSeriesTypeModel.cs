// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Model Timeseries 

// Created: 12/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.ViewModels.TimeSeries
{
    using System.Collections.Generic;

    public class TimeSeriesTypeModel
    {
        public List<string[]> TableType { get; set; }

        public List<string[]> TsPrice { get; set; }
    }
}
