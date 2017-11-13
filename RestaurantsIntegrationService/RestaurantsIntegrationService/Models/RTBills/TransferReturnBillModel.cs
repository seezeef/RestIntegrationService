using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.RTBills
{
    public class TransferReturnBillModel
    {
        public List<ReturnBillMasterModel> ReturnMasterData { get; set; }
        public List<ReturnBillDetailModel> ReturnDetailsData { get; set; }
        public List<ReturnBillComponentsModel> ReturnComponentsData { get; set; }
    }
}