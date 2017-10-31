using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OracleClient;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using Microsoft.AspNet.Identity;

namespace RestaurantsIntegrationService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            
            //string oracleConnection = "Provider = ORAOLEDB.Oracle.1; User ID =onyxproxy[ias20171]; Password =YS$ONYX#PROXY; Data Source =YemenSoft";

            //OleDbConnection conn = new OleDbConnection();
            //conn.ConnectionString = oracleConnection;
            //conn.Open();
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM USER_R", conn);
            //DataTable dt = new DataTable();
            //da.Fill(dt);


            //// Close connection
            //if (conn.State == ConnectionState.Open)
            //    conn.Close();



            return View();
        }
    }
}
