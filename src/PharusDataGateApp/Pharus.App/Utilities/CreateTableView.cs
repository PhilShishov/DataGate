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
                    if (stringValue != null && stringValue.ToLower().Contains(searchString.ToLower()))
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
        //private static void AddColumnNamesAndRecordsToWorkSheet(ExcelWorksheet worksheet, DataSet dataSet)
        //{
        //    var columnName = dataSet.Tables[0].Columns.Cast<DataColumn>()
        //                         .Select(x => x.ColumnName)
        //                         .ToArray();
        //    int i = 0;

        //    foreach (var col in columnName)
        //    {
        //        i++;
        //        worksheet.Cells[1, i].Value = col;
        //    }

        //    int j;
        //    for (i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        //    {
        //        for (j = 0; j < dataSet.Tables[0].Columns.Count; j++)
        //        {
        //            worksheet.Cells[i + 2, j + 1].Value = Convert.ToString(dataSet.Tables[0].Rows[i][j]);
        //        }
        //    }
        //}
    }
}
