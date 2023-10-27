using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GB_ASP
{
    public class CustTurnOverInvoiceDivisionList
    {
        public string S_NO { get; set; }
        public string Customer_Account { get; set; }
        public string Customer_Name { get; set; }

        public string Group { get; set; }

        public string Currency { get; set; }

        public string ExcludingAmountCharges { get; set; }

        public string IncludingAmountCharges { get; set; }

        public string Division { get; set; }

        


    }
    public class CustomerTurnOverInvoiceDivisionList
    {

        public static List<CustTurnOverInvoiceDivisionList> GetCustTurnOverDivisionReport(int pageIndex, int pageSize,  out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustTurnOverInvoiceDivisionList> listCustTurnOverDivision = new List<CustTurnOverInvoiceDivisionList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CustomerTurnOverInvoiceDivision", con);
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

                


                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    CustTurnOverInvoiceDivisionList CustTurnOverDivision = new CustTurnOverInvoiceDivisionList();

                    CustTurnOverDivision.S_NO = rdr["RowNumber"].ToString();
                    //CustTurnOverDivision.Company = rdr["DATAAREAID"].ToString();
                    CustTurnOverDivision.Customer_Account = rdr["ORDERACCOUNT"].ToString();
                    CustTurnOverDivision.Customer_Name = rdr["INVOICINGNAME"].ToString();
                    CustTurnOverDivision.Group = rdr["CUSTGROUP"].ToString();
                    CustTurnOverDivision.Currency = rdr["CURRENCYCODE"].ToString();
                    CustTurnOverDivision.IncludingAmountCharges = rdr["INCLUDINGAMOUNTCHARGES"].ToString();
                    CustTurnOverDivision.ExcludingAmountCharges = rdr["EXCLUDINGAMOUNTCHARGES"].ToString();
                    CustTurnOverDivision.Division = rdr["DIVISION"].ToString();
                    
                    

                    listCustTurnOverDivision.Add(CustTurnOverDivision);
                }

                rdr.Close();
                if ((object)cmd.Parameters["@TotalRows"].Value != null)
                {
                    totalRows = 1;
                }
                else
                {
                    totalRows = (int)cmd.Parameters["@TotalRows"].Value;


                }
                con.Close();
                con.Dispose();
            }
            return listCustTurnOverDivision;
        }


    }
}