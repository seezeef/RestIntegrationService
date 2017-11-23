using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.StockAdjustment
{
    public class TransferStockAdjustment
    {
        public List<RES_STK_MSTModel> StockMaster { get; set; }
        public List<RES_STK_DTLModel> StockDetails { get; set; }
    }
}