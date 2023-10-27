using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace GB_ASP
{
    public class OpenCustInvoicePastDueTodayList
    {
        public string S_No { get; set; }
        public string Customer_Account { get; set; }
        public string Customer_Name { get; set; }
        public string Deal_For_Branch { get; set; }
        public string Customer_Group { get; set; }

        public string SalesID { get; set; }
        public string Invoice { get; set; }
        public string TermsOfPayment { get; set; }

        public string Date { get; set; }
        public string DueDate { get; set; }

        public string Method_Of_Payment { get; set; }
        public string InvoiceAmount { get; set; }

        public string Payment { get; set; }

        public string AmountNotSettled { get; set; }
        public string Division { get; set; }
        public string SalesTaker { get; set; }
        public string Region { get; set; }
        public string Team { get; set; }
        public string CollectionStatus { get; set; }
        public string Reason { get; set; }
        public string ReasonComment { get; set; }

        //public string BillOfExchangesStatus { get; set; }
        //public string Voucher { get; set; }
        //public string TransactionType { get; set; }


        public string PromiseDate { get; set; }


    }
    public class CustInvoicePastDueToday
    {
        public static List<OpenCustInvoicePastDueTodayList> GetOpenCustomerInvoicePastToday(int pageIndex, int pageSize, string StartDate, string EndDate, string CustomerID, string CustomerName,string Branch,string Employee, string Division, string Region, string InvoiceID, string SalesID, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<OpenCustInvoicePastDueTodayList> listOpenCustomerInvoicePastToday = new List<OpenCustInvoicePastDueTodayList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("OpenCustomerInvoicePastDueToday", con);
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

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@Branch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);

                SqlParameter paramEmployee = new SqlParameter();
                paramEmployee.ParameterName = "@Employee";
                paramEmployee.Value = Employee;
                cmd.Parameters.Add(paramEmployee);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustomerName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramSalesID = new SqlParameter();
                paramSalesID.ParameterName = "@SalesID";
                paramSalesID.Value = SalesID;
                cmd.Parameters.Add(paramSalesID);

                SqlParameter paramInvoice = new SqlParameter();
                paramInvoice.ParameterName = "@Invoice";
                paramInvoice.Value = InvoiceID;
                cmd.Parameters.Add(paramInvoice);

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
                    OpenCustInvoicePastDueTodayList OpenCustomerInvoicePastToday = new OpenCustInvoicePastDueTodayList();

                    OpenCustomerInvoicePastToday.S_No = rdr["RowNumber"].ToString();
                    OpenCustomerInvoicePastToday.Customer_Account = rdr["CUSTOMERACCOUNT"].ToString();
                    OpenCustomerInvoicePastToday.Customer_Name = rdr["NAME"].ToString();
                    OpenCustomerInvoicePastToday.Deal_For_Branch = rdr["INVENTLOCATIONBR"].ToString();
                    OpenCustomerInvoicePastToday.Customer_Group = rdr["CUSTGROUP"].ToString();
                    OpenCustomerInvoicePastToday.DueDate = rdr["DUEDATE"].ToString();
                    OpenCustomerInvoicePastToday.Invoice = rdr["INVOICE"].ToString();
                    OpenCustomerInvoicePastToday.Method_Of_Payment = rdr["PAYMMODE"].ToString();
                    OpenCustomerInvoicePastToday.SalesID = rdr["SALESID"].ToString();
                    //OpenCustomerInvoicePastToday.BillingClassification = rdr["BILLINGCLASSIFICATION"].ToString();
                    OpenCustomerInvoicePastToday.TermsOfPayment = rdr["TERMSOFPAYMENT"].ToString();
                    OpenCustomerInvoicePastToday.Payment = rdr["Payment"].ToString();
                    OpenCustomerInvoicePastToday.InvoiceAmount = rdr["INVOICEAMOUNT"].ToString();
                    OpenCustomerInvoicePastToday.SalesTaker = rdr["SALESTAKER"].ToString();
                    OpenCustomerInvoicePastToday.Division = rdr["DIVISION"].ToString();
                    OpenCustomerInvoicePastToday.Region = rdr["Region"].ToString();
                    OpenCustomerInvoicePastToday.Team = rdr["TEAM"].ToString();
                    OpenCustomerInvoicePastToday.Reason = rdr["REASON"].ToString();
                    OpenCustomerInvoicePastToday.ReasonComment = rdr["REASONCOMMENT"].ToString();
                    OpenCustomerInvoicePastToday.AmountNotSettled = rdr["AMOUNT NOTSETTLED"].ToString();
                    OpenCustomerInvoicePastToday.CollectionStatus = rdr["COLLECTION STATUS"].ToString();
                    OpenCustomerInvoicePastToday.Date = rdr["DATE"].ToString();
                    //OpenCustomerInvoicePastToday.PaymReference = rdr["PAYMREFERENCE"].ToString();
                    OpenCustomerInvoicePastToday.PromiseDate = rdr["PROMISEDATE"].ToString();


                    listOpenCustomerInvoicePastToday.Add(OpenCustomerInvoicePastToday);
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
                //if ((int)cmd.Parameters["@TotalRows"].Value == 0)
                //{
                //    totalRows = 1;
                //}
                //else
                //{
                //    totalRows = (int)cmd.Parameters["@TotalRows"].Value;


                //}
                con.Close();
                con.Dispose();
                //totalRows = (int)cmd.Parameters["@TotalRows"].Value;

                //    con.Close();
                //    con.Dispose();

            }
            return listOpenCustomerInvoicePastToday;
        }
    }


    public class CustInvoicePastDueToday2
    {
        public static List<OpenCustInvoicePastDueTodayList> GetOpenCustomerInvoicePastToday(int pageIndex, int pageSize, string StartDate, string EndDate, string CustomerID, string CustomerName, string Division, string Region, string InvoiceID, string SalesID, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<OpenCustInvoicePastDueTodayList> listOpenCustomerInvoicePastToday = new List<OpenCustInvoicePastDueTodayList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("OpenCustomerInvoicePastDueToday2", con);
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

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@Branch";
                //paramBranch.Value = Branch;
                //cmd.Parameters.Add(paramBranch);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustomerName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramSalesID = new SqlParameter();
                paramSalesID.ParameterName = "@SalesID";
                paramSalesID.Value = SalesID;
                cmd.Parameters.Add(paramSalesID);

                SqlParameter paramInvoice = new SqlParameter();
                paramInvoice.ParameterName = "@Invoice";
                paramInvoice.Value = InvoiceID;
                cmd.Parameters.Add(paramInvoice);

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
                    OpenCustInvoicePastDueTodayList OpenCustomerInvoicePastToday = new OpenCustInvoicePastDueTodayList();

                    OpenCustomerInvoicePastToday.S_No = rdr["RowNumber"].ToString();
                    OpenCustomerInvoicePastToday.Customer_Account = rdr["CUSTOMERACCOUNT"].ToString();
                    OpenCustomerInvoicePastToday.Customer_Name = rdr["NAME"].ToString();
                    OpenCustomerInvoicePastToday.Deal_For_Branch = rdr["INVENTLOCATIONBR"].ToString();
                    OpenCustomerInvoicePastToday.Customer_Group = rdr["CUSTGROUP"].ToString();
                    OpenCustomerInvoicePastToday.DueDate = rdr["DUEDATE"].ToString();
                    OpenCustomerInvoicePastToday.Invoice = rdr["INVOICE"].ToString();
                    OpenCustomerInvoicePastToday.Method_Of_Payment = rdr["PAYMMODE"].ToString();
                    OpenCustomerInvoicePastToday.SalesID = rdr["SALESID"].ToString();
                    //OpenCustomerInvoicePastToday.BillingClassification = rdr["BILLINGCLASSIFICATION"].ToString();
                    OpenCustomerInvoicePastToday.TermsOfPayment = rdr["TERMSOFPAYMENT"].ToString();
                    OpenCustomerInvoicePastToday.Payment = rdr["Payment"].ToString();
                    OpenCustomerInvoicePastToday.InvoiceAmount = rdr["INVOICEAMOUNT"].ToString();
                    OpenCustomerInvoicePastToday.SalesTaker = rdr["SALESTAKER"].ToString();
                    OpenCustomerInvoicePastToday.Division = rdr["DIVISION"].ToString();
                    OpenCustomerInvoicePastToday.Region = rdr["Region"].ToString();
                    OpenCustomerInvoicePastToday.Team = rdr["TEAM"].ToString();
                    OpenCustomerInvoicePastToday.Reason = rdr["REASON"].ToString();
                    OpenCustomerInvoicePastToday.ReasonComment = rdr["REASONCOMMENT"].ToString();
                    OpenCustomerInvoicePastToday.AmountNotSettled = rdr["AMOUNT NOTSETTLED"].ToString();
                    OpenCustomerInvoicePastToday.CollectionStatus = rdr["COLLECTION STATUS"].ToString();
                    OpenCustomerInvoicePastToday.Date = rdr["DATE"].ToString();
                    //OpenCustomerInvoicePastToday.PaymReference = rdr["PAYMREFERENCE"].ToString();
                    OpenCustomerInvoicePastToday.PromiseDate = rdr["PROMISEDATE"].ToString();


                    listOpenCustomerInvoicePastToday.Add(OpenCustomerInvoicePastToday);
                }

                rdr.Close();
                totalRows = (int)cmd.Parameters["@TotalRows"].Value;
                con.Close();
                con.Dispose();
            }
            return listOpenCustomerInvoicePastToday;
        }
    }
}