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
    public partial class SignIn : System.Web.UI.Page
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

            if (output != "")
            {
                Session["User"] = txtUserName.Text.ToUpper();

                /////////////////////////////////////    FTD   /////////////////////////////////////

                if(txtUserName.Text.ToUpper()=="MUDASSIR.G")
                {
                    Session["Division"] = "FEED TECH DIVISION";
                    Session["Region"] = "KARACHI-FTD";
                    Session["Division1"] = "FTD";
                    Session["Division2"] = "'FEED TECH DIVISION'";
                    Session["Branch"] = "KHO,HDC";
                    Session["Branch1"] = "'KHO','HDC'";
                }
                

                else if (txtUserName.Text.ToUpper() == "M.IMRAN")
                {
                    Session["Division"] = "FEED TECH DIVISION";
                    Session["Division2"] = "'FEED TECH DIVISION'";
                    Session["Region"] = "GUJRANWALA-FTD";
                    Session["Division1"] = "FTD";
                    Session["Branch"] = "GDC";
                    Session["Branch1"] = "'GDC'";
                }

                else if (txtUserName.Text.ToUpper() == "SALMAN.A")
                {
                    Session["Division"] = "FEED TECH DIVISION";
                    Session["Division2"] = "'FEED TECH DIVISION'";
                    Session["Region"] = "MULTAN-FTD";
                    Session["Division1"] = "FTD";
                    Session["Branch"] = "MDC";
                    Session["Branch1"] = "'MDC'";
                }

                else if (txtUserName.Text.ToUpper() == "HAFIZ.KAM")
                {
                    Session["Division"] = "FEED TECH DIVISION";
                    Session["Division2"] = "'FEED TECH DIVISION'";
                    Session["Region"] = "LAHORE-FTD";
                    Session["Division1"] = "FTD";
                    Session["Branch"] = "LDC";
                    Session["Branch1"] = "'LDC'";
                }
                else if (txtUserName.Text.ToUpper() == "FAISAL.M")
                {
                    Session["Division"] = "FEED TECH DIVISION";
                    Session["Division2"] = "'FEED TECH DIVISION'";
                    Session["Region"] = "RAWALPINDI-FTD";
                    Session["Division1"] = "FTD";
                    Session["Branch"] = "IDC";
                    Session["Branch1"] = "'IDC'";
                }

                else if (txtUserName.Text.ToUpper() == "ARIF.YOUSU")
                {
                    Session["Division"] = "FEED TECH DIVISION";
                    Session["Division2"] = "'FEED TECH DIVISION'";
                    Session["Region"] = "FAISALABAD-FTD";
                    Session["Division1"] = "FTD";
                    Session["Branch"] = "FDC";
                    Session["Branch1"] = "'FDC'";
                }

/////////////////////////////////////    SPD/PHD TEAM KARACHI   /////////////////////////////////////

                else if (txtUserName.Text.ToUpper() == "ARSHAD.A")
                {
                    Session["Division"] = "SPECIALITY PRODUCT DIVISION";
                    Session["Division2"] = "'SPECIALITY PRODUCT DIVISION'";
                    Session["Region"] = "KARACHI-SPD";
                    Session["Division1"] = "SPD";
                    Session["Branch"] = "KHO";
                }

                else if (txtUserName.Text.ToUpper() == "AMIR.SHAH")
                {
                    Session["Division"] = "POULTRY HEALTH DIVISION";
                    Session["Division2"] = "'POULTRY HEALTH DIVISION'";
                    Session["Region"] = "KARACHI-FTD";
                    Session["Division1"] = "PHD";
                    Session["Branch"] = "KHO,HDC";
                    Session["Branch1"] = "'KHO','HDC'";
                }

/////////////////////////////////////    PHD TEAM A   /////////////////////////////////////
                else if (txtUserName.Text.ToUpper() == "ZULFIQAR.A")
                {
                    Session["Division"] = "POULTRY HEALTH DIVISION";
                    Session["Division2"] = "'POULTRY HEALTH DIVISION'";
                    Session["Region"] = "RAWALPINDI-PHD";
                    Session["Division1"] = "PHD";
                    Session["Branch"] = "IDC";
                    Session["Branch1"] = "'IDC'";
                }

                else if (txtUserName.Text.ToUpper() == "ADIL.AMJAD")
                {
                    Session["Division"] = "POULTRY HEALTH DIVISION";
                    Session["Division2"] = "'POULTRY HEALTH DIVISION'";
                    Session["Region"] = "MULTAN-PHD";
                    Session["Division1"] = "PHD";
                    Session["Branch"] = "MDC";
                    Session["Branch1"] = "'MDC'";
                }

                else if (txtUserName.Text.ToUpper() == "NAEEM.A")
                {
                    Session["Division"] = "POULTRY HEALTH DIVISION";
                    Session["Division2"] = "'POULTRY HEALTH DIVISION'";
                    Session["Region"] = "GUJRANWALA-PHD";
                    Session["Division1"] = "PHD";
                    Session["Branch"] = "GDC";
                    Session["Branch1"] = "'GDC'";
                }

                else if (txtUserName.Text.ToUpper() == "OMARSHARIF")
                {
                    Session["Division"] = "POULTRY HEALTH DIVISION";
                    Session["Division2"] = "'POULTRY HEALTH DIVISION'";
                    Session["Region"] = "FAISALABAD-PHD";
                    Session["Division1"] = "PHD";
                    Session["Branch"] = "FDC";
                    Session["Branch1"] = "'FDC'";
                }

                else if (txtUserName.Text.ToUpper() == "ZIA.REHMAN")
                {
                    Session["Division"] = "POULTRY HEALTH DIVISION";
                    Session["Division2"] = "'POULTRY HEALTH DIVISION'";
                    Session["Region"] = "LAHORE-PHD";
                    Session["Division1"] = "PHD";
                    Session["Branch"] = "LDC";
                    Session["Branch1"] = "'LDC'";
                }
                /////////////////////////////////////    PHD TEAM B   /////////////////////////////////////
                else if (txtUserName.Text.ToUpper() == "AABIS.RAZA")
                {
                    Session["Division"] = "SPECIALITY PRODUCT DIVISION";
                    Session["Division2"] = "'SPECIALITY PRODUCT DIVISION'";
                    Session["Region"] = "LAHORE-SPD";
                    Session["Division1"] = "SPD";
                    Session["Branch"] = "LDC";
                    Session["Branch1"] = "'LDC'";
                }

                else if (txtUserName.Text.ToUpper() == "DR.AHSAN")
                {
                    Session["Division"] = "SPECIALITY PRODUCT DIVISION";
                    Session["Division2"] = "'SPECIALITY PRODUCT DIVISION'";
                    Session["Region"] = "FAISALABAD-SPD";
                    Session["Division1"] = "SPD";
                    Session["Branch"] = "FDC";
                    Session["Branch1"] = "'FDC'";
                }

                else if (txtUserName.Text.ToUpper() == "AWAISIMRAN")
                {
                    Session["Division"] = "SPECIALITY PRODUCT DIVISION";
                    Session["Division2"] = "'SPECIALITY PRODUCT DIVISION'";
                    Session["Region"] = "RAWALPINDI-SPD";
                    Session["Division1"] = "SPD";
                    Session["Branch"] = "IDC";
                    Session["Branch1"] = "'IDC'";
                }
                else if (txtUserName.Text.ToUpper() == "RAMZAN.M")
                {
                    Session["Division"] = "SPECIALITY PRODUCT DIVISION";
                    Session["Division2"] = "'SPECIALITY PRODUCT DIVISION'";
                    Session["Region"] = "MULTAN-SPD";
                    Session["Division1"] = "SPD";
                    Session["Branch"] = "MDC";
                    Session["Branch1"] = "'MDC'";
                }
                else if (txtUserName.Text.ToUpper() == "TEHSEEN.A")
                {
                    Session["Division"] = "SPECIALITY PRODUCT DIVISION";
                    Session["Division2"] = "'SPECIALITY PRODUCT DIVISION'";
                    Session["Region"] = "HYDERADAD-SPD";
                    Session["Division1"] = "SPD";
                    Session["Branch"] = "KHO";
                    Session["Branch1"] = "'KHO'";
                }
                /////////////////////////////////////    DIVISION AHD   /////////////////////////////////////

                else if(txtUserName.Text.ToUpper() == "AHD")
                {
                    Session["Division"] = "ANIMAL HEALTH DIVISION";
                    Session["Division2"] = "'ANIMAL HEALTH DIVISION'";
                    Session["Division1"] = "AHD";
                    Session["Branch"] = "KHO,HDC,LDC,MDC,FDC,GDC";
                }

                else if (txtUserName.Text.ToUpper() == "ADMIN")
                {
                    Session["Division"] = "'ANIMAL HEALTH DIVISION','FEED TECH DIVISION','HUMAN HEALTH DIVISION','POULTRY HEALTH DIVISION', 'SPECIALITY PRODUCT DIVISION'";
                    Session["Division2"] = "ANIMAL HEALTH DIVISION,FEED TECH DIVISION,HUMAN HEALTH DIVISION,POULTRY HEALTH DIVISION, SPECIALITY PRODUCT DIVISION";
                    Session["Division1"] = "AHD,FTD,SPD,HHD,PHD";
                    Session["Branch"] = "KHO,HDC,LDC,MDC,FDC,GDC";
                    Session["Region"] = "KARACHI-FTD";
                    Session["Branch1"] = "'KHO','HDC','LDC','FDC','PDC','KDC','IDC','MDC','GDC'";
                }
                Response.Redirect("~/OpenCustomerInvoice.aspx");


            }
            else
            {
                Response.Write("~/SignIn.aspx");
            }

        }
    }
}