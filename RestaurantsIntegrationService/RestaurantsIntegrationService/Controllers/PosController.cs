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
    }
}