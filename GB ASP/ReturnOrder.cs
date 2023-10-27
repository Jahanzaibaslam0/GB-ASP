using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class ReturnOrderList
    {
        public string SerialNo { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }

        public string Branch { get; set; }

        

        public string CreatedDate { get; set; }
        public string Division { get; set; }
        public string Employee { get; set; }
        public string ReturnNumber { get; set; }

        public string ReturnDeadLine { get; set; }

        public string SalesID { get; set; }
        public string SalesName { get; set; }
        public string Currency { get; set; }
        public string Site { get; set; }
        public string Warehouse { get; set; }

        public string DeliveryName { get; set; }
        public string Address { get; set; }
        public string ReturnReasonCode { get; set; }
    }

    public class ReturnOrder
    {
        public static List<ReturnOrderList> GetReturnOrder(int pageIndex, int pageSize, string StartDate, string EndDate, string CustomerID, string CustomerName, string Division, string SalesID, string Employee, string Branch, string status, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<ReturnOrderList> listReturnOrder = new List<ReturnOrderList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spReturnOrder", con);
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
                paramStatus.ParameterName = "@Status";
                paramStatus.Value = status;
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
                paramEmployee.ParameterName = "@SALESTAKER";
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
                    ReturnOrderList ReturnOrder = new ReturnOrderList();

                    ReturnOrder.SerialNo = rdr["RowNumber"].ToString();
                    ReturnOrder.CustomerID = rdr["CUSTACCOUNT"].ToString();
                    ReturnOrder.CustomerName = rdr["SALESNAME"].ToString();
                    ReturnOrder.Branch = rdr["DealForBranch"].ToString();
                    ReturnOrder.CreatedDate = rdr["CREATEDDATETIME"].ToString();
                    ReturnOrder.SalesID = rdr["salesid"].ToString();
                    ReturnOrder.Division = rdr["DIVISION"].ToString();
                    ReturnOrder.Employee = rdr["SALESTAKER"].ToString();
                    ReturnOrder.ReturnNumber = rdr["RETURNITEMNUM"].ToString();
                    ReturnOrder.ReturnDeadLine = rdr["RETURNDEADLINE"].ToString();
                    ReturnOrder.ReturnReasonCode = rdr["RETURNREASONCODEID"].ToString();
                    ReturnOrder.SalesName = rdr["SALESNAME"].ToString();
                    ReturnOrder.Address = rdr["ADDRESS"].ToString();
                    ReturnOrder.DeliveryName = rdr["DELIVERYNAME"].ToString();
                    ReturnOrder.Site = rdr["SITE"].ToString();
                    ReturnOrder.Warehouse = rdr["WAREHOUSE"].ToString();
                    ReturnOrder.Currency = rdr["CURRENCYCODE"].ToString();



                    listReturnOrder.Add(ReturnOrder);
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
            return listReturnOrder;
        }
    }

    public class ReturnOrder2
    {
        public static List<ReturnOrderList> GetReturnOrder(int pageIndex, int pageSize, string StartDate, string EndDate, string CustomerID, string CustomerName, string Division, string SalesID, string Employee, string status, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<ReturnOrderList> listReturnOrder = new List<ReturnOrderList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spReturnOrder2", con);
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
                paramStatus.ParameterName = "@Status";
                paramStatus.Value = status;
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
                paramEmployee.ParameterName = "@SALESTAKER";
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
                    ReturnOrderList ReturnOrder = new ReturnOrderList();

                    ReturnOrder.SerialNo = rdr["RowNumber"].ToString();
                    ReturnOrder.CustomerID = rdr["CUSTACCOUNT"].ToString();
                    ReturnOrder.CustomerName = rdr["SALESNAME"].ToString();
                    ReturnOrder.Branch = rdr["DealForBranch"].ToString();
                    ReturnOrder.CreatedDate = rdr["CREATEDDATETIME"].ToString();
                    ReturnOrder.SalesID = rdr["salesid"].ToString();
                    ReturnOrder.Division = rdr["DIVISION"].ToString();
                    ReturnOrder.Employee = rdr["SALESTAKER"].ToString();
                    ReturnOrder.ReturnNumber = rdr["RETURNITEMNUM"].ToString();
                    ReturnOrder.ReturnDeadLine = rdr["RETURNDEADLINE"].ToString();
                    ReturnOrder.ReturnReasonCode = rdr["RETURNREASONCODEID"].ToString();
                    ReturnOrder.SalesName = rdr["SALESNAME"].ToString();
                    ReturnOrder.Address = rdr["ADDRESS"].ToString();
                    ReturnOrder.DeliveryName = rdr["DELIVERYNAME"].ToString();
                    ReturnOrder.Site = rdr["SITE"].ToString();
                    ReturnOrder.Warehouse = rdr["WAREHOUSE"].ToString();
                    ReturnOrder.Currency = rdr["CURRENCYCODE"].ToString();



                    listReturnOrder.Add(ReturnOrder);
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
            return listReturnOrder;
        }
    }
}