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
    public partial class Complaint_Form : System.Web.UI.Page
    {
        public string sConnectionString = @"Data Source=GB-ERP-JAHANZAI;Initial Catalog=Complaint;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("select * from Customer");
            cmd.Connection = con;
            con.Open();
            this.DropDownList1.DataSource = cmd.ExecuteReader();
            this.DropDownList1.DataTextField = "CustName";
            this.DropDownList1.DataValueField = "CustID";
            this.DropDownList1.DataBind();
            con.Close();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BindTypeList(DropDownList ddlType)
        {
            SqlConnection con = new SqlConnection(sConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("select * from Customer");
            cmd.Connection = con;
            con.Open();
            this.DropDownList1.DataSource = cmd.ExecuteReader();
            this.DropDownList1.DataTextField = "CustName";
            this.DropDownList1.DataValueField = "CustID";
            this.DropDownList1.DataBind();
            con.Close();

        }

        public void InsertDataInDB()
        {

            //string sQuery = string.Format("INSERT INTO StudentInfo (NAME) VALUES ('{0}')", name);
            //SqlConnection con = new SqlConnection(sConnectionString);

            //con.Open();
            //SqlCommand cmd = new SqlCommand(sQuery, con);
            //cmd.ExecuteNonQuery(); //INSERT, UPDATE, DELETE
            // string sQuery = string.Format("INSERT INTO Complaint (Phoneno,Alternateno,City,[Descripton],Issue) Values (@Phoneno,@Alternateno,@City,@Description,@Issue)");

            string sQuery = string.Format("INSERT INTO Complaint (CustID,[Complaint Type],[Complaint Details],[Assigned To],[Closed To],[Closed Detail],[Closed Remarks],ComplaintDate,[ONT Replace],[ONT  OLD Serial No],[ONT NEW Serial No],[DTP Replace],[DTP OLD Serial No],[DTP New Serial No],[Remote Replace],[Power Adopter],[Power Adopter ONT],[Power Adopter DTU],Nature) Values (@CustID,@ComplaintType,@ComplaintDetail,@AssignTo,@ClosedTo,@ClosedDetail,@ClosedRemark,@ComplaintDate,@ONTREplace,@ONTOLDSERIES,@ONTNEWSERIES,@DTPREplace,@DTPOLDSERIES,@DTPNEWSERIES,@RemoteReplace,@PowerAdoptor,@PowerAdoptorONT,@PowerAdoptorDTU,@Nature)");

            SqlConnection con = new SqlConnection(sConnectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand(sQuery, con);
            ///cmd.Parameters.AddWithValue("@CustID", txtCustID.Text.Trim());
            cmd.Parameters.AddWithValue("@CustID", DropDownList1.SelectedItem.Value);
            //cmd.Parameters["@CustID"].Value = DropDownList1.SelectedItem.Value;
            cmd.Parameters.AddWithValue("@ComplaintType", txtComplaintType.Text.Trim());
            cmd.Parameters.AddWithValue("@ComplaintDetail", txtComplaintDetails.Text.Trim());
            cmd.Parameters.AddWithValue("@AssignTo", txtEmployee.Text.Trim());
            cmd.Parameters.AddWithValue("@ClosedTo", txtClosedTo.Text.Trim());
            cmd.Parameters.AddWithValue("@ClosedDetail", txtClosedDetails.Text.Trim());
            cmd.Parameters.AddWithValue("@ClosedRemark", txtClosedRemarks.Text.Trim());
            cmd.Parameters.AddWithValue("@ComplaintDate", txtComplaintDate.Text.Trim());
            cmd.Parameters.AddWithValue("@ONTREplace", txtONTReplace.Text.Trim());
            cmd.Parameters.AddWithValue("@ONTOLDSERIES", txtONTOLDSerialNumber.Text.Trim());
            cmd.Parameters.AddWithValue("@ONTNEWSERIES", txtONTNewSerialNo.Text.Trim());
            cmd.Parameters.AddWithValue("@DTPREplace", txtDTPReplace.Text.Trim());
            cmd.Parameters.AddWithValue("@DTPOLDSERIES", txtDTPOLDSerialNumber.Text.Trim());
            cmd.Parameters.AddWithValue("@DTPNEWSERIES", txtDTPNEwSerialNumber.Text.Trim());
            cmd.Parameters.AddWithValue("@RemoteReplace", txtRemoteReplace.Text.Trim());
            cmd.Parameters.AddWithValue("@PowerAdoptor", txtPowerAdoptor.Text.Trim());
            cmd.Parameters.AddWithValue("@PowerAdoptorONT", txtPowerAdoptorONT.Text.Trim());
            cmd.Parameters.AddWithValue("@PowerAdoptorDTU", txtPowerAdoptorDTU.Text.Trim());
            cmd.Parameters.AddWithValue("@Nature", txtNature.Text.Trim());
            cmd.ExecuteNonQuery(); //INSERT, UPDATE, DELETE
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InsertDataInDB();
            //GetDataInDB();

            //txtCustID.Text = lblCustID.Text;
            //lblRPhone.Visible = true;
            //txtPHno.Visible = false;

            //txtAtno.Text = lblrAlter.Text;
            //lblrAlter.Visible = true;
            //txtAtno.Visible = false;

            //txtcity.Text = lblrcity.Text;
            //lblrcity.Visible = true;
            //txtcity.Visible = false;

            //txtDesc.Text = lblrDesc.Text;
            //lblrDesc.Visible = true;
            //txtDesc.Visible = false;

            //txtIssue.Text = lblrIssue.Text;
            //lblrIssue.Visible = true;
            //txtIssue.Visible = false;

            //lblDesc.Visible = true;
            //txtDesc.Visible = false;

            //PHno = txtPHno.Text;
        }
        public void GetDataInDB()
        {

            DataTable dt = new DataTable();
            string sQuery = "SELECT * from Complaint where newid()";
            SqlConnection con = new SqlConnection(sConnectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand(sQuery, con);
            SqlDataReader sdr = cmd.ExecuteReader(); //  SELECT 
            dt.Load(sdr);

            //gvcomplaint.DataSource = dt;
            //gvcomplaint.DataBind();
        }



        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            /*
            string Command = "SELECT * from Complaint where City like '" + txtSearch.Text + "%'" + "OR Phoneno like '" + txtSearch.Text + "%'" + "OR Alternateno like '" + txtSearch.Text + "%'" + "OR Issue like '" + txtSearch.Text + "%'";
            SqlConnection con = new SqlConnection(sConnectionString);
            SqlCommand cmd = new SqlCommand(Command, con);
            con.Open();
            gvcomplaint.DataSource = cmd.ExecuteReader();
            gvcomplaint.DataBind();
            con.Close();

            //string sQuery = string.Format("SELECT ID,Phoneno,Alternateno,City,[Descripton] from Complaint");

            //SqlConnection con = new SqlConnection(sConnectionString);

            //con.Open();
            //SqlCommand cmd = new SqlCommand(sQuery, con);

            ////lblCreatedOn.Text = cmd.ExecuteScalar().ToString(); // assign to your label

            //SqlDataReader sdr = cmd.ExecuteReader(); //  SELECT 
            ////dt.Load(sdr);
            //while (sdr.Read())
            //{
            //    lblPhoneno.Text = sdr["Phoneno"].ToString();

            //    lblAlternate.Text = sdr["Alternateno"].ToString();

            //    lblCity.Text = sdr["City"].ToString();

            //    lblDescription.Text = sdr["Descripton"].ToString();

            //    lblIssue.Text = sdr["Issue"].ToString();

            //}
            //con.Close();

    */

        }
    }
}