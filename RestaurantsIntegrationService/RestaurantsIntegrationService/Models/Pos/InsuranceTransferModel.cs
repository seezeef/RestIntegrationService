using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class InsuranceTransferModel
    {
        public List<Insurance> Master { get; set; }
        public List<Insurance_Bills_DTL> Detail { get; set; }
        public List<Insurances_Closed> Closed { get; set; }
    }
}