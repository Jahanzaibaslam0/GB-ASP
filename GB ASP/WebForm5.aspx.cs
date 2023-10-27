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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string constr = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";
                //ConfigurationManager.ConnectionStrings["binddropdown"].ToString(); // connection string
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand com = new SqlCommand("select * from custtable", con); // table name 
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset
                DDLProduct.DataTextField = ds.Tables[0].Columns["Accountnum"].ToString(); // text field name of table dispalyed in dropdown
                DDLProduct.DataValueField = ds.Tables[0].Columns["CustGroup"].ToString();             // to retrive specific  textfield name 
                DDLProduct.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                DDLProduct.DataBind();  //binding dropdownlist
            }

        }


        private void DatabindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            List<ListItem> pages = new List<ListItem>();
            if (totalPages > 1)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != (pageIndex + 1)));
                }
            }
            RepeaterPaging.DataSource = pages;
            RepeaterPaging.DataBind();
        }

        protected void RepeaterPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void LinkButton_Click(object sender, EventArgs e)

        {
            int totalRows = 0;
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            GridView1.PageIndex = pageIndex;
            //    GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(pageIndex, GridView1.PageSize, 'abc', '123', inputProductCode.Value, inputProductName.Value, inputDivision.Value, inputRegion.Value, out totalRows);
            GridView1.DataBind();
            DatabindRepeater(pageIndex, GridView1.PageSize, totalRows);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int totalRows = 0;
            // GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(0, GridView1.PageSize, inputProductCode.Value, inputProductName.Value, inputDivision.Value, inputRegion.Value, out totalRows);
            // (0, GridView1.PageSize, out totalRows);
            GridView1.DataBind();

            DatabindRepeater(0, GridView1.PageSize, totalRows);

        }
    }
    }
