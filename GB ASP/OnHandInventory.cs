using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{

    public class OnHandInventoryList
    {
        public string S_No { get; set; }
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Group { get; set; }
        public string Inventory_Type { get; set; }
        public string Division { get; set; }
        public string Unit { get; set; }

        public string Batch { get; set; }
        public string Batch_Expiry { get; set; }
        public string Days_In_Expiry { get; set; }

        public string MDC { get; set; }
        public string GDC { get; set; }
        public string IDC { get; set; }
        public string AHDC { get; set; }
        public string KDC { get; set; }
        public string HDC { get; set; }
        public string PDC { get; set; }
        public string LDC { get; set; }
        public string FDC { get; set; }
        public string LHA { get; set; }
        public string KHO { get; set; }
        public string KPC { get; set; }
        public string ADJW { get; set; }
        public string RWP { get; set; }
        public string LTC { get; set; }
        public string KCC { get; set; }

    }
    public class OnHandInventory
    {
        public static List<OnHandInventoryList> GetOnHandInventory(int pageIndex, int pageSize, string StartDate, string EndDate, string ProductID, string ProductName,string ProductGroup,string InventoryType, string Batch, string Division, string Site, string Warehouse, string Sample, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<OnHandInventoryList> ListOnHandInventory = new List<OnHandInventoryList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("InventoryOnHand", con);
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

                SqlParameter paramBatch = new SqlParameter();
                paramBatch.ParameterName = "@Batch";
                paramBatch.Value = Batch;
                cmd.Parameters.Add(paramBatch);

                SqlParameter paramProductID = new SqlParameter();
                paramProductID.ParameterName = "@Product";
                paramProductID.Value = ProductID;
                cmd.Parameters.Add(paramProductID);


                SqlParameter paramProductName = new SqlParameter();
                paramProductName.ParameterName = "@ProductName";
                paramProductName.Value = ProductName;
                cmd.Parameters.Add(paramProductName);

                SqlParameter paramProductGroup = new SqlParameter();
                paramProductGroup.ParameterName = "@ProductGroup";
                paramProductGroup.Value = ProductGroup;
                cmd.Parameters.Add(paramProductGroup);

                SqlParameter paramItemInventory = new SqlParameter();
                paramItemInventory.ParameterName = "@ItemInventoryType";
                paramItemInventory.Value = InventoryType;
                cmd.Parameters.Add(paramItemInventory);


                SqlParameter paramSite = new SqlParameter();
                paramSite.ParameterName = "@Site";
                paramSite.Value = Site;
                cmd.Parameters.Add(paramSite);

                SqlParameter paramWarehouse = new SqlParameter();
                paramWarehouse.ParameterName = "@Warehouse";
                paramWarehouse.Value = Warehouse;
                cmd.Parameters.Add(paramWarehouse);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramSample = new SqlParameter();
                paramSample.ParameterName = "@Sample";
                paramSample.Value = Sample;
                cmd.Parameters.Add(paramSample);

  
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
                    OnHandInventoryList OnhandInventory = new OnHandInventoryList();

                    OnhandInventory.S_No = rdr["RowNumber"].ToString();
                    OnhandInventory.Product_ID = rdr["PRODUCTCODE"].ToString();
                    OnhandInventory.Product_Name = rdr["Product Name"].ToString();
                    OnhandInventory.Product_Group = rdr["Product Group"].ToString();
                    OnhandInventory.Inventory_Type = rdr["Item Inventory Type"].ToString();
                    OnhandInventory.Division = rdr["Division"].ToString();
                    OnhandInventory.Unit = rdr["unitid"].ToString();
                    OnhandInventory.Batch = rdr["INVENTBATCHID"].ToString();
                    OnhandInventory.Batch_Expiry = rdr["EXPDATE"].ToString();
                    OnhandInventory.Days_In_Expiry = rdr["DAYS IN EXPIRY"].ToString();
                    OnhandInventory.MDC = rdr["MDC"].ToString();
                    OnhandInventory.GDC = rdr["GDC"].ToString();
                    OnhandInventory.IDC = rdr["IDC"].ToString();
                    OnhandInventory.AHDC = rdr["AHDC"].ToString();
                    OnhandInventory.KDC = rdr["KDC"].ToString();
                    OnhandInventory.HDC = rdr["HDC"].ToString();
                    OnhandInventory.PDC = rdr["PDC"].ToString();
                    OnhandInventory.LDC = rdr["LDC"].ToString();
                    OnhandInventory.FDC = rdr["FDC"].ToString();
                    OnhandInventory.LHA = rdr["LHA"].ToString();
                    OnhandInventory.KHO = rdr["KHO"].ToString();
                    OnhandInventory.KPC = rdr["KPC"].ToString();
                    OnhandInventory.ADJW = rdr["ADJW"].ToString();
                    OnhandInventory.RWP = rdr["RWP"].ToString();
                    OnhandInventory.LTC = rdr["LTC"].ToString();
                    OnhandInventory.KCC = rdr["KCC"].ToString();
                    
                    ListOnHandInventory.Add(OnhandInventory);
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
            return ListOnHandInventory;
        }

    }
}