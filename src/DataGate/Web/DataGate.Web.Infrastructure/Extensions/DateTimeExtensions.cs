// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Infrastructure.Extensions
{
    using System;
    using System.Globalization;

    using DataGate.Common;

    public static class DateTimeExtensions
    {
        private const int FixedDayNavValue = 5;

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

        public static string TimeAgo(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;

            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return String.Format("{0} {1} ago", years, years == 1 ? "year" : "years");
            }

            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return String.Format("{0} {1} ago", months, months == 1 ? "month" : "months");
            }

            if (span.Days > 0)
            {
                return String.Format("{0} {1} ago", span.Days, span.Days == 1 ? "day" : "days");
            }

            if (span.Hours > 0)
            {
                return String.Format("{0} {1} ago", span.Hours, span.Hours == 1 ? "hour" : "hours");
            }

            if (span.Minutes > 0)
            {
                return String.Format("{0} {1} ago", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
            }

            if (span.Seconds > 5)
            {
                return String.Format("{0} seconds ago", span.Seconds);
            }

            if (span.Seconds <= 5)
            {
                return "just now";
            }

            return string.Empty;
        }

        public static DateTime BuildReportDate(this DateTime chosenDate, string type, int previous = 0)
        {
            var date = new DateTime();

            if (chosenDate.Month == 1)
            {
                int day = (type == EndpointsConstants.FundArea) ?
                  FixedDayNavValue :
                  DateTime.DaysInMonth(chosenDate.Year - 1, 12);

                date = new DateTime(chosenDate.Year - 1, 12, day);
            }
            else
            {
                int day = (type == EndpointsConstants.FundArea) ?
                  FixedDayNavValue :
                  DateTime.DaysInMonth(chosenDate.Year, chosenDate.Month - previous);
                date = new DateTime(chosenDate.Year, chosenDate.Month - previous, day);
            }

            return date;
        }

    }
}
