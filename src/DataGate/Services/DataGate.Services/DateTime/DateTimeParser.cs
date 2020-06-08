namespace DataGate.Services.DateTime
{
    using System;
    using System.Globalization;

    using DataGate.Common;

    public static class DateTimeParser
    {
        public static DateTime FromWebFormat(string date)
        {
            if (date != null)
            {
                return DateTime.ParseExact(date, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
            }

            return DateTime.UtcNow;
        }

        public static DateTime FromSqlFormat(string date)
        {
            if (date != null)
            {
                return DateTime.ParseExact(date, GlobalConstants.SqlDateTimeFormatParsing, CultureInfo.InvariantCulture);
            }

            return DateTime.UtcNow;
        }
    }
}
