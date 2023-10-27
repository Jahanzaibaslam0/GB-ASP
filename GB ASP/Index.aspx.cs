using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using GB_ASP.SalesReport;

namespace GB_ASP
{
    public partial class Index : System.Web.UI.Page
    {
        public string sConnectionString = @"Data Source=GB-ERP-JAHANZAI;Initial Catalog=Complaint;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] != null)
            {

                // TextBox1.Text = "Welcome:" + Session["User"].ToString();
            }
            else
            {
                Response.Redirect("~/SignIn.aspx");

            }
        }
      
            protected void Button1_Click1(object sender, EventArgs e)
        {
            GridView1.AllowPaging = true;
            GridView1.PageSize = 10;
            GridView1.PageIndexChanging += new GridViewPageEventHandler(GridView1_PageIndexChanging);
            this.form1.Controls.Add(GridView1);


            if (String.IsNullOrEmpty(txtQty.Text))
            {

                SalesReport.WebService1SoapClient client = new SalesReport.WebService1SoapClient();
                GridView1.DataSource = client.SalesDatawithItem(txtItemID.Text);
                GridView1.DataBind();

            }
            else
            {
                SalesReport.WebService1SoapClient client = new SalesReport.WebService1SoapClient();
                GridView1.DataSource = client.SalesDatawithArgument(txtItemID.Text, txtQty.Text);
                GridView1.DataBind();

            }

        }

    



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();



        }





        //        private void BindTypeList(DropDownList ddlType)
        //        {
        //            SqlConnection con = new SqlConnection(sConnectionString);
        //            SqlDataAdapter sda = new SqlDataAdapter();
        //            SqlCommand cmd = new SqlCommand(@"SELECT 


        //CUSTINVOICETRANS.ITEMID 
        // FROM  CUSTINVOICEJOUR , CUSTINVOICETRANS 
        //WHERE  CUSTINVOICEJOUR.SALESID = CUSTINVOICETRANS.SALESID
        //AND CUSTINVOICEJOUR.INVOICEID = CUSTINVOICETRANS.INVOICEID
        //AND CUSTINVOICEJOUR.INVOICEDATE = CUSTINVOICETRANS.INVOICEDATE
        //and CUSTINVOICEJOUR.INVOICEACCOUNT!='CUS003345'
        //and CUSTINVOICEJOUR.INVOICEACCOUNT!='CUS003346'
        //--AND CUSTINVOICETRANS.SALESQTY != CUSTINVOICETRANS.QTY
        //  AND CUSTINVOICEJOUR.INVOICEDATE >'7/1/18'");
        //            cmd.Connection = con;
        //            con.Open();
        //            this.DropDownList1.DataSource = cmd.ExecuteReader();
        //            this.DropDownList1.DataTextField = "CustName";
        //            this.DropDownList1.DataValueField = "CustID";
        //            this.DropDownList1.DataBind();
        //            con.Close();

        //        }


    }
}
