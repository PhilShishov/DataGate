// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Helpers
{
    public class SqlFunctionTimeSeries
    {
        // TimeSeries
        // Share Classes
        public const string TimeSeriesSC = "SELECT CONVERT(varchar, date_ts, 103)date_ts , " +
                                                  "value_ts [type], " +
                                                  "CONCAT(tst.desc_ts,' ', tsp.desc_provider,' ',currency_ts) [providerccy] " +
                                                  "FROM [tb_timeseries_shareclass] tsc " +
                                                  "JOIN tb_dom_timeseries_provider tsp on tsp.id_provider = provider_ts " +
                                                  "JOIN tb_dom_timeseries_type tst on tst.id_ts=tsc.id_ts " +
                                                  "WHERE id_shareclass = {0} AND CONCAT(tst.desc_ts,' ', tsp.desc_provider,' ',currency_ts) = '{1}' " +
                                                  "ORDER BY YEAR(date_ts), MONTH(date_ts), DAY(date_ts)";

        public const string ProvidersShareClass = "select * from [fn_view_timeseriesSC] ({0})";

        // Sub Funds
        public const string TimeSeriesSF = "SELECT CONCAT(MONTH(date_ts),'/', YEAR(date_ts)), " +
                                                  "AVG(value_ts) [value], " +
                                                  "CONCAT(tst.desc_ts, ' ', tsp.desc_provider, ' ', currency_ts) [providerccy] " +
                                                  "FROM [tb_timeseries_subfund] tsc " +
                                                  "JOIN tb_dom_timeseries_provider tsp on tsp.id_provider = provider_ts " +
                                                  "JOIN tb_dom_timeseries_type tst on tst.id_ts= tsc.id_ts " +
                                                  "WHERE id_subfund = {0} AND CONCAT(tst.desc_ts,' ', tsp.desc_provider,' ',currency_ts) = '{1}' " +
                                                  "GROUP BY MONTH(date_ts), YEAR(date_ts), tst.desc_ts, tsp.desc_provider, currency_ts " +
                                                  "ORDER BY YEAR(date_ts) ASC, MONTH(date_ts)";

        public const string ProvidersSubFund = "select * from [fn_view_timeseriesSF] ({0})";
    }
}
