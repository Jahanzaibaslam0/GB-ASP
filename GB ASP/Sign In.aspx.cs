using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public partial class Sign_In : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

             //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GBAX12ConnectionString"].ToString());

                con.Open();
                string query = "select * from employeeUser where UserID='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "' ";

                SqlCommand cmd = new SqlCommand(query, con);
                string output = cmd.ExecuteScalar().ToString();

                if (output !="")
                {
                    Session["User"] = txtUserName.Text;
                    Response.Redirect("~/AllCustomer.aspx");


                }
                else
                {
                    Response.Write("~/Sign In.aspx");
                }

            }
        }
    }
