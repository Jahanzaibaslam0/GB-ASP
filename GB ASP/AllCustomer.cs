using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class AllCustomerList
    {
            public string SerialNo { get; set; }
            public string CustomerID { get; set; }
            public string CustomerName { get; set; }

            public string Group { get; set; }

            public string Branch { get; set; }

            public string AccountNumber { get; set; }

            public string City { get; set; }
            public string Province { get; set; }
            public string Address { get; set; }

            public string PhoneNumber { get; set; }

            public string NationalTaxNum { get; set; }

            public string CNIC { get; set; }

            public string SalesTaxRegNum { get; set; }
            public string ClassificationID { get; set; }
            public string Currency { get; set; }
            public string CreditLimit { get; set; }
            public string PaymentMode { get; set; }
            public string Site { get; set; }
            public string Warehouse { get; set; }


    }

        public class AllCustomer123
        {
            public static List<AllCustomerList> GetAllCustomer(int pageIndex, int pageSize, string CustomerID, string CustomerName,string Blocked, string Group, string Branch, out int totalRows)
            {
                // Replace square brackets with angular brackets
                List<AllCustomerList> listAllCustomer = new List<AllCustomerList>();

                string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAXDB";

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spCustomer2", con);
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
                    paramCustomerCode.ParameterName = "@Customer";
                    paramCustomerCode.Value = CustomerID;
                    cmd.Parameters.Add(paramCustomerCode);


                    SqlParameter paramCustGroup = new SqlParameter();
                    paramCustGroup.ParameterName = "@Group";
                    paramCustGroup.Value = Group;
                    cmd.Parameters.Add(paramCustGroup);


                    SqlParameter paramCustName = new SqlParameter();
                    paramCustName.ParameterName = "@CustName";
                    paramCustName.Value = CustomerName;
                    cmd.Parameters.Add(paramCustName);

                    SqlParameter paramBranch = new SqlParameter();
                    paramBranch.ParameterName = "@DealForBranch";
                    paramBranch.Value = Branch;
                    cmd.Parameters.Add(paramBranch);

                SqlParameter paramBlocked = new SqlParameter();
                paramBlocked.ParameterName = "@Blocked";
                paramBlocked.Value = Blocked;
                cmd.Parameters.Add(paramBlocked);



                SqlParameter paramOutputTotalRows = new SqlParameter();
                    paramOutputTotalRows.ParameterName = "@TotalRows";
                    paramOutputTotalRows.Direction = ParameterDirection.Output;
                    paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                    cmd.Parameters.Add(paramOutputTotalRows);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        AllCustomerList Customer = new AllCustomerList();

                    Customer.SerialNo = rdr["RowNumber"].ToString();
                    Customer.CustomerID = rdr["accountnum"].ToString();
                    Customer.CustomerName = rdr["NAME"].ToString();
                    Customer.Branch = rdr["INVENTLOCATIONBR"].ToString();
                    Customer.Group = rdr["CUSTGROUP"].ToString();
                    Customer.AccountNumber = rdr["OURACCOUNTNUM"].ToString();
                    Customer.City = rdr["CITY"].ToString();
                    Customer.Province = rdr["PROVINCE"].ToString();
                    Customer.Address = rdr["ADDRESS"].ToString();
                    Customer.PhoneNumber = rdr["PHONE NUMBER"].ToString();
                    Customer.NationalTaxNum = rdr["NATIONALTAXNUM"].ToString();
                    Customer.CNIC = rdr["CNIC"].ToString();
                    Customer.SalesTaxRegNum = rdr["SALESTAXREGNUM"].ToString();
                    Customer.ClassificationID = rdr["CustClassificationID"].ToString();
                    Customer.Currency = rdr["Currency"].ToString();
                    Customer.CreditLimit = rdr["CreditLimit"].ToString();
                    Customer.PaymentMode = rdr["Paymmode"].ToString();
                    Customer.Site = rdr["INVENTSITEID"].ToString();
                    Customer.Warehouse = rdr["InventLocation"].ToString();
                    


                    listAllCustomer.Add(Customer);
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
                return listAllCustomer;
            }


            
        }

    public class AllCustomer2
    {
        public static List<AllCustomerList> GetAllCustomer(int pageIndex, int pageSize, string CustomerID, string CustomerName, string Blocked, string Group,string Branch, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<AllCustomerList> listAllCustomer = new List<AllCustomerList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spCustomer2", con);
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
                paramCustomerCode.ParameterName = "@Customer";
                paramCustomerCode.Value = CustomerID;
                cmd.Parameters.Add(paramCustomerCode);


                SqlParameter paramCustGroup = new SqlParameter();
                paramCustGroup.ParameterName = "@Group";
                paramCustGroup.Value = Group;
                cmd.Parameters.Add(paramCustGroup);


                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@DealForBranch";
                paramBranch.Value = Branch;
                cmd.Parameters.Add(paramBranch);

                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustomerName;
                cmd.Parameters.Add(paramCustName);

                //SqlParameter paramBranch = new SqlParameter();
                //paramBranch.ParameterName = "@DealForBranch";
                //paramBranch.Value = Branch;
                //cmd.Parameters.Add(paramBranch);

                SqlParameter paramBlocked = new SqlParameter();
                paramBlocked.ParameterName = "@Blocked";
                paramBlocked.Value = Blocked;
                cmd.Parameters.Add(paramBlocked);



                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AllCustomerList Customer = new AllCustomerList();

                    Customer.SerialNo = rdr["RowNumber"].ToString();
                    Customer.CustomerID = rdr["accountnum"].ToString();
                    Customer.CustomerName = rdr["NAME"].ToString();
                    Customer.Branch = rdr["INVENTLOCATIONBR"].ToString();
                    Customer.Group = rdr["CUSTGROUP"].ToString();
                    Customer.AccountNumber = rdr["OURACCOUNTNUM"].ToString();
                    Customer.City = rdr["CITY"].ToString();
                    Customer.Province = rdr["PROVINCE"].ToString();
                    Customer.Address = rdr["ADDRESS"].ToString();
                    Customer.PhoneNumber = rdr["PHONE NUMBER"].ToString();
                    Customer.NationalTaxNum = rdr["NATIONALTAXNUM"].ToString();
                    Customer.CNIC = rdr["CNIC"].ToString();
                    Customer.SalesTaxRegNum = rdr["SALESTAXREGNUM"].ToString();
                    Customer.ClassificationID = rdr["CustClassificationID"].ToString();
                    Customer.Currency = rdr["Currency"].ToString();
                    Customer.CreditLimit = rdr["CreditLimit"].ToString();
                    Customer.PaymentMode = rdr["Paymmode"].ToString();
                    Customer.Site = rdr["INVENTSITEID"].ToString();
                    Customer.Warehouse = rdr["InventLocation"].ToString();



                    listAllCustomer.Add(Customer);
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
            return listAllCustomer;
        }



    }
}
