using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class ItemWiseYearlySalesAmountList
    {
        public string S_NO { get; set; }
        public string ITEM_ID { get; set; }
        public string ITEM_NAME { get; set; }

        public string YEAR_2014 { get; set; }
        public string YEAR_2015 { get; set; }
        public string YEAR_2016 { get; set; }
        public string YEAR_2017 { get; set; }
        public string YEAR_2018 { get; set; }
        public string YEAR_2019 { get; set; }
        public string YEAR_2020 { get; set; }

        public string TOTAL_REVENUE { get; set; }

    }
    public class ItemWiseYearlySalesAmount
    {
        public static List<ItemWiseYearlySalesAmountList> GetItemWiseYearlySalesAmount(int pageIndex, int pageSize, string Itemid, string itemName, string Region, string Division, string Team, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<ItemWiseYearlySalesAmountList> listItemWiseYearlySalesAmount = new List<ItemWiseYearlySalesAmountList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("ItemWiseYearlySalesAmount", con);
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

                SqlParameter paramItemID = new SqlParameter();
                paramItemID.ParameterName = "@ItemID";
                paramItemID.Value = Itemid;
                cmd.Parameters.Add(paramItemID);


                SqlParameter paramItemName = new SqlParameter();
                paramItemName.ParameterName = "@ItemName";
                paramItemName.Value = itemName;
                cmd.Parameters.Add(paramItemName);

                SqlParameter paramTeam = new SqlParameter();
                paramTeam.ParameterName = "@Team";
                paramTeam.Value = Team;
                cmd.Parameters.Add(paramTeam);

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
                    ItemWiseYearlySalesAmountList YearlySalesAmount = new ItemWiseYearlySalesAmountList();

                    YearlySalesAmount.S_NO = rdr["RowNumber"].ToString();
                    //DivisionWiseBalance.COMPANY = rdr["DATAAREAID"].ToString();
                    YearlySalesAmount.ITEM_ID = rdr["ITEMID"].ToString();
                    YearlySalesAmount.ITEM_NAME = rdr["ITEMNAME"].ToString();
                   
                    YearlySalesAmount.YEAR_2014 = rdr["2014"].ToString();
                    YearlySalesAmount.YEAR_2015 = rdr["2015"].ToString();
                    YearlySalesAmount.YEAR_2016 = rdr["2016"].ToString();
                    YearlySalesAmount.YEAR_2017 = rdr["2017"].ToString();
                    YearlySalesAmount.YEAR_2018 = rdr["2018"].ToString();
                    YearlySalesAmount.YEAR_2019 = rdr["2019"].ToString();
                    YearlySalesAmount.YEAR_2020 = rdr["2020"].ToString();
                    YearlySalesAmount.TOTAL_REVENUE = rdr["REVENUE"].ToString();

                    listItemWiseYearlySalesAmount.Add(YearlySalesAmount);
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
            return listItemWiseYearlySalesAmount;
        }


    }
}