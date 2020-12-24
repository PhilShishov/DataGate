// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.SqlClient
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
