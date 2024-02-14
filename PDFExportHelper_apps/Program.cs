using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;

namespace PDFExportHelper_apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var newDataTable = new DataTable();

            var headerColumns = new List<string>() { "SL", "MobileNo", "City" };
            foreach ( var item in headerColumns)
            {
                var dataColumn = new DataColumn(item);
                newDataTable.Columns.Add(dataColumn);
            }

            DataRow toInsert = newDataTable.NewRow();
            int sl = 1;
            foreach (var column in headerColumns)
            {   
                toInsert[column] = $"Test Value {sl}";
            }
            foreach (var column in headerColumns)
            {
                toInsert[column] = $"Test Value {sl}";
            }
            newDataTable.Rows.Add(toInsert);

            PDFExportHelper.ExportToPdf(newDataTable, "D:\\BracBank\\FeatureDevelopment\\21_40462_Backend_Report_Processing\\pdfTest.pdf");

            Console.ReadLine();
        }
    }
}
