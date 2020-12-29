// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Infrastructure.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using DataGate.Common;

    public static class StringExtensions
    {
        private static List<string> specialCharactersNotAllowed = new List<string>
        {
          "/", "\\", "<", ">", ":", "\"", "|", "?", "%", "&", "$", "(", ")", "'"
        };

        public static string ReplaceSpecial(this string s)
        {
            foreach (var c in specialCharactersNotAllowed)
            {
                s = s.Replace(c, "");
            }
            return s;
        }

        public static string GetFileName(string fileName) => Path.GetFileNameWithoutExtension(fileName);

        public static string BuildDisplayLink(this string link)
        {
            string displayLink = string.Empty;

            if (link.Contains("/search"))
            {
                int startIndex = link.IndexOf("=") + 1;
                string searchTerm = link.Substring(startIndex);

                displayLink = $"Search Results - '{searchTerm}'";
            }
            else
            {
                var linkArr = link.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var type = linkArr[0];

                if (int.TryParse(linkArr[1], out int id))
                {
                    var action = id;
                    var date = linkArr[2];

                    switch (type)
                    {
                        case "f":
                            displayLink = $"Fund Details for ID:{id} at {date}";
                            break;
                        case "sf":
                            displayLink = $"Sub Fund Details for ID:{id} at {date}";
                            break;
                        case "sc":
                            displayLink = $"Share Class Details for ID:{id} at {date}";
                            break;
                    }
                }
                else if (linkArr[1] == "new")
                {
                    switch (type)
                    {
                        case "f":
                            displayLink = "Create New Fund";
                            break;
                        case "sf":
                            displayLink = "Create New Sub Fund";
                            break;
                        case "sc":
                            displayLink = "Create New Share Class";
                            break;
                    }
                }
                else if (linkArr[1] == "edit")
                {
                    var editId = linkArr[2];
                    var date = linkArr[3];

                    switch (type)
                    {
                        case "f":
                            displayLink = $"Edit Fund ID:{editId} at {date}";
                            break;
                        case "sf":
                            displayLink = $"Edit Sub Fund ID:{editId} at {date}";
                            break;
                        case "sc":
                            displayLink = $"Edit Share Class ID:{editId} at {date}";
                            break;
                    }
                }
            }

            return displayLink;
        }


        public static List<string> FormatColumns(
            IReadOnlyCollection<string> preSelectedColumns, 
            IEnumerable<string> selectedColumns)
        {
            List<string> resultColumns = new List<string>(preSelectedColumns);

            resultColumns.AddRange(selectedColumns);

            // Prepare items for DB query with []
            resultColumns = resultColumns.Select(col => string.Format(GlobalConstants.SqlItemFormatRequired, col)).ToList();

            //if (resultColumns == null)
            //{
            //    return resultColumns;
            //}
            //    var enumerable = columns as string[] ?? Enumerable.ToArray(columns);

            //    if (enumerable.Length <= 0)
            //    {
            //        return result;
            //    }

            //    foreach (var column in enumerable)
            //    {
            //        if (!string.IsNullOrEmpty(column))
            //        {
            //            result.Add(column.Contains(" ") ? $"[{column.Trim()}]" : $"{column.Trim()}");
            //        }
            //    }

            return resultColumns;
        }
    }
}
