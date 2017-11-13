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
using RestaurantsIntegrationService.Models.RTBills;

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
                    var errorMessage = "";
                    foreach (var item in data.Items.MasterData)
                    {
                        errorMessage = ValidateInsertBills(item.A_CODE, item.CC_CODE, item.U_ID, item.W_Code, item.AC_CODE_DTL, item.CARD_NO, item.AC_DTL_TYP, item.A_CY, data.DatabaseName);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                        }
                    }

                    errorMessage = ValidateInsertBillsDetails(data);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    foreach (var item in data.Items.MasterData)
                    {
                        //TODO: Active Number is null, please check after ProjectNumber
                        var ccCode = string.IsNullOrEmpty(data.CodeCostCenter) ? "NULL" : data.CodeCostCenter;
                        var cardNo = !item.CARD_NO.HasValue ? "NULL" : item.CARD_NO.Value.ToString();
                        string query = "insert into Res_bill_mst (BILL_NO, BILL_SER, PAY_TYPE, BILL_DATE, A_CY, AC_RATE, BILL_AMT, DISC_AMT, VAT_AMT, OTHR_AMT, CREDIT_CARD, CR_CARD_NO, CR_CARD_AMT, AC_DTL_TYP, AC_CODE_DTL, A_CODE, CASH_NO, CC_CODE, PJ_NO, ACTV_NO, DOC_POST, W_CODE, MACHINE_NO, U_ID, MOVE_BILL, MOVE_INC, MOVE_OUT, CMP_NO, BRN_NO, BRN_YEAR, BRN_USR, CARD_AMT, CARD_NO) values" +
                            "(" + item.BILL_NO + ", " + item.BILL_SER + ", " + item.PAY_TYPE + ", to_date('" + item.BILL_DATE.Value.ToString("dd/MM/yyyy") + "', 'dd/mm/yyyy'), '" + item.A_CY + "' , " + item.AC_RATE + ", " + item.BILL_AMT + ", " + item.DISC_AMT + ", " + item.VAT_AMT + ", " + item.OTHR_AMT + ", " + item.CREDIT_CARD + ", " + item.CR_CARD_NO + ", " + item.CR_CARD_AMT + ", " + item.AC_DTL_TYP + ", '" + item.AC_CODE_DTL + "', '" + item.A_CODE + "', " + item.Cash_No + ", " + ccCode + " "
                            + ", " + data.OnyxProjectNumber + ", " + data.OnyxActiveNumber + ", " + item.DOC_POST + ", " + item.W_Code + ", " + item.MACHINE_NO + ", " + item.U_ID + ", " + item.MOVE_BILL + ", " + item.MOVE_INC + ", " + item.MOVE_OUT + ", " + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + ", " + item.CARD_AMT + ", " + cardNo + ")";
                        OracleCommand command = new OracleCommand(query, conn);
                        command.Transaction = transaction;
                        testQuery = query;
                        command.ExecuteNonQuery();
                        //----------------------------------------------------------------------------------------
                        //Posting Detail
                        var detail = data.Items.DetailsData.FirstOrDefault(b => b.BILL_SER == item.BILL_SER && b.W_Code == item.W_Code);
                        query = "insert into Res_bill_dtl (BILL_NO,BILL_SER,PAY_TYPE,I_Code,ITM_UNT,P_SIZE,I_QTY,P_QTY,I_PRICE,VAT_AMT,OTHR_AMT,DISC_AMT,CC_CODE,PJ_NO,ACTV_NO,W_Code,OUT_W_CODE,SERVICE_ITEM,Expire_Date,Batch_No,CMP_NO, BRN_NO, BRN_YEAR, BRN_USR) values" +
                            "(" + item.BILL_NO + ", " + item.BILL_SER + ", " + item.PAY_TYPE + ",'" + detail.I_Code + "','" + detail.ITM_UNT + "', " + detail.P_SIZE + ", " + detail.I_QTY + ", " + detail.P_QTY + ", " + detail.I_PRICE + ", " + detail.VAT_AMT + ", " + detail.OTHR_AMT + ", " + detail.DISC_AMT + ", '" + detail.CC_CODE + "', " + data.OnyxProjectNumber + ", " + data.OnyxActiveNumber + ", '" + detail.W_Code + "', '" + detail.OUT_W_CODE + "', " + (detail.SERVICE_ITEM ? 1 : 0) + "," + GetOracleDate(detail.Expire_Date) + ",'" + detail.Batch_No + "'," + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + ")";
                        command = new OracleCommand(query, conn);
                        testQuery = query;
                        command.ExecuteNonQuery();
                        //----------------------------------------------------------------------------------------
                        //Posting Components
                        var Comp = data.Items.ComponentsData.FirstOrDefault(b => b.BILL_SER == item.BILL_SER && b.Bill_No == item.BILL_NO && b.W_Code == item.W_Code);
                        query = "insert into RES_BILL_COMPND_DTL (BILL_NO, BILL_SER, I_CODE, ITM_UNT, P_SIZE, I_QTY, P_QTY, DI_CODE, DITM_UNT, DP_SIZE, DI_QTY, DP_QTY, W_CODE, CMP_NO, BRN_NO, BRN_YEAR, BRN_USR,Expire_Date,Batch_No) values" +
                            "(" + item.BILL_NO + ", " + item.BILL_SER + ", '" + Comp.I_Code + "','" + Comp.ITM_UNT + "', " + Comp.P_SIZE + ", " + Comp.I_QTY + "," + Comp.P_QTY + ", '" + Comp.DI_Code + "','" + Comp.DITM_UNT + "', " + Comp.DP_SIZE + ", " + Comp.DI_QTY + ", " + Comp.DP_QTY + ",'" + Comp.W_Code + "', " + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + "," + GetOracleDate(Comp.Expire_Date) + ",'" + Comp.Batch_No + "')";
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


        private string ValidateInsertBills(string aCode, string cCode, short? uId, short? wCode, int? acCodeDetail, int? cardNo, int? acDetailType, string aCY, string databaseName)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(databaseName))
            {
                conn.Open();
                if (GetCommandDataCount("SELECT A_CODE FROM ACCOUNT_CURR Where A_CODE ='" + aCode + "' AND A_CY = '" + aCY + "'", conn) == 0)
                {
                    message = $"Account code {aCode} Not exist";
                    return message;
                }

                if (!string.IsNullOrEmpty(cCode))
                {
                    if (GetCommandDataCount("SELECT CC_CODE FROM COST_CENTERS Where CC_CODE ='" + cCode + "'", conn) == 0)
                    {
                        message = $"Cost Center code {cCode} Not exist";
                        return message;
                    }
                }


                if (uId.HasValue)
                {
                    if (GetCommandDataCount("SELECT U_ID FROM USER_R Where U_ID = " + uId, conn) == 0)
                    {
                        message = $"User code {uId} Not exist";
                        return message;
                    }
                }


                if (wCode.HasValue)
                {
                    if (GetCommandDataCount("SELECT W_CODE FROM WAREHOUSE_DETAILS Where W_CODE = " + wCode, conn) == 0)
                    {
                        message = $"Warehouse code {wCode} Not exist";
                        return message;
                    }
                }

                if (acCodeDetail.HasValue)
                {
                    if (acDetailType == 1) // Cash_no
                    {
                        if (GetCommandDataCount("SELECT CASH_NO FROM CASH_IN_HAND Where CASH_NO = " + acCodeDetail, conn) == 0)
                        {
                            message = $"Cach Number {acCodeDetail} Not exist";
                            return message;
                        }
                    }
                    else if (acDetailType == 2) // Card_no
                    {
                        if (cardNo.HasValue)
                        {
                            if (GetCommandDataCount("SELECT CR_CARD_NO FROM CREDIT_CARD_TYPES Where CR_CARD_NO = " + cardNo, conn) == 0)
                            {
                                message = $"Card Number {cardNo} Not exist";
                                return message;
                            }
                        }
                    }
                    else if (acDetailType == 3) // Customer Code
                    {
                        if (GetCommandDataCount("SELECT CC_CODE FROM CUSTOMER Where C_CODE = " + acCodeDetail, conn) == 0)
                        {
                            message = $"Customer Code {acCodeDetail} Not exist";
                            return message;
                        }
                    }
                }

            }

            return message;
        }


        private string ValidateInsertBillsDetails(TransferModel<TransferBillModel> data)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(data.DatabaseName))
            {
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

        private string ValidateInsertRTBillsDetails(TransferModel<TransferReturnBillModel> data)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(data.DatabaseName))
            {
                foreach (var item in data.Items.ReturnDetailsData)
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

        [Route("InsertReturnBills")]
        [HttpPost]
        public IHttpActionResult InsertReturnBills(TransferModel<TransferReturnBillModel> data)
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
                    var errorMessage = "";
                    foreach (var item in data.Items.ReturnMasterData)
                    {
                        errorMessage = ValidateInsertBills(item.A_CODE, item.CC_CODE, item.U_ID, item.W_Code, item.AC_CODE_DTL, null, item.AC_DTL_TYP, item.A_CY, data.DatabaseName);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                        }
                    }

                    errorMessage = ValidateInsertRTBillsDetails(data);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    foreach (var item in data.Items.ReturnMasterData)
                    {
                        //TODO: Active Number is null, please check after ProjectNumber
                        var ccCode = data.CodeCostCenter;
                        var cardNo = "NULL";
                        var billSerial = string.IsNullOrEmpty(item.RT_BILL_SER) ? "NULL" : item.RT_BILL_SER;
                        string query = "insert into RES_RT_BILL_MST (RT_BILL_NO, RT_BILL_SER, BILL_NO, BILL_SER, PAY_TYPE, BILL_DATE, A_CY, AC_RATE, BILL_AMT, DISC_AMT, VAT_AMT, OTHR_AMT, CREDIT_CARD, CR_CARD_NO, CR_CARD_AMT, AC_DTL_TYP, AC_CODE_DTL, A_CODE, CASH_NO, CC_CODE, PJ_NO, ACTV_NO, DOC_POST, W_CODE, MACHINE_NO, U_ID, MOVE_BILL, MOVE_INC, MOVE_OUT, CMP_NO, BRN_NO, BRN_YEAR, BRN_USR) values" +
                            "(" + item.RT_Bill_No + ", " + item.RT_BILL_SER + "," + item.BILL_NO + ", " + billSerial + ", " + item.PAY_TYPE + ", to_date('" + item.BILL_DATE.Value.ToString("dd/MM/yyyy") + "', 'dd/mm/yyyy'), '" + item.A_CY + "' , " + item.AC_RATE + ", " + item.BILL_AMT + ", " + item.DISC_AMT + ", " + item.VAT_AMT + ", " + item.OTHR_AMT + ", " + 0 + ", " + 0 + ", " + 0 + ", " + item.AC_DTL_TYP + ", '" + item.AC_CODE_DTL + "', '" + item.A_CODE + "', " + item.Cash_No + ", " + ccCode + " "
                            + ", " + data.OnyxProjectNumber + ", NULL , " + item.DOC_POST + ", " + item.W_Code + ", " + item.MACHINE_NO + ", " + item.U_ID + ", " + item.MOVE_BILL + ", " + item.MOVE_INC + ", " + item.MOVE_OUT + ", " + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + ")";
                        OracleCommand command = new OracleCommand(query, conn);
                        command.Transaction = transaction;
                        testQuery = query;
                        command.ExecuteNonQuery();
                        //----------------------------------------------------------------------------------------
                        //Posting Detail
                        var detail = data.Items.ReturnDetailsData.FirstOrDefault(b => b.RT_BILL_SER == item.RT_BILL_SER && b.W_Code == item.W_Code);
                        query = "insert into RES_RT_BILL_DTL (RT_BILL_NO, RT_BILL_SER, BILL_NO, BILL_SER, PAY_TYPE, I_CODE, ITM_UNT, P_SIZE, I_QTY, P_QTY, I_PRICE, VAT_AMT, OTHR_AMT, DISC_AMT, CC_CODE, PJ_NO, ACTV_NO, W_CODE, OUT_W_CODE, SERVICE_ITEM, CMP_NO, BRN_NO, BRN_YEAR, BRN_USR,Expire_Date,Batch_No) values" +
                            "(" + item.RT_Bill_No + ", " + item.RT_BILL_SER + "," + item.BILL_NO + ", " + billSerial + ", " + item.PAY_TYPE + ",'" + detail.I_Code + "','" + detail.ITM_UNT + "', " + detail.P_SIZE + ", " + detail.I_QTY + "," + detail.P_QTY + ", " + detail.I_PRICE + ", " + detail.VAT_AMT + ", " + detail.OTHR_AMT + ", " + detail.DISC_AMT + ", '" + ccCode + "', " + data.OnyxProjectNumber + ", NULL , '" + detail.W_Code + "', '" + detail.OUT_W_CODE + "', " + (detail.SERVICE_ITEM ? 1 : 0) + ", " + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + "," + GetOracleDate(detail.Expire_Date) + ",'" + detail.Batch_No + "')";
                        command = new OracleCommand(query, conn);
                        testQuery = query;
                        command.ExecuteNonQuery();
                        //----------------------------------------------------------------------------------------
                        //Posting Components
                        var Comp = data.Items.ReturnComponentsData.FirstOrDefault(b => b.RT_BILL_SER == item.RT_BILL_SER && b.RT_Bill_No == item.RT_Bill_No && b.W_Code == item.W_Code);
                        query = "insert into RES_RT_BILL_COMPND_DTL (RT_BILL_NO, RT_BILL_SER, I_CODE, ITM_UNT, P_SIZE, I_QTY, P_QTY, DI_CODE, DITM_UNT, DP_SIZE, DI_QTY, DP_QTY, W_CODE, CMP_NO, BRN_NO, BRN_YEAR, BRN_USR,Expire_Date,Batch_No) values" +
                            "(" + item.RT_Bill_No + ", " + item.RT_BILL_SER + ", '" + Comp.I_Code + "','" + Comp.ITM_UNT + "', " + Comp.P_SIZE + ", " + Comp.I_QTY + "," + Comp.P_QTY + ", '" + Comp.DI_Code + "','" + Comp.DITM_UNT + "', " + Comp.DP_SIZE + ", " + Comp.DI_QTY + ", " + Comp.DP_QTY + ",'" + Comp.W_Code + "', " + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + "," + GetOracleDate(Comp.Expire_Date) + ",'" + Comp.Batch_No + "')";
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


        private int GetCommandDataCount(string query, OracleConnection conn)
        {
            OracleCommand command = new OracleCommand(query, conn);
            OracleDataAdapter adp = new OracleDataAdapter(command);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt.Rows.Count;
        }


        private string GetOracleDate(DateTime? date)
        {
            if (date.HasValue)
            {
                return "to_date('" + date.Value.ToString("dd/MM/yyyy") + "','dd/MM/yyyy')";
            }

            return "to_date('01/01/1900','dd/MM/yyyy')";
        }

        private string GetOracleDate(DateTime date)
        {
            return "to_date('" + date.ToString("dd/MM/yyyy") + "','dd/MM/yyyy')";
        }

        private string GetOracleDate(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return "to_date('01/01/1900','dd/MM/yyyy')";
            }

            var dateTime = DateTime.Parse(date);
            return "to_date('" + dateTime.ToString("dd/MM/yyyy") + "','dd/MM/yyyy')";
        }

    }
}