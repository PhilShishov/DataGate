namespace DataGate.Web.Helpers
{
    public class SqlFunctionTimeSeries
    {
        // TimeSeries
        // Share Classes
        public const string PricesShareClass = "SELECT convert(varchar, date_ts, 103)date_ts , value_ts [type], " +
                                                        "concat(tst.desc_ts,' ', tsp.desc_provider,' ',currency_ts)  " +
                                                        "providerccy FROM [tb_timeseries_shareclass] tsc " +
                                                        "join tb_dom_timeseries_provider tsp on tsp.id_provider = provider_ts " +
                                                        "join tb_dom_timeseries_type tst on tst.id_ts=tsc.id_ts " +
                                                        "where id_shareclass = {0} order by date_ts asc";

        public const string DatesShareClass = "SELECT distinct date_ts, convert(varchar,date_ts , 103) " +
                                                         "datechart FROM [tb_timeseries_shareclass] " +
                                                         "join tb_dom_timeseries_provider tsp on tsp.id_provider = provider_ts " +
                                                         "where id_shareclass = {0} order by date_ts asc";

        public const string ProvidersShareClass = "select * from [fn_view_timeseriesSC] ({0})";

        // Sub Funds
        public const string PricesSubFund = "SELECT convert(varchar, date_ts, 103)date_ts , value_ts [type], " +
                                                        "concat(tst.desc_ts,' ', tsp.desc_provider,' ',currency_ts)  " +
                                                        "providerccy FROM [tb_timeseries_subfund] tsc " +
                                                        "join tb_dom_timeseries_provider tsp on tsp.id_provider = provider_ts " +
                                                        "join tb_dom_timeseries_type tst on tst.id_ts=tsc.id_ts " +
                                                        "where id_subfund = {0} order by date_ts asc";

        public const string DatesSubFund = "SELECT distinct date_ts, convert(varchar,date_ts , 103) " +
                                                         "datechart FROM [tb_timeseries_subfund] " +
                                                         "join tb_dom_timeseries_provider tsp on tsp.id_provider = provider_ts " +
                                                         "where id_subfund = {0} order by date_ts asc";


    //    SELECT CONCAT(MONTH(date_ts),'/', YEAR(date_ts)),		
	   //AVG(value_ts) [value],
	   //CONCAT(tst.desc_ts,' ', tsp.desc_provider,' ', currency_ts) providerccy
    //    FROM[tb_timeseries_subfund] tsc
    //   JOIN tb_dom_timeseries_provider tsp on tsp.id_provider = provider_ts
    //   JOIN tb_dom_timeseries_type tst on tst.id_ts= tsc.id_ts

    //   WHERE id_subfund = 1

    //   GROUP BY MONTH(date_ts), YEAR(date_ts), tst.desc_ts, tsp.desc_provider, currency_ts
    //   ORDER BY YEAR(date_ts) ASC, MONTH(date_ts)

        //SELECT CONCAT(MONTH(date_ts),'/', YEAR(date_ts))

        //        FROM[tb_timeseries_subfund]
        //        join tb_dom_timeseries_provider tsp on tsp.id_provider = provider_ts
        //        where id_subfund = 1

        //        GROUP BY MONTH(date_ts), YEAR(date_ts)
        //        ORDER BY YEAR(date_ts) ASC, MONTH(date_ts)

        public const string ProvidersSubFund = "select * from [fn_view_timeseriesSF] ({0})";
    }
}
