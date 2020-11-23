namespace DataGate.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Common;

    public class FormatSql
    {
        public static List<string> FormatColumns(IReadOnlyCollection<string> preSelectedColumns, IEnumerable<string> selectedColumns)
        {
            List<string> resultColumns = new List<string>(preSelectedColumns);

            resultColumns.AddRange(selectedColumns);

            // Prepare items for DB query with []
            resultColumns = resultColumns.Select(col => string.Format(GlobalConstants.SqlItemFormatRequired, col)).ToList();
            return resultColumns;
        }
    }
}
