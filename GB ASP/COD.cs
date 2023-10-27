using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class CODlist
    {
        public string S_No { get; set; }
        public string Customer_Account { get; set; }
        public string Customer_Name { get; set; }
        public string DealForBranch { get; set; }
        public string TERMSOFPAYMENT { get; set; }
        public string Date { get; set; }
        public string SalesID { get; set; }
        public string InvoiceID { get; set; }

        public string InvoiceAmount { get; set; }
        public string Payment { get; set; }
        public string Balance { get; set; }
        public string Division { get; set; }
        public string OrderTaker { get; set; }
        
        public string Team { get; set; }
        public string Region { get; set; }
        public string CollectionStatus { get; set; }
        public string Reason { get; set; }
        public string ReasonComment { get; set; }
        
       
        

    }
    public class COD
    {
        public static List<CODlist> GetCODLIST(int pageIndex, int pageSize, string StartDate, string EndDate, string Branch, string CustID, string CustName,string InvoiceID, string SalesID, string Division, string Region, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CODlist> listCOD = new List<CODlist>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spCOD2", con);
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

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@DealForBranch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);


                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramSalesID = new SqlParameter();
                paramSalesID.ParameterName = "@SalesID";
                paramSalesID.Value = SalesID;
                cmd.Parameters.Add(paramSalesID);

                SqlParameter paramInvoiceID = new SqlParameter();
                paramInvoiceID.ParameterName = "@InvoiceID";
                paramInvoiceID.Value = InvoiceID;
                cmd.Parameters.Add(paramInvoiceID);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

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
                    CODlist COD = new CODlist();

                    COD.S_No = rdr["RowNumber"].ToString();
                    COD.Customer_Account = rdr["accountNum"].ToString();
                    COD.Customer_Name = rdr["CustomerName"].ToString();
                    COD.DealForBranch = rdr["DealForBranch"].ToString();
                    COD.SalesID = rdr["SalesID"].ToString();
                    COD.InvoiceID = rdr["invoice"].ToString();
                    COD.InvoiceAmount = rdr["InvoiceAmount"].ToString();
                    COD.Payment = rdr["SettleAmountCur"].ToString();
                    COD.Balance = rdr["Balance"].ToString();
                    COD.Date = rdr["TransDate"].ToString();
                    COD.TERMSOFPAYMENT = rdr["TERMSOFPAYMENT"].ToString();
                    COD.OrderTaker = rdr["ORDERTAKER"].ToString();
                    COD.Reason = rdr["REASON"].ToString();
                    COD.ReasonComment = rdr["REASONCOMMENT"].ToString();
                    COD.Division = rdr["Division"].ToString();
                    COD.Region = rdr["Region"].ToString();
                    
                    COD.Team = rdr["Team"].ToString();
                    COD.CollectionStatus = rdr["COLLECTION STATUS"].ToString();


                    listCOD.Add(COD);
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
            return listCOD;
        }



    }


    public class COD2
    {
        public static List<CODlist> GetCODLIST(int pageIndex, int pageSize, string StartDate, string EndDate,  string CustID, string CustName, string InvoiceID, string SalesID, string Division, string Region, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CODlist> listCOD = new List<CODlist>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spCOD2", con);
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

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@DealForBranch";
                //paramBranch.Value = Branch;
                //cmd.Parameters.Add(paramBranch);


                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramSalesID = new SqlParameter();
                paramSalesID.ParameterName = "@SalesID";
                paramSalesID.Value = SalesID;
                cmd.Parameters.Add(paramSalesID);

                SqlParameter paramInvoiceID = new SqlParameter();
                paramInvoiceID.ParameterName = "@InvoiceID";
                paramInvoiceID.Value = InvoiceID;
                cmd.Parameters.Add(paramInvoiceID);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

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
                    CODlist COD = new CODlist();

                    COD.S_No = rdr["RowNumber"].ToString();
                    COD.Customer_Account = rdr["accountNum"].ToString();
                    COD.Customer_Name = rdr["CustomerName"].ToString();
                    COD.DealForBranch = rdr["DealForBranch"].ToString();
                    COD.SalesID = rdr["SalesID"].ToString();
                    COD.InvoiceID = rdr["invoice"].ToString();
                    COD.InvoiceAmount = rdr["InvoiceAmount"].ToString();
                    COD.Payment = rdr["SettleAmountCur"].ToString();
                    COD.Balance = rdr["Balance"].ToString();
                    COD.Date = rdr["TransDate"].ToString();
                    COD.TERMSOFPAYMENT = rdr["TERMSOFPAYMENT"].ToString();
                    COD.OrderTaker = rdr["ORDERTAKER"].ToString();
                    COD.Reason = rdr["REASON"].ToString();
                    COD.ReasonComment = rdr["REASONCOMMENT"].ToString();
                    COD.Division = rdr["Division"].ToString();
                    COD.Region = rdr["Region"].ToString();

                    COD.Team = rdr["Team"].ToString();
                    COD.CollectionStatus = rdr["COLLECTION STATUS"].ToString();


                    listCOD.Add(COD);
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
            return listCOD;
        }



    }
}