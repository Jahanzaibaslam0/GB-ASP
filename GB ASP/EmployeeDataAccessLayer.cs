using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace GB_ASP
{
        public class Employee
        {
             public string SerialNo { get; set; }
            public string Productcode { get; set; }
            public string ProductName { get; set; }
            
            public string SalesUnit { get; set; }
        
            public string Qty { get; set; }
            
            public string GrossAmount { get; set; }
            public string DiscountAmount { get; set; }

            public string Revenue { get; set; }

            

            
        }

    public class EmployeeDataAccessLayer
    {
        // Replace square brackets with angular brackets 
        public static List<Employee> GetEmployees(int pageIndex, int pageSize,string StartDate,string EndDate ,string prdCode,string prdName,string Branch,string Division,string Region, out int totalRows)
            {
                // Replace square brackets with angular brackets
                List<Employee> listEmployees = new List<Employee>();

                string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spNetSales", con);
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

                    SqlParameter paramProductCode = new SqlParameter();
                    paramProductCode.ParameterName = "@ProductCode";
                    paramProductCode.Value = prdCode;
                    cmd.Parameters.Add(paramProductCode);


                    SqlParameter paramProductName = new SqlParameter();
                    paramProductName.ParameterName = "@ProductName";
                    paramProductName.Value = prdName;
                    cmd.Parameters.Add(paramProductName);


                    SqlParameter paramDivision = new SqlParameter();
                    paramDivision.ParameterName = "@Division";
                    paramDivision.Value = Division;
                    cmd.Parameters.Add(paramDivision);

                    SqlParameter paramRegion = new SqlParameter();
                    paramRegion.ParameterName = "@Region";
                    paramRegion.Value = Region;
                    cmd.Parameters.Add(paramRegion);

                    SqlParameter paramBranch = new SqlParameter();
                    paramBranch.ParameterName = "@DealForBranch";
                    paramBranch.Value = Region;
                    cmd.Parameters.Add(paramBranch);

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
                        Employee employee = new Employee();

                        employee.SerialNo =    rdr["RowNumber2"].ToString();
                        employee.Productcode = rdr["ProductCode"].ToString();
                        employee.ProductName = rdr["ProductName"].ToString();
                        employee.Qty =         rdr["Qty"].ToString();
                        employee.SalesUnit =   rdr["SalesUnit"].ToString();
                        employee.GrossAmount = rdr["GrossAmount"].ToString();
                        employee.DiscountAmount = rdr["DiscountAmount"].ToString();
                        employee.Revenue =     rdr["Revenue"].ToString();
                        

                        listEmployees.Add(employee);
                    }

                    rdr.Close();
                    totalRows = (int)cmd.Parameters["@TotalRows"].Value;
                    con.Close();
                con.Dispose();
            }
                return listEmployees;
            }
        }


    public class EmployeeDataAccessLayer2
    {
        // Replace square brackets with angular brackets 
        public static List<Employee> GetEmployees(int pageIndex, int pageSize, string StartDate, string EndDate, string prdCode, string prdName, string Division ,out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<Employee> listEmployees = new List<Employee>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spNetSales2Test", con);
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

                SqlParameter paramProductCode = new SqlParameter();
                paramProductCode.ParameterName = "@ProductCode";
                paramProductCode.Value = prdCode;
                cmd.Parameters.Add(paramProductCode);


                SqlParameter paramProductName = new SqlParameter();
                paramProductName.ParameterName = "@ProductName";
                paramProductName.Value = prdName;
                cmd.Parameters.Add(paramProductName);


                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                //SqlParameter paramRegion = new SqlParameter();
                //paramRegion.ParameterName = "@Region";
                //paramRegion.Value = Region;
                //cmd.Parameters.Add(paramRegion);

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
                    Employee employee = new Employee();

                    employee.SerialNo = rdr["RowNumber2"].ToString();
                    employee.Productcode = rdr["ProductCode"].ToString();
                    employee.ProductName = rdr["ProductName"].ToString();
                    employee.Qty = rdr["Qty"].ToString();
                    employee.SalesUnit = rdr["SalesUnit"].ToString();
                    employee.GrossAmount = rdr["GrossAmount"].ToString();
                    employee.DiscountAmount = rdr["DiscountAmount"].ToString();
                    employee.Revenue = rdr["Revenue"].ToString();


                    listEmployees.Add(employee);
                }

                rdr.Close();
                totalRows = (int)cmd.Parameters["@TotalRows"].Value;
                con.Close();
                con.Dispose();
            }
            return listEmployees;
        }
    }
}


    