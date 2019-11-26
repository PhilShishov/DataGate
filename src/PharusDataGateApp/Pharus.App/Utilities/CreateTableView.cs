namespace Pharus.App.Utilities
{
    using System.Collections.Generic;

    public class CreateTableView
    {
        public static void AddTableToView(List<string[]> activeFunds, List<string[]> tableFundsWithoutHeaders, string searchString)
        {
            foreach (var fund in tableFundsWithoutHeaders)
            {
                foreach (var stringValue in fund)
                {
                    if (stringValue != null && stringValue
                        .ToLower()
                        .Contains(searchString.ToLower()))
                    {
                        activeFunds.Add(fund);
                        break;
                    }
                }
            }
        }

        public static void AddHeadersToView(List<string[]> activeFunds, List<string[]> tableHeaders)
        {
            foreach (var tableHeader in tableHeaders)
            {
                activeFunds.Add(tableHeader);
            }
        }
    }
}
