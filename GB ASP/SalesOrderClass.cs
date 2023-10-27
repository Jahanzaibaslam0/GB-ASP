using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class AllSalesOrderList
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
        public string Hold { get; set; }
        public string Address { get; set; }
        public string SalesPriority { get; set; }
        public string Payment { get; set; }
        public string PaymMode { get; set; }
        public string ContactPerson { get; set; }
        
        public string Division { get; set; }
        public string Region { get; set; }
       
    }

    public class SalesOrderClass
    { 
    public static List<AllSalesOrderList> GetAllSalesOrder(int pageIndex, int pageSize,string Status,string hold,string Branch,string StartDate,string EndDate ,string CreatedBy, string CustomerID, string CustomerName, string SalesOrder, string Division, string Region, out int totalRows)
    {
            // Replace square brackets with angular brackets
            List<AllSalesOrderList> listAllSalesOrder = new List<AllSalesOrderList>();

        string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spSalesOrder1", con);
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

            SqlParameter paramStatus = new SqlParameter();
            paramStatus.ParameterName = "@Status";
            paramStatus.Value = Status;
            cmd.Parameters.Add(paramStatus);

            SqlParameter paramHold = new SqlParameter();
            paramHold.ParameterName = "@Hold";
            paramHold.Value = hold;
            cmd.Parameters.Add(paramHold);

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
            paramBranch.ParameterName = "@DealForBranch";
            paramBranch.Value = Branch;
            cmd.Parameters.Add(paramBranch);

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
                    AllSalesOrderList SalesOrderList = new AllSalesOrderList();

                    SalesOrderList.S_No = rdr["RowNumber"].ToString();
                    SalesOrderList.CustomerID = rdr["CUSTACCOUNT"].ToString();
                    SalesOrderList.CustomerName = rdr["CustomerName"].ToString();
                    SalesOrderList.Branch = rdr["DEALFORBRANCH"].ToString();
                    SalesOrderList.Group = rdr["CUSTGROUP"].ToString();
                    SalesOrderList.NetAmount = rdr["ORDERNETAMOUNT"].ToString();
                    SalesOrderList.Hold = rdr["Hold"].ToString();
                    SalesOrderList.WFSTATE = rdr["WORKFLOW STATUS"].ToString();
                    SalesOrderList.SalesStatus = rdr["ORDER STATUS"].ToString();
                    SalesOrderList.Address = rdr["ADDRESS"].ToString();
                    SalesOrderList.SalesPriority = rdr["sales priority"].ToString();
                    SalesOrderList.Region = rdr["Region"].ToString();
                    SalesOrderList.Division = rdr["DIVISION"].ToString();
                    SalesOrderList.ContactPerson = rdr["CONTACTPERSON"].ToString();
                    SalesOrderList.DeliveryTerm = rdr["DLVTERM"].ToString();
                    SalesOrderList.CreatedDate = rdr["OrderDate"].ToString();
                    SalesOrderList.CreatedBy = rdr["CreatedBy"].ToString();
                    SalesOrderList.ModifiedDate = rdr["ModifiedDate"].ToString();
                    SalesOrderList.ModifiedBy = rdr["ModifiedBy"].ToString();

                    SalesOrderList.Sales_Order_ID = rdr["SALESID"].ToString();
                    SalesOrderList.DeliveryMode = rdr["DLVMODE"].ToString();
                    SalesOrderList.Site = rdr["INVENTSITEID"].ToString();
                    SalesOrderList.Warehouse = rdr["INVENTLOCATIONID"].ToString();
                    SalesOrderList.SalespoolID = rdr["SALESPOOLID"].ToString();
                    SalesOrderList.Payment = rdr["PAYMENT"].ToString();
                    SalesOrderList.PaymMode = rdr["PAYMMODE"].ToString();

                    listAllSalesOrder.Add(SalesOrderList);
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
        return listAllSalesOrder;
    }
}


    public class SalesOrderClass2
    {
        public static List<AllSalesOrderList> GetAllSalesOrder(int pageIndex, int pageSize, string Status, string hold, string StartDate, string EndDate, string CreatedBy, string CustomerID, string CustomerName, string SalesOrder, string Division, string Region, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<AllSalesOrderList> listAllSalesOrder = new List<AllSalesOrderList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spSalesOrder12", con);
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

                SqlParameter paramStatus = new SqlParameter();
                paramStatus.ParameterName = "@Status";
                paramStatus.Value = Status;
                cmd.Parameters.Add(paramStatus);

                SqlParameter paramHold = new SqlParameter();
                paramHold.ParameterName = "@Hold";
                paramHold.Value = hold;
                cmd.Parameters.Add(paramHold);

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
                    AllSalesOrderList SalesOrderList = new AllSalesOrderList();

                    SalesOrderList.S_No = rdr["RowNumber"].ToString();
                    SalesOrderList.CustomerID = rdr["CUSTACCOUNT"].ToString();
                    SalesOrderList.CustomerName = rdr["SALESNAME"].ToString();
                    SalesOrderList.Branch = rdr["DEALFORBRANCH"].ToString();
                    SalesOrderList.Group = rdr["CUSTGROUP"].ToString();
                    SalesOrderList.NetAmount = rdr["ORDERNETAMOUNT"].ToString();
                    SalesOrderList.Hold = rdr["Hold"].ToString();
                    SalesOrderList.WFSTATE = rdr["WORKFLOW STATUS"].ToString();
                    SalesOrderList.SalesStatus = rdr["ORDER STATUS"].ToString();
                    SalesOrderList.Address = rdr["ADDRESS"].ToString();
                    SalesOrderList.SalesPriority = rdr["sales priority"].ToString();
                    SalesOrderList.Region = rdr["Region"].ToString();
                    SalesOrderList.Division = rdr["DIVISION"].ToString();
                    SalesOrderList.ContactPerson = rdr["CONTACTPERSON"].ToString();
                    SalesOrderList.DeliveryTerm = rdr["DLVTERM"].ToString();
                    SalesOrderList.CreatedDate = rdr["OrderDate"].ToString();
                    SalesOrderList.CreatedBy = rdr["CreatedBy"].ToString();
                    SalesOrderList.ModifiedDate = rdr["ModifiedDate"].ToString();
                    SalesOrderList.ModifiedBy = rdr["ModifiedBy"].ToString();

                    SalesOrderList.Sales_Order_ID = rdr["SALESID"].ToString();
                    SalesOrderList.DeliveryMode = rdr["DLVMODE"].ToString();
                    SalesOrderList.Site = rdr["INVENTSITEID"].ToString();
                    SalesOrderList.Warehouse = rdr["INVENTLOCATIONID"].ToString();
                    SalesOrderList.SalespoolID = rdr["SALESPOOLID"].ToString();
                    SalesOrderList.Payment = rdr["PAYMENT"].ToString();
                    SalesOrderList.PaymMode = rdr["PAYMMODE"].ToString();

                    listAllSalesOrder.Add(SalesOrderList);
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
            return listAllSalesOrder;
        }
    }
}