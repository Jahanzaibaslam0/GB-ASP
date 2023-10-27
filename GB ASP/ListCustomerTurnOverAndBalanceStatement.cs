using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class CustomerTurnOverAndBalanceStatementList
    {
        public string S_No { get; set; }
      
        public string Customer_ID { get; set; }

        public string Customer_Name { get; set; }
        public string Deal_For_Branch { get; set; }
        public string Group { get; set; }
        public string Opening { get; set; }  
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Transaction_During_Period { get; set; }
        public string Closing { get; set; }

    }
    public class ListCustomerTurnOverAndBalanceStatement
    {

        public static List<CustomerTurnOverAndBalanceStatementList> GetCustomerTurnOverAndBalanceList (int pageIndex, int pageSize, string CustomerID, string CustomerName, string startDate, string EndDate, string Branch  , string Division, string Group, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustomerTurnOverAndBalanceStatementList> listCustomerTurnOverBalance = new List<CustomerTurnOverAndBalanceStatementList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustomerBalanceList", con);
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
                paramCustName.Value = CustomerName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@Branch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);

                SqlParameter paramGroup = new SqlParameter();
                paramGroup.ParameterName = "@Group";
                paramGroup.Value = Group;
                cmd.Parameters.Add(paramGroup);

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = startDate;
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
                    CustomerTurnOverAndBalanceStatementList CustomerBalanceStatement = new CustomerTurnOverAndBalanceStatementList();

                    CustomerBalanceStatement.Opening = rdr["Opening"].ToString();
                    CustomerBalanceStatement.Debit = rdr["Debit"].ToString();
                    CustomerBalanceStatement.Credit = rdr["Credit"].ToString();
                    CustomerBalanceStatement.Transaction_During_Period = rdr["DuringThePeriodTransaction"].ToString();
                    CustomerBalanceStatement.Closing = rdr["Ending"].ToString();
                    CustomerBalanceStatement.S_No = rdr["RowNumber"].ToString();
                    CustomerBalanceStatement.Customer_ID = rdr["accountnum"].ToString();
                    CustomerBalanceStatement.Customer_Name = rdr["CustomerName"].ToString();
                    CustomerBalanceStatement.Group = rdr["CustGroup"].ToString();
                    CustomerBalanceStatement.Deal_For_Branch = rdr["Branch"].ToString();
                    

                    listCustomerTurnOverBalance.Add(CustomerBalanceStatement);
                }

                rdr.Close();
                //totalRows = (int)cmd.Parameters["@TotalRows"].Value;
                //con.Close();
                //con.Dispose();
                try
                {
                    totalRows = (int)cmd.Parameters["@TotalRows"].Value;
                }
                catch
                {
                    totalRows = 1;
                }
            }
            return listCustomerTurnOverBalance;
        }
    }


    public class ListCustomerTurnOverAndBalanceStatement2
    {

        public static List<CustomerTurnOverAndBalanceStatementList> GetCustomerTurnOverAndBalanceList(int pageIndex, int pageSize, string CustomerID, string CustomerName, string startDate, string EndDate, string Division, string Group, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustomerTurnOverAndBalanceStatementList> listCustomerTurnOverBalance = new List<CustomerTurnOverAndBalanceStatementList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustomerTurnOverAndBalanceReport2", con);
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
                paramCustName.Value = CustomerName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@Branch";
                //paramBranch.Value = Branch;
                //cmd.Parameters.Add(paramBranch);

                SqlParameter paramGroup = new SqlParameter();
                paramGroup.ParameterName = "@Group";
                paramGroup.Value = Group;
                cmd.Parameters.Add(paramGroup);

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = startDate;
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
                    CustomerTurnOverAndBalanceStatementList CustomerBalanceStatement = new CustomerTurnOverAndBalanceStatementList();

                    CustomerBalanceStatement.S_No = rdr["RowNumber"].ToString();
                    CustomerBalanceStatement.Customer_ID = rdr["accountnum"].ToString();
                    CustomerBalanceStatement.Customer_Name = rdr["CustomerName"].ToString();
                    CustomerBalanceStatement.Group = rdr["CustGroup"].ToString();
                    CustomerBalanceStatement.Deal_For_Branch = rdr["Branch"].ToString();
                    CustomerBalanceStatement.Opening = rdr["Opening"].ToString();
                    CustomerBalanceStatement.Debit = rdr["Debit"].ToString();
                    CustomerBalanceStatement.Credit = rdr["Credit"].ToString();
                    CustomerBalanceStatement.Transaction_During_Period = rdr["DuringThePeriodTransaction"].ToString();
                    CustomerBalanceStatement.Closing = rdr["Ending"].ToString();

                    listCustomerTurnOverBalance.Add(CustomerBalanceStatement);
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
            return listCustomerTurnOverBalance;
        }
    }
}