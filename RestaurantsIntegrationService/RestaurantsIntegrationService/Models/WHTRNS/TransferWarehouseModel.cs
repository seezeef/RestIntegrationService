using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.WHTRNS
{
    public class TransferWarehouseModel
    {
        public List<RES_WHTRNS_MSTModel> WarehouseMasterData { get; set; }
        public List<RES_WHTRNS_DTLModel> WarehouseDetailsData { get; set; }
    }
}