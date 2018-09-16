using RestaurantsIntegrationService.DataAccess;
using RestaurantsIntegrationService.Models.Pos;
using RestaurantsIntegrationService.Models.Result;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web.Http;
using EntityFramework.Utilities;
using RestaurantsIntegrationService.Core.Extensions;
using WebGrease.Css.Extensions;

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
            try
            {
                using (var ts = new TransactionScope())
                {

                    using (Restaurants context = new Restaurants())
                    {
                        data.BillsMaster.ForEach(x =>
                        {
                            x.B_Sync = true;
                            x.SyncDate = DateTime.Now;
                        });
                        //data.RestaurantOrders.ForEach(x =>
                        //{
                        //    x.B_Sync = true;
                        //    x.SyncDate = DateTime.Now;
                        //});
                        data.ItemMoves.ForEach(x =>
                        {
                            x.B_Sync = true;
                            x.SyncDate = DateTime.Now;
                        });

                        data.DeletedHs.ForEach(x => x.B_Sync = true);
                        data.CanceledOrderHs.ForEach(x=>x.B_Sync=true);
                        // EFBatch

                        EFBatchOperation.For(context, context.HstrRest_H).InsertAll(data.BillsMaster);
                        EFBatchOperation.For(context, context.HstrRest_D).InsertAll(data.BillsDetail);
                        EFBatchOperation.For(context, context.HstrRest_D_DTL).InsertAll(data.BillsComponents);
                        EFBatchOperation.For(context, context.Item_Move).InsertAll(data.ItemMoves);
                        //EFBatchOperation.For(context, context.Restaurant_Orders).InsertAll(data.RestaurantOrders);
                        EFBatchOperation.For(context, context.Dlvr_Dtl).InsertAll(data.DeliveryDetails);
                        EFBatchOperation.For(context, context.CanceledOrder_H).InsertAll(data.CanceledOrderHs);
                        EFBatchOperation.For(context, context.Deleted_H).InsertAll(data.DeletedHs);
                        
                        ts.Complete();
                    }
                }
            }
            catch (TransactionAbortedException ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
            }
            catch (Exception ex)
            {
                var error = ex as SqlException;
                if (error != null && error.Number == 2627 &&
                    ex.GetLastException().Contains("Violation of PRIMARY KEY constraint"))
                {
                    using (var tranasactionScope = new TransactionScope())
                    {
                        using (var context = new Restaurants())
                        {
                            var branch = data.BillsMaster.Select(x => x.Branch_No).FirstOrDefault();
                            var date = context.HstrRest_H.OrderByDescending(x => x.S_Date).Select(x => x.S_Date)
                                .FirstOrDefault().GetValueOrDefault().AddDays(-10);
                            var allEntities = context.HstrRest_H
                                .Where(x => x.Branch_No == branch &&
                                            DbFunctions.TruncateTime(x.S_Date) >= DbFunctions.TruncateTime(date))
                                .AsNoTracking();

                            var similarEntities = data.BillsMaster.Intersect(allEntities,
                                new LambdaComparer<HstrRest_H>(
                                    (x, y) => x.ASerial == y.ASerial && x.Order_No == y.Order_No &&
                                              x.Branch_No == y.Branch_No && x.POS_No == y.POS_No)).ToList();
                            foreach (var entity in similarEntities)
                            {
                                var detailsToberemoved =
                                    data.BillsDetail
                                        .Where(x => x.ASerial == entity.ASerial && x.POS_No == entity.POS_No).ToList();

                                detailsToberemoved.ForEach(x => data.BillsDetail.Remove(x));

                                //foreach (var detail in detailsToberemoved)
                                //{
                                //    data.BillsDetail.Remove(detail);
                                //}
                                //foreach (var hstrRestDDtl in entity.Restaurant_Info.HstrRest_D_DTL)
                                //{
                                //    data.BillsComponents.Remove(hstrRestDDtl);
                                //}
                                //foreach (var item in entity.Restaurant_Info.Item_Move)
                                //{
                                //    data.ItemMoves.Remove(item);
                                //}
                                //foreach (var order in entity.Restaurant_Info.Restaurant_Orders)
                                //{
                                //    data.RestaurantOrders.Remove(order);
                                //}
                                //var ordersTobeRemoved =
                                //    data.RestaurantOrders.Where(
                                //        x => x.ASerial == entity.ASerial && x.POS_No == entity.POS_No && x.Branch_No == entity.Branch_No && x.Serial_No == entity.Serial_No);
                                //data.RestaurantOrders.RemoveRange(0, ordersTobeRemoved.Count());
                                //ordersTobeRemoved.ForEach(x=>data.RestaurantOrders.Remove(x));
                                data.BillsMaster.Remove(entity);

                            }
                            var ddTlEntities = context.HstrRest_D_DTL.Where(x => x.Branch_No == branch)
                                .OrderByDescending(x => x.ASerial).AsNoTracking().Take(20000);

                            var similarDdtl = data.BillsComponents.Intersect(ddTlEntities,
                                new LambdaComparer<HstrRest_D_DTL>(
                                    (x, y) => x.ASerial == y.ASerial && x.S_ID == y.S_ID &&
                                              x.Branch_No == y.Branch_No && x.RCRD_No == y.RCRD_No &&
                                              x.POS_No == y.POS_No)).ToList();
                            similarDdtl.ForEach(x => data.BillsComponents.Remove(x));

                            var itemMovesEntites = context.Item_Move
                                .Where(x => x.Branch_No == branch && x.Doc_Type == 1)
                                .OrderByDescending(x => x.Doc_No).AsNoTracking().Take(20000);
                            var similarItemMoves = data.ItemMoves.Intersect(itemMovesEntites,
                                new LambdaComparer<Item_Move>(
                                    (x, y) => x.SN_No == y.SN_No)).ToList();
                            similarItemMoves.ForEach(x => data.ItemMoves.Remove(x));

                            //var restaurantOrdersEntities = context.Restaurant_Orders.Where(x => x.Branch_No == branch)
                            //    .AsNoTracking().Take(20000);
                            //var similarRestaurantOrders = data.RestaurantOrders.Intersect(restaurantOrdersEntities,
                            //    new LambdaComparer<Restaurant_Orders>(
                            //        (x, y) => x.ASerial == y.ASerial && x.Branch_No == y.Branch_No && x.Serial_No == y.Serial_No && x.POS_No == y.POS_No));
                            //similarRestaurantOrders.ForEach(x => data.RestaurantOrders.Remove(x));
                            EFBatchOperation.For(context, context.HstrRest_H).InsertAll(data.BillsMaster);
                            EFBatchOperation.For(context, context.HstrRest_D).InsertAll(data.BillsDetail);
                            EFBatchOperation.For(context, context.HstrRest_D_DTL).InsertAll(data.BillsComponents);
                            EFBatchOperation.For(context, context.Item_Move).InsertAll(data.ItemMoves);
                            // EFBatchOperation.For(context, context.Restaurant_Orders).InsertAll(data.RestaurantOrders);

                            tranasactionScope.Complete();
                        }
                    }

                }
                else
                {
                    return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                }

            }


            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        [Route("InsertReturnBills")]
        [HttpPost]
        public IHttpActionResult InsertReturnBills(ReturnBillsTransferModel data)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    using (Restaurants context = new Restaurants())
                    {
                        data.ReturnBillsMaster.ForEach(x =>
                        {
                            x.B_Sync = true;
                            x.SyncDate = DateTime.Now;
                        });
                        data.ItemMoves.ForEach(x => x.B_Sync = true);
                        EFBatchOperation.For(context, context.RT_Bill_MST).InsertAll(data.ReturnBillsMaster);
                        EFBatchOperation.For(context, context.RT_Bill_DTL).InsertAll(data.ReturnBillsDetail);
                        EFBatchOperation.For(context, context.RT_Bill_DTL_DTL).InsertAll(data.ReturnBillsComponents);
                        EFBatchOperation.For(context, context.Item_Move).InsertAll(data.ItemMoves);
                        ts.Complete();

                        #region Old code
                        //context.RT_Bill_MST.AddRange(data.ReturnBillsMaster);
                        //context.RT_Bill_DTL.AddRange(data.ReturnBillsDetail);
                        //context.RT_Bill_DTL_DTL.AddRange(data.ReturnBillsComponents);
                        //context.Item_Move.AddRange(data.ItemMoves);
                        //context.SaveChanges();
                        //dbContextTransaction.Commit(); 
                        #endregion
                    }
                }
            }
            catch (TransactionAbortedException ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
            }
            catch (Exception ex)
            {
                var error = ex as SqlException;
                if (error != null && error.Number == 2627 && ex.GetLastException().Contains("Violation of PRIMARY KEY constraint"))
                {
                    using (var tranasactionScope = new TransactionScope())
                    {
                        using (var context = new Restaurants())
                        {
                            var branch = data.ReturnBillsMaster.Select(x => x.Branch_No).FirstOrDefault();
                            //var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                            //&& DbFunctions.TruncateTime(x.SyncDate) >= DbFunctions.TruncateTime(date)
                            var allEntities = context.RT_Bill_MST.Where(x => x.Branch_No == branch).ToList();

                            var similarEntities = data.ReturnBillsMaster.Intersect(allEntities,
                                new LambdaComparer<RT_Bill_MST>(
                                    (x, y) => x.RT_Bill_No == y.RT_Bill_No && x.Branch_No == y.Branch_No &&
                                              x.POS_No == y.POS_No)).ToList();
                            foreach (var entity in similarEntities)
                            {
                                var detailsToberemoved =
                                    data.ReturnBillsDetail.Where(x => x.RT_Bill_No == entity.RT_Bill_No && x.POS_No == entity.POS_No).ToList();
                                foreach (var rtBillDtl in detailsToberemoved)
                                {
                                    var componentsTobeDeleted = data.ReturnBillsComponents.Where(
                                        x => x.RT_Bill_No == rtBillDtl.RT_Bill_No && x.POS_No == entity.POS_No && x.S_ID == rtBillDtl.S_ID).ToList();
                                    foreach (var component in componentsTobeDeleted)
                                    {
                                        data.ReturnBillsComponents.Remove(component);
                                    }

                                    data.ReturnBillsDetail.Remove(rtBillDtl);
                                }
                                data.ReturnBillsMaster.Remove(entity);
                            }
                            EFBatchOperation.For(context, context.RT_Bill_MST).InsertAll(data.ReturnBillsMaster);
                            EFBatchOperation.For(context, context.RT_Bill_DTL).InsertAll(data.ReturnBillsDetail);
                            EFBatchOperation.For(context, context.RT_Bill_DTL_DTL).InsertAll(data.ReturnBillsComponents);
                            EFBatchOperation.For(context, context.Item_Move).InsertAll(data.ItemMoves);
                            tranasactionScope.Complete();
                        }
                    }

                }
                else
                {
                    return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                }

            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        [Route("InsertCustomerPayment")]
        [HttpPost]
        public IHttpActionResult InsertCustomerPayment(CustomerPamentsModel data)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    using (Restaurants context = new Restaurants())
                    {
                        data.CustomerPaymnets.ForEach(x =>
                        {
                            x.B_Sync = true;
                            x.SyncDate = DateTime.Now;
                        });
                        EFBatchOperation.For(context, context.Customers_Payment).InsertAll(data.CustomerPaymnets);
                        ts.Complete();
                        #region Old code
                        //context.RT_Bill_MST.AddRange(data.ReturnBillsMaster);
                        //context.RT_Bill_DTL.AddRange(data.ReturnBillsDetail);
                        //context.RT_Bill_DTL_DTL.AddRange(data.ReturnBillsComponents);
                        //context.Item_Move.AddRange(data.ItemMoves);
                        //context.SaveChanges();
                        //dbContextTransaction.Commit(); 
                        #endregion
                    }
                }
            }
            catch (TransactionAbortedException ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
            }
            catch (Exception ex)
            {
                var error = ex as SqlException;
                if (error != null && error.Number == 2627 && ex.GetLastException().Contains("Violation of PRIMARY KEY constraint"))
                {
                    using (var tranasactionScope = new TransactionScope())
                    {
                        using (var context = new Restaurants())
                        {
                            var branch = data.CustomerPaymnets.Select(x => x.Branch_No).FirstOrDefault();
                            //var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                            //&& DbFunctions.TruncateTime(x.SyncDate) >= DbFunctions.TruncateTime(date)
                            var allEntities = context.Customers_Payment.Where(x => x.Branch_No == branch).ToList();

                            var similarEntities = data.CustomerPaymnets.Intersect(allEntities,
                                new LambdaComparer<Customers_Payment>(
                                    (x, y) => x.Trans_ID == y.Trans_ID && x.Branch_No == y.Branch_No)).ToList();
                            foreach (var entity in similarEntities)
                            {
                                data.CustomerPaymnets.Remove(entity);
                            }
                            EFBatchOperation.For(context, context.Customers_Payment).InsertAll(data.CustomerPaymnets);
                            tranasactionScope.Complete();
                        }
                    }

                }
                else
                {
                    return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                }

            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        [Route("InsertStockAdjustment")]
        [HttpPost]
        public IHttpActionResult InsertStockAdjustment(StockAdjustmentTransferModel data)
        {
            try
            {
                using (Restaurants context = new Restaurants())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            data.Master.ForEach(x =>
                            {
                                x.B_Sync = true;
                                x.SyncDate = DateTime.Now;
                            });
                            data.ItemMoves.ForEach(x => x.B_Sync = true);
                            context.Stock_Adjst_MST.AddRange(data.Master);
                            context.Stock_Adjst_DTL.AddRange(data.Detail);
                            context.Item_Move.AddRange(data.ItemMoves);
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                        }
                    }
                    context.Stock_Adjst_MST.AddRange(data.Master);
                    context.Stock_Adjst_DTL.AddRange(data.Detail);
                    context.Item_Move.AddRange(data.ItemMoves);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }


        [Route("InsertWarehouse")]
        [HttpPost]
        public IHttpActionResult InsertWarehouse(WarehouseTransferModel data)
        {
            try
            {
                using (Restaurants context = new Restaurants())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            data.Master.ForEach(x =>
                            {
                                x.B_Sync = true;
                                x.SyncDate = DateTime.Now;
                            });
                            data.ItemMoves.ForEach(x => x.B_Sync = true);
                            context.RES_WHTRNS_MST.AddRange(data.Master);
                            context.RES_WHTRNS_DTL.AddRange(data.Detail);
                            context.Item_Move.AddRange(data.ItemMoves);
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }


        [Route("InsertInsurances")]
        [HttpPost]
        public IHttpActionResult InsertInsurances(InsuranceTransferModel data)
        {
            try
            {
                using (Restaurants context = new Restaurants())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            data.Master.ForEach(x =>
                            {
                                x.B_Sync = true;
                                x.SyncDate = DateTime.Now;
                            });
                            context.Insurances.AddRange(data.Master);
                            context.Insurance_Bills_DTL.AddRange(data.Detail);
                            context.Insurances_Closed.AddRange(data.Closed);
                            context.SaveChanges();
                            dbContextTransaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        [Route("InsertReturnIns")]
        [HttpPost]
        public IHttpActionResult InsertReturnIns(ReturnInsTransferModel data)
        {
            try
            {
                using (Restaurants context = new Restaurants())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            data.Master.ForEach(x =>
                            {
                                x.B_Sync = true;
                                x.SyncDate = DateTime.Now;
                            });
                            context.RT_Ins_MST.AddRange(data.Master);
                            context.RT_Ins_DTL.AddRange(data.Detail);
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }


        [Route("InsertIncoming")]
        [HttpPost]
        public IHttpActionResult InsertIncoming(IncomingTransferModel data)
        {
            try
            {
                using (Restaurants context = new Restaurants())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            data.Master.ForEach(x =>
                            {
                                x.B_Sync = true;
                                x.SyncDate = DateTime.Now;
                            });
                            context.InComing_Mst.AddRange(data.Master);
                            context.InComing_DTL.AddRange(data.Detail);
                            context.Item_Move.AddRange(data.ItemMoves);
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        [Route("InsertDamage")]
        [HttpPost]
        public IHttpActionResult InsertDamage(DamageTransferModel data)
        {
            try
            {
                using (Restaurants context = new Restaurants())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            data.Master.ForEach(x =>
                            {
                                x.B_Sync = true;
                                x.SyncDate = DateTime.Now;
                            });
                            context.Damage_MST.AddRange(data.Master);
                            context.Damage_DTL.AddRange(data.Detail);
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
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
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            data.Master.ForEach(x =>
                            {
                                x.B_Sync = true;
                                x.SyncDate = DateTime.Now;
                            });
                            context.Restaurant_Orders.AddRange(data.Master);
                            //context.Damage_DTL.AddRange(data.Detail);
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
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
                using (Restaurants context = new Restaurants())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        //try
                        //{
                        data.Master.ForEach(x =>
                        {
                            x.B_Sync = true;
                            x.SyncDate = DateTime.Now;
                        });
                        context.User_Income.AddRange(data.Master);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        //}
                        //catch (Exception ex)
                        //{
                        //    dbContextTransaction.Rollback();
                        //    return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                        //}
                    }

                }
            }
            catch (Exception ex)
            {
                var error = ex as SqlException;
                if (error != null && error.Number == 2627 &&
                    ex.GetLastException().Contains("Violation of PRIMARY KEY constraint"))
                {
                    DeleteDuplicateUserIncomes(data);

                }
                if (ex.GetLastException().Contains("Cannot insert duplicate key row in object"))
                {
                    DeleteDuplicateUserIncomes(data);
                }
                else
                {
                    return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                }


            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        private static void DeleteDuplicateUserIncomes(UserIncomeModel data)
        {
            using (var tranasactionScope = new TransactionScope())
            {
                using (var context = new Restaurants())
                {
                    var branch = data.Master.Select(x => x.Branch_No).FirstOrDefault();
                    //var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    var allEntities = context.User_Income
                        .Where(x => x.Branch_No == branch)
                        .ToList();

                    var similarEntities = data.Master.Intersect(allEntities,
                        new LambdaComparer<User_Income>(
                            (x, y) => x.Branch_No == y.Branch_No && x.Income_Date == y.Income_Date &&
                                      x.User_ID == y.User_ID)).ToList();
                    foreach (var entity in similarEntities)
                    {
                        data.Master.Remove(entity);
                    }
                    EFBatchOperation.For(context, context.User_Income).InsertAll(data.Master);
                    tranasactionScope.Complete();
                }
            }
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
                using (Restaurants context = new Restaurants())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            data.Master.ForEach(x =>
                            {
                                x.B_Sync = true;
                                x.SyncDate = DateTime.Now;
                            });
                            context.Spends.AddRange(data.Master);
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                var error = ex as SqlException;
                if (error != null && error.Number == 2627 &&
                    ex.GetLastException().Contains("Violation of PRIMARY KEY constraint"))
                {
                    using (var tranasactionScope = new TransactionScope())
                    {
                        using (var context = new Restaurants())
                        {
                            var branch = data.Master.Select(x => x.Branch_No).FirstOrDefault();
                            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                            var allEntities = context.Spends
                                .Where(x => x.Branch_No == branch &&
                                            DbFunctions.TruncateTime(x.SyncDate) >= DbFunctions.TruncateTime(date))
                                .ToList();

                            var similarEntities = data.Master.Intersect(allEntities,
                                new LambdaComparer<Spend>(
                                    (x, y) => x.Branch_No == y.Branch_No && x.Sp_No == y.Sp_No &&
                                              x.User_ID == y.User_ID)).ToList();
                            foreach (var entity in similarEntities)
                            {
                                data.Master.Remove(entity);
                            }
                            EFBatchOperation.For(context, context.Spends).InsertAll(data.Master);
                            tranasactionScope.Complete();
                        }
                    }

                }
                else
                {
                    return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
                }
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

        [Route("InsertMaintaince")]
        [HttpPost]
        public IHttpActionResult InsertMaintaince(MainatainceTransferModel data)
        {
            try
            {
                using (Restaurants context = new Restaurants())
                {
                    data.Master.ForEach(x =>
                    {
                        x.B_Sync = true;
                        x.SyncDate = DateTime.Now;
                    });
                    context.MNTNC_REQ.AddRange(data.Master);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok(new AjaxResponse<object>() { Success = false, ErrorMessage = ex.GetLastException() });
            }

            return Ok(new AjaxResponse<object>() { Success = true, SuccessMessage = "Successfully" });
        }

    }
}