using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.BinaryDrawingFormat;
using System.Resources;

namespace Apex.Models
{
    public class C_SpreadSheetBuilder
    {
        private List<string> listExcel;
        private DateTime startDate;
        private DateTime endDate;
        public C_SpreadSheetBuilder( List<string> listquery, DateTime start, DateTime end)
        {            
            listExcel = listquery;
            startDate = start;
            endDate = end;            
        }

        public void CreateExcelFile()
        {
            //create new xls file
            string file = "C:\\Users\\"+Environment.UserName+"\\Desktop\\Report.xls";
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Report_Due_Date");
            int i = 0, j = 0;
            worksheet.Cells[i, j] = new Cell("Sold At");
            worksheet.Cells[i, ++j] = new Cell("Sold To");//Full Name
            worksheet.Cells[i, ++j] = new Cell("Account Number");//Account Number
            worksheet.Cells[i, ++j] = new Cell("Invoice #");//Invoice #
            worksheet.Cells[i, ++j] = new Cell("Customer PO#");//Customer PO#
            worksheet.Cells[i, ++j] = new Cell("Order Date");//Order Date
            worksheet.Cells[i, ++j] = new Cell("Due Date");//Due Date
            worksheet.Cells[i, ++j] = new Cell("Invoice Total");//Invoice Total
            worksheet.Cells[i, ++j] = new Cell("Product Number");//Product Number                    
            worksheet.Cells[i, ++j] = new Cell("Order Qty");//Order Qty
            worksheet.Cells[i, ++j] = new Cell("Unit Net");//Unit Net
            worksheet.Cells[i, ++j] = new Cell("Line Total");//Line Total

            int k = 0;
            for (i = 1, k = 0; i <= listExcel.Count; i++,k++)
            {
                string[] s = listExcel[k].Split('&');
                j = 0;                
                    
                worksheet.Cells[i, j] = new Cell(s[j]);//Company Name
                worksheet.Cells[i, ++j] = new Cell(s[j]);//Full Name
                worksheet.Cells[i, ++j] = new Cell(s[j]);//Account Number
                worksheet.Cells[i, ++j] = new Cell(s[j]);//Invoice #
                worksheet.Cells[i, ++j] = new Cell(s[j]);//Customer PO#
                worksheet.Cells[i, ++j] = new Cell(s[j], @"YYYY\-MM\-DD");//Order Date
                worksheet.Cells[i, ++j] = new Cell(s[j], @"YYYY\-MM\-DD");//Due Date
                worksheet.Cells[i, ++j] = new Cell(s[j], "#,##0.00");//Invoice Total
                worksheet.Cells[i, ++j] = new Cell(s[j]);//Product Number                    
                worksheet.Cells[i, ++j] = new Cell(s[j]);//Order Qty
                worksheet.Cells[i, ++j] = new Cell(s[j], "#,##0.00");//Unit Net
                worksheet.Cells[i, ++j] = new Cell(s[j], "#,##0.00");//Line Total                            
            }
            
             workbook.Worksheets.Add(worksheet);
            workbook.Save(file);            
        }
    }
}