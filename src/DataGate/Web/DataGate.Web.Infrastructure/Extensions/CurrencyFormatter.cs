namespace DataGate.Web.Infrastructure.Extensions
{
    using System.Globalization;

    public static class CurrencyFormatter
    {
        private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-US");

        public static string ToString(this decimal currency)
                => currency.ToString("€" + "##,0.00", Culture);
    }
}
