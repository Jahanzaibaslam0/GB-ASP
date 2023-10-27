using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class CustomerWiseSalesAmountList
    {
        public string S_NO { get; set; }
        public string CUSTOMER_ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string ITEM_ID { get; set; }
        public string ITEM_NAME { get; set; }
        //public string SALESUNIT { get; set; }
        //public string INVOICEDATE { get; set; }
        public string DIVISION { get; set; }
        public string REGION { get; set; }
        public string REVENUE { get; set; }

    }
    public class CustomerWiseSalesAmount
    {
        public static List<CustomerWiseSalesAmountList> GetCustomerWiseSalesAmount(int pageIndex, int pageSize, string startDate, string EndDate, string CustomeID, string CustName, string Itemid, string itemName, string Region, string Division, string Branch, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustomerWiseSalesAmountList> listCustomerWiseSalesAmount = new List<CustomerWiseSalesAmountList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustomerWiseSalesAmount", con);
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

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = startDate;
                cmd.Parameters.Add(paramStartInvoiceDate);

                SqlParameter paramEndInvoiceDate = new SqlParameter();
                paramEndInvoiceDate.ParameterName = "@EndDate";
                paramEndInvoiceDate.Value = EndDate;
                cmd.Parameters.Add(paramEndInvoiceDate);


                SqlParameter paramCustID = new SqlParameter();
                paramCustID.ParameterName = "@Customer";
                paramCustID.Value = CustomeID;
                cmd.Parameters.Add(paramCustID);


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramItemID = new SqlParameter();
                paramItemID.ParameterName = "@ItemID";
                paramItemID.Value = Itemid;
                cmd.Parameters.Add(paramItemID);


                SqlParameter paramItemName = new SqlParameter();
                paramItemName.ParameterName = "@ItemName";
                paramItemName.Value = itemName;
                cmd.Parameters.Add(paramItemName);

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@Branch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);



                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CustomerWiseSalesAmountList CustomerWiseSalesAmount = new CustomerWiseSalesAmountList();

                    CustomerWiseSalesAmount.S_NO = rdr["RowNumber"].ToString();
                    //DivisionWiseBalance.COMPANY = rdr["DATAAREAID"].ToString();
                    CustomerWiseSalesAmount.ITEM_ID = rdr["ITEMID"].ToString();
                    CustomerWiseSalesAmount.ITEM_NAME = rdr["ITEMNAME"].ToString();

                    CustomerWiseSalesAmount.CUSTOMER_ID = rdr["CUSTOMERACCOUNT"].ToString();
                    CustomerWiseSalesAmount.CUSTOMER_NAME = rdr["CUSTOMERNAME"].ToString();
                    //CustomerWiseSalesAmount.SALESUNIT = rdr["SALESUNIT"].ToString();
                    CustomerWiseSalesAmount.DIVISION = rdr["DIVISION"].ToString();
                    CustomerWiseSalesAmount.REGION = rdr["REGION"].ToString();
                    //CustomerWiseSalesAmount.INVOICEDATE = rdr["INVOICEDATE"].ToString();
                    CustomerWiseSalesAmount.REVENUE = rdr["REVENUE"].ToString();

                    listCustomerWiseSalesAmount.Add(CustomerWiseSalesAmount);
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
            return listCustomerWiseSalesAmount;
        }


    }

    public class CustomerWiseSalesAmountSindh
    {
        public static List<CustomerWiseSalesAmountList> GetCustomerWiseSalesAmount(int pageIndex, int pageSize, string startDate, string EndDate, string CustomeID, string CustName, string Itemid, string itemName, string Region, string Division, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustomerWiseSalesAmountList> listCustomerWiseSalesAmount = new List<CustomerWiseSalesAmountList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustomerWiseSalesAmount2", con);
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

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = startDate;
                cmd.Parameters.Add(paramStartInvoiceDate);

                SqlParameter paramEndInvoiceDate = new SqlParameter();
                paramEndInvoiceDate.ParameterName = "@EndDate";
                paramEndInvoiceDate.Value = EndDate;
                cmd.Parameters.Add(paramEndInvoiceDate);


                SqlParameter paramCustID = new SqlParameter();
                paramCustID.ParameterName = "@Customer";
                paramCustID.Value = CustomeID;
                cmd.Parameters.Add(paramCustID);


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramItemID = new SqlParameter();
                paramItemID.ParameterName = "@ItemID";
                paramItemID.Value = Itemid;
                cmd.Parameters.Add(paramItemID);


                SqlParameter paramItemName = new SqlParameter();
                paramItemName.ParameterName = "@ItemName";
                paramItemName.Value = itemName;
                cmd.Parameters.Add(paramItemName);

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@Branch";
                //paramBranch.Value = Branch;
                //cmd.Parameters.Add(paramBranch);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);



                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CustomerWiseSalesAmountList CustomerWiseSalesAmount = new CustomerWiseSalesAmountList();

                    CustomerWiseSalesAmount.S_NO = rdr["RowNumber"].ToString();
                    //DivisionWiseBalance.COMPANY = rdr["DATAAREAID"].ToString();
                    CustomerWiseSalesAmount.ITEM_ID = rdr["ITEMID"].ToString();
                    CustomerWiseSalesAmount.ITEM_NAME = rdr["ITEMNAME"].ToString();

                    CustomerWiseSalesAmount.CUSTOMER_ID = rdr["CUSTOMERACCOUNT"].ToString();
                    CustomerWiseSalesAmount.CUSTOMER_NAME = rdr["CUSTOMERNAME"].ToString();
                    //CustomerWiseSalesAmount.SALESUNIT = rdr["SALESUNIT"].ToString();
                    CustomerWiseSalesAmount.DIVISION = rdr["DIVISION"].ToString();
                    CustomerWiseSalesAmount.REGION = rdr["REGION"].ToString();
                    //CustomerWiseSalesAmount.INVOICEDATE = rdr["INVOICEDATE"].ToString();
                    CustomerWiseSalesAmount.REVENUE = rdr["REVENUE"].ToString();

                    listCustomerWiseSalesAmount.Add(CustomerWiseSalesAmount);
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
            return listCustomerWiseSalesAmount;
        }


    }
    public class CustomerWiseSalesAmount2
    {
        public static List<CustomerWiseSalesAmountList> GetCustomerWiseSalesAmount(int pageIndex, int pageSize, string startDate, string EndDate, string CustomeID, string CustName, string Itemid, string itemName, string Region, string Division, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustomerWiseSalesAmountList> listCustomerWiseSalesAmount = new List<CustomerWiseSalesAmountList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustomerWiseSalesAmount2", con);
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

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = startDate;
                cmd.Parameters.Add(paramStartInvoiceDate);

                SqlParameter paramEndInvoiceDate = new SqlParameter();
                paramEndInvoiceDate.ParameterName = "@EndDate";
                paramEndInvoiceDate.Value = EndDate;
                cmd.Parameters.Add(paramEndInvoiceDate);


                SqlParameter paramCustID = new SqlParameter();
                paramCustID.ParameterName = "@Customer";
                paramCustID.Value = CustomeID;
                cmd.Parameters.Add(paramCustID);


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramItemID = new SqlParameter();
                paramItemID.ParameterName = "@ItemID";
                paramItemID.Value = Itemid;
                cmd.Parameters.Add(paramItemID);


                SqlParameter paramItemName = new SqlParameter();
                paramItemName.ParameterName = "@ItemName";
                paramItemName.Value = itemName;
                cmd.Parameters.Add(paramItemName);

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@Branch";
                //paramBranch.Value = Branch;
                //cmd.Parameters.Add(paramBranch);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);



                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CustomerWiseSalesAmountList CustomerWiseSalesAmount = new CustomerWiseSalesAmountList();

                    CustomerWiseSalesAmount.S_NO = rdr["RowNumber"].ToString();
                    //DivisionWiseBalance.COMPANY = rdr["DATAAREAID"].ToString();
                    CustomerWiseSalesAmount.ITEM_ID = rdr["ITEMID"].ToString();
                    CustomerWiseSalesAmount.ITEM_NAME = rdr["ITEMNAME"].ToString();

                    CustomerWiseSalesAmount.CUSTOMER_ID = rdr["CUSTOMERACCOUNT"].ToString();
                    CustomerWiseSalesAmount.CUSTOMER_NAME = rdr["CUSTOMERNAME"].ToString();
                    //CustomerWiseSalesAmount.SALESUNIT = rdr["SALESUNIT"].ToString();
                    CustomerWiseSalesAmount.DIVISION = rdr["DIVISION"].ToString();
                    CustomerWiseSalesAmount.REGION = rdr["REGION"].ToString();
                    //CustomerWiseSalesAmount.INVOICEDATE = rdr["INVOICEDATE"].ToString();
                    CustomerWiseSalesAmount.REVENUE = rdr["REVENUE"].ToString();

                    listCustomerWiseSalesAmount.Add(CustomerWiseSalesAmount);
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
            return listCustomerWiseSalesAmount;
        }


    }
}