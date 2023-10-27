using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class SalesReportInvoiceWiseList
    {
        public string S_No { get; set; }
        public string INVOICEDATE { get; set; }
        public string INVOICEID { get; set; }

        public string SALESID { get; set; }



        public string CUSTOMER_ID { get; set; }
        public string CUSTOMERR_NAME { get; set; }
        public string GROUP { get; set; }
        public string DEALFORBRANCH { get; set; }

        public string ITEMID { get; set; }
        public string ITEMNAME { get; set; }

        public string CURRENCY { get; set; }
        public string BATCH { get; set; }
        public string SITE { get; set; }
        public string WAREHOUSE { get; set; }
        public string SALESUNIT { get; set; }

        public string SALES_QTY { get; set; }
        public string UNIT_PRICE { get; set; }
        public string REVENUE { get; set; }
        public string DISCOUNT_AMOUNT { get; set; }
        public string AMOUNT { get; set; }
        public string LOCATION { get; set; }
        public string SALES_TAKER { get; set; }
        public string DIVISION { get; set; }
        public string REGION { get; set; }
        
    }
    public class ListSalesReportInvoiceWise
    {
        public static List<SalesReportInvoiceWiseList> GetSalesReportInvoiceWise(int pageIndex, int pageSize, string StartDate, string EndDate, string Employee, string CustomerID, string CustomerName, string Branch, string Division, string Region, string InvoiceID,  string SalesID, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<SalesReportInvoiceWiseList> listSalesReportInvoice = new List<SalesReportInvoiceWiseList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SalesReportinvoiceWise", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 240;
                SqlParameter paramStartIndex = new SqlParameter();
                paramStartIndex.ParameterName = "@PageIndex";
                paramStartIndex.Value = pageIndex;
                cmd.Parameters.Add(paramStartIndex);

                SqlParameter paramMaximumRows = new SqlParameter();
                paramMaximumRows.ParameterName = "@PageSize";
                paramMaximumRows.Value = pageSize;
                cmd.Parameters.Add(paramMaximumRows);

                SqlParameter paramCustomerCode = new SqlParameter();
                paramCustomerCode.ParameterName = "@Customer";
                paramCustomerCode.Value = CustomerID;
                cmd.Parameters.Add(paramCustomerCode);

                SqlParameter paramCustomerName = new SqlParameter();
                paramCustomerName.ParameterName = "@CustName";
                paramCustomerName.Value = CustomerName;
                cmd.Parameters.Add(paramCustomerName);


                SqlParameter paramStatus = new SqlParameter();
                paramStatus.ParameterName = "@Region";
                paramStatus.Value = Region;
                cmd.Parameters.Add(paramStatus);


                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramSalesID = new SqlParameter();
                paramSalesID.ParameterName = "@SalesID";
                paramSalesID.Value = SalesID;
                cmd.Parameters.Add(paramSalesID);

                SqlParameter paramEmployee = new SqlParameter();
                paramEmployee.ParameterName = "@Employee";
                paramEmployee.Value = Employee;
                cmd.Parameters.Add(paramEmployee);

                SqlParameter paramInvoice= new SqlParameter();
                paramInvoice.ParameterName = "@Invoice";
                paramInvoice.Value = InvoiceID;
                cmd.Parameters.Add(paramInvoice);

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@Branch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = StartDate;
                cmd.Parameters.Add(paramStartInvoiceDate);

                SqlParameter paramEndInvoiceDate = new SqlParameter();
                paramEndInvoiceDate.ParameterName = "@EndDate";
                paramEndInvoiceDate.Value = EndDate;
                cmd.Parameters.Add(paramEndInvoiceDate);


                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SalesReportInvoiceWiseList SalesInvoiceWise = new SalesReportInvoiceWiseList();

                    SalesInvoiceWise.S_No = rdr["RowNumber"].ToString();
                    SalesInvoiceWise.INVOICEDATE = rdr["INVOICEDATE"].ToString();
                    SalesInvoiceWise.INVOICEID = rdr["INVOICEID"].ToString();
                    SalesInvoiceWise.SALESID = rdr["SALESID"].ToString();
                    SalesInvoiceWise.CUSTOMER_ID = rdr["INVOICEACCOUNT"].ToString();
                    SalesInvoiceWise.CUSTOMERR_NAME = rdr["CUSTOMER NAME"].ToString();
                    SalesInvoiceWise.GROUP = rdr["CUSTGROUP"].ToString();
                    SalesInvoiceWise.DEALFORBRANCH = rdr["DEALFORBRANCH"].ToString();
                    SalesInvoiceWise.ITEMID = rdr["ITEMID"].ToString();
                    SalesInvoiceWise.ITEMNAME = rdr["ITEMNAME"].ToString();
                    SalesInvoiceWise.CURRENCY = rdr["CURRENCYCODE"].ToString();
                    SalesInvoiceWise.BATCH = rdr["BATCH"].ToString();
                    SalesInvoiceWise.SITE = rdr["SITE"].ToString();
                    SalesInvoiceWise.WAREHOUSE = rdr["WAREHOUSE"].ToString();
                    SalesInvoiceWise.SALESUNIT = rdr["SALESUNIT"].ToString();
                    SalesInvoiceWise.SALES_QTY = rdr["SALESQTY"].ToString();
                    SalesInvoiceWise.UNIT_PRICE = rdr["SALESPRICE"].ToString();
                    SalesInvoiceWise.REVENUE = rdr["REVENUE"].ToString();
                    SalesInvoiceWise.DISCOUNT_AMOUNT = rdr["DISCOUNT AMOUNT"].ToString();
                    SalesInvoiceWise.AMOUNT = rdr["AMOUNT"].ToString();
                    SalesInvoiceWise.LOCATION = rdr["LOCATION"].ToString();
                    SalesInvoiceWise.SALES_TAKER = rdr["SALESTAKER"].ToString();
                    SalesInvoiceWise.DIVISION = rdr["DIVISION"].ToString();
                    SalesInvoiceWise.REGION = rdr["REGION"].ToString();


                    listSalesReportInvoice.Add(SalesInvoiceWise);
                }

                rdr.Close();
                try
                {
                    totalRows = (int)cmd.Parameters["@TotalRows"].Value;
                }
                catch
                {
                    totalRows = 1;
                }
                con.Close();
                con.Dispose();
            }
            return listSalesReportInvoice;
        }
    }


    public class ListSalesReportInvoiceWise2
    {
        public static List<SalesReportInvoiceWiseList> GetSalesReportInvoiceWise(int pageIndex, int pageSize, string StartDate, string EndDate, string Employee, string CustomerID, string CustomerName, string Division, string Region, string InvoiceID, string SalesID, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<SalesReportInvoiceWiseList> listSalesReportInvoice = new List<SalesReportInvoiceWiseList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SalesReportinvoiceWise2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 240;
                SqlParameter paramStartIndex = new SqlParameter();
                paramStartIndex.ParameterName = "@PageIndex";
                paramStartIndex.Value = pageIndex;
                cmd.Parameters.Add(paramStartIndex);

                SqlParameter paramMaximumRows = new SqlParameter();
                paramMaximumRows.ParameterName = "@PageSize";
                paramMaximumRows.Value = pageSize;
                cmd.Parameters.Add(paramMaximumRows);

                SqlParameter paramCustomerCode = new SqlParameter();
                paramCustomerCode.ParameterName = "@Customer";
                paramCustomerCode.Value = CustomerID;
                cmd.Parameters.Add(paramCustomerCode);

                SqlParameter paramCustomerName = new SqlParameter();
                paramCustomerName.ParameterName = "@CustName";
                paramCustomerName.Value = CustomerName;
                cmd.Parameters.Add(paramCustomerName);


                SqlParameter paramStatus = new SqlParameter();
                paramStatus.ParameterName = "@Region";
                paramStatus.Value = Region;
                cmd.Parameters.Add(paramStatus);


                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramSalesID = new SqlParameter();
                paramSalesID.ParameterName = "@SalesID";
                paramSalesID.Value = SalesID;
                cmd.Parameters.Add(paramSalesID);

                SqlParameter paramEmployee = new SqlParameter();
                paramEmployee.ParameterName = "@Employee";
                paramEmployee.Value = Employee;
                cmd.Parameters.Add(paramEmployee);

                SqlParameter paramInvoice = new SqlParameter();
                paramInvoice.ParameterName = "@Invoice";
                paramInvoice.Value = InvoiceID;
                cmd.Parameters.Add(paramInvoice);

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@Branch";
                //paramBranch.Value = Branch;
                //cmd.Parameters.Add(paramBranch);

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = StartDate;
                cmd.Parameters.Add(paramStartInvoiceDate);

                SqlParameter paramEndInvoiceDate = new SqlParameter();
                paramEndInvoiceDate.ParameterName = "@EndDate";
                paramEndInvoiceDate.Value = EndDate;
                cmd.Parameters.Add(paramEndInvoiceDate);


                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SalesReportInvoiceWiseList SalesInvoiceWise = new SalesReportInvoiceWiseList();

                    SalesInvoiceWise.S_No = rdr["RowNumber"].ToString();
                    SalesInvoiceWise.INVOICEDATE = rdr["INVOICEDATE"].ToString();
                    SalesInvoiceWise.INVOICEID = rdr["INVOICEID"].ToString();
                    SalesInvoiceWise.SALESID = rdr["SALESID"].ToString();
                    SalesInvoiceWise.CUSTOMER_ID = rdr["INVOICEACCOUNT"].ToString();
                    SalesInvoiceWise.CUSTOMERR_NAME = rdr["CUSTOMER NAME"].ToString();
                    SalesInvoiceWise.GROUP = rdr["CUSTGROUP"].ToString();
                    SalesInvoiceWise.DEALFORBRANCH = rdr["DEALFORBRANCH"].ToString();
                    SalesInvoiceWise.ITEMID = rdr["ITEMID"].ToString();
                    SalesInvoiceWise.CURRENCY = rdr["CURRENCYCODE"].ToString();
                    SalesInvoiceWise.BATCH = rdr["BATCH"].ToString();
                    SalesInvoiceWise.SITE = rdr["SITE"].ToString();
                    SalesInvoiceWise.WAREHOUSE = rdr["WAREHOUSE"].ToString();
                    SalesInvoiceWise.SALESUNIT = rdr["SALESUNIT"].ToString();
                    SalesInvoiceWise.SALES_QTY = rdr["SALESQTY"].ToString();
                    SalesInvoiceWise.UNIT_PRICE = rdr["SALESPRICE"].ToString();
                    SalesInvoiceWise.REVENUE = rdr["REVENUE"].ToString();
                    SalesInvoiceWise.DISCOUNT_AMOUNT = rdr["DISCOUNT AMOUNT"].ToString();
                    SalesInvoiceWise.AMOUNT = rdr["AMOUNT"].ToString();
                    SalesInvoiceWise.LOCATION = rdr["LOCATION"].ToString();
                    SalesInvoiceWise.SALES_TAKER = rdr["SALESTAKER"].ToString();
                    SalesInvoiceWise.DIVISION = rdr["DIVISION"].ToString();
                    SalesInvoiceWise.REGION = rdr["REGION"].ToString();


                    listSalesReportInvoice.Add(SalesInvoiceWise);
                }

                rdr.Close();
                try
                {
                    totalRows = (int)cmd.Parameters["@TotalRows"].Value;
                }
                catch
                {
                    totalRows = 1;
                }
                con.Close();
                con.Dispose();
            }
            return listSalesReportInvoice;
        }
    }
}