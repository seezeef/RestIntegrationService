﻿using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class BillsTransferModel
    {
        public List<HstrRest_H> BillsMaster { get; set; }
        public List<HstrRest_D> BillsDetail { get; set; }
        public List<HstrRest_D_DTL> BillsComponents { get; set; }
        public List<Item_Move> ItemMoves { get; set; }
        //public List<Restaurant_Orders> RestaurantOrders { get; set; }
        public List<Dlvr_Dtl> DeliveryDetails { get; set; }
        public List<CanceledOrder_H> CanceledOrderHs { get; set; }
        public List<CanceledOrder_D> CanceledOrderDs { get; set; }
        public List<Deleted_H> DeletedHs { get; set; }
        public List<Deleted_D> DeletedDs { get; set; }

    }
}