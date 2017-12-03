using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class StockAdjustmentTransferModel
    {
        public List<Stock_Adjst_MST> Master { get; set; }
        public List<Stock_Adjst_DTL> Detail { get; set; }
    }
}