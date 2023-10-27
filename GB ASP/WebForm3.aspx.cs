using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace GB_ASP
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            TextBox1.Text = inputProductCode.Value;
            string connectionStr = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";//ConfigurationManager .ConnectionStrings["connectionStr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spSalesReport";
                cmd.CommandType = CommandType.StoredProcedure;

                if (inputend.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@maximumrows", inputend.Value);
                    cmd.Parameters.Add(param);
                }


                if (inputProductName.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@ProductName", inputProductName.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputProductCode.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@ProductCode", inputProductCode.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputDivision.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@Division", inputDivision.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputRegion.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@Region", inputRegion.Value);
                    cmd.Parameters.Add(param);
                }

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                gvSearchResults.DataSource = rdr;
                gvSearchResults.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = inputProductCode.Value;
            string connectionStr = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";//ConfigurationManager .ConnectionStrings["connectionStr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spSalesReport";
                cmd.CommandType = CommandType.StoredProcedure;

                //if (inputstart.Value.Trim() != "")
                //{
                //    SqlParameter param = new SqlParameter
                //        ("@StartIndex", inputstart.Value);

                //    cmd.Parameters.Add(param);
                //}

                //if (inputend.Value.Trim() != "")
                //{
                //    SqlParameter param = new SqlParameter
                //        ("@maximumRows", inputend.Value);

                //    cmd.Parameters.Add(param);
                //}





                if (inputProductName.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@ProductName", inputProductName.Value);
                        
                    cmd.Parameters.Add(param);
                }

                if (inputProductCode.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@ProductCode", inputProductCode.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputDivision.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@Division", inputDivision.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputRegion.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@Region", inputRegion.Value);
                    cmd.Parameters.Add(param);
                }

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                gvSearchResults.DataSource = rdr;
                gvSearchResults.DataBind();
                
            }
        }


        public static int GetTotalCount()
        {
            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(@"
SELECT
count(*)
 FROM  CUSTINVOICEJOUR, CUSTINVOICETRANS
WHERE  CUSTINVOICEJOUR.SALESID = CUSTINVOICETRANS.SALESID
AND CUSTINVOICEJOUR.INVOICEID = CUSTINVOICETRANS.INVOICEID
AND CUSTINVOICEJOUR.INVOICEDATE = CUSTINVOICETRANS.INVOICEDATE
and CUSTINVOICEJOUR.INVOICEACCOUNT != 'CUS003345'
and CUSTINVOICEJOUR.INVOICEACCOUNT != 'CUS003346'
--AND CUSTINVOICETRANS.SALESQTY != CUSTINVOICETRANS.QTY
--AND CUSTINVOICETRANS.ITEMID = 'ITM000054'
--AND MONTH(CUSTINVOICEJOUR.INVOICEDATE) = 5
and CUSTINVOICETRANS.ITEMID != ''

--and CUSTINVOICEJOUR.INVOICEDATE >= '1/1/2017'", con);

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }

    public class salesreport2
    {

        public static List<GB_ASP.SalesReport1> SalesReport12(int startRowIndex, int maximumRows)
        {
            List<GB_ASP.SalesReport1> listSalesReport = new List<GB_ASP.SalesReport1>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spnetsalesreport", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramStartIndex = new SqlParameter();
                paramStartIndex.ParameterName = "@StartIndex";
                paramStartIndex.Value = startRowIndex;
                cmd.Parameters.Add(paramStartIndex);

                SqlParameter paramMaximumRows = new SqlParameter();
                paramMaximumRows.ParameterName = "@MaximumRows";
                paramMaximumRows.Value = maximumRows;
                cmd.Parameters.Add(paramMaximumRows);

                //SqlParameter parmProduct = new SqlParameter();
                //parmProduct.ParameterName = "@ProductName";
                //parmProduct.Value = i
                //cmd.Parameters.Add(parmProduct);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    GB_ASP.SalesReport1 SalesReport = new GB_ASP.SalesReport1();

                    SalesReport.Productcode = rdr["ProductCode"].ToString();
                    SalesReport.ProductName = rdr["ProductName"].ToString();
                    SalesReport.Itemid = rdr["itemid"].ToString();
                    SalesReport.CustGroup = rdr["CustGroup"].ToString();
                    SalesReport.DataareaID = rdr["DataareaID"].ToString();
                    SalesReport.SalesUnit = rdr["SalesUnit"].ToString();
                    //SalesReport.ItemName = rdr["Name"].ToString();
                    SalesReport.SalesPrice = rdr["Salesprice"].ToString();
                    SalesReport.Qty = rdr["Qty"].ToString();
                    SalesReport.Division = rdr["Division"].ToString();
                    SalesReport.Region = rdr["Region"].ToString();

                    listSalesReport.Add(SalesReport);
                }
            }
            return listSalesReport;
        }


        public static int GetTotalCount()
        {
            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(@"
SELECT
count(*)
 FROM  CUSTINVOICEJOUR, CUSTINVOICETRANS
WHERE  CUSTINVOICEJOUR.SALESID = CUSTINVOICETRANS.SALESID
AND CUSTINVOICEJOUR.INVOICEID = CUSTINVOICETRANS.INVOICEID
AND CUSTINVOICEJOUR.INVOICEDATE = CUSTINVOICETRANS.INVOICEDATE
and CUSTINVOICEJOUR.INVOICEACCOUNT != 'CUS003345'
and CUSTINVOICEJOUR.INVOICEACCOUNT != 'CUS003346'
--AND CUSTINVOICETRANS.SALESQTY != CUSTINVOICETRANS.QTY
--AND CUSTINVOICETRANS.ITEMID = 'ITM000054'
--AND MONTH(CUSTINVOICEJOUR.INVOICEDATE) = 5
and CUSTINVOICETRANS.ITEMID != ''

--and CUSTINVOICEJOUR.INVOICEDATE >= '1/1/2017'", con);

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }


    }


}





