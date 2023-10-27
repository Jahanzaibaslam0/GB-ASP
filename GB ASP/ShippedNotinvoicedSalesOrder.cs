using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace GB_ASP
{
    public class NotInvoicedSalesOrderList
    {
        public string S_No { get; set; }
        public string Sales_Order_ID { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public string Group { get; set; }
        public string Branch { get; set; }
        public string NetAmount { get; set; }
        public string WFSTATE { get; set; }
        public string SalesStatus { get; set; }
        public string Site { get; set; }
        public string Warehouse { get; set; }
        public string SalespoolID { get; set; }
        public string DeliveryMode { get; set; }
        public string DeliveryTerm { get; set; }

        public string Address { get; set; }
        public string SalesPriority { get; set; }
        public string Payment { get; set; }
        public string PaymMode { get; set; }
        public string ContactPerson { get; set; }

        public string Division { get; set; }
        public string Region { get; set; }

    }


    public class ShippedNotinvoicedSalesOrder
    {

        public static List<NotInvoicedSalesOrderList> GetNotInvoicedSalesOrder(int pageIndex, int pageSize, string StartDate, string EndDate, string CreatedBy,string Branch, string CustomerID, string CustomerName, string SalesOrder, string Division, string Region, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<NotInvoicedSalesOrderList> listNotInvoicedSalesOrder = new List<NotInvoicedSalesOrderList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spSalesOrder3", con);
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

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramSalesID = new SqlParameter();
                paramSalesID.ParameterName = "@SalesID";
                paramSalesID.Value = SalesOrder;
                cmd.Parameters.Add(paramSalesID);

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

                SqlParameter paramCreatedBy = new SqlParameter();
                paramCreatedBy.ParameterName = "@CreatedBy";
                paramCreatedBy.Value = CreatedBy;
                cmd.Parameters.Add(paramCreatedBy);

                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    NotInvoicedSalesOrderList NotInvoicedSalesOrderList = new NotInvoicedSalesOrderList();

                    NotInvoicedSalesOrderList.S_No = rdr["RowNumber"].ToString();
                    NotInvoicedSalesOrderList.CustomerID = rdr["CUSTACCOUNT"].ToString();
                    NotInvoicedSalesOrderList.CustomerName = rdr["SALESNAME"].ToString();
                    NotInvoicedSalesOrderList.Branch = rdr["DEALFORBRANCH"].ToString();
                    NotInvoicedSalesOrderList.Group = rdr["CUSTGROUP"].ToString();
                    NotInvoicedSalesOrderList.NetAmount = rdr["ORDERNETAMOUNT"].ToString();
                    NotInvoicedSalesOrderList.WFSTATE = rdr["WORKFLOW STATUS"].ToString();
                    NotInvoicedSalesOrderList.SalesStatus = rdr["ORDER STATUS"].ToString();
                    NotInvoicedSalesOrderList.Address = rdr["ADDRESS"].ToString();
                    NotInvoicedSalesOrderList.SalesPriority = rdr["sales priority"].ToString();
                    NotInvoicedSalesOrderList.Region = rdr["Region"].ToString();
                    NotInvoicedSalesOrderList.Division = rdr["DIVISION"].ToString();
                    NotInvoicedSalesOrderList.ContactPerson = rdr["CONTACTPERSON"].ToString();
                    NotInvoicedSalesOrderList.DeliveryTerm = rdr["DLVTERM"].ToString();
                    NotInvoicedSalesOrderList.CreatedDate = rdr["OrderDate"].ToString();
                    NotInvoicedSalesOrderList.CreatedBy = rdr["CreatedBy"].ToString();
                    NotInvoicedSalesOrderList.ModifiedDate = rdr["ModifiedDate"].ToString();
                    NotInvoicedSalesOrderList.ModifiedBy = rdr["ModifiedBy"].ToString();

                    NotInvoicedSalesOrderList.Sales_Order_ID = rdr["SALESID"].ToString();
                    NotInvoicedSalesOrderList.DeliveryMode = rdr["DLVMODE"].ToString();
                    NotInvoicedSalesOrderList.Site = rdr["INVENTSITEID"].ToString();
                    NotInvoicedSalesOrderList.Warehouse = rdr["INVENTLOCATIONID"].ToString();
                    NotInvoicedSalesOrderList.SalespoolID = rdr["SALESPOOLID"].ToString();
                    NotInvoicedSalesOrderList.Payment = rdr["PAYMENT"].ToString();
                    NotInvoicedSalesOrderList.PaymMode = rdr["PAYMMODE"].ToString();

                    listNotInvoicedSalesOrder.Add(NotInvoicedSalesOrderList);
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
                con.Close();
                con.Dispose();
            }
            return listNotInvoicedSalesOrder;
        }
    }

    public class ShippedNotinvoicedSalesOrder2
    {

        public static List<NotInvoicedSalesOrderList> GetNotInvoicedSalesOrder(int pageIndex, int pageSize, string StartDate, string EndDate, string CreatedBy, string CustomerID, string CustomerName, string SalesOrder, string Division, string Region, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<NotInvoicedSalesOrderList> listNotInvoicedSalesOrder = new List<NotInvoicedSalesOrderList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spSalesOrderSindh", con);
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

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramSalesID = new SqlParameter();
                paramSalesID.ParameterName = "@SalesID";
                paramSalesID.Value = SalesOrder;
                cmd.Parameters.Add(paramSalesID);

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = StartDate;
                cmd.Parameters.Add(paramStartInvoiceDate);

                SqlParameter paramEndInvoiceDate = new SqlParameter();
                paramEndInvoiceDate.ParameterName = "@EndDate";
                paramEndInvoiceDate.Value = EndDate;
                cmd.Parameters.Add(paramEndInvoiceDate);

                SqlParameter paramCreatedBy = new SqlParameter();
                paramCreatedBy.ParameterName = "@CreatedBy";
                paramCreatedBy.Value = CreatedBy;
                cmd.Parameters.Add(paramCreatedBy);

                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    NotInvoicedSalesOrderList NotInvoicedSalesOrderList = new NotInvoicedSalesOrderList();

                    NotInvoicedSalesOrderList.S_No = rdr["RowNumber"].ToString();
                    NotInvoicedSalesOrderList.CustomerID = rdr["CUSTACCOUNT"].ToString();
                    NotInvoicedSalesOrderList.CustomerName = rdr["SALESNAME"].ToString();
                    NotInvoicedSalesOrderList.Branch = rdr["DEALFORBRANCH"].ToString();
                    NotInvoicedSalesOrderList.Group = rdr["CUSTGROUP"].ToString();
                    NotInvoicedSalesOrderList.NetAmount = rdr["ORDERNETAMOUNT"].ToString();
                    NotInvoicedSalesOrderList.WFSTATE = rdr["WORKFLOW STATUS"].ToString();
                    NotInvoicedSalesOrderList.SalesStatus = rdr["ORDER STATUS"].ToString();
                    NotInvoicedSalesOrderList.Address = rdr["ADDRESS"].ToString();
                    NotInvoicedSalesOrderList.SalesPriority = rdr["sales priority"].ToString();
                    NotInvoicedSalesOrderList.Region = rdr["Region"].ToString();
                    NotInvoicedSalesOrderList.Division = rdr["DIVISION"].ToString();
                    NotInvoicedSalesOrderList.ContactPerson = rdr["CONTACTPERSON"].ToString();
                    NotInvoicedSalesOrderList.DeliveryTerm = rdr["DLVTERM"].ToString();
                    NotInvoicedSalesOrderList.CreatedDate = rdr["OrderDate"].ToString();
                    NotInvoicedSalesOrderList.CreatedBy = rdr["CreatedBy"].ToString();
                    NotInvoicedSalesOrderList.ModifiedDate = rdr["ModifiedDate"].ToString();
                    NotInvoicedSalesOrderList.ModifiedBy = rdr["ModifiedBy"].ToString();

                    NotInvoicedSalesOrderList.Sales_Order_ID = rdr["SALESID"].ToString();
                    NotInvoicedSalesOrderList.DeliveryMode = rdr["DLVMODE"].ToString();
                    NotInvoicedSalesOrderList.Site = rdr["INVENTSITEID"].ToString();
                    NotInvoicedSalesOrderList.Warehouse = rdr["INVENTLOCATIONID"].ToString();
                    NotInvoicedSalesOrderList.SalespoolID = rdr["SALESPOOLID"].ToString();
                    NotInvoicedSalesOrderList.Payment = rdr["PAYMENT"].ToString();
                    NotInvoicedSalesOrderList.PaymMode = rdr["PAYMMODE"].ToString();

                    listNotInvoicedSalesOrder.Add(NotInvoicedSalesOrderList);
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
            return listNotInvoicedSalesOrder;
        }
    }

    public class ShippedNotinvoicedSalesOrderKHO
    {

        public static List<NotInvoicedSalesOrderList> GetNotInvoicedSalesOrder(int pageIndex, int pageSize, string StartDate, string EndDate, string CreatedBy, string CustomerID, string CustomerName, string SalesOrder, string Division, string Region, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<NotInvoicedSalesOrderList> listNotInvoicedSalesOrder = new List<NotInvoicedSalesOrderList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spSalesOrderKHO", con);
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

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramSalesID = new SqlParameter();
                paramSalesID.ParameterName = "@SalesID";
                paramSalesID.Value = SalesOrder;
                cmd.Parameters.Add(paramSalesID);

                SqlParameter paramStartInvoiceDate = new SqlParameter();
                paramStartInvoiceDate.ParameterName = "@StartDate";
                paramStartInvoiceDate.Value = StartDate;
                cmd.Parameters.Add(paramStartInvoiceDate);

                SqlParameter paramEndInvoiceDate = new SqlParameter();
                paramEndInvoiceDate.ParameterName = "@EndDate";
                paramEndInvoiceDate.Value = EndDate;
                cmd.Parameters.Add(paramEndInvoiceDate);

                SqlParameter paramCreatedBy = new SqlParameter();
                paramCreatedBy.ParameterName = "@CreatedBy";
                paramCreatedBy.Value = CreatedBy;
                cmd.Parameters.Add(paramCreatedBy);

                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    NotInvoicedSalesOrderList NotInvoicedSalesOrderList = new NotInvoicedSalesOrderList();

                    NotInvoicedSalesOrderList.S_No = rdr["RowNumber"].ToString();
                    NotInvoicedSalesOrderList.CustomerID = rdr["CUSTACCOUNT"].ToString();
                    NotInvoicedSalesOrderList.CustomerName = rdr["SALESNAME"].ToString();
                    NotInvoicedSalesOrderList.Branch = rdr["DEALFORBRANCH"].ToString();
                    NotInvoicedSalesOrderList.Group = rdr["CUSTGROUP"].ToString();
                    NotInvoicedSalesOrderList.NetAmount = rdr["ORDERNETAMOUNT"].ToString();
                    NotInvoicedSalesOrderList.WFSTATE = rdr["WORKFLOW STATUS"].ToString();
                    NotInvoicedSalesOrderList.SalesStatus = rdr["ORDER STATUS"].ToString();
                    NotInvoicedSalesOrderList.Address = rdr["ADDRESS"].ToString();
                    NotInvoicedSalesOrderList.SalesPriority = rdr["sales priority"].ToString();
                    NotInvoicedSalesOrderList.Region = rdr["Region"].ToString();
                    NotInvoicedSalesOrderList.Division = rdr["DIVISION"].ToString();
                    NotInvoicedSalesOrderList.ContactPerson = rdr["CONTACTPERSON"].ToString();
                    NotInvoicedSalesOrderList.DeliveryTerm = rdr["DLVTERM"].ToString();
                    NotInvoicedSalesOrderList.CreatedDate = rdr["OrderDate"].ToString();
                    NotInvoicedSalesOrderList.CreatedBy = rdr["CreatedBy"].ToString();
                    NotInvoicedSalesOrderList.ModifiedDate = rdr["ModifiedDate"].ToString();
                    NotInvoicedSalesOrderList.ModifiedBy = rdr["ModifiedBy"].ToString();

                    NotInvoicedSalesOrderList.Sales_Order_ID = rdr["SALESID"].ToString();
                    NotInvoicedSalesOrderList.DeliveryMode = rdr["DLVMODE"].ToString();
                    NotInvoicedSalesOrderList.Site = rdr["INVENTSITEID"].ToString();
                    NotInvoicedSalesOrderList.Warehouse = rdr["INVENTLOCATIONID"].ToString();
                    NotInvoicedSalesOrderList.SalespoolID = rdr["SALESPOOLID"].ToString();
                    NotInvoicedSalesOrderList.Payment = rdr["PAYMENT"].ToString();
                    NotInvoicedSalesOrderList.PaymMode = rdr["PAYMMODE"].ToString();

                    listNotInvoicedSalesOrder.Add(NotInvoicedSalesOrderList);
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
            return listNotInvoicedSalesOrder;
        }
    }
}