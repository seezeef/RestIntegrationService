using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Data.Odbc;
using System.Data;
using System.Data.OleDb;
using RestaurantsIntegrationService.Models;
using Oracle.DataAccess.Client;
using RestaurantsIntegrationService.Core.DataAccess;
using RestaurantsIntegrationService.Models.Bills;

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
        public IHttpActionResult TestGetData(string databaseName)
        {

            using (var conn = ConnectionManager.GetConnection(databaseName))
            {
                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM RES_BILL_MST", conn);
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


        [Route("InsertBills")]
        [HttpPost]
        public IHttpActionResult InsertBills(TransferModel<TransferBillModel> data)
        {
            using (var conn = ConnectionManager.GetConnection(data.DatabaseName))
            {
                conn.Open();
                var companyInfo = ConnectionManager.GetCompanyInfo(data.DatabaseName, data.OnyxBranchNumber);
                OracleCommand command = new OracleCommand(conn);
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


        private string ValidateInsertBills(TransferModel<TransferBillModel> data)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(data.DatabaseName))
            {
                conn.Open();
                foreach (var item in data.Items.MasterData)
                {
                    OracleCommand command = new OracleCommand("SELECT A_CODE FROM ACCOUNT_CURR Where A_CODE =" + item.A_CODE+ " AND A_CY = " + item.A_CY  , conn);
                    OracleDataAdapter adp = new OracleDataAdapter(command);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if(dt.Rows.Count == 0)
                    {
                        message = $"Account code {item.A_CODE} Not exist";
                        return message;
                    }

                    

                    command = new OracleCommand("SELECT U_ID FROM USER_R Where U_ID = " + item.U_ID, conn);
                    adp.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        message = $"User code {item.U_ID} Not exist";
                        return message;
                    }

                    command = new OracleCommand("SELECT W_CODE FROM WAREHOUSE_DETAILS Where W_CODE = " + item.W_CODE, conn);
                    adp.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        message = $"Warehose code {item.W_CODE} Not exist";
                        return message;
                    }


                    if (item.AC_DTL_TYP == 1) // Cash_no
                    {
                        command = new OracleCommand("SELECT CASH_NO FROM CASH_IN_HAND Where CASH_NO = " + item.AC_CODE_DTL , conn);
                        adp.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            message = $"Cash No  {item.AC_CODE_DTL} Not exist";
                            return message;
                        }

                    }
                    else if (item.AC_DTL_TYP == 2) // Card_no
                    {
                        command = new OracleCommand("SELECT CR_CARD_NO FROM CREDIT_CARD_TYPES Where CR_CARD_NO = " + item.CARD_NO , conn);
                        adp.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            message = $" Card No  {item.CARD_NO} Not exist";
                            return message;
                        }

                    }
                    else if (item.AC_DTL_TYP == 3) // Customer Code
                    {
                        command = new OracleCommand("SELECT CC_CODE FROM COST_CENTERS Where CC_CODE = " + item.AC_CODE_DTL, conn);
                        adp.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            message = $"Customer code {item.AC_CODE_DTL} Not exist";
                            return message;
                        }

                    }

                    //command = new OracleCommand("SELECT U_ID FROM USER_R Where U_ID = " + item.U_ID, conn);

                    //command = new OracleCommand("SELECT U_ID FROM USER_R Where U_ID = " + item.U_ID, conn);
                    //adp.Fill(dt);
                    //if (dt.Rows.Count == 0)
                    //{
                    //    message = $"User code {item.U_ID} Not exist";
                    //    return message;
                    //}
                }
            }

            return message;
        }

    }
}