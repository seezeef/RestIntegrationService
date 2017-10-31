using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Data.OracleClient;
using System.Data.Odbc;
using System.Data;
using System.Data.OleDb;
using RestaurantsIntegrationService.Models;

namespace RestaurantsIntegrationService.Controllers
{
    [Authorize]
    [RoutePrefix("api/integrations")]
    public class IntegrationController : ApiController
    {
        [Route("TestConnection")]
        [HttpGet]
        public IHttpActionResult TestConnection()
        {
            string message = "Connected Successfully";
            return Ok(message);
        }



        [Route("TestGetData")]
        [HttpGet]
        public IHttpActionResult TestGetData()
        {
            string oracleConnection = "Provider = ORAOLEDB.Oracle.1; User ID =onyxproxy[ias20171]; Password =YS$ONYX#PROXY; Data Source =YemenSoft";
            using (OleDbConnection conn = new OleDbConnection())
            {
                conn.ConnectionString = oracleConnection;
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM RES_BILL_MST", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<string> ids = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    ids.Add(row["U_Id"].ToString());
                }

                return Ok(ids);
            }
        }

        [Route("IsAccountNumberExist")]
        [HttpGet]
        public IHttpActionResult IsAccountNumberExist(string accountNumber)
        {
            string oracleConnection = "Provider = ORAOLEDB.Oracle.1; User ID =onyxproxy[ias20171]; Password =YS$ONYX#PROXY; Data Source =YemenSoft";
            using (OleDbConnection conn = new OleDbConnection())
            {
                conn.ConnectionString = oracleConnection;
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM ACCOUNT_CURR WHERE A_CODE = " + accountNumber, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    return Ok(false);
                }

                return Ok(true);
            }
        }

        [Route("TestInsertData")]
        [HttpPost]
        public IHttpActionResult TestInsertData(List<TestModel> data)
        {
            string oracleConnection = "Provider = ORAOLEDB.Oracle.1; User ID =onyxproxy[ias20171]; Password =YS$ONYX#PROXY; Data Source =YemenSoft";
            using (OleDbConnection conn = new OleDbConnection(oracleConnection))
            {
                //OleDbTransaction transaction = null;

                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                conn.Open();
                //transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                foreach (var item in data)
                {
                    var random = new Random().Next(1, 9999999);
                    var creditCardType = item.CreditCard_Type.HasValue ? item.CreditCard_Type.Value.ToString() : "NULL";
                    command.CommandText = "insert into Res_bill_mst (BILL_NO, BILL_SER, PAY_TYPE, BILL_DATE, A_CY, AC_RATE, BILL_AMT, DISC_AMT, VAT_AMT, OTHR_AMT, CREDIT_CARD, CR_CARD_NO, CR_CARD_AMT, AC_DTL_TYP, AC_CODE_DTL, A_CODE, CASH_NO, CC_CODE, PJ_NO, ACTV_NO, DOC_POST, W_CODE, MACHINE_NO, U_ID, MOVE_BILL, MOVE_INC, MOVE_OUT, CMP_NO, BRN_NO, BRN_YEAR, BRN_USR, CARD_AMT, CARD_NO) values" +
                        "(" + item.ASerial + ", " + random + ", " + item.Bill_Pay_Type + ", '" + item.S_Date.Value.ToShortDateString() + "', 'SAR' , " + 1 + ", " + item.Net_Amount + ", " + item.Itm_Disc + ", " + 0 + ", " + 0 + ", " + 1 + ", " + creditCardType + ", " + item.Net_Amount + ", " + 1 + ", " + 1 + ", '" + item.AccountNumber + "', " + 1 + ", NULL , NULL, NULL, " + 0 + ", " + 1 + ", " + 1 + ", " + item.User_ID + ", " + 0 + ", " + 0 + ", " + 0 + ", " + 1 + ", " + 1 + ", " + 2017 + ", " + 1 + ", " + 0 + ", " + 0 + ")";
                    var test = command.ExecuteNonQuery();
                }


            }
            return Ok("Ok");
        }

        //[Route("TestConnection")]
        //[HttpGet]
        //public HttpResponseMessage TestConnection()
        //{
        //    return Request.CreateErrorResponse(HttpStatusCode.OK, "Connected Successfully");
        //}


    }
}