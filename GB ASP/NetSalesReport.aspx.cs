using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace GB_ASP
{
    public partial class NetSalesReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {

            if (!IsPostBack)

            {

                DropDownList1.DataSource = GetData();

                DropDownList1.DataValueField = "Id";

                DropDownList1.DataTextField = "Item";

                DropDownList1.DataBind();

            }


        }

        public DataTable GetData()

        {

            DataTable dt = new DataTable();


            //Add columns to DataTable.

            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("Item") });


            //Set AutoIncrement True for the First Column.

            dt.Columns["Id"].AutoIncrement = true;


            //Set the Starting or Seed value.

            dt.Columns["Id"].AutoIncrementSeed = 1;


            //Set the Increment value.

            dt.Columns["Id"].AutoIncrementStep = 1;


            //Add rows to DataTable.


            for (int i = 1; i < 20; i++)

            {

                dt.Rows.Add(null, "Item " + i.ToString());

            }



            return dt;

        }


    }
}