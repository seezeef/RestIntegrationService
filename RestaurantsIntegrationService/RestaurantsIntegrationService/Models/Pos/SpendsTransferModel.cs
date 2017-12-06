using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class SpendsTransferModel
    {
        public List<Spend> Master { get; set; }
    }
}