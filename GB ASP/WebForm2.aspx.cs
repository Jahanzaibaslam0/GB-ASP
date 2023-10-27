using GB_ASP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GB_ASP
{

    public partial class WebForm2 : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string connectionStr = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";//ConfigurationManager .ConnectionStrings["connectionStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spNetSalesReport";
                cmd.CommandType = CommandType.StoredProcedure;

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
                SqlDataReader rdr = cmd.ExecuteReader();
                gvSearchResults.DataSource = rdr;
                gvSearchResults.DataBind();
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionStr = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";//ConfigurationManager .ConnectionStrings["connectionStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spNetSalesReport";
                cmd.CommandType = CommandType.StoredProcedure;

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
                SqlDataReader rdr = cmd.ExecuteReader();
                gvSearchResults.DataSource = rdr;
                gvSearchResults.DataBind();
                con.Close();
            }

        }
    }
}