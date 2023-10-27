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
    public partial class OnHandInventory1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    if (Session["User"].ToString().ToUpper() != "ADMIN")// || Session["User"].ToString().ToUpper() == "AMIR.SHAH" || Session["User"].ToString().ToUpper() == "ARSHAD.A")
                    {
                        Response.Write("<script>alert('Do Not Allow This Page Access. Contact To Business Solution Department');window.location ='AllCustomer.aspx';</script>");

                        //Response.Redirect("~/AllCustomer.aspx");
                    }
                    else
                    {
                        Label1.Text = "Welcome:" + Session["User"].ToString().ToUpper();
                    }
                }
                else
                {
                    Response.Redirect("~/SignIn.aspx");

                }

                string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                SqlConnection sqlConn = new SqlConnection(conString);
                string query = @"
                select Distinct (select ep.displayproductnumber from ecoresproduct ep 
                where ep.RECID = it.product )'PRODUCTCODE' 
                from INVENTSUM ISum
                INNER join inventdim Idim
                on	isum.INVENTDIMID = Idim.INVENTDIMID and isum.DATAAREAID = idim.DATAAREAID
                --INNER join INVENTLOCATION  il
                 --on il.INVENTLOCATIONID = idim.INVENTLOCATIONID and il.DATAAREAID = Idim.DATAAREAI
                 left outer join INVENTBATCH ib
                on ib.ITEMID = isum.ITEMID and ib.DATAAREAID = isum.DATAAREAID and ib.INVENTBATCHID = Idim.INVENTBATCHID 
                inner join INVENTTABLE IT
                on it.ITEMID = ISum.ITEMID and it.DATAAREAID = ISum.DATAAREAID
                WHERE 
                SAMPLE = 0";

                SqlCommand cmd = new SqlCommand(query, sqlConn);
                sqlConn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                cmd.CommandTimeout = 240;
                if (sdr.HasRows)
                {

                    multiselect1.DataSource = sdr;
                    multiselect1.DataTextField = "PRODUCTCODE";
                    multiselect1.DataBind();



                }
                sqlConn.Close();

                //string conString2 = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                //SqlConnection sqlConn2 = new SqlConnection(conString);
                string query2 = @"
                select Distinct (select ept.name from ecoresproducttranslation ept where it.product = ept.product)'PRODUCTNAME' 
                from INVENTSUM ISum INNER join inventdim Idim on	isum.INVENTDIMID = Idim.INVENTDIMID and isum.DATAAREAID = idim.DATAAREAID
                --INNER join INVENTLOCATION  il
                --on il.INVENTLOCATIONID = idim.INVENTLOCATIONID and il.DATAAREAID = Idim.DATAAREAI
                left outer join INVENTBATCH ib on ib.ITEMID = isum.ITEMID and ib.DATAAREAID = isum.DATAAREAID and ib.INVENTBATCHID = Idim.INVENTBATCHID 
                inner join INVENTTABLE IT on it.ITEMID = ISum.ITEMID and it.DATAAREAID = ISum.DATAAREAID WHERE SAMPLE = 0";

                SqlCommand cmd2 = new SqlCommand(query2, sqlConn);
                sqlConn.Open();
                SqlDataReader sdr2 = cmd2.ExecuteReader();
                cmd2.CommandTimeout = 240;
                if (sdr2.HasRows)
                {

                    multiselect2.DataSource = sdr2;
                    multiselect2.DataTextField = "PRODUCTNAME";
                    multiselect2.DataBind();



                }
                sqlConn.Close();


                //string conString3 = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                //SqlConnection sqlConn3 = new SqlConnection(conString3);
                string query3 = @"select Distinct ib.INVENTBATCHID
                from INVENTSUM ISum INNER join inventdim Idim on	isum.INVENTDIMID = Idim.INVENTDIMID and isum.DATAAREAID = idim.DATAAREAID
                --INNER join INVENTLOCATION  il
                --on il.INVENTLOCATIONID = idim.INVENTLOCATIONID and il.DATAAREAID = Idim.DATAAREAI
                left outer join INVENTBATCH ib on ib.ITEMID = isum.ITEMID and ib.DATAAREAID = isum.DATAAREAID and ib.INVENTBATCHID = Idim.INVENTBATCHID 
                inner join INVENTTABLE IT on it.ITEMID = ISum.ITEMID and it.DATAAREAID = ISum.DATAAREAID WHERE SAMPLE = 0";


                SqlCommand cmd3 = new SqlCommand(query3, sqlConn);
                sqlConn.Open();
                SqlDataReader sdr3 = cmd3.ExecuteReader();
                cmd3.CommandTimeout = 240;
                if (sdr3.HasRows)
                {

                    multiselect3.DataSource = sdr3;
                    multiselect3.DataTextField = "INVENTBATCHID";
                    multiselect3.DataBind();



                }
                sqlConn.Close();


                string conString4 = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
                SqlConnection sqlConn4 = new SqlConnection(conString4);
                string query4 = @"select Distinct Idim.INVENTLOCATIONID
                    from INVENTSUM ISum
                    INNER join inventdim Idim
                    on	isum.INVENTDIMID = Idim.INVENTDIMID and isum.DATAAREAID = idim.DATAAREAID
                    --INNER join INVENTLOCATION  il
                     --on il.INVENTLOCATIONID = idim.INVENTLOCATIONID and il.DATAAREAID = Idim.DATAAREAI
                     left outer join INVENTBATCH ib
                    on ib.ITEMID = isum.ITEMID and ib.DATAAREAID = isum.DATAAREAID and ib.INVENTBATCHID = Idim.INVENTBATCHID 
                    inner join INVENTTABLE IT
                    on it.ITEMID = ISum.ITEMID and it.DATAAREAID = ISum.DATAAREAID
                    WHERE 
                    SAMPLE = 0";



                SqlCommand cmd4 = new SqlCommand(query4, sqlConn);
                sqlConn.Open();
                SqlDataReader sdr4 = cmd4.ExecuteReader();
                cmd4.CommandTimeout = 240;
                if (sdr4.HasRows)
                {

                    multiselect5.DataSource = sdr4;
                    multiselect5.DataTextField = "INVENTLOCATIONID";
                    multiselect5.DataBind();



                }
                sqlConn.Close();


                //if (Session["User"] != null)
                //{

                //    Label1.Text = "Welcome:" + Session["User"].ToString().ToUpper();
                //}
                //else
                //{
                //    Response.Redirect("~/SignIn.aspx");

                //}



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
                    inputProductID.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputProductID.Value = condition.Substring(0, condition.Length - 1);
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
                    inputProductName.Value = condition;
                }
                else
                {
                    inputProductName.Value = condition.Substring(0, condition.Length - 1);
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
                    inputBatch.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputBatch.Value = condition.Substring(0, condition.Length - 1);
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
                    inputDivision.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputDivision.Value = condition.Substring(0, condition.Length - 1);
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
                    inputWarehouse.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputWarehouse.Value = condition.Substring(0, condition.Length - 1);
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
                    inputSite.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputSite.Value = condition.Substring(0, condition.Length - 1);
                }

            }

        }
        public void BindGrid7()
        {
            //string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
            //string query = @"select DATAAREAID,ACCOUNTNUM,INVENTLOCATIONBR, PAYMMODE , INVENTSITEID from CUSTTABLE LEFT OUTER JOIN DIRPARTYTABLE d ON CUSTTABLE.PARTY = d.RECID ";

            string condition = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem item in multiselect7.Items)
            {
                condition += item.Selected ? string.Format("{0},", item.Value) : "";
                if (condition == "")
                {
                    inputSample.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    if(condition.Substring(0, condition.Length - 1) == "YES")
                    {
                        inputSample.Value = "1";
                    }
                    else if (condition.Substring(0, condition.Length - 1) == "NO")
                    {
                        inputSample.Value = "0";
                    }
                    //inputSample.Value = condition.Substring(0, condition.Length - 1);
                }

            }

        }

        public void BindGrid8()
        {
            //string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
            //string query = @"select DATAAREAID,ACCOUNTNUM,INVENTLOCATIONBR, PAYMMODE , INVENTSITEID from CUSTTABLE LEFT OUTER JOIN DIRPARTYTABLE d ON CUSTTABLE.PARTY = d.RECID ";

            string condition = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem item in multiselect8.Items)
            {
                condition += item.Selected ? string.Format("{0},", item.Value) : "";
                if (condition == "")
                {
                    
                    inputItemInventory.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    if (condition.Substring(0, condition.Length - 1) == "Merchandise")
                    {
                        inputItemInventory.Value = "1";
                    }
                    else if (condition.Substring(0, condition.Length - 1) == "Non Merchandise")
                    {
                        inputItemInventory.Value = "2";
                    }
                    else if(condition.Substring(0, condition.Length - 1) == "Blank")
                    {
                        inputItemInventory.Value = "0";
                    }
                    //inputItemInventory.Value = condition.Substring(0, condition.Length - 1);
                }

            }
        }

            public void BindGrid9()
        {
            //string conString = ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ConnectionString;
            //string query = @"select DATAAREAID,ACCOUNTNUM,INVENTLOCATIONBR, PAYMMODE , INVENTSITEID from CUSTTABLE LEFT OUTER JOIN DIRPARTYTABLE d ON CUSTTABLE.PARTY = d.RECID ";

            string condition = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem item in multiselect9.Items)
            {
                condition += item.Selected ? string.Format("{0},", item.Value) : "";
                if (condition == "")
                {
                    inputProductGroup.Value = condition;
                    // TextBox1.Text = condition;
                }
                else
                {
                    inputProductGroup.Value = condition.Substring(0, condition.Length - 1);
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
        protected void multiselect6_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid6();
        }

        protected void multiselect7_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid7();
        }

        protected void multiselect8_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid8();
        }

        protected void multiselect9_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid9();
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
            //string Admin = "Admin";
            string AHD = "AHD";
            string SPD = "SPD";
            string FTD = "FTD";
            string PHD = "PHD";
            string HHD = "HHD";
            string Mudassir = "MUDASSIR.G";
            string Amir = "AMIR.SHAH";
            string Arshad = "ARSHAD.A";

            string User = Session["User"].ToString().ToUpper();
            pageIndex -= 1;
            GridView1.PageIndex = pageIndex;
            //GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductCode.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputDivision.Value, inputSite.Value, out totalRows);
            if (Session["User"].ToString().ToUpper() != "ADMIN")
            {
                GridView1.DataSource = OnHandInventory.GetOnHandInventory(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, Session["Division"].ToString(), inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
            }
            //else if (User == SPD)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, "SPECIAL PRODUCT DIVISION", inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
            //}
            //else if (User == FTD)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, "FEED TECH DIVISION", inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
            //}
            //else if (User == PHD)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, "POULTRY HEALTH DIVISION", inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
            //}
            //else if (User == HHD)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, "HUMAN HEALTH DIVISION", inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
            //}
            //else if (User == Mudassir)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value, inputProductGroup.Value, inputItemInventory.Value, inputBatch.Value, "FEED TECH DIVISION", "KHI", "KCC,AHDC,KDC,PDC,KHO,KPC", inputSample.Value, out totalRows);
            //}
            //else if (User == Amir)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value, inputProductGroup.Value, inputItemInventory.Value, inputBatch.Value, "POULTRY HEALTH DIVISION", "KHI", "KCC,AHDC,KDC,PDC,KHO,KPC", inputSample.Value, out totalRows);
            //}
            //else if (User == Arshad)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value, inputProductGroup.Value, inputItemInventory.Value, inputBatch.Value, "SPECIALITY PRODUCT DIVISION", "KHI", "KCC,AHDC,KDC,PDC,KHO,KPC", inputSample.Value, out totalRows);
            //}
            else
            {
                GridView1.DataSource = OnHandInventory.GetOnHandInventory(pageIndex, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, inputDivision.Value, inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
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

            string User = Session["User"].ToString().ToUpper();
            //GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductCode.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputDivision.Value, inputSite.Value, out totalRows);

            if (Session["User"].ToString().ToUpper() != "ADMIN")
            {
                GridView1.DataSource = OnHandInventory.GetOnHandInventory(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value, inputProductGroup.Value, inputItemInventory.Value, inputBatch.Value, Session["Division"].ToString(), inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
            }
            //else if (User == SPD)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, "SPECIALITY PRODUCT DIVISION", inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
            //}
            //else if (User == FTD)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, "FEED TECH DIVISION", inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
            //}
            //else if (User == PHD)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, "POULTRY HEALTH DIVISION", inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
            //}
            //else if (User == HHD)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, "HUMAN HEALTH DIVISION", inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
            //}
            //else if (User == Mudassir)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, "FEED TECH DIVISION", "KHI", "KCC,AHDC,KDC,PDC,KHO,KPC", inputSample.Value, out totalRows);
            //}
            //else if (User == Amir)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, "POULTRY HEALTH DIVISION", "KHI", "KCC,AHDC,KDC,PDC,KHO,KPC", inputSample.Value, out totalRows);
            //}
            //else if (User == Arshad)
            //{
            //    GridView1.DataSource = OnHandInventory.GetOnHandInventory(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, "SPECIALITY PRODUCT DIVISION", "KHI", "KCC,AHDC,KDC,PDC,KHO,KPC", inputSample.Value, out totalRows);
            //}
            else
            {
                GridView1.DataSource = OnHandInventory.GetOnHandInventory(0, GridView1.PageSize, inputStartInvoiceDate.Value, inputEndInvoiceDate.Value, inputProductID.Value, inputProductName.Value,inputProductGroup.Value,inputItemInventory.Value, inputBatch.Value, inputDivision.Value, inputSite.Value, inputWarehouse.Value, inputSample.Value, out totalRows);
            }
            // (0, GridView1.PageSize, out totalRows);
            GridView1.DataBind();

            DatabindRepeater1(0, GridView1.PageSize, totalRows);

        }

        protected void ExpToExcel_Click(object sender, EventArgs e)
        {
            // Clear all content output from the buffer stream
            Response.ClearContent();
            // Specify the default file name using "content-disposition" RESPONSE header
            Response.AppendHeader("content-disposition", "attachment; filename=OnHandInventory.xls");
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
                    "attachment;filename=OnHandInventory.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
        }
    }
}