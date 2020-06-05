namespace DataGate.Services.DateTime
{
    using System;
    using System.Globalization;

    using DataGate.Common;

    public static class DateTimeParser
    {
        public static DateTime FromWebFormat(string date)
        {
            return DateTime.ParseExact(date, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
        }

        public static DateTime FromSqlFormat(string date)
        {
            return DateTime.ParseExact(date, GlobalConstants.SqlDateTimeFormatParsing, CultureInfo.InvariantCulture);
        }
    }
}
