using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace GB_ASP
{
    public partial class MonthWiseItemSaleAmount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Branch1 = Session["Branch1"].ToString();
                string Division = Session["Division2"].ToString();
                string Division1 = Session["Division1"].ToString();

                if (Session["User"] != null)
                {
                    if (Session["User"].ToString().ToUpper() == "MUDASSIR.G" || Session["User"].ToString().ToUpper() == "AMIR.SHAH" || Session["User"].ToString().ToUpper() == "ARSHAD.A")

                    {
                        Response.Write("<script>alert('Do Not Allow This Page Access. Contact To Business Solution Department');window.location ='AllCustomer.aspx';</script>");

                        //Response.Redirect("~/AllCustomer.aspx");
                    }
                    else
                    {
                        Label1.Text = "Welcome:" + Session["User"].ToString();
                    }
                }
                else
                {
                    Response.Redirect("~/SignIn.aspx");

                }
                string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                SqlConnection sqlConn = new SqlConnection(conString);
                string query = @"select distinct Itemid from CUSTINVOICETRANS";

                SqlCommand cmd = new SqlCommand(query, sqlConn);
                sqlConn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                cmd.CommandTimeout = 240;
                if (sdr.HasRows)
                {

                    multiselect1.DataSource = sdr;
                    multiselect1.DataTextField = "Itemid";
                    multiselect1.DataBind();



                }
                sqlConn.Close();



                //string conString3 = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                //SqlConnection sqlConn3 = new SqlConnection(conString3);
                string query3 = @"select distinct Name from CUSTINVOICETRANS";


                SqlCommand cmd3 = new SqlCommand(query3, sqlConn);
                sqlConn.Open();
                SqlDataReader sdr3 = cmd3.ExecuteReader();
                cmd3.CommandTimeout = 240;
                if (sdr3.HasRows)
                {

                    multiselect3.DataSource = sdr3;
                    multiselect3.DataTextField = "Name";
                    multiselect3.DataBind();



                }
                sqlConn.Close();

                string conString5 = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                SqlConnection sqlConn5 = new SqlConnection(conString5);
                string query5 = @"select distinct (Select top 1 DIMATTRIBUTEOMBUSINESSUNIT.NAME
	            FROM DEFAULTDIMENSIONVIEW , DIMATTRIBUTEOMBUSINESSUNIT 
	            WHERE DEFAULTDIMENSIONVIEW.NAME = 'Division' AND DISPLAYVALUE = VALUE
	            AND DEFAULTDIMENSIONVIEW.DEFAULTDIMENSION = cu.defaultdimension
	            AND DIMATTRIBUTEOMBUSINESSUNIT.PARTITION = cu.PARTITION)'Division' from CUSTTRANS cu 
		        where (Select top 1 DIMATTRIBUTEOMBUSINESSUNIT.NAME
	            FROM DEFAULTDIMENSIONVIEW , DIMATTRIBUTEOMBUSINESSUNIT 
	            WHERE DEFAULTDIMENSIONVIEW.NAME = 'Division' AND DISPLAYVALUE = VALUE
	            AND DEFAULTDIMENSIONVIEW.DEFAULTDIMENSION = cu.defaultdimension
	            AND DIMATTRIBUTEOMBUSINESSUNIT.PARTITION = cu.PARTITION)    in  (" + Division + ")";

                SqlCommand cmd5 = new SqlCommand(query5, sqlConn5);
                sqlConn5.Open();
                SqlDataReader sdr5 = cmd5.ExecuteReader();
                cmd5.CommandTimeout = 240;
                if (sdr5.HasRows)
                {

                    multiselect5.DataSource = sdr5;
                    multiselect5.DataTextField = "Division";
                    multiselect5.DataBind();



                }
                sqlConn5.Close();

                string conString6 = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                SqlConnection sqlConn6 = new SqlConnection(conString6);
                string query6 = @"select distinct (Select top 1 DimensionFinancialTag.Description
                FROM DEFAULTDIMENSIONVIEW , DimensionFinancialTag 
                WHERE DEFAULTDIMENSIONVIEW.NAME = 'Region' AND DISPLAYVALUE = VALUE
                AND DEFAULTDIMENSIONVIEW.DEFAULTDIMENSION = cu.DEFAULTDIMENSION
		        AND DimensionFinancialTag.PARTITION = cu.PARTITION
                )'Region' from CUSTTRANS cu 
		        where (Select top 1 DimensionFinancialTag.Description
                FROM DEFAULTDIMENSIONVIEW , DimensionFinancialTag 
                WHERE DEFAULTDIMENSIONVIEW.NAME = 'Region' AND DISPLAYVALUE = VALUE
                AND DEFAULTDIMENSIONVIEW.DEFAULTDIMENSION = cu.DEFAULTDIMENSION
		        AND DimensionFinancialTag.PARTITION = cu.PARTITION
                )  like '%" + Division1 + "'";

                SqlCommand cmd6 = new SqlCommand(query6, sqlConn6);
                sqlConn6.Open();
                SqlDataReader sdr6 = cmd6.ExecuteReader();
                cmd6.CommandTimeout = 240;
                if (sdr6.HasRows)
                {

                    multiselect6.DataSource = sdr6;
                    multiselect6.DataTextField = "Region";
                    multiselect6.DataBind();



                }
                sqlConn6.Close();




                if (Session["User"] != null)
                {

                    Label1.Text = "Welcome:" + Session["User"].ToString().ToUpper();
                }
                else
                {
                    Response.Redirect("~/SignIn.aspx");

                }



            }
        }

        public void BindGrid()
        {
            //string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
            //string query = @"select DATAAREAID,ACCOUNTNUM,INVENTLOCATIONBR, PAYMMODE , INVENTSITEID from CUSTTABLE LEFT OUTER JOIN DIRPARTYTABLE d ON CUSTTABLE.PARTY = d.RECID ";

            string condition = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem item in multiselect1.Items)
            {
                condition += item.Selected ? string.Format("{0},", item.Value) : "";
                if (condition == "")
                {
                    inputITEMID.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputITEMID.Value = condition.Substring(0, condition.Length - 1);
                }

            }


        }


        public void BindGrid3()
        {
            // string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
            // string query = @"select DATAAREAID,ACCOUNTNUM,INVENTLOCATIONBR, PAYMMODE , INVENTSITEID from CUSTTABLE LEFT OUTER JOIN DIRPARTYTABLE d ON CUSTTABLE.PARTY = d.RECID ";

            string condition = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem item in multiselect3.Items)
            {
                condition += item.Selected ? string.Format("{0},", item.Value) : "";
                if (condition == "")
                {
                    inputItemName.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputItemName.Value = condition.Substring(0, condition.Length - 1);
                }

            }
        }
        public void BindGrid5()
        {
            //string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
            //string query = @"select DATAAREAID,ACCOUNTNUM,INVENTLOCATIONBR, PAYMMODE , INVENTSITEID from CUSTTABLE LEFT OUTER JOIN DIRPARTYTABLE d ON CUSTTABLE.PARTY = d.RECID ";

            string condition = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem item in multiselect5.Items)
            {
                condition += item.Selected ? string.Format("{0},", item.Value) : "";
                if (condition == "")
                {
                    inputDivision.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputDivision.Value = condition.Substring(0, condition.Length - 1);
                }

            }
        }



        public void BindGrid6()
        {
            //string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
            //string query = @"select DATAAREAID,ACCOUNTNUM,INVENTLOCATIONBR, PAYMMODE , INVENTSITEID from CUSTTABLE LEFT OUTER JOIN DIRPARTYTABLE d ON CUSTTABLE.PARTY = d.RECID ";

            string condition = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem item in multiselect6.Items)
            {
                condition += item.Selected ? string.Format("{0},", item.Value) : "";
                if (condition == "")
                {
                    inputRegion.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputRegion.Value = condition.Substring(0, condition.Length - 1);
                }

            }
        }



        protected void multiselect1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void multiselect3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid3();
        }


        protected void multiselect5_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid5();
        }
        protected void multiselect6_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid6();
        }

        private void DatabindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            List<System.Web.UI.WebControls.ListItem> pages = new List<System.Web.UI.WebControls.ListItem>();
            if (totalPages > 1)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString(), i != (pageIndex + 1)));
                }
            }
            RepeaterPaging.DataSource = pages;
            RepeaterPaging.DataBind();
        }

        private void DatabindRepeater1(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            int showMax = 10;
            int startPage;
            int endPage;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;

                if (totalPages <= showMax)
                {
                    startPage = 1;
                    endPage = totalPages + 1;
                }
                else
                {
                    startPage = pageIndex;
                    endPage = pageIndex + showMax - 1;

                }



                List<System.Web.UI.WebControls.ListItem> pages = new List<System.Web.UI.WebControls.ListItem>();
                pages.Add(new System.Web.UI.WebControls.ListItem("First", "1", pageIndex > 1));

                for (int i = startPage; i <= endPage; i++)
                {
                    pages.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString(), i != pageIndex));
                }

                pages.Add(new System.Web.UI.WebControls.ListItem("Last", totalPages.ToString(), pageIndex <= totalPages));

                RepeaterPaging.DataSource = pages;
                RepeaterPaging.DataBind();
            }
        }

        protected void RepeaterPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void LinkButton_Click(object sender, EventArgs e)

        {
            int totalRows = 0;
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            string AHD = "AHD";
            string SPD = "SPD";
            string FTD = "FTD";
            string PHD = "PHD";
            string HHD = "HHD";

            string User = Session["User"].ToString().ToUpper();
            GridView1.PageIndex = pageIndex;
            //GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductCode.Value, inputProductName.Value, inputDivision.Value, inputRegion.Value, out totalRows);
            if (Session["User"].ToString().ToUpper() != "ADMIN")
            {
                GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(pageIndex, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, Session["Division"].ToString(), out totalRows);
            }
            //if (User == FTD)
            //{
            //    GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(pageIndex, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, "FEED TECH DIVISION", out totalRows);
            //}
            //if (User == SPD)
            //{
            //    GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(pageIndex, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, "SPECIALITY PRODUCT DIVISION", out totalRows);
            //}
            //if (User == PHD)
            //{
            //    GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(pageIndex, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, "POULTRY HEALTH DIVISION", out totalRows);
            //}
            //if (User == HHD)
            //{
            //    GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(pageIndex, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, "HUMAN HEALTH DIVISION", out totalRows);
            //}
            else
            {
                GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(pageIndex, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, inputDivision.Value, out totalRows);
            }
            GridView1.DataBind();
            DatabindRepeater1(pageIndex, GridView1.PageSize, totalRows);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int totalRows = 0;
            string AHD = "AHD";
            string SPD = "SPD";
            string FTD = "FTD";
            string PHD = "PHD";
            string HHD = "HHD";

            string User = Session["User"].ToString().ToUpper();
            //GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductCode.Value, inputProductName.Value, inputDivision.Value, inputRegion.Value, out totalRows);
            if (Session["User"].ToString().ToUpper() != "ADMIN")
            {
                GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(0, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, Session["Division"].ToString(), out totalRows);
            }
            //if (User == FTD)
            //{
            //    GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(0, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, "FEED TECH DIVISION", out totalRows);
            //}
            //if (User == SPD)
            //{
            //    GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(0, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, "SPECIALITY PRODUCT DIVISION", out totalRows);
            //}
            //if (User == PHD)
            //{
            //    GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(0, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, "POULTRY HEALTH DIVISION", out totalRows);
            //}
            //if (User == HHD)
            //{
            //    GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(0, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, "HUMAN HEALTH DIVISION", out totalRows);
            //}
            else
            {
                GridView1.DataSource = MonthWiseItemSalesAmount.GetMonthWiseItemSales(0, GridView1.PageSize, inputITEMID.Value, inputItemName.Value, inputRegion.Value, inputDivision.Value, out totalRows);
            }// (0, GridView1.PageSize, out totalRows);
            GridView1.DataBind();

            DatabindRepeater1(0, GridView1.PageSize, totalRows);

        }

        protected void ExpToExcel_Click(object sender, EventArgs e)
        {
            // Clear all content output from the buffer stream
            Response.ClearContent();
            // Specify the default file name using "content-disposition" RESPONSE header
            Response.AppendHeader("content-disposition", "attachment; filename=MonthWiseItemSalesInAmount.xls");
            // Set excel as the HTTP MIME type
            Response.ContentType = "application/excel";
            // Create an instance of stringWriter for writing information to a string
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            // Create an instance of HtmlTextWriter class for writing markup 
            // characters and text to an ASP.NET server control output stream
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            // Set white color as the background color for gridview header row
            GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");

            // Set background color of each cell of GridView1 header row
            foreach (TableCell tableCell in GridView1.HeaderRow.Cells)
            {
                tableCell.Style["background-color"] = "#A55129";
            }

            // Set background color of each cell of each data row of GridView1
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                gridViewRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell gridViewRowTableCell in gridViewRow.Cells)
                {
                    gridViewRowTableCell.Style["background-color"] = "#FFF7E7";
                }
            }

            GridView1.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void ExpToPDF_Click(object sender, EventArgs e)
        {
            {
                int columnsCount = GridView1.HeaderRow.Cells.Count;
                // Create the PDF Table specifying the number of columns
                PdfPTable pdfTable = new PdfPTable(columnsCount);

                // Loop thru each cell in GrdiView header row
                foreach (TableCell gridViewHeaderCell in GridView1.HeaderRow.Cells)
                {
                    // Create the Font Object for PDF document
                    Font font = new Font();
                    // Set the font color to GridView header row font color
                    font.Color = new BaseColor(GridView1.HeaderStyle.ForeColor);

                    // Create the PDF cell, specifying the text and font
                    PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                    // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                    pdfCell.BackgroundColor = new BaseColor(GridView1.HeaderStyle.BackColor);

                    // Add the cell to PDF table
                    pdfTable.AddCell(pdfCell);
                }

                // Loop thru each datarow in GrdiView
                foreach (GridViewRow gridViewRow in GridView1.Rows)
                {
                    if (gridViewRow.RowType == DataControlRowType.DataRow)
                    {
                        // Loop thru each cell in GrdiView data row
                        foreach (TableCell gridViewCell in gridViewRow.Cells)
                        {
                            Font font = new Font();
                            font.Color = new BaseColor(GridView1.RowStyle.ForeColor);

                            PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                            pdfCell.BackgroundColor = new BaseColor(GridView1.RowStyle.BackColor);

                            pdfTable.AddCell(pdfCell);
                        }
                    }
                }

                // Create the PDF document specifying page size and margins
                Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                // Roate page using Rotate() function, if you want in Landscape
                // pdfDocument.SetPageSize(PageSize.A4.Rotate());

                // Using PageSize.A4_LANDSCAPE may not work as expected
                // Document pdfDocument = new Document(PageSize.A4_LANDSCAPE, 10f, 10f, 10f, 10f);

                PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

                pdfDocument.Open();
                pdfDocument.Add(pdfTable);
                pdfDocument.Close();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition",
                    "attachment;filename=MonthWiseItemSalesInAmount.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
        }
    }
}