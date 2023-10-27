using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class ChequeReceivedlist
    {
        public string SerialNo { get; set; }
        
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Branch { get; set; }
        public string Voucher { get; set; }

        public string TransDate { get; set; }

        public string PostedDateTime { get; set; }
        public string BookNo { get; set; }

        public string Amount { get; set; }
        public string Division { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentReference { get; set; }
        public string DocumentDate { get; set; }
        public string CustVendBankAccount { get; set; }
        public string BankNameWithBranch { get; set; }
        public string ChequeOwnerName { get; set; }
        public string ReceivedFrom { get; set; }
        public string CreatedBy { get; set; }

    }

    public class ChequeReceivedReportList
    {
        public static List<ChequeReceivedlist> GetChequeReceivedReport(int pageIndex, int pageSize, string StartDate, string EndDate,  string CustID, string CustName,string Branch,string ReceivedFrom, string Division,  out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<ChequeReceivedlist> listChequeReceivedReport = new List<ChequeReceivedlist>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("ChequeReceivedReport2", con);
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

                SqlParameter paramCustID = new SqlParameter();
                paramCustID.ParameterName = "@Customer";
                paramCustID.Value = CustID;
                cmd.Parameters.Add(paramCustID);


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramReceivedFrom = new SqlParameter();
                paramReceivedFrom.ParameterName = "@ReceivedFrom";
                paramReceivedFrom.Value = ReceivedFrom;
                cmd.Parameters.Add(paramReceivedFrom);

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
                    ChequeReceivedlist ChequeReceived = new ChequeReceivedlist();

                    ChequeReceived.SerialNo = rdr["RowNumber"].ToString();

                    ChequeReceived.CustomerID = rdr["CUSTOMERID"].ToString();
                    ChequeReceived.CustomerName = rdr["CustomerName"].ToString();
                    ChequeReceived.Voucher = rdr["VOUCHER"].ToString();
                    ChequeReceived.TransDate = rdr["TRANSDATE"].ToString();
                    ChequeReceived.PostedDateTime = rdr["POSTEDDATETIME"].ToString();
                    ChequeReceived.BookNo = rdr["BOOKNO"].ToString();
                    ChequeReceived.Amount = rdr["AMOUNT"].ToString();
                    ChequeReceived.Division = rdr["DIVISION"].ToString();
                    ChequeReceived.PaymentMode = rdr["PAYMMODE"].ToString();
                    ChequeReceived.PaymentReference = rdr["PAYMREFERENCE"].ToString();
                    ChequeReceived.DocumentDate = rdr["DOCUMENTDATE"].ToString();
                    ChequeReceived.CustVendBankAccount = rdr["CUSTVENDBANKACCOUNTID"].ToString();
                    ChequeReceived.Branch = rdr["DEAL FOR BRANCH"].ToString();
                    ChequeReceived.BankNameWithBranch = rdr["BANKNAMEWITHBRANCH"].ToString();
                    ChequeReceived.ChequeOwnerName = rdr["CHEQUEOWNERNAME"].ToString();
                    ChequeReceived.ReceivedFrom = rdr["RECEIVEDFROM"].ToString();
                    ChequeReceived.CreatedBy = rdr["CREATEDBY"].ToString();

                    listChequeReceivedReport.Add(ChequeReceived);
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

            
            return listChequeReceivedReport;
        }


    }

    public class ChequeReceivedReportList2
    {
        public static List<ChequeReceivedlist> GetChequeReceivedReport(int pageIndex, int pageSize, string StartDate, string EndDate, string CustID, string CustName,  string ReceivedFrom, string Division, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<ChequeReceivedlist> listChequeReceivedReport = new List<ChequeReceivedlist>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("ChequeReceivedReport2", con);
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

                SqlParameter paramCustID = new SqlParameter();
                paramCustID.ParameterName = "@Customer";
                paramCustID.Value = CustID;
                cmd.Parameters.Add(paramCustID);


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramReceivedFrom = new SqlParameter();
                paramReceivedFrom.ParameterName = "@ReceivedFrom";
                paramReceivedFrom.Value = ReceivedFrom;
                cmd.Parameters.Add(paramReceivedFrom);

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@Branch";
                //paramBranch.Value = Branch;
                //cmd.Parameters.Add(paramBranch);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

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
                    ChequeReceivedlist ChequeReceived = new ChequeReceivedlist();

                    ChequeReceived.SerialNo = rdr["RowNumber"].ToString();

                    ChequeReceived.CustomerID = rdr["CUSTOMERID"].ToString();
                    ChequeReceived.CustomerName = rdr["CustomerName"].ToString();
                    ChequeReceived.Voucher = rdr["VOUCHER"].ToString();
                    ChequeReceived.TransDate = rdr["TRANSDATE"].ToString();
                    ChequeReceived.PostedDateTime = rdr["POSTEDDATETIME"].ToString();
                    ChequeReceived.BookNo = rdr["BOOKNO"].ToString();
                    ChequeReceived.Amount = rdr["AMOUNT"].ToString();
                    ChequeReceived.Division = rdr["DIVISION"].ToString();
                    ChequeReceived.PaymentMode = rdr["PAYMMODE"].ToString();
                    ChequeReceived.PaymentReference = rdr["PAYMREFERENCE"].ToString();
                    ChequeReceived.DocumentDate = rdr["DOCUMENTDATE"].ToString();
                    ChequeReceived.CustVendBankAccount = rdr["CUSTVENDBANKACCOUNTID"].ToString();
                    ChequeReceived.Branch = rdr["DEAL FOR BRANCH"].ToString();
                    ChequeReceived.BankNameWithBranch = rdr["BANKNAMEWITHBRANCH"].ToString();
                    ChequeReceived.ChequeOwnerName = rdr["CHEQUEOWNERNAME"].ToString();
                    ChequeReceived.ReceivedFrom = rdr["RECEIVEDFROM"].ToString();
                    ChequeReceived.CreatedBy = rdr["CREATEDBY"].ToString();

                    listChequeReceivedReport.Add(ChequeReceived);
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
            return listChequeReceivedReport;
        }


    }
}