using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class ReturnBillsTransferModel
    {
        public List<RT_Bill_MST> ReturnBillsMaster { get; set; }
        public List<RT_Bill_DTL> ReturnBillsDetail { get; set; }
        public List<RT_Bill_DTL_DTL> ReturnBillsComponents { get; set; }
    }
}