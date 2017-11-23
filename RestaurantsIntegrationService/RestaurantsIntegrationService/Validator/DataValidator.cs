using Oracle.DataAccess.Client;
using RestaurantsIntegrationService.Core.DataAccess;
using RestaurantsIntegrationService.Models;
using RestaurantsIntegrationService.Models.Bills;
using RestaurantsIntegrationService.Models.RTBills;
using RestaurantsIntegrationService.Models.StockAdjustment;
using RestaurantsIntegrationService.Models.Validators;
using RestaurantsIntegrationService.Models.WHTRNS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Validator
{
    public static class DataValidator
    {
        public static string ValidateInsertBillsDetails(TransferModel<TransferBillModel> data)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(data.DatabaseName))
            {
                var query = "select ";
                var i = 0;
                foreach (var item in data.Items.DetailsData.GroupBy(x => x.I_Code).Select(x => x.FirstOrDefault()))
                {
                    if (i == 0)
                    {
                        query += "'" + item.I_Code + "' AS I_CODE, '" + item.ITM_UNT + "' AS ITM_UNT FROM DUAL";
                    }
                    else
                    {
                        query += " union select '" + item.I_Code + "', '" + item.ITM_UNT + "' FROM DUAL";
                    }
                    i++;
                }

                query = query + " MINUS SELECT I_CODE, ITM_UNT FROM IAS_V_ITM_UNT";

                OracleCommand command = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    message = "Item Code(s) (";
                    foreach (DataRow item in dt.Rows)
                    {
                        message += item[0].ToString() + " " + item[1].ToString() + " , ";
                    }
                    message += ") Not exist(s)";
                }

                return message;

            }
        }


        public static string ValidateInsertRTBillsDetails(TransferModel<TransferReturnBillModel> data)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(data.DatabaseName))
            {
                var query = "select ";
                var i = 0;
                foreach (var item in data.Items.ReturnDetailsData.GroupBy(x => x.I_Code).Select(x => x.FirstOrDefault()))
                {
                    if (i == 0)
                    {
                        query += "'" + item.I_Code + "' AS I_CODE, '" + item.ITM_UNT + "' AS ITM_UNT FROM DUAL";
                    }
                    else
                    {
                        query += " union select '" + item.I_Code + "', '" + item.ITM_UNT + "' FROM DUAL";
                    }
                    i++;
                }

                query = query + " MINUS SELECT I_CODE, ITM_UNT FROM IAS_V_ITM_UNT";

                OracleCommand command = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    message = "Item Code(s) (";
                    foreach (DataRow item in dt.Rows)
                    {
                        message += item[0].ToString() + " " + item[1].ToString() + " , ";
                    }
                    message += ") Not exist(s)";
                }

                return message;

            }
        }

        public static string ValidateInsertWarehouse(TransferModel<TransferWarehouseModel> data)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(data.DatabaseName))
            {
                var query = "select ";
                var i = 0;
                foreach (var item in data.Items.WarehouseDetailsData.GroupBy(x => x.I_Code).Select(x => x.FirstOrDefault()))
                {
                    if (i == 0)
                    {
                        query += "'" + item.I_Code + "' AS I_CODE, '" + item.ITM_UNT + "' AS ITM_UNT FROM DUAL";
                    }
                    else
                    {
                        query += " union select '" + item.I_Code + "', '" + item.ITM_UNT + "' FROM DUAL";
                    }
                    i++;
                }

                query = query + " MINUS SELECT I_CODE, ITM_UNT FROM IAS_V_ITM_UNT";

                OracleCommand command = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    message = "Item Code(s) (";
                    foreach (DataRow item in dt.Rows)
                    {
                        message += item[0].ToString() + " " + item[1].ToString() + " , ";
                    }
                    message += ") Not exist(s)";
                }

                return message;

            }
        }


        public static string ValidateInsertStockAdjustment(TransferModel<TransferStockAdjustment> data)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(data.DatabaseName))
            {
                var query = "select ";
                var i = 0;
                foreach (var item in data.Items.StockDetails.GroupBy(x => x.I_Code).Select(x => x.FirstOrDefault()))
                {
                    if (i == 0)
                    {
                        query += "'" + item.I_Code + "' AS I_CODE, '" + item.ITM_UNT + "' AS ITM_UNT FROM DUAL";
                    }
                    else
                    {
                        query += " union select '" + item.I_Code + "', '" + item.ITM_UNT + "' FROM DUAL";
                    }
                    i++;
                }

                query = query + " MINUS SELECT I_CODE, ITM_UNT FROM IAS_V_ITM_UNT";

                OracleCommand command = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    message = "Item Code(s) (";
                    foreach (DataRow item in dt.Rows)
                    {
                        message += item[0].ToString() + " " + item[1].ToString() + " , ";
                    }
                    message += ") Not exist(s)";
                }

                return message;

            }
        }

        public static string ValidateACode(List<ValidateACodeModel> aCodes, string databaseName)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(databaseName))
            {
                var query = "select ";
                var i = 0;
                foreach (var item in aCodes)
                {
                    if (i == 0)
                    {
                        query += "'" + item.ACode + "' AS A_CODE, '" + item.ACY + "' AS A_CY FROM DUAL";
                    }
                    else
                    {
                        query += " union select '" + item.ACode + "', '" + item.ACY + "' FROM DUAL";
                    }
                    i++;
                }

                query = query + " MINUS SELECT A_CODE, A_CY FROM ACCOUNT_CURR";

                OracleCommand command = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    message = "Account Code(s) (";
                    foreach (DataRow item in dt.Rows)
                    {
                        message += item[0].ToString() + " , ";
                    }
                    message += ") Not exist(s)";
                }

                return message;

            }
        }

        public static string ValidateCCCode(List<string> cCCodes, string databaseName)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(databaseName))
            {
                if (cCCodes.All(a => string.IsNullOrEmpty(a)))
                {
                    return "";
                }
                var query = "select ";
                var i = 0;
                foreach (var item in cCCodes.Distinct())
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        query += "'" + item + "' AS CC_CODE FROM DUAL";
                    }
                    else
                    {
                        query += " union select '" + item + "' FROM DUAL";
                    }
                    i++;
                }

                query = query + " MINUS SELECT CC_CODE FROM COST_CENTERS";

                OracleCommand command = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    message = "Cost Center Code(s) (";
                    foreach (DataRow item in dt.Rows)
                    {
                        message += item[0].ToString() + " , ";
                    }
                    message += ") Not exist(s)";
                }

                return message;

            }
        }

        public static string ValidateUid(List<short?> uids, string databaseName)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(databaseName))
            {
                var query = "select ";
                var i = 0;
                foreach (var item in uids.Distinct())
                {
                    if (!item.HasValue)
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        query += "" + item + " AS U_ID FROM DUAL";
                    }
                    else
                    {
                        query += " union select " + item + " FROM DUAL";
                    }
                    i++;
                }

                query = query + " MINUS SELECT U_ID FROM USER_R";

                OracleCommand command = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    message = "User Code(s) (";
                    foreach (DataRow item in dt.Rows)
                    {
                        message += item[0].ToString() + " , ";
                    }
                    message += ") Not exist(s)";
                }

                return message;

            }
        }

        public static string ValidateWcode(List<short?> wCodes, string databaseName)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(databaseName))
            {
                var query = "select ";
                var i = 0;
                foreach (var item in wCodes.Distinct())
                {
                    if (!item.HasValue)
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        query += "" + item + " AS W_CODE FROM DUAL";
                    }
                    else
                    {
                        query += " union select " + item + " FROM DUAL";
                    }
                    i++;
                }

                query = query + " MINUS SELECT W_CODE FROM WAREHOUSE_DETAILS";

                OracleCommand command = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    message = "Warehouse Code(s) (";
                    foreach (DataRow item in dt.Rows)
                    {
                        message += item[0].ToString() + " , ";
                    }
                    message += ") Not exist(s)";
                }

                return message;

            }
        }

        public static string ValidateAccDetail(List<ValidateAccDetailModel> data, string databaseName)
        {

            string errorMessage = "";
            errorMessage = ValidateCacheNo(data.Where(d => d.AccountTypeId == 1).Select(d => d.CacheNo).ToList(), databaseName);

            if (string.IsNullOrEmpty(errorMessage))
            {
                return errorMessage;
            }

            errorMessage = ValidateCardNo(data.Where(d => d.AccountTypeId == 2).Select(d => d.CacheNo).ToList(), databaseName);

            if (string.IsNullOrEmpty(errorMessage))
            {
                return errorMessage;
            }

            errorMessage = ValidateCCCodeForAccountDetail(data.Where(d => d.AccountTypeId == 3).Select(d => d.CacheNo).ToList(), databaseName);


            return errorMessage;
        }


        private static string ValidateCacheNo(List<int?> cacheNos, string databaseName)
        {
            var message = "";
            using (var conn = ConnectionManager.GetConnection(databaseName))
            {
                var query = "select ";
                var i = 0;
                foreach (var item in cacheNos.Distinct())
                {
                    if (!item.HasValue)
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        query += "" + item + " AS CASH_NO FROM DUAL";
                    }
                    else
                    {
                        query += " union select " + item + " FROM DUAL";
                    }
                    i++;
                }

                query = query + " MINUS SELECT CASH_NO FROM CASH_IN_HAND";

                OracleCommand command = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    message = "Cach Number(s) (";
                    foreach (DataRow item in dt.Rows)
                    {
                        message += item[0].ToString() + " , ";
                    }
                    message += ") Not exist(s)";
                }

                return message;

            }
        }


        private static string ValidateCardNo(List<int?> cardNos, string databaseName)
        {
            var message = "";
            if (cardNos.All(a => !a.HasValue))
            {
                return "";
            }
            using (var conn = ConnectionManager.GetConnection(databaseName))
            {
                var query = "select ";
                var i = 0;
                foreach (var item in cardNos.Distinct())
                {
                    if (!item.HasValue)
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        query += "" + item + " AS CR_CARD_NO FROM DUAL";
                    }
                    else
                    {
                        query += " union select " + item + " FROM DUAL";
                    }
                    i++;
                }

                query = query + " MINUS SELECT CR_CARD_NO FROM CREDIT_CARD_TYPES";

                OracleCommand command = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    message = "Card Number(s) (";
                    foreach (DataRow item in dt.Rows)
                    {
                        message += item[0].ToString() + " , ";
                    }
                    message += ") Not exist(s)";
                }

                return message;

            }
        }


        private static string ValidateCCCodeForAccountDetail(List<int?> ccCodes, string databaseName)
        {
            var message = "";
            if (ccCodes.All(a => !a.HasValue))
            {
                return "";
            }
            using (var conn = ConnectionManager.GetConnection(databaseName))
            {
                var query = "select ";
                var i = 0;
                foreach (var item in ccCodes.Distinct())
                {
                    if (!item.HasValue)
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        query += "'" + item + "' AS C_CODE FROM DUAL";
                    }
                    else
                    {
                        query += " union select '" + item + "' FROM DUAL";
                    }
                    i++;
                }

                query = query + " MINUS SELECT C_CODE FROM CUSTOMER";

                OracleCommand command = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    message = "Customer Code(s) (";
                    foreach (DataRow item in dt.Rows)
                    {
                        message += item[0].ToString() + " , ";
                    }
                    message += ") Not exist(s)";
                }

                return message;

            }
        }
        //public static string ValidateInsertBills(string aCode, string cCode, short? uId, short? wCode, int? acCodeDetail, int? cardNo, int? acDetailType, string aCY, string databaseName)
        //{
        //    var message = "";
        //    using (var conn = ConnectionManager.GetConnection(databaseName))
        //    {
        //        conn.Open();

        //        if (cCode != null)
        //            if (!string.IsNullOrEmpty(cCode))
        //            {
        //                if (GetCommandDataCount("SELECT CC_CODE FROM COST_CENTERS Where CC_CODE ='" + cCode + "'", conn) == 0)
        //                {
        //                    message = $"Cost Center code {cCode} Not exist";
        //                    return message;
        //                }
        //            }


        //        if (uId.HasValue)
        //        {
        //            if (GetCommandDataCount("SELECT U_ID FROM USER_R Where U_ID = " + uId, conn) == 0)
        //            {
        //                message = $"User code {uId} Not exist";
        //                return message;
        //            }
        //        }


        //        if (wCode.HasValue)
        //        {
        //            if (GetCommandDataCount("SELECT W_CODE FROM WAREHOUSE_DETAILS Where W_CODE = " + wCode, conn) == 0)
        //            {
        //                message = $"Warehouse code {wCode} Not exist";
        //                return message;
        //            }
        //        }

        //        if (acCodeDetail.HasValue)
        //        {
        //            if (acDetailType == 1) // Cash_no
        //            {
        //                if (GetCommandDataCount("SELECT CASH_NO FROM CASH_IN_HAND Where CASH_NO = " + acCodeDetail, conn) == 0)
        //                {
        //                    message = $"Cach Number {acCodeDetail} Not exist";
        //                    return message;
        //                }
        //            }
        //            else if (acDetailType == 2) // Card_no
        //            {
        //                if (cardNo.HasValue)
        //                {
        //                    if (GetCommandDataCount("SELECT CR_CARD_NO FROM CREDIT_CARD_TYPES Where CR_CARD_NO = " + cardNo, conn) == 0)
        //                    {
        //                        message = $"Card Number {cardNo} Not exist";
        //                        return message;
        //                    }
        //                }
        //            }
        //            else if (acDetailType == 3) // Customer Code
        //            {
        //                if (GetCommandDataCount("SELECT CC_CODE FROM CUSTOMER Where C_CODE = " + acCodeDetail, conn) == 0)
        //                {
        //                    message = $"Customer Code {acCodeDetail} Not exist";
        //                    return message;
        //                }
        //            }
        //        }

        //    }

        //    return message;
        //}

    }
}