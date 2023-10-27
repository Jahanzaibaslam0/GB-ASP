using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace GB_ASP
{
    public class ListCollectionMonthWise
    {
    
        public string Date { get; set; }
        public string FTD { get; set; }
        public string PHD { get; set; }
        public string SPD { get; set; }
        public string AHD { get; set; }
        public string HHD { get; set; }
       

    }
    public class CollectionReportMonthWiseList
    {
        public static List<ListCollectionMonthWise> GetCollectionMonthWise(int pageIndex, int pageSize, string CustomerID, string CustName,string Group,string year,string division,string region,string Branch,string startDate,string EndDate, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<ListCollectionMonthWise> listCollectionMonthWise = new List<ListCollectionMonthWise>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CollectionReportMonthWise", con);
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
                paramCustName.Value = CustName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramGroup = new SqlParameter();
                paramGroup.ParameterName = "@Group";
                paramGroup.Value = Group;
                cmd.Parameters.Add(paramGroup);


                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramYear = new SqlParameter();
                paramYear.ParameterName = "@Year";
                paramYear.Value = year;
                cmd.Parameters.Add(paramYear);

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@DealForBranch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);

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
                    ListCollectionMonthWise CollectionMonthWise = new ListCollectionMonthWise();

                   // CollectionMonthWise.SerialNo = rdr["RowNumber"].ToString();
                    CollectionMonthWise.Date = rdr["DATE"].ToString();
                    CollectionMonthWise.FTD = rdr["FTD"].ToString();
                    CollectionMonthWise.PHD = rdr["PHD"].ToString();
                    CollectionMonthWise.SPD = rdr["SPD"].ToString();
                    CollectionMonthWise.AHD = rdr["AHD"].ToString();
                    CollectionMonthWise.HHD = rdr["HHD"].ToString();
                   
                    listCollectionMonthWise.Add(CollectionMonthWise);
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
            return listCollectionMonthWise;
        }

    }


    public class CollectionReportMonthWiseList2
    {
        public static List<ListCollectionMonthWise> GetCollectionMonthWise(int pageIndex, int pageSize, string CustomerID, string CustName, string Group, string year, string division, string region, string startDate, string EndDate, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<ListCollectionMonthWise> listCollectionMonthWise = new List<ListCollectionMonthWise>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CollectionReportMonthWise2", con);
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
                paramCustName.Value = CustName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramGroup = new SqlParameter();
                paramGroup.ParameterName = "@Group";
                paramGroup.Value = Group;
                cmd.Parameters.Add(paramGroup);


                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramYear = new SqlParameter();
                paramYear.ParameterName = "@Year";
                paramYear.Value = year;
                cmd.Parameters.Add(paramYear);

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@DealForBranch";
                //paramBranch.Value = Branch;
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
                    ListCollectionMonthWise CollectionMonthWise = new ListCollectionMonthWise();

                    // CollectionMonthWise.SerialNo = rdr["RowNumber"].ToString();
                    CollectionMonthWise.Date = rdr["DATE"].ToString();
                    CollectionMonthWise.FTD = rdr["FTD"].ToString();
                    CollectionMonthWise.PHD = rdr["PHD"].ToString();
                    CollectionMonthWise.SPD = rdr["SPD"].ToString();
                    CollectionMonthWise.AHD = rdr["AHD"].ToString();
                    CollectionMonthWise.HHD = rdr["HHD"].ToString();

                    listCollectionMonthWise.Add(CollectionMonthWise);
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
            return listCollectionMonthWise;
        }

    }
}