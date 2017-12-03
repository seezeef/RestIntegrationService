using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class WarehouseTransferModel
    {
        public List<RES_WHTRNS_MST> Master { get; set; }
        public List<RES_WHTRNS_DTL> Detail { get; set; }
    }
}