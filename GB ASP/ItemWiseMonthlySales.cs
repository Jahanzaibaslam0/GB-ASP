using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class ItemWiseMonthlySalesList
    {
        public string SerialNo { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string Jan { get; set; }
        public string Feb { get; set; }
        public string Mar { get; set; }
        public string April { get; set; }
        public string May { get; set; }
        public string Jun { get; set; }
        public string Jul { get; set; }
        public string Aug { get; set; }
        public string Sep { get; set; }
        public string Oct { get; set; }
        public string Nov { get; set; }
        public string Dec { get; set; }
        public string Total { get; set; }

    }

    public class ItemWiseMonthlySales
    {
        public static List<ItemWiseMonthlySalesList> GetMonthWiseItemSales(int pageIndex, int pageSize, string Itemid,string itemName, string Region, string Division, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<ItemWiseMonthlySalesList> listitemWise = new List<ItemWiseMonthlySalesList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spMonthWiseItemSales", con);
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
                paramCustomerCode.ParameterName = "@Itemid";
                paramCustomerCode.Value = Itemid;
                cmd.Parameters.Add(paramCustomerCode);

                SqlParameter paramItemName = new SqlParameter();
                paramItemName.ParameterName = "@ItemName";
                paramItemName.Value = itemName;
                cmd.Parameters.Add(paramItemName);


                SqlParameter paramStatus = new SqlParameter();
                paramStatus.ParameterName = "@Region";
                paramStatus.Value = Region;
                cmd.Parameters.Add(paramStatus);


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
                    ItemWiseMonthlySalesList itemWiseMonthlySales = new ItemWiseMonthlySalesList();

                    itemWiseMonthlySales.SerialNo = rdr["RowNumber"].ToString();
                    itemWiseMonthlySales.ItemID = rdr["ITEMID"].ToString();
                    itemWiseMonthlySales.ItemName = rdr["ITEMNAME"].ToString();
                    itemWiseMonthlySales.Jan = rdr["JAN"].ToString();
                    itemWiseMonthlySales.Feb = rdr["FEB"].ToString();
                    itemWiseMonthlySales.Mar = rdr["MAR"].ToString();
                    itemWiseMonthlySales.April = rdr["APR"].ToString();
                    itemWiseMonthlySales.May = rdr["MAY"].ToString();
                    itemWiseMonthlySales.Jun = rdr["JUN"].ToString();
                    itemWiseMonthlySales.Jul = rdr["JUL"].ToString();
                    itemWiseMonthlySales.Aug = rdr["AUG"].ToString();
                    itemWiseMonthlySales.Sep = rdr["SEP"].ToString();
                    itemWiseMonthlySales.Oct = rdr["OCT"].ToString();
                    itemWiseMonthlySales.Nov = rdr["NOV"].ToString();
                    itemWiseMonthlySales.Dec = rdr["DEC"].ToString();
                    itemWiseMonthlySales.Total = rdr["TOTAL"].ToString();



                    listitemWise.Add(itemWiseMonthlySales);
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
            return listitemWise;
        }

    }
}