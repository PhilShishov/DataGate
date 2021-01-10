// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Infrastructure.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Data.Models.Parameters;

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
            else if (link.Contains("/agreements"))
            {
                var linkArr = link.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var entity = linkArr[1];

                displayLink = string.Format(LinkMessages.Agreements, entity);
            }
            else if (link.Contains("/reports"))
            {
                var linkArr = link.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var entity = linkArr[1];
                var type = linkArr[2];

                if (type == "aum")
                {
                    type = "AuM";
                }
                else if (type == "timeseries")
                {
                    type = "TimeSeries";
                }

                displayLink = string.Format(LinkMessages.Reports, entity, type);
            }
            else
            {
                var linkArr = link.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var entity = linkArr[0];
                var entityToDisplay = StringSwapper.ByArea(entity,
                        EndpointsConstants.FundArea,
                        EndpointsConstants.SubFundNameDisplay,
                        EndpointsConstants.ShareClassNameDisplay);

                if (int.TryParse(linkArr[1], out int id))
                {
                    var arg = linkArr[2];

                    if (DateTime.TryParse(arg, out _))
                    {
                        displayLink = string.Format(LinkMessages.Details, entityToDisplay, id, arg);
                    }
                    else
                    {
                        displayLink = string.Format(LinkMessages.SubEntities, entityToDisplay, id);
                    }
                }
                else if (linkArr[1] == "new")
                {
                    displayLink = string.Format(LinkMessages.Create, entityToDisplay);
                }
                else if (linkArr[1] == "edit")
                {
                    var editId = linkArr[2];
                    var arg = linkArr[3];

                    displayLink = string.Format(LinkMessages.Edit, entityToDisplay, editId, arg);
                }
            }

            return displayLink;
        }

        public static string BuildProcedure(string procedure, IEnumerable<Parameter> parameters)
        {
            foreach (var param in parameters)
            {
                procedure += param.Name + ", ";
            }

            return procedure.Remove(procedure.Length - 2, 2);

        }

        public static List<string> FormatColumns(
            IReadOnlyCollection<string> preSelectedColumns,
            IEnumerable<string> selectedColumns)
        {
            List<string> result = new List<string>(preSelectedColumns);

            result.AddRange(selectedColumns);

            // Prepare items for DB query with [] and trim spaces
            result = result
                .Select(col => string.Format(GlobalConstants.SqlItemFormatRequired, col.Trim()))
                .ToList();

            return result;
        }
    }
}
