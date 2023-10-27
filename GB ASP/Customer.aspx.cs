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
    public partial class Customer : System.Web.UI.Page
    {
        public string sConnectionString = @"Data Source=GB-ERP-JAHANZAI;Initial Catalog=Complaint;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InsertDataInDB();
            

        }


        

        public void InsertDataInDB()
        {

            //string sQuery = string.Format("INSERT INTO StudentInfo (NAME) VALUES ('{0}')", name);
            //SqlConnection con = new SqlConnection(sConnectionString);

            //con.Open();
            //SqlCommand cmd = new SqlCommand(sQuery, con);
            //cmd.ExecuteNonQuery(); //INSERT, UPDATE, DELETE
            // string sQuery = string.Format("INSERT INTO Complaint (Phoneno,Alternateno,City,[Descripton],Issue) Values (@Phoneno,@Alternateno,@City,@Description,@Issue)");

            string sQuery = string.Format("INSERT INTO Customer (CustName,Contactperson,Address,Telephone,Remarks,Mobile,Email,Package) Values (@CustName,@ContactPerson,@Address,@Telephone,@Remarks,@Mobile,@Email,@Package)");

            SqlConnection con = new SqlConnection(sConnectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand(sQuery, con);
            //cmd.Parameters.AddWithValue("@CustID", txtCustID.Text.Trim());
            cmd.Parameters.AddWithValue("@CustName", txtCustName.Text.Trim());
            cmd.Parameters.AddWithValue("@ContactPerson", txtPerson.Text.Trim());
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text.Trim());
            cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Package", txtPackage.Text.Trim());
            cmd.ExecuteNonQuery(); //INSERT, UPDATE, DELETE
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            InsertDataInDB();
        }
    }
}
