namespace DataGate.Services.DateTime
{
    using System;
    using System.Globalization;

    using DataGate.Common;

    public static class DateTimeParser
    {
        public static DateTime WebFormat(string chosenDate)
        {
            return DateTime.ParseExact(chosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
        }
    }
}
