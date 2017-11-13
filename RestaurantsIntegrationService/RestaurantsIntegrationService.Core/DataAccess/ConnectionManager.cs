using Oracle.DataAccess.Client;
using RestaurantsIntegrationService.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.DataAccess
{
    public static class ConnectionManager
    {

        public static readonly string HOST = ConfigurationManager.AppSettings["HOST"].ToString();
        public static readonly string SERVICE_NAME = ConfigurationManager.AppSettings["SERVICE_NAME"].ToString();
        public static readonly int PORT = int.Parse(ConfigurationManager.AppSettings["PORT"]);


        public static OracleConnection GetConnection(string dbName)
        {
            string oracleConnection = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + HOST +
                                      ")(PORT=" + PORT + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + SERVICE_NAME +
                                      ")));User Id=" + dbName + ";Proxy User Id=onyxproxy;Proxy Password=YS$onyx#proxy;";
            OracleConnection conn = new OracleConnection(oracleConnection);
            return conn;

        }


        public static CompanyInfo GetCompanyInfo(string dbName, int branchNumber)
        {
            using (var conn = GetConnection(dbName))
            {
                OracleCommand comm = new OracleCommand("Select CMP_NO,BRN_USR,BRN_YEAR  From S_BRN where Brn_no = " + branchNumber, conn);
                OracleDataAdapter adp = new OracleDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                var companyInfo = new CompanyInfo();
                foreach (DataRow row in dt.Rows)
                {
                    companyInfo.BranchNumber = branchNumber;
                    companyInfo.BranchUser = row["BRN_USR"].ToString();
                    //companyInfo.CompanyNumber = row["CMP_NO"].ToString();
                    companyInfo.BranchYear = row["BRN_YEAR"].ToString();
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                OracleCommand comm2 = new OracleCommand("IAS_BRN_PKG.Get_Br_Cmp", conn);
                comm2.CommandType = CommandType.StoredProcedure;
                comm2.Parameters.Add(new OracleParameter("G_BRN_NO", OracleDbType.Int32, branchNumber, ParameterDirection.Input));
                comm2.Parameters.Add(new OracleParameter("v_cmp", OracleDbType.Int32, ParameterDirection.ReturnValue));
                var companyNumber = comm2.ExecuteScalar();
                if (companyNumber == null)
                {
                    companyInfo.CompanyNumber = "NULL";
                }
                else
                {
                    companyInfo.CompanyNumber = companyNumber.ToString();
                }

                companyInfo.CompanyNumber = "1";
                return companyInfo;
            }
        }
    }
}
