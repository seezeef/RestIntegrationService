using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class ReturnInsTransferModel
    {
        public List<RT_Ins_MST> Master { get; set; }
        public List<RT_Ins_DTL> Detail { get; set; }
    }
}