using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class InternalAccountStatementList1
    {
        public string S_No { get; set; }
        public string Customer_ID { get; set; }
        public string Customer_Name { get; set; }
       
        public string Opening { get; set; }       
        public string Date { get; set; }
        
        public string DueDate { get; set; }
        public string Invoice { get; set; }
        public string Voucher { get; set; }
        
       
        public string Amount { get; set; }
       
        //public string RunningTotal { get; set; }
       
        public string Division { get; set; }
    }
    public class InternalAccountStatementList2
    {
        public string S_No { get; set; }
        public string Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Opening { get; set; }
        public string TransDate { get; set; }
       
        public string MATURITYDATE { get; set; }
        public string Voucher { get; set; }
     
        public string Cheque_Number { get; set; }
      
        public string AmountCur { get; set; }
  
        //public string RunningTotal { get; set; }
        public string Division { get; set; }
    }

    public class InternalAccountStatementList3
    {
       // public string S_No { get; set; }
        public string Customer_ID { get; set; }
        public string Customer_Name { get; set; }

        public string FTD { get; set; }
        public string PHD { get; set; }
        public string HHD { get; set; }
        public string SPD { get; set; }
        public string AHD { get; set; }
        public string Closing { get; set; }

    }

    public class InternalAccountStatement
    {
        public static List<InternalAccountStatementList1> GetInternalAccountStatementList1( string CustomerID, string CustomerName, string Division,string Branch, string startDate, string EndDate, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<InternalAccountStatementList1> InternalAccountStatementList = new List<InternalAccountStatementList1>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("InternalAccountStatement", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 480;
                //SqlParameter paramStartIndex = new SqlParameter();
                //paramStartIndex.ParameterName = "@PageIndex";
                //paramStartIndex.Value = pageIndex;
                //cmd.Parameters.Add(paramStartIndex);

                //SqlParameter paramMaximumRows = new SqlParameter();
                //paramMaximumRows.ParameterName = "@PageSize";
                //paramMaximumRows.Value = pageSize;
                //cmd.Parameters.Add(paramMaximumRows);

                SqlParameter paramCustomerCode = new SqlParameter();
                paramCustomerCode.ParameterName = "@Customer";
                paramCustomerCode.Value = CustomerID;
                cmd.Parameters.Add(paramCustomerCode);

                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustomerName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@Branch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                

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
                    InternalAccountStatementList1 AccountStatement = new InternalAccountStatementList1();

                    AccountStatement.S_No = rdr["RowNumber"].ToString();
                    AccountStatement.Customer_ID = rdr["TAccountnum"].ToString();
                    AccountStatement.Customer_Name = rdr["CustomerName"].ToString();
                    AccountStatement.Opening = rdr["TOpening"].ToString();
                    AccountStatement.Date = rdr["TDate"].ToString();
                    AccountStatement.DueDate = rdr["TDueDate"].ToString();
                    AccountStatement.Invoice= rdr["TInvoice"].ToString();
                    AccountStatement.Voucher = rdr["TVoucher"].ToString();
                    AccountStatement.Amount = rdr["TAmount"].ToString();
                    //AccountStatement.RunningTotal = rdr["TRunningTotal"].ToString();
                    AccountStatement.Division = rdr["TDivision"].ToString();

                    InternalAccountStatementList.Add(AccountStatement);
                }

                rdr.Close();
                totalRows = 1;//(int)cmd.Parameters["@TotalRows"].Value;
                con.Close();
                con.Dispose();
            }
            return InternalAccountStatementList;
        }

        public static List<InternalAccountStatementList2> GetInternalAccountStatementList2(string CustomerID,string CustomerName,string Division,string Branch, string startDate, string EndDate, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<InternalAccountStatementList2> InternalAccountStatementList2 = new List<InternalAccountStatementList2>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("InternalAccountStatement1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 480;
                //SqlParameter paramStartIndex = new SqlParameter();
                //paramStartIndex.ParameterName = "@PageIndex";
                //paramStartIndex.Value = pageIndex;
                //cmd.Parameters.Add(paramStartIndex);

                //SqlParameter paramMaximumRows = new SqlParameter();
                //paramMaximumRows.ParameterName = "@PageSize";
                //paramMaximumRows.Value = pageSize;
                //cmd.Parameters.Add(paramMaximumRows);

                SqlParameter paramCustomerCode = new SqlParameter();
                paramCustomerCode.ParameterName = "@Customer";
                paramCustomerCode.Value = CustomerID;
                cmd.Parameters.Add(paramCustomerCode);

                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustomerName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@Branch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@Branch";
                //paramBranch.Value = Division;
                //cmd.Parameters.Add(paramBranch);

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
                    InternalAccountStatementList2 AccountStatement = new InternalAccountStatementList2();

                    AccountStatement.S_No = rdr["RowNumber"].ToString();
                    AccountStatement.Customer_ID = rdr["accountnum"].ToString();
                    AccountStatement.Customer_Name = rdr["CustomerName"].ToString();
                    AccountStatement.TransDate = rdr["TRANSDATE"].ToString();
                    AccountStatement.Opening = rdr["Opening"].ToString();
                    AccountStatement.MATURITYDATE = rdr["MATURITY DATE"].ToString();
                    AccountStatement.Voucher = rdr["VOUCHER"].ToString();
                    AccountStatement.AmountCur = rdr["AMOUNT"].ToString();
                    //AccountStatement.RunningTotal = rdr["RunningTotal"].ToString();
                    AccountStatement.Cheque_Number = rdr["PAYMREFERENCE"].ToString();
                    AccountStatement.Division = rdr["DIVISION"].ToString();

                    InternalAccountStatementList2.Add(AccountStatement);
                }

                rdr.Close();
                totalRows = 1;//(int)cmd.Parameters["@TotalRows"].Value;
                con.Close();
                con.Dispose();
            }
            return InternalAccountStatementList2;
        }

        public static List<InternalAccountStatementList3> GetInternalAccountStatementList3(string CustomerID, string CustomerName, string Division,string Branch, string startDate, string EndDate/*, out int totalRows*/)
        {
            // Replace square brackets with angular brackets
            List<InternalAccountStatementList3> InternalAccountStatementList3 = new List<InternalAccountStatementList3>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PdcBalances1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 480;
                //SqlParameter paramStartIndex = new SqlParameter();
                //paramStartIndex.ParameterName = "@PageIndex";
                //paramStartIndex.Value = pageIndex;
                //cmd.Parameters.Add(paramStartIndex);

                //SqlParameter paramMaximumRows = new SqlParameter();
                //paramMaximumRows.ParameterName = "@PageSize";
                //paramMaximumRows.Value = pageSize;
                //cmd.Parameters.Add(paramMaximumRows);

                SqlParameter paramCustomerCode = new SqlParameter();
                paramCustomerCode.ParameterName = "@Customer";
                paramCustomerCode.Value = CustomerID;
                cmd.Parameters.Add(paramCustomerCode);

                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustomerName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@Branch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@Branch";
                //paramBranch.Value = Division;
                //cmd.Parameters.Add(paramBranch);

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = startDate;
                cmd.Parameters.Add(paramStartInvoiceDate);

                SqlParameter paramEndInvoiceDate = new SqlParameter();
                paramEndInvoiceDate.ParameterName = "@AsOnDate";
                paramEndInvoiceDate.Value = EndDate;
                cmd.Parameters.Add(paramEndInvoiceDate);

                //SqlParameter paramOutputTotalRows = new SqlParameter();
                //paramOutputTotalRows.ParameterName = "@TotalRows";
                //paramOutputTotalRows.Direction = ParameterDirection.Output;
                //paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                //cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    InternalAccountStatementList3 AccountStatement = new InternalAccountStatementList3();

                    //AccountStatement.S_No = rdr["RowNumber"].ToString();
                    AccountStatement.Customer_ID = rdr["ACCOUNTNUM"].ToString();
                    AccountStatement.Customer_Name = rdr["CUSTOMERNAME"].ToString();
                    AccountStatement.FTD = rdr["FTD"].ToString();
                    AccountStatement.PHD = rdr["PHD"].ToString();
                    AccountStatement.SPD = rdr["SPD"].ToString();
                    AccountStatement.AHD = rdr["AHD"].ToString();
                    AccountStatement.HHD = rdr["HHD"].ToString();
                    AccountStatement.Closing = rdr["TOTAL BALANCE"].ToString();
                  
                    InternalAccountStatementList3.Add(AccountStatement);
                }

                rdr.Close();
                // totalRows = 1;//(int)cmd.Parameters["@TotalRows"].Value;
                con.Close();
                con.Dispose();
            }
            return InternalAccountStatementList3;
        }



    }

    public class InternalAccountStatementSindh
    {
        public static List<InternalAccountStatementList1> GetInternalAccountStatementList1(string CustomerID, string CustomerName, string Division, string startDate, string EndDate, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<InternalAccountStatementList1> InternalAccountStatementList = new List<InternalAccountStatementList1>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("InternalAccountStatementSindh", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 240;
                //SqlParameter paramStartIndex = new SqlParameter();
                //paramStartIndex.ParameterName = "@PageIndex";
                //paramStartIndex.Value = pageIndex;
                //cmd.Parameters.Add(paramStartIndex);

                //SqlParameter paramMaximumRows = new SqlParameter();
                //paramMaximumRows.ParameterName = "@PageSize";
                //paramMaximumRows.Value = pageSize;
                //cmd.Parameters.Add(paramMaximumRows);

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
                //paramBranch.Value = Division;
                //cmd.Parameters.Add(paramBranch);

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
                    InternalAccountStatementList1 AccountStatement = new InternalAccountStatementList1();

                    AccountStatement.S_No = rdr["RowNumber"].ToString();
                    AccountStatement.Customer_ID = rdr["TAccountnum"].ToString();
                    AccountStatement.Customer_Name = rdr["CustomerName"].ToString();
                    AccountStatement.Opening = rdr["TOpening"].ToString();
                    AccountStatement.Date = rdr["TDate"].ToString();
                    AccountStatement.DueDate = rdr["TDueDate"].ToString();
                    AccountStatement.Invoice = rdr["TInvoice"].ToString();
                    AccountStatement.Voucher = rdr["TVoucher"].ToString();
                    AccountStatement.Amount = rdr["TAmount"].ToString();
                    //AccountStatement.RunningTotal = rdr["TRunningTotal"].ToString();
                    AccountStatement.Division = rdr["TDivision"].ToString();

                    InternalAccountStatementList.Add(AccountStatement);
                }

                rdr.Close();
                totalRows = 1;//(int)cmd.Parameters["@TotalRows"].Value;
                con.Close();
                con.Dispose();

            }
            return InternalAccountStatementList;
        }

        public static List<InternalAccountStatementList2> GetInternalAccountStatementList2(string CustomerID, string CustomerName, string Division, string startDate, string EndDate, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<InternalAccountStatementList2> InternalAccountStatementList2 = new List<InternalAccountStatementList2>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("InternalAccountStatement1Sindh", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 240;
                //SqlParameter paramStartIndex = new SqlParameter();
                //paramStartIndex.ParameterName = "@PageIndex";
                //paramStartIndex.Value = pageIndex;
                //cmd.Parameters.Add(paramStartIndex);

                //SqlParameter paramMaximumRows = new SqlParameter();
                //paramMaximumRows.ParameterName = "@PageSize";
                //paramMaximumRows.Value = pageSize;
                //cmd.Parameters.Add(paramMaximumRows);

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
                //paramBranch.Value = Division;
                //cmd.Parameters.Add(paramBranch);

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
                    InternalAccountStatementList2 AccountStatement = new InternalAccountStatementList2();

                    AccountStatement.S_No = rdr["RowNumber"].ToString();
                    AccountStatement.Customer_ID = rdr["accountnum"].ToString();
                    AccountStatement.Customer_Name = rdr["CustomerName"].ToString();
                    AccountStatement.TransDate = rdr["TRANSDATE"].ToString();
                    AccountStatement.Opening = rdr["Opening"].ToString();
                    AccountStatement.MATURITYDATE = rdr["MATURITY DATE"].ToString();
                    AccountStatement.Voucher = rdr["VOUCHER"].ToString();
                    AccountStatement.AmountCur = rdr["AMOUNT"].ToString();
                    //AccountStatement.RunningTotal = rdr["RunningTotal"].ToString();
                    AccountStatement.Cheque_Number = rdr["PAYMREFERENCE"].ToString();
                    AccountStatement.Division = rdr["DIVISION"].ToString();

                    InternalAccountStatementList2.Add(AccountStatement);
                }

                rdr.Close();
                totalRows = 1;//(int)cmd.Parameters["@TotalRows"].Value;
                con.Close();
                con.Dispose();
            }
            return InternalAccountStatementList2;
        }

        public static List<InternalAccountStatementList3> GetInternalAccountStatementList3(string CustomerID, string CustomerName, string Division, string startDate, string EndDate/*, out int totalRows*/)
        {
            // Replace square brackets with angular brackets
            List<InternalAccountStatementList3> InternalAccountStatementList3 = new List<InternalAccountStatementList3>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PdcBalancesSindh", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 240;
                //SqlParameter paramStartIndex = new SqlParameter();
                //paramStartIndex.ParameterName = "@PageIndex";
                //paramStartIndex.Value = pageIndex;
                //cmd.Parameters.Add(paramStartIndex);

                //SqlParameter paramMaximumRows = new SqlParameter();
                //paramMaximumRows.ParameterName = "@PageSize";
                //paramMaximumRows.Value = pageSize;
                //cmd.Parameters.Add(paramMaximumRows);

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
                //paramBranch.Value = Division;
                //cmd.Parameters.Add(paramBranch);

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = startDate;
                cmd.Parameters.Add(paramStartInvoiceDate);

                SqlParameter paramEndInvoiceDate = new SqlParameter();
                paramEndInvoiceDate.ParameterName = "@AsOnDate";
                paramEndInvoiceDate.Value = EndDate;
                cmd.Parameters.Add(paramEndInvoiceDate);

                //SqlParameter paramOutputTotalRows = new SqlParameter();
                //paramOutputTotalRows.ParameterName = "@TotalRows";
                //paramOutputTotalRows.Direction = ParameterDirection.Output;
                //paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                //cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    InternalAccountStatementList3 AccountStatement = new InternalAccountStatementList3();

                    //AccountStatement.S_No = rdr["RowNumber"].ToString();
                    AccountStatement.Customer_ID = rdr["ACCOUNTNUM"].ToString();
                    AccountStatement.Customer_Name = rdr["CUSTOMERNAME"].ToString();
                    AccountStatement.FTD = rdr["FTD"].ToString();
                    AccountStatement.PHD = rdr["PHD"].ToString();
                    AccountStatement.SPD = rdr["SPD"].ToString();
                    AccountStatement.AHD = rdr["AHD"].ToString();
                    AccountStatement.HHD = rdr["HHD"].ToString();
                    AccountStatement.Closing = rdr["TOTAL BALANCE"].ToString();

                    InternalAccountStatementList3.Add(AccountStatement);
                }

                rdr.Close();
                // totalRows = 1;//(int)cmd.Parameters["@TotalRows"].Value;
                con.Close();
                con.Dispose();

            }
            return InternalAccountStatementList3;
        }



    }

    public class InternalAccountStatementKHO
    {
        public static List<InternalAccountStatementList1> GetInternalAccountStatementList1(string CustomerID, string CustomerName, string Division, string startDate, string EndDate, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<InternalAccountStatementList1> InternalAccountStatementList = new List<InternalAccountStatementList1>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("InternalAccountStatementKHO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 240;
                //SqlParameter paramStartIndex = new SqlParameter();
                //paramStartIndex.ParameterName = "@PageIndex";
                //paramStartIndex.Value = pageIndex;
                //cmd.Parameters.Add(paramStartIndex);

                //SqlParameter paramMaximumRows = new SqlParameter();
                //paramMaximumRows.ParameterName = "@PageSize";
                //paramMaximumRows.Value = pageSize;
                //cmd.Parameters.Add(paramMaximumRows);

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
                //paramBranch.Value = Division;
                //cmd.Parameters.Add(paramBranch);

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
                    InternalAccountStatementList1 AccountStatement = new InternalAccountStatementList1();

                    AccountStatement.S_No = rdr["RowNumber"].ToString();
                    AccountStatement.Customer_ID = rdr["TAccountnum"].ToString();
                    AccountStatement.Customer_Name = rdr["CustomerName"].ToString();
                    AccountStatement.Opening = rdr["TOpening"].ToString();
                    AccountStatement.Date = rdr["TDate"].ToString();
                    AccountStatement.DueDate = rdr["TDueDate"].ToString();
                    AccountStatement.Invoice = rdr["TInvoice"].ToString();
                    AccountStatement.Voucher = rdr["TVoucher"].ToString();
                    AccountStatement.Amount = rdr["TAmount"].ToString();
                    //AccountStatement.RunningTotal = rdr["TRunningTotal"].ToString();
                    AccountStatement.Division = rdr["TDivision"].ToString();

                    InternalAccountStatementList.Add(AccountStatement);
                }

                rdr.Close();
                totalRows = 1;//(int)cmd.Parameters["@TotalRows"].Value;
                con.Close();
                con.Dispose();
            }
            return InternalAccountStatementList;
        }

        public static List<InternalAccountStatementList2> GetInternalAccountStatementList2(string CustomerID, string CustomerName, string Division, string startDate, string EndDate, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<InternalAccountStatementList2> InternalAccountStatementList2 = new List<InternalAccountStatementList2>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("InternalAccountStatement1KHO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 240;
                //SqlParameter paramStartIndex = new SqlParameter();
                //paramStartIndex.ParameterName = "@PageIndex";
                //paramStartIndex.Value = pageIndex;
                //cmd.Parameters.Add(paramStartIndex);

                //SqlParameter paramMaximumRows = new SqlParameter();
                //paramMaximumRows.ParameterName = "@PageSize";
                //paramMaximumRows.Value = pageSize;
                //cmd.Parameters.Add(paramMaximumRows);

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
                //paramBranch.Value = Division;
                //cmd.Parameters.Add(paramBranch);

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
                    InternalAccountStatementList2 AccountStatement = new InternalAccountStatementList2();

                    AccountStatement.S_No = rdr["RowNumber"].ToString();
                    AccountStatement.Customer_ID = rdr["accountnum"].ToString();
                    AccountStatement.Customer_Name = rdr["CustomerName"].ToString();
                    AccountStatement.TransDate = rdr["TRANSDATE"].ToString();
                    AccountStatement.Opening = rdr["Opening"].ToString();
                    AccountStatement.MATURITYDATE = rdr["MATURITY DATE"].ToString();
                    AccountStatement.Voucher = rdr["VOUCHER"].ToString();
                    AccountStatement.AmountCur = rdr["AMOUNT"].ToString();
                    //AccountStatement.RunningTotal = rdr["RunningTotal"].ToString();
                    AccountStatement.Cheque_Number = rdr["PAYMREFERENCE"].ToString();
                    AccountStatement.Division = rdr["DIVISION"].ToString();

                    InternalAccountStatementList2.Add(AccountStatement);
                }

                rdr.Close();
                totalRows = 1;//(int)cmd.Parameters["@TotalRows"].Value;
                con.Close();
                con.Dispose();
            }
            return InternalAccountStatementList2;
        }

        public static List<InternalAccountStatementList3> GetInternalAccountStatementList3(string CustomerID, string CustomerName, string Division, string startDate, string EndDate)
        {
            // Replace square brackets with angular brackets
            List<InternalAccountStatementList3> InternalAccountStatementList3 = new List<InternalAccountStatementList3>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PdcBalancesKHO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 240;
                //SqlParameter paramStartIndex = new SqlParameter();
                //paramStartIndex.ParameterName = "@PageIndex";
                //paramStartIndex.Value = pageIndex;
                //cmd.Parameters.Add(paramStartIndex);

                //SqlParameter paramMaximumRows = new SqlParameter();
                //paramMaximumRows.ParameterName = "@PageSize";
                //paramMaximumRows.Value = pageSize;
                //cmd.Parameters.Add(paramMaximumRows);

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
                //paramBranch.Value = Division;
                //cmd.Parameters.Add(paramBranch);

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = startDate;
                cmd.Parameters.Add(paramStartInvoiceDate);

                SqlParameter paramEndInvoiceDate = new SqlParameter();
                paramEndInvoiceDate.ParameterName = "@AsOnDate";
                paramEndInvoiceDate.Value = EndDate;
                cmd.Parameters.Add(paramEndInvoiceDate);

                //SqlParameter paramOutputTotalRows = new SqlParameter();
                //paramOutputTotalRows.ParameterName = "@TotalRows";
                //paramOutputTotalRows.Direction = ParameterDirection.Output;
                //paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                //cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    InternalAccountStatementList3 AccountStatement = new InternalAccountStatementList3();

                    //AccountStatement.S_No = rdr["RowNumber"].ToString();
                    AccountStatement.Customer_ID = rdr["ACCOUNTNUM"].ToString();
                    AccountStatement.Customer_Name = rdr["CUSTOMERNAME"].ToString();
                    AccountStatement.FTD = rdr["FTD"].ToString();
                    AccountStatement.PHD = rdr["PHD"].ToString();
                    AccountStatement.SPD = rdr["SPD"].ToString();
                    AccountStatement.AHD = rdr["AHD"].ToString();
                    AccountStatement.HHD = rdr["HHD"].ToString();
                    AccountStatement.Closing = rdr["BALANCE"].ToString();

                    InternalAccountStatementList3.Add(AccountStatement);
                }

                rdr.Close();
                // totalRows = 1;//(int)cmd.Parameters["@TotalRows"].Value;
                con.Close();
                con.Dispose();
            }
            return InternalAccountStatementList3;
        }



    }
}