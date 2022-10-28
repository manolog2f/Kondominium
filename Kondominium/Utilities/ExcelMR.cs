using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Kondominium.Utilities
{
    public static class ExcelMR
    {
        public static void ExportDataTableToExcel(DataTable table)
        {
            ExportDataTableToExcel(table, string.Empty, null/* TODO Change to default(_) if this is not a reference type */);
        }

        public static void ExportDataTableToExcel(DataTable table, Dictionary<string, string> captions)
        {
            ExportDataTableToExcel(table, string.Empty, captions);
        }

        public static void ExportDataTableToExcel(DataTable table, string name)
        {
            ExportDataTableToExcel(table, name, null/* TODO Change to default(_) if this is not a reference type */);
        }

        public static void ExportDataTableToExcel(DataTable table, string name, Dictionary<string, string> captions)
        {
            System.Text.StringBuilder content = new System.Text.StringBuilder();
            string columnName = string.Empty;
            foreach (DataColumn column in table.Columns)
            {
                if (captions != null)
                {
                    if (!captions.TryGetValue(column.ColumnName, out columnName))
                        columnName = column.ColumnName;
                }
                else
                    columnName = column.ColumnName;
                content.Append(columnName + ";");
            }
            content.Append(Environment.NewLine);
            string value;
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i <= table.Columns.Count - 1; i++)
                {
                    value = string.Empty;
                    if (!row.IsNull(i))
                        value = row[i].ToString().Replace(";", string.Empty);
                    content.Append(value + ";");
                }
                content.Append(Environment.NewLine);
            }
            content.Length = content.Length - 1;
            HttpContext context = HttpContext.Current;
            {
                var withBlock = context.Response;
                withBlock.Clear();
                withBlock.ContentType = "text/csv";
                if (string.IsNullOrEmpty(name))
                    name = DateTime.Now.ToString("ddMMyyyyHHmmss");
                withBlock.AppendHeader("Content-Disposition", string.Format("attachment; filename={0}.csv", name));
                withBlock.Charset = Encoding.Unicode.WebName;
                withBlock.ContentEncoding = Encoding.Unicode;
                withBlock.Write(content.ToString());
                withBlock.End();
            }
        }
    }
}