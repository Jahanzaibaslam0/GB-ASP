using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace GB_ASP
{
    public class CustTurnOverCustGroupList
    {
        public string SerialNo { get; set; }
       
        public string Group { get; set; }
        public string ExcludingAmountCharges { get; set; }
        public string IncludingAmountCharges { get; set; }

    }


    public class CustomerTurnOverByCustGroup
    {
        public static List<CustTurnOverCustGroupList> GetCustTurnOverDivisionReport(int pageIndex, int pageSize, string StartDate, string EndDate, string CustID, string CustName,string Branch, string Group, string Division, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustTurnOverCustGroupList> listCustTurnOverCustGroup = new List<CustTurnOverCustGroupList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CUSTOMERTURNOVERBYCUSTOMERGROUP", con);
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

                SqlParameter paramCustID = new SqlParameter();
                paramCustID.ParameterName = "@Customer";
                paramCustID.Value = CustID;
                cmd.Parameters.Add(paramCustID);


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramGroup = new SqlParameter();
                paramGroup.ParameterName = "@Group";
                paramGroup.Value = Group;
                cmd.Parameters.Add(paramGroup);

                SqlParameter paramBranch = new SqlParameter();
                paramBranch.ParameterName = "@DealForBranch";
                paramBranch.Value = Branch;
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
                    CustTurnOverCustGroupList CustTurnOverGroup = new CustTurnOverCustGroupList();

                    CustTurnOverGroup.SerialNo = rdr["RowNumber"].ToString();
                    
                    CustTurnOverGroup.Group = rdr["CUSTGROUP"].ToString();
                    CustTurnOverGroup.IncludingAmountCharges = rdr["INCLUDINGAMOUNTCHARGES"].ToString();
                    CustTurnOverGroup.ExcludingAmountCharges = rdr["EXCLUDINGAMOUNTCHARGES"].ToString();

                    listCustTurnOverCustGroup.Add(CustTurnOverGroup);
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
            return listCustTurnOverCustGroup;
        }

    }

    public class CustomerTurnOverByCustGroup2
    {
        public static List<CustTurnOverCustGroupList> GetCustTurnOverDivisionReport(int pageIndex, int pageSize, string StartDate, string EndDate, string CustID, string CustName, string Group, string Division, out int totalRows)
        {
            // Replace square brackets with angular brackets
            List<CustTurnOverCustGroupList> listCustTurnOverCustGroup = new List<CustTurnOverCustGroupList>();

            string CS = "Data Source = GBDBSVR.ghazibros.com; User ID = sa; Password = P@ssw0rd; Initial Catalog = GBAX12";

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CUSTOMERTURNOVERBYCUSTOMERGROUP2", con);
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

                SqlParameter paramCustID = new SqlParameter();
                paramCustID.ParameterName = "@Customer";
                paramCustID.Value = CustID;
                cmd.Parameters.Add(paramCustID);


                SqlParameter paramCustName = new SqlParameter();
                paramCustName.ParameterName = "@CustName";
                paramCustName.Value = CustName;
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramDivision = new SqlParameter();
                paramDivision.ParameterName = "@Division";
                paramDivision.Value = Division;
                cmd.Parameters.Add(paramDivision);

                SqlParameter paramGroup = new SqlParameter();
                paramGroup.ParameterName = "@Group";
                paramGroup.Value = Group;
                cmd.Parameters.Add(paramGroup);

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
                    CustTurnOverCustGroupList CustTurnOverGroup = new CustTurnOverCustGroupList();

                    CustTurnOverGroup.SerialNo = rdr["RowNumber"].ToString();

                    CustTurnOverGroup.Group = rdr["CUSTGROUP"].ToString();
                    CustTurnOverGroup.IncludingAmountCharges = rdr["INCLUDINGAMOUNTCHARGES"].ToString();
                    CustTurnOverGroup.ExcludingAmountCharges = rdr["EXCLUDINGAMOUNTCHARGES"].ToString();

                    listCustTurnOverCustGroup.Add(CustTurnOverGroup);
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
            return listCustTurnOverCustGroup;
        }

    }
}