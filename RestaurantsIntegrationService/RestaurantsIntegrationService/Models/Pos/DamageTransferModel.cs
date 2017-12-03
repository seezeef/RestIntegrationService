using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class DamageTransferModel
    {
        public List<Damage_MST> Master { get; set; }
        public List<Damage_DTL> Detail { get; set; }
    }
}