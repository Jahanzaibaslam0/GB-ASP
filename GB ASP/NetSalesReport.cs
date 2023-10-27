using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using GB_ASP;

namespace GB_ASP
{
        public class SalesReport1
        {

        public string Productcode { get; set; }
        public string ProductName { get; set; }
        public string CustGroup { get; set; }
        public string DataareaID { get; set; }
        public string Qty { get; set; }
        public string Itemid { get; set; }
        public string ItemName { get; set; }
        public string SalesPrice { get; set; }
        public string SalesUnit { get; set; }
        public string Division { get; set; }
        public string Region { get; set; }
            }



}


    public class NetSalesReport
    {

        public static List<GB_ASP.SalesReport1> SalesReport(int startRowIndex, int maximumRows)
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
            //parmProduct.Value = 
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
            con.Close();
            con.Dispose();
        }
        }
    }


