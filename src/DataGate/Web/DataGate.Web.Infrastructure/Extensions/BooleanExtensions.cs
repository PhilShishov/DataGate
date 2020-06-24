namespace DataGate.Web.Infrastructure.Extensions
{
    public static class BooleanExtensions
    {
        public static string ToYesNoString(this bool value) => value ? "Yes" : "No";
    }
}
