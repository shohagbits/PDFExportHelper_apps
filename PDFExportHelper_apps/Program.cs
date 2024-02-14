using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using static iTextSharp.text.pdf.AcroFields;

namespace PDFExportHelper_apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var newDataTable = new DataTable();
            var data = new List<string>() { "Posted Date", "Tran Date", "Particulars", "Withdraw", "Deposit", "Balance" };
            newDataTable = DataTablePrepared(data, 100);

            PDFExportHelper.ExportToPdf(newDataTable, "D:\\BracBank\\FeatureDevelopment\\21_40462_Backend_Report_Processing\\pdfTest.pdf");
            Console.WriteLine("Done PDF Generation");
            Console.ReadLine();
        }

        private static DataTable DataTablePrepared(List<string> columns, int dataSize)
        {
            DataTable newDataTable = new DataTable();

            var headerColumns = new DataColumn[columns.Count];
            for (int i = 0; i < columns.Count; i++)
            {
                var dataColumn = new DataColumn(columns[i]);
                newDataTable.Columns.Add(dataColumn);
                headerColumns[i] = dataColumn;
            }
            for (int i = 0; i < dataSize; i++)
            {
                DataRow toInsert = newDataTable.NewRow();
                foreach (var column in headerColumns)
                {
                    toInsert[column] = $"Test Value {i}";
                }
                newDataTable.Rows.Add(toInsert);
            }
            return newDataTable;
        }
    }
}
