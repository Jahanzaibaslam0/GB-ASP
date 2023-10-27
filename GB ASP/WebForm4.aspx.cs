using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace GB_ASP
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private void BindGrid()
        {
            string connectionStr = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";//ConfigurationManager .ConnectionStrings["connectionStr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spSalesReport";
                cmd.CommandType = CommandType.StoredProcedure;

                //if (inputend.Value.Trim() != "")
                //{
                //    SqlParameter param = new SqlParameter
                //        ("@maximumrows", inputend.Value);
                //    cmd.Parameters.Add(param);
                //}

                

                if (inputProductName.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@ProductName", inputProductName.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputProductCode.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@ProductCode", inputProductCode.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputDivision.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@Division", inputDivision.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputRegion.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter
                        ("@Region", inputRegion.Value);
                    cmd.Parameters.Add(param);
                }

                con.Open();
                // SqlDataReader rdr = cmd.ExecuteReader();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
        }


        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.BindGrid();

        }
    }
}