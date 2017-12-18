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
using RestaurantsIntegrationService.DataAccess;
using RestaurantsIntegrationService.Models.Bills;
using RestaurantsIntegrationService.Models.Result;
using RestaurantsIntegrationService.Models.RTBills;
using RestaurantsIntegrationService.Models.WHTRNS;
using RestaurantsIntegrationService.Models.StockAdjustment;
using RestaurantsIntegrationService.Validator;
using RestaurantsIntegrationService.Models.Validators;

namespace RestaurantsIntegrationService.Controllers
{
    [Authorize]
    [RoutePrefix("api/integrations")]
    public class IntegrationController : ApiController
    {
        [Route("TestConnection")]
        [HttpPost]
        public IHttpActionResult TestConnection()
        {
            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Connected" });
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

                    errorMessage = DataValidator.ValidateACode(data.Items.MasterData.Select(a => new ValidateACodeModel()
                    {
                        ACode = a.A_CODE,
                        ACY = a.A_CY
                    }).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }


                    errorMessage = DataValidator.ValidateCCCode(data.Items.MasterData.Select(a => a.CC_CODE).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }


                    errorMessage = DataValidator.ValidateUid(data.Items.MasterData.Select(a => a.U_ID).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    errorMessage = DataValidator.ValidateWcode(data.Items.MasterData.Select(a => a.W_Code).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    errorMessage = DataValidator.ValidateAccDetail(data.Items.MasterData.Select(a => new ValidateAccDetailModel()
                    {
                        AccountTypeId = a.AC_DTL_TYP,
                        CardNo = a.CARD_NO,
                        CacheNo = a.AC_DTL_TYP,
                        CustomerCode = a.AC_DTL_TYP
                    }).ToList(), data.DatabaseName, ref testQuery);

                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    errorMessage = DataValidator.ValidateInsertBillsDetails(data);
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
                        var details = data.Items.DetailsData.Where(b => b.BILL_SER == item.BILL_SER && b.W_Code == item.W_Code);
                        foreach (var detail in details)
                        {
                            query = "insert into Res_bill_dtl (BILL_NO,BILL_SER,PAY_TYPE,I_Code,ITM_UNT,P_SIZE,I_QTY,P_QTY,I_PRICE,VAT_AMT,OTHR_AMT,DISC_AMT,CC_CODE,PJ_NO,ACTV_NO,W_Code,OUT_W_CODE,SERVICE_ITEM,Expire_Date,Batch_No,CMP_NO, BRN_NO, BRN_YEAR, BRN_USR) values" +
                            "(" + item.BILL_NO + ", " + item.BILL_SER + ", " + item.PAY_TYPE + ",'" + detail.I_Code + "','" + detail.ITM_UNT + "', " + detail.P_SIZE + ", " + detail.I_QTY + ", " + detail.P_QTY + ", " + detail.I_PRICE + ", " + detail.VAT_AMT + ", " + detail.OTHR_AMT + ", " + detail.DISC_AMT + ", '" + detail.CC_CODE + "', " + data.OnyxProjectNumber + ", " + data.OnyxActiveNumber + ", '" + detail.W_Code + "', '" + detail.OUT_W_CODE + "', " + (detail.SERVICE_ITEM ? 1 : 0) + "," + GetOracleDate(detail.Expire_Date) + ",'" + detail.Batch_No + "'," + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + ")";
                            command = new OracleCommand(query, conn);
                            testQuery = query;
                            command.ExecuteNonQuery();
                        }

                        //----------------------------------------------------------------------------------------
                        //Posting Components
                        var Comps = data.Items.ComponentsData.Where(b => b.BILL_SER == item.BILL_SER && b.Bill_No == item.BILL_NO && b.W_Code == item.W_Code);
                        foreach (var Comp in Comps)
                        {
                            query = "insert into RES_BILL_COMPND_DTL (BILL_NO, BILL_SER, I_CODE, ITM_UNT, P_SIZE, I_QTY, P_QTY, DI_CODE, DITM_UNT, DP_SIZE, DI_QTY, DP_QTY, W_CODE, CMP_NO, BRN_NO, BRN_YEAR, BRN_USR,Expire_Date,Batch_No) values" +
                           "(" + item.BILL_NO + ", " + item.BILL_SER + ", '" + Comp.I_Code + "','" + Comp.ITM_UNT + "', " + Comp.P_SIZE + ", " + Comp.I_QTY + "," + Comp.P_QTY + ", '" + Comp.DI_Code + "','" + Comp.DITM_UNT + "', " + Comp.DP_SIZE + ", " + Comp.DI_QTY + ", " + Comp.DP_QTY + ",'" + Comp.W_Code + "', " + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + "," + GetOracleDate(Comp.Expire_Date) + ",'" + Comp.Batch_No + "')";
                            command = new OracleCommand(query, conn);
                            testQuery = query;
                            command.ExecuteNonQuery();
                        }

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

                    errorMessage = DataValidator.ValidateACode(data.Items.ReturnMasterData.Select(a => new ValidateACodeModel()
                    {
                        ACode = a.A_CODE,
                        ACY = a.A_CY
                    }).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }


                    errorMessage = DataValidator.ValidateCCCode(data.Items.ReturnMasterData.Select(a => a.CC_CODE).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }


                    errorMessage = DataValidator.ValidateUid(data.Items.ReturnMasterData.Select(a => a.U_ID).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    errorMessage = DataValidator.ValidateWcode(data.Items.ReturnMasterData.Select(a => a.W_Code).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    errorMessage = DataValidator.ValidateAccDetail(data.Items.ReturnMasterData.Select(a => new ValidateAccDetailModel()
                    {
                        AccountTypeId = a.AC_DTL_TYP,
                        CardNo = null,
                        CacheNo = a.AC_DTL_TYP,
                        CustomerCode = a.AC_DTL_TYP
                    }).ToList(), data.DatabaseName, ref testQuery);

                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    errorMessage = DataValidator.ValidateInsertRTBillsDetails(data);
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
                            "(" + item.RT_Bill_No + ", " + item.RT_BILL_SER + "," + item.BILL_NO + ",  NULL , " + item.PAY_TYPE + ", to_date('" + item.BILL_DATE.Value.ToString("dd/MM/yyyy") + "', 'dd/mm/yyyy'), '" + item.A_CY + "' , " + item.AC_RATE + ", " + item.BILL_AMT + ", " + item.DISC_AMT + ", " + item.VAT_AMT + ", " + item.OTHR_AMT + ", " + 0 + ", " + 0 + ", " + 0 + ", " + item.AC_DTL_TYP + ", '" + item.AC_CODE_DTL + "', '" + item.A_CODE + "', " + item.Cash_No + ", " + ccCode + " "
                            + ", " + data.OnyxProjectNumber + ", NULL , " + item.DOC_POST + ", " + item.W_Code + ", " + item.MACHINE_NO + ", " + item.U_ID + ", " + item.MOVE_BILL + ", " + item.MOVE_INC + ", " + item.MOVE_OUT + ", " + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + ")";
                        OracleCommand command = new OracleCommand(query, conn);
                        command.Transaction = transaction;
                        testQuery = query;
                        command.ExecuteNonQuery();
                        //----------------------------------------------------------------------------------------
                        //Posting Detail
                        var detail = data.Items.ReturnDetailsData.FirstOrDefault(b => b.RT_BILL_SER == item.RT_BILL_SER && b.W_Code == item.W_Code);
                        query = "insert into RES_RT_BILL_DTL (RT_BILL_NO, RT_BILL_SER, BILL_NO, BILL_SER, PAY_TYPE, I_CODE, ITM_UNT, P_SIZE, I_QTY, P_QTY, I_PRICE, VAT_AMT, OTHR_AMT, DISC_AMT, CC_CODE, PJ_NO, ACTV_NO, W_CODE, OUT_W_CODE, SERVICE_ITEM, CMP_NO, BRN_NO, BRN_YEAR, BRN_USR,Expire_Date,Batch_No) values" +
                            "(" + item.RT_Bill_No + ", " + item.RT_BILL_SER + "," + item.BILL_NO + ", NULL , " + item.PAY_TYPE + ",'" + detail.I_Code + "','" + detail.ITM_UNT + "', " + detail.P_SIZE + ", " + detail.I_QTY + "," + detail.P_QTY + ", " + detail.I_PRICE + ", " + detail.VAT_AMT + ", " + detail.OTHR_AMT + ", " + detail.DISC_AMT + ", " + ccCode + ", " + data.OnyxProjectNumber + ", NULL , '" + detail.W_Code + "', '" + detail.OUT_W_CODE + "', " + (detail.SERVICE_ITEM ? 1 : 0) + ", " + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + "," + GetOracleDate(detail.Expire_Date) + ",'" + detail.Batch_No + "')";
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


        [Route("InsertWarehouse")]
        [HttpPost]
        public IHttpActionResult InsertWarehouse(TransferModel<TransferWarehouseModel> data)
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

                    errorMessage = DataValidator.ValidateCCCode(data.Items.WarehouseMasterData.Select(a => a.CC_CODE).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }


                    errorMessage = DataValidator.ValidateUid(data.Items.WarehouseMasterData.Select(a => a.AD_U_ID).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    errorMessage = DataValidator.ValidateWcode(data.Items.WarehouseMasterData.Select(a => a.W_CODE).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    errorMessage = DataValidator.ValidateInsertWarehouse(data);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }


                    foreach (var item in data.Items.WarehouseMasterData)
                    {
                        //TODO: Active Number is null, please check after ProjectNumber
                        var ccCode = string.IsNullOrEmpty(data.CodeCostCenter) ? "NULL" : data.CodeCostCenter;
                        var DriverNo = item.DRIVER_NO.HasValue ? item.DRIVER_NO.ToString() : "NULL";

                        string query = "insert into RES_WHTRNS_MST (TR_INOUT_TYPE,TR_TYPE,TR_NO,TR_SER,TR_DATE ,W_CODE ,F_W_CODE ,T_W_CODE ,CC_CODE ,REF_NO ,TR_DESC ,PROCESSED ,F_TR_NO ,F_TR_SER ,AD_U_ID ,AD_DATE ,DRIVER_NO ,PJ_NO,ACTV_NO,CMP_NO, BRN_NO, BRN_YEAR, BRN_USR) values" +
                            "(" + item.TR_INOUT_TYPE + ", " + item.TR_TYPE + ", " + item.TR_NO + "," + item.TR_SER + "," + GetOracleDate(item.TR_DATE) + ", " + item.W_CODE + " , " + item.F_W_CODE + ", " + item.T_W_CODE + ", " + ccCode + " ,'RES','" + item.TR_DESC + "'," + (item.PROCESSED ? 1 : 0) + ", " + item.F_TR_NO + ", " + item.F_TR_SER + ", " + item.AD_U_ID + ", " + GetOracleDate(item.AD_DATE) + ", " + DriverNo + ", " + data.OnyxProjectNumber + "," + data.OnyxActiveNumber + "," + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + ")";
                        OracleCommand command = new OracleCommand(query, conn);
                        command.Transaction = transaction;
                        testQuery = query;
                        command.ExecuteNonQuery();
                        //----------------------------------------------------------------------------------------
                        //Posting Detail
                        var details = data.Items.WarehouseDetailsData.Where(b => b.TR_NO == item.TR_NO && b.TR_SER == item.TR_SER);
                        foreach (var detail in details)
                        {
                            query = "insert into RES_WHTRNS_DTL (TR_INOUT_TYPE,TR_TYPE ,TR_NO,TR_SER,I_Code,ITM_UNT,TR_QTY,I_QTY,P_SIZE,P_QTY,W_CODE,F_W_CODE,T_W_CODE,CC_CODE,ITEM_DESC,F_TR_NO,F_TR_SER,USE_SERIALNO,BATCH_NO,RCRD_NO,Expire_Date,PJ_NO,ACTV_NO) values" +
                            "(" + item.TR_INOUT_TYPE + ", " + item.TR_TYPE + ", " + item.TR_NO + "," + item.TR_SER + ",'" + detail.I_Code + "','" + detail.ITM_UNT + "', " + detail.TR_QTY + ", " + detail.I_QTY + ", " + detail.P_SIZE + ", " + detail.P_QTY + ", " + detail.W_CODE + " , " + detail.F_W_CODE + ", " + detail.T_W_CODE + "," + ccCode + ",'" + detail.ITEM_DESC + "', " + item.F_TR_NO + ", " + item.F_TR_SER + ", " + detail.USE_SERIALNO + ", " + detail.BATCH_NO + ", " + detail.RCRD_NO + ", " + GetOracleDate(detail.Expire_Date) + "," + data.OnyxProjectNumber + "," + data.OnyxActiveNumber + ")";
                            command = new OracleCommand(query, conn);
                            testQuery = query;
                            command.ExecuteNonQuery();
                        }

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

        [Route("InsertStockAdjustment")]
        [HttpPost]
        public IHttpActionResult InsertStockAdjustment(TransferModel<TransferStockAdjustment> data)
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

                    errorMessage = DataValidator.ValidateCCCode(data.Items.StockMaster.Select(a => a.CC_Code).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    errorMessage = DataValidator.ValidateUid(data.Items.StockMaster.Select(a => a.AD_U_ID).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    errorMessage = DataValidator.ValidateWcode(data.Items.StockMaster.Select(a => (short?)a.W_CODE).ToList(), data.DatabaseName, ref testQuery);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    errorMessage = DataValidator.ValidateInsertStockAdjustment(data);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = errorMessage });
                    }

                    foreach (var item in data.Items.StockMaster)
                    {
                        //TODO: Active Number is null, please check after ProjectNumber
                        var ccCode = string.IsNullOrEmpty(data.CodeCostCenter) ? "NULL" : data.CodeCostCenter;

                        string query = "insert into RES_STK_MST (STK_TYPE,DOC_NO,DOC_SER,DOC_DATE,W_CODE,CC_Code,DOC_DESC,DOC_POST,MOVE_STK,AD_U_ID,AD_DATE,AD_TRMNL_NM ,PJ_NO,ACTV_NO,CMP_NO, BRN_NO, BRN_YEAR, BRN_USR) values" +
                            "(" + item.STK_TYPE + ", " + item.DOC_NO + ", " + item.DOC_SER + "," + GetOracleDate(item.DOC_DATE) + ", " + item.W_CODE + " , '" + ccCode + "','" + item.DOC_DESC + "'," + item.DOC_POST + ", " + item.MOVE_STK + ", " + item.AD_U_ID + ", " + GetOracleDate(item.AD_DATE) + ", '" + item.AD_TRMNL_NM + "', " + data.OnyxProjectNumber + "," + data.OnyxActiveNumber + "," + companyInfo.CompanyNumber + ", " + companyInfo.BranchNumber + ", " + companyInfo.BranchYear + ", " + companyInfo.BranchUser + ")";
                        OracleCommand command = new OracleCommand(query, conn);
                        command.Transaction = transaction;
                        testQuery = query;
                        command.ExecuteNonQuery();
                        //----------------------------------------------------------------------------------------
                        //Posting Detail
                        var details = data.Items.StockDetails.Where(b => b.Stk_ID == item.Stk_ID && b.DOC_NO == item.DOC_NO);
                        foreach (var detail in details)
                        {
                            query = "insert into RES_STK_DTL (STK_TYPE,DOC_NO,Doc_Ser,I_Code,ITM_UNT,P_SIZE,I_QTY,P_QTY,w_code,CC_Code,EXPIRE_DATE,ITEM_DESC,RCRD_NO,USE_SERIALNO,BATCH_NO,PJ_NO,ACTV_NO) values" +
                            "(" + item.STK_TYPE + ", " + item.DOC_NO + ", " + item.DOC_SER + ",'" + detail.I_Code + "','" + detail.ITM_UNT + "', " + detail.P_SIZE + ", " + detail.I_QTY + ", " + detail.P_QTY + ", " + detail.w_code + " , " + ccCode + "," + GetOracleDate(detail.EXPIRE_DATE) + ", '" + detail.ITEM_DESC + "', " + detail.RCRD_NO + ",0, 0, " + data.OnyxProjectNumber + "," + data.OnyxActiveNumber + ")";
                            command = new OracleCommand(query, conn);
                            testQuery = query;
                            command.ExecuteNonQuery();
                        }

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

        [Route("TestDb")]
        [HttpGet]
        [AllowAnonymous]
        [OverrideAuthentication]
        public IHttpActionResult TestDb()
        {
            using (var context = new Restaurants())
            {
                try
                {
                    var x = context.Areas.Count();
                    return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "connected" });
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.InnerException.Message });
                    }
                    return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
                }
            }
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