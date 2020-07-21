namespace DataGate.Web.Infrastructure.Extensions
{
    using System;
    using System.Globalization;

    using DataGate.Common;

    public static class DateTimeParser
    {
        public static DateTime FromWebFormat(this string date)
        {
            if (date != null)
            {
                return DateTime.ParseExact(date, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
            }

            return DateTime.UtcNow;
        }

        public static DateTime FromSqlFormat(this string date)
        {
            if (date != null)
            {
                return DateTime.ParseExact(date, GlobalConstants.SqlDateTimeFormatParsing, CultureInfo.InvariantCulture);
            }

            return DateTime.UtcNow;
        }

        public static string ToWebFormat(this DateTime date)
        {
            if (date != null)
            {
                return date.ToString(GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.CurrentCulture);
            }

            return string.Empty;
        }

        public static string ToSqlFormat(this DateTime? date)
        {
            if (date.HasValue)
            {
                return date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat, CultureInfo.InvariantCulture);
            }

            return string.Empty;
        }
    }
}
