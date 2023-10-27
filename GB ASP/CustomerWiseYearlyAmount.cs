using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class CustomerYearlySalesAmountList
    {
        public string S_NO { get; set; }
        public string CUSTOMER_ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string YEAR_2014 { get; set; }
        public string YEAR_2015 { get; set; }
        public string YEAR_2016 { get; set; }
        public string YEAR_2017 { get; set; }
        public string YEAR_2018 { get; set; }
        public string YEAR_2019 { get; set; }
        public string YEAR_2020 { get; set; }
        public string TOTAL_REVENUE { get; set; }

    }
    public class CustomerWiseYearlyAmount
    {
        public static List<CustomerYearlySalesAmountList> GetCustomerWiseYearlySalesAmount(int pageIndex, int pageSize, string CustomerID, string CustomerName, string Region, string Division, string Branch, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustomerYearlySalesAmountList> listCustomerWiseYearlySalesAmount = new List<CustomerYearlySalesAmountList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustomerWiseYearlyAmount", con);
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

                SqlParameter paramCustomerID = new SqlParameter();
                paramCustomerID.ParameterName = "@Customer";
                paramCustomerID.Value = CustomerID;
                cmd.Parameters.Add(paramCustomerID);


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustomerName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@Branch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);



                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CustomerYearlySalesAmountList YearlySalesAmount = new CustomerYearlySalesAmountList();

                    YearlySalesAmount.S_NO = rdr["RowNumber"].ToString();
                    //DivisionWiseBalance.COMPANY = rdr["DATAAREAID"].ToString();
                    YearlySalesAmount.CUSTOMER_ID = rdr["CUSTOMER ACCOUNT"].ToString();
                    YearlySalesAmount.CUSTOMER_NAME = rdr["CUSTOMER NAME"].ToString();

                    YearlySalesAmount.YEAR_2014 = rdr["2014"].ToString();
                    YearlySalesAmount.YEAR_2015 = rdr["2015"].ToString();
                    YearlySalesAmount.YEAR_2016 = rdr["2016"].ToString();
                    YearlySalesAmount.YEAR_2017 = rdr["2017"].ToString();
                    YearlySalesAmount.YEAR_2018 = rdr["2018"].ToString();
                    YearlySalesAmount.YEAR_2019 = rdr["2019"].ToString();
                    YearlySalesAmount.YEAR_2020 = rdr["2020"].ToString();
                    YearlySalesAmount.TOTAL_REVENUE = rdr["REVENUE"].ToString();

                    listCustomerWiseYearlySalesAmount.Add(YearlySalesAmount);
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
            return listCustomerWiseYearlySalesAmount;
        }


    }


    public class CustomerWiseYearlyAmount2
    {
        public static List<CustomerYearlySalesAmountList> GetCustomerWiseYearlySalesAmount(int pageIndex, int pageSize, string CustomerID, string CustomerName, string Region, string Division, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustomerYearlySalesAmountList> listCustomerWiseYearlySalesAmount = new List<CustomerYearlySalesAmountList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustomerWiseYearlyAmount2", con);
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

                SqlParameter paramCustomerID = new SqlParameter();
                paramCustomerID.ParameterName = "@Customer";
                paramCustomerID.Value = CustomerID;
                cmd.Parameters.Add(paramCustomerID);


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustomerName;
                cmd.Parameters.Add(paramCustName);

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@Branch";
                //paramBranch.Value = Branch;
                //cmd.Parameters.Add(paramBranch);

                SqlParameter paramRegion = new SqlParameter();
                paramRegion.ParameterName = "@Region";
                paramRegion.Value = Region;
                cmd.Parameters.Add(paramRegion);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);



                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CustomerYearlySalesAmountList YearlySalesAmount = new CustomerYearlySalesAmountList();

                    YearlySalesAmount.S_NO = rdr["RowNumber"].ToString();
                    //DivisionWiseBalance.COMPANY = rdr["DATAAREAID"].ToString();
                    YearlySalesAmount.CUSTOMER_ID = rdr["CUSTOMER ACCOUNT"].ToString();
                    YearlySalesAmount.CUSTOMER_NAME = rdr["CUSTOMER NAME"].ToString();

                    YearlySalesAmount.YEAR_2014 = rdr["2014"].ToString();
                    YearlySalesAmount.YEAR_2015 = rdr["2015"].ToString();
                    YearlySalesAmount.YEAR_2016 = rdr["2016"].ToString();
                    YearlySalesAmount.YEAR_2017 = rdr["2017"].ToString();
                    YearlySalesAmount.YEAR_2018 = rdr["2018"].ToString();
                    YearlySalesAmount.YEAR_2019 = rdr["2019"].ToString();
                    YearlySalesAmount.YEAR_2020 = rdr["2020"].ToString();
                    YearlySalesAmount.TOTAL_REVENUE = rdr["REVENUE"].ToString();

                    listCustomerWiseYearlySalesAmount.Add(YearlySalesAmount);
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
            return listCustomerWiseYearlySalesAmount;
        }


    }

}