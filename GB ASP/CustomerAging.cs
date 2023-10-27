using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class CustomerAgingList
    {
        public string SerialNo { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Branch { get; set; }
        public string InvoiceID { get; set; }
        public string InvoiceDate{ get; set; }
        public string DueDate { get; set; }
        public string Division { get; set; }
        public string Region { get; set; }
        public string InvoiceAmount { get; set; }
        public string PaymentReceived { get; set; }
        public string NotDueAmount { get; set; }

        public string Zero_Fifteen { get; set; }
        public string Sixteen_Thirty { get; set; }
        public string ThirtyOne_Sixty { get; set; }
        public string SixtyOne_Ninety { get; set; }
        public string OverNinety { get; set; }
        public string LastPayment { get; set; }
        public string LastPaymentDate { get; set; }
    }

    public class CustomerAging
    {
        public static List<CustomerAgingList> GetCustomerAging(int pageIndex, int pageSize, string StartDate, string EndDate, string CustomerID,string CustomerName, string Group, string Division, string Region, string Employee, string Branch, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustomerAgingList> listCustAging = new List<CustomerAgingList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustomerAging2", con);
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


                SqlParameter paramCustGroup = new SqlParameter();
                paramCustGroup.ParameterName = "@Group";
                paramCustGroup.Value = Group;
                cmd.Parameters.Add(paramCustGroup);


                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramEmployee = new SqlParameter();
                paramEmployee.ParameterName = "@Employee";
                paramEmployee.Value = Employee;
                cmd.Parameters.Add(paramEmployee);

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@DealForBranch";
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
                    CustomerAgingList CustAging = new CustomerAgingList();

                    CustAging.SerialNo = rdr["RowNumber"].ToString();
                    CustAging.CustomerID = rdr["accountnum"].ToString();
                    CustAging.CustomerName = rdr["CustomerName"].ToString();
                    CustAging.Branch = rdr["DealForBranch"].ToString();
                    CustAging.InvoiceID = rdr["InvoiceID"].ToString();
                    CustAging.InvoiceDate = rdr["InvoiceDate"].ToString();
                    CustAging.DueDate = rdr["DUEDATE"].ToString();
                    CustAging.Division = rdr["Division"].ToString();
                    CustAging.Region = rdr["Region"].ToString();
                    CustAging.InvoiceAmount = rdr["OriginalAmount"].ToString();
                    CustAging.PaymentReceived = rdr["PaymentReceived"].ToString();
                    CustAging.NotDueAmount = rdr["NotDueAmount"].ToString();
                    CustAging.Zero_Fifteen = rdr["DueFifteen"].ToString();
                    CustAging.Sixteen_Thirty = rdr["Duethirty"].ToString();
                    CustAging.ThirtyOne_Sixty = rdr["DueSixty"].ToString();
                    CustAging.SixtyOne_Ninety = rdr["Dueninety"].ToString();
                    CustAging.OverNinety = rdr["Dueoverninety"].ToString();
                    CustAging.LastPayment = rdr["LastPayment"].ToString();
                    CustAging.LastPaymentDate = rdr["LastPaymentDate"].ToString();



                    listCustAging.Add(CustAging);
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
            return listCustAging;
        }
    }

    public class CustomerAging2
    {
        public static List<CustomerAgingList> GetCustomerAging(int pageIndex, int pageSize, string StartDate, string EndDate, string CustomerID, string Group, string Division, string Region, string Employee, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustomerAgingList> listCustAging = new List<CustomerAgingList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustomerAging2", con);
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


                SqlParameter paramCustGroup = new SqlParameter();
                paramCustGroup.ParameterName = "@Group";
                paramCustGroup.Value = Group;
                cmd.Parameters.Add(paramCustGroup);


                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramEmployee = new SqlParameter();
                paramEmployee.ParameterName = "@Employee";
                paramEmployee.Value = Employee;
                cmd.Parameters.Add(paramEmployee);

                

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
                    CustomerAgingList CustAging = new CustomerAgingList();

                    CustAging.SerialNo = rdr["RowNumber"].ToString();
                    CustAging.CustomerID = rdr["accountnum"].ToString();
                    CustAging.CustomerName = rdr["CustomerName"].ToString();
                    CustAging.Branch = rdr["DealForBranch"].ToString();
                    CustAging.InvoiceID = rdr["InvoiceID"].ToString();
                    CustAging.InvoiceDate = rdr["InvoiceDate"].ToString();
                    CustAging.DueDate = rdr["DUEDATE"].ToString();
                    CustAging.Division = rdr["Division"].ToString();
                    CustAging.Region = rdr["Region"].ToString();
                    CustAging.InvoiceAmount = rdr["OriginalAmount"].ToString();
                    CustAging.PaymentReceived = rdr["PaymentReceived"].ToString();
                    CustAging.NotDueAmount = rdr["NotDueAmount"].ToString();
                    CustAging.Zero_Fifteen = rdr["DueFifteen"].ToString();
                    CustAging.Sixteen_Thirty = rdr["Duethirty"].ToString();
                    CustAging.ThirtyOne_Sixty = rdr["DueSixty"].ToString();
                    CustAging.SixtyOne_Ninety = rdr["Dueninety"].ToString();
                    CustAging.OverNinety = rdr["Dueoverninety"].ToString();
                    CustAging.LastPayment = rdr["LastPayment"].ToString();
                    CustAging.LastPaymentDate = rdr["LastPaymentDate"].ToString();



                    listCustAging.Add(CustAging);
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
            return listCustAging;
        }
    }
}