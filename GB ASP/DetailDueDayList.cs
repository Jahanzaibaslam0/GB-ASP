using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class ListDetailDueDay
    {
        public string SerialNo { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }

        public string Branch { get; set; }

        public string InvoiceID { get; set; }

        public string InvoiceDate { get; set; }
        public string Division { get; set; }

        public string Region { get; set; }

        public string CreditLimit { get; set; }

        public string InvoiceAmount { get; set; }

        public string NotDueAmount { get; set; }

        public string DueAmount { get; set; }
        public string PastDueDay { get; set; }
        public string Group { get; set; }
        public string BillingClassification { get; set; }
        public string Reason { get; set; }
        public string ReasonComment { get; set; }
        public string Employee { get; set; }
        public string Duedate { get; set; }
       
       
        public string RemainingAmount { get; set; }
        public string SettleAmount { get; set; }
        public string LastSettleAmount { get; set; }
        public string LastSettleDate { get; set; }
        public string Company { get; set; }

    }

    public class DetailDueDayList
    {
        public static List<ListDetailDueDay> GetDetailDueDayList(int pageIndex, int pageSize, string StartDate, string EndDate, string CustomerID,string CustomerName, string Group, string Division, string Region, string Employee, string Branch, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<ListDetailDueDay> DetailDueDayList = new List<ListDetailDueDay>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DetailDueDayList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 480;
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
                paramCustomerName.ParameterName = "@CustomerName";
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
                    ListDetailDueDay DetailDueDay = new ListDetailDueDay();

                    DetailDueDay.SerialNo = rdr["RowNumber"].ToString();
                    DetailDueDay.CustomerID = rdr["accountnum"].ToString();
                    DetailDueDay.CustomerName = rdr["CustomerName"].ToString();
                    DetailDueDay.Branch = rdr["DealForBranch"].ToString();
                    DetailDueDay.InvoiceID = rdr["INVOICE"].ToString();
                    DetailDueDay.InvoiceDate = rdr["InvoiceDate"].ToString();
                    DetailDueDay.Division = rdr["Division"].ToString();
                    DetailDueDay.Region = rdr["Region"].ToString();
                    DetailDueDay.InvoiceAmount = rdr["OriginalAmount"].ToString();
                    DetailDueDay.RemainingAmount = rdr["RemainingAmount"].ToString();
                    DetailDueDay.NotDueAmount = rdr["NotDueAmount"].ToString();
                    DetailDueDay.SettleAmount = rdr["SettlementAmountCur"].ToString();
                    DetailDueDay.Duedate = rdr["DUEDATE"].ToString();
                    DetailDueDay.PastDueDay = rdr["DueDatediff"].ToString();
                    DetailDueDay.Reason = rdr["REASON"].ToString();
                    DetailDueDay.ReasonComment = rdr["Reason Comment"].ToString();
                    DetailDueDay.CreditLimit = rdr["CreditLimit"].ToString();
                    DetailDueDay.DueAmount = rdr["DueAmount"].ToString();
                    DetailDueDay.LastSettleDate = rdr["LASTSETTLEDATE"].ToString();
                    DetailDueDay.Employee = rdr["ORDERTAKERNAME"].ToString();
                    DetailDueDay.Group = rdr["CUSTGROUP"].ToString();
                    DetailDueDay.BillingClassification = rdr["BILLINGCLASSIFICATION"].ToString();







                    DetailDueDayList.Add(DetailDueDay);
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
            return DetailDueDayList;
        }

    }

    public class DetailDueDayList2
    {
        public static List<ListDetailDueDay> GetDetailDueDayList(int pageIndex, int pageSize, string StartDate, string EndDate, string CustomerID, string Group, string Division, string Region, string Employee, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<ListDetailDueDay> DetailDueDayList = new List<ListDetailDueDay>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DetailDueDayList2", con);
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

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@DealForBranch";
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
                    ListDetailDueDay DetailDueDay = new ListDetailDueDay();

                    DetailDueDay.SerialNo = rdr["RowNumber"].ToString();
                    DetailDueDay.CustomerID = rdr["accountnum"].ToString();
                    DetailDueDay.CustomerName = rdr["CustomerName"].ToString();
                    DetailDueDay.Branch = rdr["DealForBranch"].ToString();
                    DetailDueDay.InvoiceID = rdr["INVOICE"].ToString();
                    DetailDueDay.InvoiceDate = rdr["InvoiceDate"].ToString();
                    DetailDueDay.Division = rdr["Division"].ToString();
                    DetailDueDay.Region = rdr["Region"].ToString();
                    DetailDueDay.InvoiceAmount = rdr["OriginalAmount"].ToString();
                    DetailDueDay.RemainingAmount = rdr["RemainingAmount"].ToString();
                    DetailDueDay.NotDueAmount = rdr["NotDueAmount"].ToString();
                    DetailDueDay.SettleAmount = rdr["SettlementAmountCur"].ToString();
                    DetailDueDay.Duedate = rdr["DUEDATE"].ToString();
                    DetailDueDay.PastDueDay = rdr["DueDatediff"].ToString();
                    DetailDueDay.Reason = rdr["REASON"].ToString();
                    DetailDueDay.ReasonComment = rdr["Reason Comment"].ToString();
                    DetailDueDay.CreditLimit = rdr["CreditLimit"].ToString();
                    DetailDueDay.DueAmount = rdr["DueAmount"].ToString();
                    DetailDueDay.LastSettleDate = rdr["LASTSETTLEDATE"].ToString();
                    DetailDueDay.Employee = rdr["ORDERTAKERNAME"].ToString();
                    DetailDueDay.Group = rdr["CUSTGROUP"].ToString();
                    DetailDueDay.BillingClassification = rdr["BILLINGCLASSIFICATION"].ToString();







                    DetailDueDayList.Add(DetailDueDay);
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
            return DetailDueDayList;
        }

    }
}