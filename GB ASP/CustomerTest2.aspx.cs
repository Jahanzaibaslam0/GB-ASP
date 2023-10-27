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
    public partial class CustomerTest2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                SqlConnection sqlConn = new SqlConnection(conString);
                string query = @"select c.ACCOUNTNUM,c.InventLocationBr from CUSTTABLE c where c.DATAAREAID = 'ph1'";

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

                string conString2 = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                SqlConnection sqlConn2 = new SqlConnection(conString);
                string query2 = @"select Distinct c.InventLocationBr from CUSTTABLE c where c.DATAAREAID = 'ph1'";

                SqlCommand cmd2 = new SqlCommand(query2, sqlConn2);
                sqlConn2.Open();
                SqlDataReader sdr2 = cmd2.ExecuteReader();
                cmd2.CommandTimeout = 240;
                if (sdr2.HasRows)
                {

                    multiselect2.DataSource = sdr2;
                    multiselect2.DataTextField = "InventLocationBr";
                    multiselect2.DataBind();



                }
                sqlConn.Close();

                if (Session["User"] != null)
                {

                    Label1.Text = "Welcome:" + Session["User"].ToString();
                }
                else
                {
                    Response.Redirect("~/SignIn.aspx");

                }





            }

        }

        public void BindGrid()
        {
            string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
            string query = @"select DATAAREAID,ACCOUNTNUM,INVENTLOCATIONBR, PAYMMODE , INVENTSITEID from CUSTTABLE LEFT OUTER JOIN DIRPARTYTABLE d ON CUSTTABLE.PARTY = d.RECID ";

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
            string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
            string query = @"select DATAAREAID,ACCOUNTNUM,INVENTLOCATIONBR, PAYMMODE , INVENTSITEID from CUSTTABLE";

            string condition = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem item in multiselect2.Items)
            {
                condition += item.Selected ? string.Format("{0},", item.Value) : "";
                if (condition == "")
                {
                    TextBox2.Text = condition;
                }
                else
                {
                    TextBox2.Text = condition.Substring(0, condition.Length - 1);
                }

            }


        }
        protected void Country_Selected(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid2();
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
            //string blocked = Convert.ToString("0");
            string Mudassir = "Mudassir.g";
            string Amir = "Amir.Shah";
            string Arshad = "Arshad.a";
            string User = Session["User"].ToString();
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            example.PageIndex = pageIndex;

            //example.DataSource = spCustomer.(pageIndex, example.PageSize,inp , out totalRows);

            if (User == Mudassir)
            {
                example.DataSource = AllCustomer2.GetAllCustomer(pageIndex, example.PageSize, inputCustomerCode.Value, inputCustomerName.Value, Blocked.Value, inputCustGroup.Value,"KHO", out totalRows);//EmployeeDataAccessLayer.GetEmployees(pageIndex, example.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductCode.Value, inputProductName.Value, inputDivision.Value, inputRegion.Value, out totalRows);
            }
            else if (User == Amir)
            {
                example.DataSource = AllCustomer2.GetAllCustomer(pageIndex, example.PageSize, inputCustomerCode.Value, inputCustomerName.Value, Blocked.Value, inputCustGroup.Value,"KHO", out totalRows); 
            }
            else if (User == Arshad)
            {
                example.DataSource = AllCustomer2.GetAllCustomer(pageIndex, example.PageSize, inputCustomerCode.Value, inputCustomerName.Value, Blocked.Value, inputCustGroup.Value, "KHO", out totalRows);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
            }
            else
            {
                example.DataSource = AllCustomer2.GetAllCustomer(pageIndex, example.PageSize, inputCustomerCode.Value, inputCustomerName.Value, Blocked.Value, inputCustGroup.Value, inputBranch.Value, out totalRows);
            }
            example.DataBind();
            DatabindRepeater1(pageIndex, example.PageSize, 1);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int totalRows = 0;
            string Mudassir = "Mudassir.g";
            string Amir = "Amir.Shah";
            string Arshad = "Arshad.a";
            string User = Session["User"].ToString();
            // string blocked = Convert.ToString("0");
            if (User == Mudassir)
            {
                example.DataSource = AllCustomer2.GetAllCustomer(0, example.PageSize, inputCustomerCode.Value, inputCustomerName.Value, Blocked.Value, inputCustGroup.Value, "KHO", out totalRows);
            }
            else if (User == Amir)
            {
                example.DataSource = AllCustomer2.GetAllCustomer(0, example.PageSize, inputCustomerCode.Value, inputCustomerName.Value, Blocked.Value, inputCustGroup.Value, "KHO", out totalRows);
            }
            else if (User == Arshad)
            {
                example.DataSource = AllCustomer2.GetAllCustomer(0, example.PageSize, inputCustomerCode.Value, inputCustomerName.Value, Blocked.Value, inputCustGroup.Value, "KHO", out totalRows);

            }
            else
            {
                example.DataSource = AllCustomer2.GetAllCustomer(0, example.PageSize, TextBox1.Text, inputCustomerName.Value, Blocked.Value, inputCustGroup.Value, TextBox2.Text, out totalRows);

            }
            example.DataBind();

            DatabindRepeater1(0, example.PageSize, 1);

        }

        protected void ExpToExcel_Click(object sender, EventArgs e)
        {                                                                                                                                                                                                                                                                                                                                                                                                                             
            // Clear all content output from the buffer stream
            Response.ClearContent();
            // Specify the default file name using "content-disposition" RESPONSE header
            Response.AppendHeader("content-disposition", "attachment; filename=AllCustomer.xls");
            // Set excel as the HTTP MIME type
            Response.ContentType = "application/excel";
            // Create an instance of stringWriter for writing information to a string
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            // Create an instance of HtmlTextWriter class for writing markup 
            // characters and text to an ASP.NET server control output stream
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            // Set white color as the background color for gridview header row
            example.HeaderRow.Style.Add("background-color", "#FFFFFF");

            // Set background color of each cell of example header row
            foreach (TableCell tableCell in example.HeaderRow.Cells)
            {
                tableCell.Style["background-color"] = "#A55129";
            }

            // Set background color of each cell of each data row of example
            foreach (GridViewRow gridViewRow in example.Rows)
            {
                gridViewRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell gridViewRowTableCell in gridViewRow.Cells)
                {
                    gridViewRowTableCell.Style["background-color"] = "#FFF7E7";
                }
            }

            example.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void ExpToPDF_Click(object sender, EventArgs e)
        {
            {
                int columnsCount = example.HeaderRow.Cells.Count;
                // Create the PDF Table specifying the number of columns
                PdfPTable pdfTable = new PdfPTable(columnsCount);

                // Loop thru each cell in GrdiView header row
                foreach (TableCell gridViewHeaderCell in example.HeaderRow.Cells)
                {
                    // Create the Font Object for PDF document
                    Font font = new Font();
                    // Set the font color to GridView header row font color
                    font.Color = new BaseColor(example.HeaderStyle.ForeColor);

                    // Create the PDF cell, specifying the text and font
                    PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                    // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                    pdfCell.BackgroundColor = new BaseColor(example.HeaderStyle.BackColor);

                    // Add the cell to PDF table
                    pdfTable.AddCell(pdfCell);
                }

                // Loop thru each datarow in GrdiView
                foreach (GridViewRow gridViewRow in example.Rows)
                {
                    if (gridViewRow.RowType == DataControlRowType.DataRow)
                    {
                        // Loop thru each cell in GrdiView data row
                        foreach (TableCell gridViewCell in gridViewRow.Cells)
                        {
                            Font font = new Font();
                            font.Color = new BaseColor(example.RowStyle.ForeColor);

                            PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                            pdfCell.BackgroundColor = new BaseColor(example.RowStyle.BackColor);

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
                    "attachment;filename=AllCustomer.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
        }
    }
}