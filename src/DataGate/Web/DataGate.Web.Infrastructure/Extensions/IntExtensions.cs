namespace DataGate.Web.Infrastructure.Extensions
{
    public static class IntExtensions
    {
        public static int? ToNullInt(this int? value)
        {
            if (value <= 0)
            {
                return null;
            }

            return value;
        }
    }
}
