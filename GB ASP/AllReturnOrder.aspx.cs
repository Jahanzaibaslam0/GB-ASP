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
//using ClosedXML;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace GB_ASP
{
    public partial class AllReturnOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Branch1 = Session["Branch1"].ToString();
                string Division = Session["Division2"].ToString();
                string Division1 = Session["Division1"].ToString();

                string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                SqlConnection sqlConn = new SqlConnection(conString);
                string query = @"select ACCOUNTNUM,InventLocationBr from CUSTTABLE  where DATAAREAID = 'ph1' and InventLocationBr in (" + Branch1 + ")";


                SqlCommand cmd = new SqlCommand(query, sqlConn);
                sqlConn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                cmd.CommandTimeout = 240;
                if (sdr.HasRows)
                {

                    multiselect1.DataSource = sdr;
                    multiselect1.DataTextField = "Accountnum";
                    multiselect1.DataBind();



                }
                sqlConn.Close();

                //string conString2 = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                //SqlConnection sqlConn2 = new SqlConnection(conString);
                string query2 = @"select Distinct c.InventLocationBr from CUSTTABLE c where c.DATAAREAID = 'ph1' and InventLocationBr in (" + Branch1 + ")";


                SqlCommand cmd2 = new SqlCommand(query2, sqlConn);
                sqlConn.Open();
                SqlDataReader sdr2 = cmd2.ExecuteReader();
                cmd2.CommandTimeout = 240;
                if (sdr2.HasRows)
                {

                    multiselect2.DataSource = sdr2;
                    multiselect2.DataTextField = "InventLocationBr";
                    multiselect2.DataBind();



                }
                sqlConn.Close();


                //string conString3 = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                //SqlConnection sqlConn3 = new SqlConnection(conString3);
                string query3 = @"select distinct d.Name from CUSTTABLE LEFT OUTER JOIN DIRPARTYTABLE d ON CUSTTABLE.PARTY = d.RECID and CUSTTABLE.INVENTLOCATIONBR in (" + Branch1 + ") ";



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


                string conString4 = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                SqlConnection sqlConn4 = new SqlConnection(conString4);
                string query4 = @"  select distinct ((Select DIMATTRIBUTEHCMWORKER.NAME
                FROM DEFAULTDIMENSIONVIEW , DIMATTRIBUTEHCMWORKER 
                WHERE DEFAULTDIMENSIONVIEW.NAME = 'Employee' AND DISPLAYVALUE = VALUE
                AND DEFAULTDIMENSIONVIEW.DEFAULTDIMENSION = cu.DEFAULTDIMENSION
                AND DIMATTRIBUTEHCMWORKER.PARTITION = cu.PARTITION))'Salestaker' from CUSTTRANS cu 
		        where (Select top 1 DIMATTRIBUTEOMBUSINESSUNIT.NAME
	            FROM DEFAULTDIMENSIONVIEW , DIMATTRIBUTEOMBUSINESSUNIT 
	            WHERE DEFAULTDIMENSIONVIEW.NAME = 'Division' AND DISPLAYVALUE = VALUE
	            AND DEFAULTDIMENSIONVIEW.DEFAULTDIMENSION = cu.defaultdimension
	            AND DIMATTRIBUTEOMBUSINESSUNIT.PARTITION = cu.PARTITION)  in (" + Division + ")";



                SqlCommand cmd4 = new SqlCommand(query4, sqlConn);
                sqlConn.Open();
                SqlDataReader sdr4 = cmd4.ExecuteReader();
                cmd4.CommandTimeout = 240;
                if (sdr4.HasRows)
                {

                    multiselect4.DataSource = sdr4;
                    multiselect4.DataTextField = "SALESTAKER";
                    multiselect4.DataBind();



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
                    inputCustomerCode.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputCustomerCode.Value = condition.Substring(0, condition.Length - 1);
                }

            }


        }

        public void BindGrid2()
        {
            //string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
            //string query = @"select DATAAREAID,ACCOUNTNUM,INVENTLOCATIONBR, PAYMMODE , INVENTSITEID from CUSTTABLE";

            string condition = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem item in multiselect2.Items)
            {
                condition += item.Selected ? string.Format("{0},", item.Value) : "";
                if (condition == "")
                {
                    inputBranch.Value = condition;
                }
                else
                {
                    inputBranch.Value = condition.Substring(0, condition.Length - 1);
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
                    inputCustomerName.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputCustomerName.Value = condition.Substring(0, condition.Length - 1);
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

        public void BindGrid4()
        {
            //string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
            //string query = @"select DATAAREAID,ACCOUNTNUM,INVENTLOCATIONBR, PAYMMODE , INVENTSITEID from CUSTTABLE LEFT OUTER JOIN DIRPARTYTABLE d ON CUSTTABLE.PARTY = d.RECID ";

            string condition = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem item in multiselect4.Items)
            {
                condition += item.Selected ? string.Format("{0},", item.Value) : "";
                if (condition == "")
                {
                    inputSalesTaker.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputSalesTaker.Value = condition.Substring(0, condition.Length - 1);
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

        protected void multiselect2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid2();
        }

        protected void multiselect4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid4();
        }
        protected void multiselect5_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid5();
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
            string Mudassir = "MUDASSIR.G";
            string Amir = "AMIR.SHAH";
            string Arshad = "ARSHAD.A";
            string User = Session["User"].ToString().ToUpper();
            GridView1.PageIndex = pageIndex;
            //GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductCode.Value, inputProductName.Value, inputDivision.Value, inputRegion.Value, out totalRows);
            if (Session["User"].ToString().ToUpper() != "ADMIN")
            { 
            GridView1.DataSource = AllReturnOrder1.GetReturnOrder(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, Session["Division"].ToString(), inputSalesID.Value, inputSalesTaker.Value, Session["Branch"].ToString(), inputStatus.Value, out totalRows);
            }
            //else if (User == AHD)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "ANIMAL HEALTH DIVISION", inputSalesID.Value, inputSalesTaker.Value, inputBranch.Value, "0", out totalRows);
            //}
            //else if (User == FTD)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "FEED TECH DIVISION", inputSalesID.Value, inputSalesTaker.Value, inputBranch.Value, "0", out totalRows);
            //}
            //else if (User == PHD)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "POULTRY HEALTH DIVISION", inputSalesID.Value, inputSalesTaker.Value, inputBranch.Value, "0", out totalRows);
            //}
            //else if (User == SPD)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "SPECIALITY PRODUCT DIVISION", inputSalesID.Value, inputSalesTaker.Value, inputBranch.Value, "0", out totalRows);
            //}
            //else if (User == Mudassir)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "FEED TECH DIVISION", inputSalesID.Value, inputSalesTaker.Value,"KHO,HDC",  "0", out totalRows);
            //}
            //else if (User == Amir)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "POULTRY HEALTH DIVISION ", inputSalesID.Value, inputSalesTaker.Value,"KHO,HDC", "0", out totalRows);
            //}
            //else if (User == Arshad)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "SPECIALITY PRODUCT DIVISION", inputSalesID.Value, inputSalesTaker.Value, "KHO", "0", out totalRows);
            //}
            else
            {
                GridView1.DataSource = AllReturnOrder1.GetReturnOrder(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, inputDivision.Value, inputSalesID.Value, inputSalesTaker.Value, inputBranch.Value, inputStatus.Value, out totalRows);
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
            string Mudassir = "MUDASSIR.G";
            string Amir = "AMIR.SHAH";
            string Arshad = "ARSHAD.A";
            // string Branch = "KHO,HDC";

            string User = Session["User"].ToString().ToUpper();
            //GridView1.PageIndex = pageIndex;
            //GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductCode.Value, inputProductName.Value, inputDivision.Value, inputRegion.Value, out totalRows);
            if (Session["User"].ToString().ToUpper() != "ADMIN")
            {
                GridView1.DataSource = AllReturnOrder1.GetReturnOrder(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, Session["Division"].ToString(), inputSalesID.Value, inputSalesTaker.Value, Session["Branch"].ToString(), inputStatus.Value, out totalRows);
            }
            //else if (User == AHD)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "ANIMAL HEALTH DIVISION", inputSalesID.Value, inputSalesTaker.Value, inputBranch.Value, "0", out totalRows);
            //}
            //else if (User == FTD)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "FEED TECH DIVISION", inputSalesID.Value, inputSalesTaker.Value, inputBranch.Value, "0", out totalRows);
            //}
            //else if (User == PHD)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "POULTRY HEALTH DIVISION", inputSalesID.Value, inputSalesTaker.Value, inputBranch.Value, "0", out totalRows);
            //}
            //else if (User == SPD)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "SPECIALITY PRODUCT DIVISION", inputSalesID.Value, inputSalesTaker.Value, inputBranch.Value, "0", out totalRows);
            //}
            //else if (User == Mudassir)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "FEED TECH DIVISION", inputSalesID.Value, inputSalesTaker.Value,"KHO,HDC", "0", out totalRows);
            //}
            //else if (User == Amir)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "POULTRY HEALTH DIVISION", inputSalesID.Value, inputSalesTaker.Value,"KHO,HDC", "0", out totalRows);
            //}
            //else if (User == Arshad)
            //{
            //    GridView1.DataSource = AllReturnOrder1.GetReturnOrder(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, "SPECIALITY PRODUCT DIVISION", inputSalesID.Value, inputSalesTaker.Value, "KHO", "0", out totalRows);
            //}
             else
            {
                GridView1.DataSource = AllReturnOrder1.GetReturnOrder(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputCustomerCode.Value, inputCustomerName.Value, inputDivision.Value, inputSalesID.Value, inputSalesTaker.Value, inputBranch.Value, inputStatus.Value, out totalRows);
            }
            GridView1.DataBind();

            DatabindRepeater1(0, GridView1.PageSize, totalRows);

        }

        protected void ExpToExcel_Click(object sender, EventArgs e)
        {
            // Clear all content output from the buffer stream
            Response.ClearContent();
            // Specify the default file name using "content-disposition" RESPONSE header
            Response.AppendHeader("content-disposition", "attachment; filename=AllReturnOrder.xls");
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
        //protected void ExportExcel(object sender, EventArgs e)
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customers"))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                sda.SelectCommand = cmd;
        //                using (DataTable dt = new DataTable())
        //                {
        //                    sda.Fill(dt);
        //                    using (XLWorkbook wb = new XLWorkbook())
        //                    {
        //                        wb.Worksheets.Add(dt, "Customers");

        //                        Response.Clear();
        //                        Response.Buffer = true;
        //                        Response.Charset = "";
        //                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //                        Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
        //                        using (MemoryStream MyMemoryStream = new MemoryStream())
        //                        {
        //                            wb.SaveAs(MyMemoryStream);
        //                            MyMemoryStream.WriteTo(Response.OutputStream);
        //                            Response.Flush();
        //                            Response.End();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
            DataTable dt = new DataTable();
            con.Open();

            string queryStr = "select * from ChequedReceivedReport";
            SqlDataAdapter sda = new SqlDataAdapter(queryStr, con);
            sda.Fill(dt);
            ExportTableData(dt);
        }

        // this does all the work to export to excel
        public void ExportTableData(DataTable dtdata)
        {
            string attach = "attachment;filename=AllReturnOrder.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attach);
            Response.ContentType = "application/ms-excel";
            if (dtdata != null)
            {
                foreach (DataColumn dc in dtdata.Columns)
                {
                    Response.Write(dc.ColumnName + "\t");
                    //sep = ";";
                }
                Response.Write(System.Environment.NewLine);
                foreach (DataRow dr in dtdata.Rows)
                {
                    for (int i = 0; i < dtdata.Columns.Count; i++)
                    {
                        Response.Write(dr[i].ToString() + "\t");
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
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
                    "attachment;filename=AllReturnOrder.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
        }

    }
}