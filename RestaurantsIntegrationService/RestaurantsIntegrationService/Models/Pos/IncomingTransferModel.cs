using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class IncomingTransferModel
    {
        public List<InComing_Mst> Master { get; set; }
        public List<InComing_DTL> Detail { get; set; }
    }
}