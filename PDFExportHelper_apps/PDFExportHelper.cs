using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PDFExportHelper_apps
{
    public static class PDFExportHelper
    {
        public static void ExportToPdf(DataTable dt, string filePath_fileName)
        {
            using (iTextSharp.text.Document document = new iTextSharp.text.Document())
            {
                using (PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath_fileName, FileMode.Create)))
                {
                    document.Open();

                    PdfPTable table = new PdfPTable(dt.Columns.Count);
                    PdfPRow row = null;
                    float[] widths = new float[dt.Columns.Count];
                    for (int i = 0; i < dt.Columns.Count; i++)
                        widths[i] = 4f;

                    table.SetWidths(widths);

                    table.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Products"));

                    cell.Colspan = dt.Columns.Count;
                    AddCellToHeader(table, "Account Number: 1501204392595001", Element.ALIGN_LEFT, colspan: 3);
                    AddCellToHeader(table, "December 31, 2018", Element.ALIGN_RIGHT, colspan: 3);
                    AddCellToHeader(table, "STATEMENT OF ACCOUNT FOR THE PERIOD OF 11-JUN-2023 TO 12-JUN-2023 FROM FINACLE", Element.ALIGN_LEFT);
                    foreach (DataColumn c in dt.Columns)
                    {
                        AddCellToTableHeader(table, c.ColumnName);
                    }
                    foreach (DataRow r in dt.Rows)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            for (int h = 0; h < dt.Columns.Count; h++)
                            {
                                AddCellToBody(table, r[h].ToString());
                            }
                        }
                    }
                    document.Add(table);
                    document.Close();
                }
            }
        }
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText, int alignElement, int colspan=12)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.NORMAL, 13, 1, new iTextSharp.text.BaseColor(153, 51, 0)))) { Colspan = colspan, Border = 0, PaddingBottom = 5, HorizontalAlignment = alignElement });
        }
        private static void AddCellToTableHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.NORMAL, 8, 1, iTextSharp.text.BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = new iTextSharp.text.BaseColor(0, 51, 102) });
        }
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.NORMAL, 8, 1, iTextSharp.text.BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        }
    }
}
