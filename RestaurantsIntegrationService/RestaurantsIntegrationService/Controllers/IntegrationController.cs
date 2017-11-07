using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Data;
using RestaurantsIntegrationService.Models;
using Oracle.DataAccess.Client;
using RestaurantsIntegrationService.Core.DataAccess;
using RestaurantsIntegrationService.Models.Bills;
using RestaurantsIntegrationService.Models.Result;

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
            var testQuery = "";
            OracleTransaction transaction = null;

            using (var conn = ConnectionManager.GetConnection(data.DatabaseName))
            {
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                    var companyInfo = ConnectionManager.GetCompanyInfo(data.DatabaseName, data.OnyxBranchNumber);
                    //transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                    var errorMessage = ValidateInsertBills(data);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }
                    foreach (var item in data.Items.MasterData)
                    {
                        //TODO: Active Number is null, please check after ProjectNumber
                        var ccCode = string.IsNullOrEmpty(item.CC_CODE) ? "NULL" : item.CC_CODE;
                        var cardNo = !item.CARD_NO.HasValue ? "NULL" : item.CARD_NO.Value.ToString();
                        string query = "insert into Res_bill_mst (BILL_NO, BILL_SER, PAY_TYPE, BILL_DATE, A_CY, AC_RATE, BILL_AMT, DISC_AMT, VAT_AMT, OTHR_AMT, CREDIT_CARD, CR_CARD_NO, CR_CARD_AMT, AC_DTL_TYP, AC_CODE_DTL, A_CODE, CASH_NO, CC_CODE, PJ_NO, ACTV_NO, DOC_POST, W_CODE, MACHINE_NO, U_ID, MOVE_BILL, MOVE_INC, MOVE_OUT, CMP_NO, BRN_NO, BRN_YEAR, BRN_USR, CARD_AMT, CARD_NO) values" +
                            "(" + item.BILL_NO + ", " + item.BILL_SER + ", " + item.PAY_TYPE + ", to_date('" + item.BILL_DATE.Value.ToString("dd/MM/yyyy") + "', 'dd/mm/yyyy'), '" + item.A_CY + "' , " + item.AC_RATE + ", " + item.BILL_AMT + ", " + item.DISC_AMT + ", " + item.VAT_AMT + ", " + item.OTHR_AMT + ", " + item.CREDIT_CARD + ", " + item.CR_CARD_NO + ", " + item.CR_CARD_AMT + ", " + item.AC_DTL_TYP + ", '" + item.AC_CODE_DTL + "', '" + item.A_CODE + "', " + item.Cash_No + ", " + ccCode + " "
                            + ", " + companyInfo.ProjectNumber + ", NULL, " + item.DOC_POST + ", " + item.W_Code + ", " + item.MACHINE_NO + ", " + item.U_ID + ", " + item.MOVE_BILL + ", " + item.MOVE_INC + ", " + item.MOVE_OUT + ", " + companyInfo.CompanyNumber + ", " + item.brn_no + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + ", " + item.CARD_AMT + ", " + cardNo + ")";
                        OracleCommand command = new OracleCommand(query, conn);
                        command.Transaction = transaction;
                        testQuery = query;
                        command.ExecuteNonQuery();
                        //----------------------------------------------------------------------------------------
                        //Posting Detail
                        var detail = data.Items.DetailsData.FirstOrDefault(b => b.BILL_SER == item.BILL_SER && b.W_Code == item.W_Code);
                        query = "insert into Res_bill_dtl (BILL_NO,BILL_SER,PAY_TYPE,I_Code,ITM_UNT,P_SIZE,I_QTY,P_QTY,I_PRICE,VAT_AMT,OTHR_AMT,DISC_AMT,CC_CODE,PJ_NO,ACTV_NO,W_Code,OUT_W_CODE,SERVICE_ITEM) values" +
                            "(" + item.BILL_NO + ", " + item.BILL_SER + ", " + item.PAY_TYPE + ",'" + detail.I_Code + "','" + detail.ITM_UNT + "', " + detail.P_SIZE+ ", " + detail.P_QTY + ", " + detail.I_PRICE + ", " + detail.VAT_AMT + ", " + detail.OTHR_AMT + ", " + detail.DISC_AMT + ", '" + detail.CC_CODE + "', NULL, " + detail.ACTV_NO + ", '" + detail.W_Code + "', '" + detail.OUT_W_CODE + "', " + detail.SERVICE_ITEM + ")";
                        command = new OracleCommand(query, conn);
                        testQuery = query;
                        command.ExecuteNonQuery();
                        //----------------------------------------------------------------------------------------
                        //Posting Components
                        var Comp = data.Items.ComponentsData.FirstOrDefault(b => b.BILL_SER == item.BILL_SER && b.BILL_NO == item.BILL_NO  && b.W_Code == item.W_Code);
                        query = "insert into RES_BILL_COMPND_DTL (BILL_NO, BILL_SER, I_CODE, ITM_UNT, P_SIZE, I_QTY, P_QTY, DI_CODE, DITM_UNT, DP_SIZE, DI_QTY, DP_QTY, W_CODE, CMP_NO, BRN_NO, BRN_YEAR, BRN_USR) values" +
                            "(" + item.BILL_NO + ", " + item.BILL_SER + ", '" + Comp.I_Code + "','" + Comp.ITM_UNT + "', " + Comp.P_SIZE + ", " + Comp.Prnt_qty + "," + (Comp.P_SIZE * Comp.Prnt_qty) + ", '" + Comp.DI_code + "','" + Comp.DI_UNT + "', " + Comp.DP_SIZE + ", " + Comp.Di_qty + ", " + (Comp.DP_SIZE * Comp.Di_qty) + ",'" + Comp.W_Code + "', " + companyInfo.CompanyNumber + ", " + item.brn_no + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + ")";
                        command = new OracleCommand(query, conn);
                        testQuery = query;
                        command.ExecuteNonQuery();
                    }
                    
                    transaction.Commit();
                    return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Completed Successfully" });
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
                }
            }
        }


        private string ValidateInsertBills(TransferModel<TransferBillModel> data)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(data.DatabaseName))
            {
                conn.Open();
                foreach (var item in data.Items.MasterData)
                {
                    if (GetCommandDataCount("SELECT A_CODE FROM ACCOUNT_CURR Where A_CODE ='" + item.A_CODE + "' AND A_CY = '" + item.A_CY + "'", conn) == 0)
                    {
                        message = $"Account code {item.A_CODE} Not exist";
                        return message;
                    }

                    if (!string.IsNullOrEmpty(item.CC_CODE))
                    {
                        if (GetCommandDataCount("SELECT CC_CODE FROM COST_CENTERS Where CC_CODE ='" + item.CC_CODE + "'", conn) == 0)
                        {
                            message = $"Cost Center code {item.CC_CODE} Not exist";
                            return message;
                        }
                    }


                    if (GetCommandDataCount("SELECT U_ID FROM USER_R Where U_ID = " + item.U_ID, conn) == 0)
                    {
                        message = $"User code {item.U_ID} Not exist";
                        return message;
                    }


                    if (GetCommandDataCount("SELECT W_CODE FROM WAREHOUSE_DETAILS Where W_CODE = " + item.W_Code, conn) == 0)
                    {
                        message = $"Warehouse code {item.W_Code} Not exist";
                        return message;
                    }

                    if (item.AC_DTL_TYP == 1) // Cash_no
                    {
                        if (GetCommandDataCount("SELECT CASH_NO FROM CASH_IN_HAND Where CASH_NO = " + item.AC_CODE_DTL, conn) == 0)
                        {
                            message = $"Cach Number {item.AC_CODE_DTL} Not exist";
                            return message;
                        }
                    }
                    else if (item.AC_DTL_TYP == 2) // Card_no
                    {
                        if (GetCommandDataCount("SELECT CR_CARD_NO FROM CREDIT_CARD_TYPES Where CR_CARD_NO = " + item.CARD_NO, conn) == 0)
                        {
                            message = $"Card Number {item.CARD_NO} Not exist";
                            return message;
                        }
                    }
                    else if (item.AC_DTL_TYP == 3) // Customer Code
                    {
                        if (GetCommandDataCount("SELECT CC_CODE FROM CUSTOMER Where C_CODE = " + item.AC_CODE_DTL, conn) == 0)
                        {
                            message = $"Customer Code {item.AC_CODE_DTL} Not exist";
                            return message;
                        }
                    }
                }

                foreach (var item in data.Items.DetailsData)
                {
                    if (GetCommandDataCount("SELECT I_CODE FROM IAS_V_ITM_UNT Where I_CODE ='" + item.I_Code + "' AND ITM_UNT = '" + item.ITM_UNT + "'", conn) == 0)
                    {
                        message = $"Item code {item.I_Code} - {item.ITM_UNT} Not exist";
                        return message;
                    }
                }
            }

            return message;
        }

        private int GetCommandDataCount(string query, OracleConnection conn)
        {
            OracleCommand command = new OracleCommand(query, conn);
            OracleDataAdapter adp = new OracleDataAdapter(command);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt.Rows.Count;
        }

    }
}