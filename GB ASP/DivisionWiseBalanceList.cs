using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{

    public class DivisionWiseBalanceReportList    {
        public string S_NO { get; set; }
        public string CUSTOMER_ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string BRANCH { get; set; }
        public string GROUP { get; set; }
        public string DIVISION { get; set; }
        public string BALANCEWITHPDC { get; set; }
        public string POSTDATEDAMOUNT { get; set; }
        public string BALANCEWITHOUTPDC { get; set; }

    }

    public class DivisionWiseBalanceList
    {

        public static List<DivisionWiseBalanceReportList> GetDivisionWiseBalanceReport(int pageIndex, int pageSize, string Company,  string CustID, string CustName,string Group, string Branch, string Division, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<DivisionWiseBalanceReportList> listDivisionWiseBalanceReport = new List<DivisionWiseBalanceReportList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PdcBalances", con);
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

                SqlParameter paramGroup = new SqlParameter();
                paramGroup.ParameterName = "@CustomerGroup";
                paramGroup.Value = Group;
                cmd.Parameters.Add(paramGroup);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramCompany = new SqlParameter();
                paramCompany.ParameterName = "@Company";
                paramCompany.Value = Company;
                cmd.Parameters.Add(paramCompany);


                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DivisionWiseBalanceReportList DivisionWiseBalance = new DivisionWiseBalanceReportList();

                    DivisionWiseBalance.S_NO = rdr["RowNumber"].ToString();
                    //DivisionWiseBalance.COMPANY = rdr["DATAAREAID"].ToString();
                    DivisionWiseBalance.CUSTOMER_ID = rdr["ACCOUNTNUM"].ToString();
                    DivisionWiseBalance.CUSTOMER_NAME = rdr["CUSTOMERNAME"].ToString();
                    DivisionWiseBalance .BRANCH= rdr["DEAL FOR BRANCH"].ToString();
                    DivisionWiseBalance.GROUP = rdr["CUSTOMER GROUP"].ToString();
                    DivisionWiseBalance.DIVISION = rdr["DIVISION"].ToString();
                    DivisionWiseBalance.BALANCEWITHPDC = rdr["BALANCE"].ToString();
                    DivisionWiseBalance.POSTDATEDAMOUNT = rdr["POST DATED AMOUNT"].ToString();
                    DivisionWiseBalance.BALANCEWITHOUTPDC = rdr["BALANCE WITHOUT PDC"].ToString();
                    

                    listDivisionWiseBalanceReport.Add(DivisionWiseBalance);
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

            }
            return listDivisionWiseBalanceReport;
        }


    }

    public class DivisionWiseBalanceList2
    {

        public static List<DivisionWiseBalanceReportList> GetDivisionWiseBalanceReport(int pageIndex, int pageSize, string Company, string CustID, string CustName, string Group, string Division, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<DivisionWiseBalanceReportList> listDivisionWiseBalanceReport = new List<DivisionWiseBalanceReportList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PdcBalances2", con);
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

                SqlParameter paramGroup = new SqlParameter();
                paramGroup.ParameterName = "@CustomerGroup";
                paramGroup.Value = Group;
                cmd.Parameters.Add(paramGroup);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramCompany = new SqlParameter();
                paramCompany.ParameterName = "@Company";
                paramCompany.Value = Company;
                cmd.Parameters.Add(paramCompany);


                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DivisionWiseBalanceReportList DivisionWiseBalance = new DivisionWiseBalanceReportList();

                    DivisionWiseBalance.S_NO = rdr["RowNumber"].ToString();
                    //DivisionWiseBalance.COMPANY = rdr["DATAAREAID"].ToString();
                    DivisionWiseBalance.CUSTOMER_ID = rdr["ACCOUNTNUM"].ToString();
                    DivisionWiseBalance.CUSTOMER_NAME = rdr["CUSTOMERNAME"].ToString();
                    DivisionWiseBalance.BRANCH = rdr["DEAL FOR BRANCH"].ToString();
                    DivisionWiseBalance.GROUP = rdr["CUSTOMER GROUP"].ToString();
                    DivisionWiseBalance.DIVISION = rdr["DIVISION"].ToString();
                    DivisionWiseBalance.BALANCEWITHPDC = rdr["BALANCE"].ToString();
                    DivisionWiseBalance.POSTDATEDAMOUNT = rdr["POST DATED AMOUNT"].ToString();
                    DivisionWiseBalance.BALANCEWITHOUTPDC = rdr["BALANCE WITHOUT PDC"].ToString();


                    listDivisionWiseBalanceReport.Add(DivisionWiseBalance);
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

            }
            return listDivisionWiseBalanceReport;
        }


    }
}