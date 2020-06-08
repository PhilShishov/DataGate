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

        public static string ToWebFormat(DateTime date)
        {
            if (date != null)
            {
                return date.ToString(GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
            }

            return string.Empty;
        }

        public static string ToSqlFormat(DateTime? date)
        {
            if (date.HasValue)
            {
                return date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat, CultureInfo.InvariantCulture);
            }

            return string.Empty;
        }
    }
}
