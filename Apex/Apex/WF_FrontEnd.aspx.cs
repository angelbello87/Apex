using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;

namespace Apex
{
    public partial class WF_FrontEnd : System.Web.UI.Page
    {
        private C_AdventureDBDataContext database;
        private DateTime endDateReport;
        private DateTime startDateReport;
        private List<string> listquery;

        protected void Page_Load(object sender, EventArgs e)
        {
            database = new C_AdventureDBDataContext();
            
            if (!IsPostBack)
            {
                lbl_start.Text = cal_startdatereport.SelectedDate.ToShortDateString();
                lbl_end.Text = cal_enddatereport.SelectedDate.ToShortDateString();
                cal_startdatereport.Visible = false;
                cal_enddatereport.Visible = false;
                LoadReportDate();
                Report(startDateReport, endDateReport);                
            }      
            
                                 
        }

        private void Report(DateTime start, DateTime end)
        {
            var queryJoinreport = from client in database.Customers
                                  join sales in database.SalesOrderHeaders on client.CustomerID equals sales.CustomerID
                                  join salesD in database.SalesOrderDetails on sales.SalesOrderID equals salesD.SalesOrderID
                                  join prod in database.Products on salesD.ProductID equals prod.ProductID
                                  where (sales.DueDate >= start && sales.DueDate <= end)
                                  select new
                                  {
                                      SoldAt = client.CompanyName,
                                      SoldTo = (client.FirstName + " " + client.LastName),
                                      AccountNumber = sales.AccountNumber,
                                      InvoiceNumber = sales.SalesOrderNumber,
                                      CustomerPO = sales.PurchaseOrderNumber,
                                      OrderDate = sales.OrderDate,
                                      DueDate = sales.DueDate,
                                      InvoiceTotal = "$ " + sales.TotalDue,
                                      ProductNumber = prod.ProductNumber,
                                      OrderQty = salesD.OrderQty,
                                      UnitNet = "$ " + salesD.UnitPrice,
                                      LineTotal = "$ " + salesD.LineTotal
                                  };
            GridView1.DataSource = queryJoinreport;
            GridView1.DataBind();
            listquery = new List<string>();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string s="";
                for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
                {
                    s +=GridView1.Rows[i].Cells[j].Text + "&";
                }
                listquery.Add(s);
            }
            GridView1.DataSource = queryJoinreport.Take(15);
            GridView1.DataBind();

        }

        private void LoadReportDate()
        {
            //this month
            if (DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) == DateTime.Today.Day)
            {
                endDateReport = DateTime.Today;
                startDateReport = new DateTime(endDateReport.Year, endDateReport.Month, 1);                
            }
            //last month
            else
            {
                endDateReport = DateTime.Today.AddMonths(-1);
                endDateReport = new DateTime(endDateReport.Year, endDateReport.Month, DateTime.DaysInMonth(endDateReport.Year, endDateReport.Month));
                startDateReport = new DateTime(endDateReport.Year, endDateReport.Month, 1);
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (cal_startdatereport.SelectedDate <= cal_enddatereport.SelectedDate)
                Report(cal_startdatereport.SelectedDate, cal_enddatereport.SelectedDate);
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The end date selected have to be greater than the start date')", true);
        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            LoadReportDate();
            Report(cal_startdatereport.SelectedDate, cal_enddatereport.SelectedDate);
            Models.C_SpreadSheetBuilder file = new Models.C_SpreadSheetBuilder(listquery,cal_startdatereport.SelectedDate,cal_enddatereport.SelectedDate);
            file.CreateExcelFile();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (cal_startdatereport.Visible)
                cal_startdatereport.Visible = false;
            else
                cal_startdatereport.Visible = true;
            cal_startdatereport.VisibleDate = cal_startdatereport.SelectedDate;
            
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (cal_enddatereport.Visible)
                cal_enddatereport.Visible = false;
            else
                cal_enddatereport.Visible = true;
            
            cal_enddatereport.VisibleDate = cal_enddatereport.SelectedDate;
        }

        protected void cal_startdatereport_SelectionChanged(object sender, EventArgs e)
        {
            cal_startdatereport.VisibleDate = cal_startdatereport.SelectedDate;
            cal_enddatereport.VisibleDate = cal_enddatereport.SelectedDate;
            lbl_start.Text = cal_startdatereport.SelectedDate.ToShortDateString();
            cal_startdatereport.Visible = false;
        }

        protected void cal_enddatereport_SelectionChanged(object sender, EventArgs e)
        {
            cal_startdatereport.VisibleDate = cal_startdatereport.SelectedDate;
            cal_enddatereport.VisibleDate = cal_enddatereport.SelectedDate;
            lbl_end.Text = cal_enddatereport.SelectedDate.ToShortDateString();
            cal_enddatereport.Visible = false;
        }
    }
}