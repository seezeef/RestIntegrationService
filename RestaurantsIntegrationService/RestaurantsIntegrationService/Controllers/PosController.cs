using RestaurantsIntegrationService.DataAccess;
using RestaurantsIntegrationService.Models.Pos;
using RestaurantsIntegrationService.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RestaurantsIntegrationService.Controllers
{
    [Authorize]
    [RoutePrefix("api/pos")]
    public class PosController : ApiController
    {
        [Route("InsertBills")]
        [HttpPost]
        public IHttpActionResult InsertBills(BillsTransferModel data)
        {
            long test = 0;
            try
            {
                using (Restaurants context = new DataAccess.Restaurants())
                {
                    context.HstrRest_H.AddRange(data.BillsMaster);                  
                    context.HstrRest_D.AddRange(data.BillsDetail);
                    context.HstrRest_D_DTL.AddRange(data.BillsComponents);
                    context.Item_Move.AddRange(data.ItemMoves);
                    context.Restaurant_Orders.AddRange(data.RestaurantOrders);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        [Route("InsertReturnBills")]
        [HttpPost]
        public IHttpActionResult InsertReturnBills(ReturnBillsTransferModel data)
        {
            try
            {
                using (Restaurants context = new DataAccess.Restaurants())
                {
                    context.RT_Bill_MST.AddRange(data.ReturnBillsMaster);
                    context.RT_Bill_DTL.AddRange(data.ReturnBillsDetail);
                    context.RT_Bill_DTL_DTL.AddRange(data.ReturnBillsComponents);
                    context.Item_Move.AddRange(data.ItemMoves);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        [Route("InsertStockAdjustment")]
        [HttpPost]
        public IHttpActionResult InsertStockAdjustment(StockAdjustmentTransferModel data)
        {
            try
            {
                using (Restaurants context = new DataAccess.Restaurants())
                {
                    context.Stock_Adjst_MST.AddRange(data.Master);
                    context.Stock_Adjst_DTL.AddRange(data.Detail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }


        [Route("InsertWarehouse")]
        [HttpPost]
        public IHttpActionResult InsertWarehouse(WarehouseTransferModel data)
        {
            try
            {
                using (Restaurants context = new DataAccess.Restaurants())
                {
                    context.RES_WHTRNS_MST.AddRange(data.Master);
                    context.RES_WHTRNS_DTL.AddRange(data.Detail);
                    context.Item_Move.AddRange(data.ItemMoves);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }
        

        [Route("InsertInsurances")]
        [HttpPost]
        public IHttpActionResult InsertInsurances(InsuranceTransferModel data)
        {
            try
            {
                using (Restaurants context = new DataAccess.Restaurants())
                {
                    context.Insurances.AddRange(data.Master);
                    context.Insurance_Bills_DTL.AddRange(data.Detail);
                    context.Insurances_Closed.AddRange(data.Closed);                    
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        [Route("InsertReturnIns")]
        [HttpPost]
        public IHttpActionResult InsertReturnIns(ReturnInsTransferModel data)
        {
            try
            {
                using (Restaurants context = new DataAccess.Restaurants())
                {
                    context.RT_Ins_MST.AddRange(data.Master);
                    context.RT_Ins_DTL.AddRange(data.Detail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }


        [Route("InsertIncoming")]
        [HttpPost]
        public IHttpActionResult InsertIncoming(IncomingTransferModel data)
        {
            try
            {
                using (Restaurants context = new DataAccess.Restaurants())
                {
                    context.InComing_Mst.AddRange(data.Master);
                    context.InComing_DTL.AddRange(data.Detail);
                    context.Item_Move.AddRange(data.ItemMoves);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        [Route("InsertDamage")]
        [HttpPost]
        public IHttpActionResult InsertDamage(DamageTransferModel data)
        {
            try
            {
                using (Restaurants context = new DataAccess.Restaurants())
                {
                    context.Damage_MST.AddRange(data.Master);
                    context.Damage_DTL.AddRange(data.Detail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        /// <summary>
        /// Restaurant_Orders
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("InsertRestaurantOrders")]
        [HttpPost]
        public IHttpActionResult InsertRestaurantOrders(RestaurantOrdersTransferModel data)
        {
            try
            {
                using (Restaurants context = new Restaurants())
                {
                    context.Restaurant_Orders.AddRange(data.Master);
                    //context.Damage_DTL.AddRange(data.Detail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        /// <summary>
        /// Item_Move
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Route("InsertItemMove")]
        //[HttpPost]
        //public IHttpActionResult InsertItemMove(ItemMoveTransferModel data)
        //{
        //    try
        //    {
        //        using (Restaurants context = new Restaurants())
        //        {
        //            context.Item_Move.AddRange(data.Master);
        //            //context.Damage_DTL.AddRange(data.Detail);
        //            context.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
        //    }

        //    return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        //}

        /// <summary>
        /// User_Income
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("InsertUserIncome")]
        [HttpPost]
        public IHttpActionResult InsertUserIncome(UserIncomeModel data)
        {
            try
            {
                using (Restaurants context = new DataAccess.Restaurants())
                {
                    context.User_Income.AddRange(data.Master);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        /// <summary>
        /// Spends
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("InsertSpends")]
        [HttpPost]
        public IHttpActionResult InsertSpends(SpendsTransferModel data)
        {
            try
            {
                using (Restaurants context = new DataAccess.Restaurants())
                {
                    context.Spends.AddRange(data.Master);                    
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.Message });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

    }
}