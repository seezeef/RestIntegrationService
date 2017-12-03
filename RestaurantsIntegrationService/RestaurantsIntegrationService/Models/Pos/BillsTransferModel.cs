using RestaurantsIntegrationService.DataAccess;
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
    }
}