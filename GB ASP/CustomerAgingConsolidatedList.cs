using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class CustAgingConsolidatedList
    {
        public string SerialNo { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceAmount { get; set; }
        public string PaymentReceived { get; set; }
        public string NotDueAmount { get; set; }
        public string DueAmount { get; set; }
        public string DueFifteen { get; set; }
        public string DueThirty{ get; set; }
        public string DueSixty { get; set; }
        public string DueNinety { get; set; }
        public string DueOverNinety { get; set; }



    }
    public class CustomerAgingConsolidatedList
    {

        public static List<CustAgingConsolidatedList> GetCustomerAgingConsolidated(int pageIndex, int pageSize,string CustomerID,string CustName,string Branch, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustAgingConsolidatedList> listCustAgingConsolidated = new List<CustAgingConsolidatedList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustomerAgingConsolidated", con);
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


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustName;
                cmd.Parameters.Add(paramCustName);

                
                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@DealForBranch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);

                //SqlParameter paramStartInvoiceDate = new SqlParameter();
                //paramStartInvoiceDate.ParameterName = "@StartDate";
                //paramStartInvoiceDate.Value = StartDate;
                //cmd.Parameters.Add(paramStartInvoiceDate);

                //SqlParameter paramEndInvoiceDate = new SqlParameter();
                //paramEndInvoiceDate.ParameterName = "@EndDate";
                //paramEndInvoiceDate.Value = EndDate;
                //cmd.Parameters.Add(paramEndInvoiceDate);


                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CustAgingConsolidatedList CustAgingConsolidated = new CustAgingConsolidatedList();

                    CustAgingConsolidated.SerialNo = rdr["RowNumber"].ToString();
                    CustAgingConsolidated.CustomerID = rdr["accountnum"].ToString();
                    CustAgingConsolidated.CustomerName = rdr["CustomerName"].ToString();
                    CustAgingConsolidated.InvoiceAmount = rdr["InvoiceAmount"].ToString();
                    CustAgingConsolidated.PaymentReceived = rdr["PaymentReceived"].ToString();
                    CustAgingConsolidated.DueAmount = rdr["DueAmount"].ToString();
                    CustAgingConsolidated.NotDueAmount = rdr["NotDueAmount"].ToString();
                    CustAgingConsolidated.DueFifteen = rdr["DueFifteen"].ToString();
                    CustAgingConsolidated.DueThirty = rdr["DueThirty"].ToString();
                    CustAgingConsolidated.DueSixty = rdr["DueSixty"].ToString();
                    CustAgingConsolidated.DueNinety = rdr["Dueninety"].ToString();
                    CustAgingConsolidated.DueOverNinety = rdr["DueOverninety"].ToString();
                    
                    listCustAgingConsolidated.Add(CustAgingConsolidated);
                 
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
            return listCustAgingConsolidated;
        }

    }


    public class CustomerAgingConsolidatedList2
    {

        public static List<CustAgingConsolidatedList> GetCustomerAgingConsolidated(int pageIndex, int pageSize, string CustomerID, string CustName, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustAgingConsolidatedList> listCustAgingConsolidated = new List<CustAgingConsolidatedList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustAgingConsolidated2", con);
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


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustName;
                cmd.Parameters.Add(paramCustName);


                //SqlParameter paramDivision = new SqlParameter();
                //paramDivision.ParameterName = "@Division";
                //paramDivision.Value = Division;
                //cmd.Parameters.Add(paramDivision);

                //SqlParameter paramRegion = new SqlParameter();
                //paramRegion.ParameterName = "@Region";
                //paramRegion.Value = Region;
                //cmd.Parameters.Add(paramRegion);

                //SqlParameter paramEmployee = new SqlParameter();
                //paramEmployee.ParameterName = "@Employee";
                //paramEmployee.Value = Employee;
                //cmd.Parameters.Add(paramEmployee);

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@DealForBranch";
                //paramBranch.Value = Branch;
                //cmd.Parameters.Add(paramBranch);

                //SqlParameter paramStartInvoiceDate = new SqlParameter();
                //paramStartInvoiceDate.ParameterName = "@StartDate";
                //paramStartInvoiceDate.Value = StartDate;
                //cmd.Parameters.Add(paramStartInvoiceDate);

                //SqlParameter paramEndInvoiceDate = new SqlParameter();
                //paramEndInvoiceDate.ParameterName = "@EndDate";
                //paramEndInvoiceDate.Value = EndDate;
                //cmd.Parameters.Add(paramEndInvoiceDate);


                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CustAgingConsolidatedList CustAgingConsolidated = new CustAgingConsolidatedList();

                    CustAgingConsolidated.SerialNo = rdr["RowNumber"].ToString();
                    CustAgingConsolidated.CustomerID = rdr["accountnum"].ToString();
                    CustAgingConsolidated.CustomerName = rdr["CustomerName"].ToString();
                    CustAgingConsolidated.InvoiceAmount = rdr["InvoiceAmount"].ToString();
                    CustAgingConsolidated.PaymentReceived = rdr["PaymentReceived"].ToString();
                    CustAgingConsolidated.DueAmount = rdr["DueAmount"].ToString();
                    CustAgingConsolidated.NotDueAmount = rdr["NotDueAmount"].ToString();
                    

                    listCustAgingConsolidated.Add(CustAgingConsolidated);

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
            return listCustAgingConsolidated;
        }

    }
}