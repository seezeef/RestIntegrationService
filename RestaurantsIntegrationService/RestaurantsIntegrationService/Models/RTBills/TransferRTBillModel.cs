using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.RTBills
{
    public class TransferRTBillModel
    {
        public List<RTBillMasterModel> RTMasterData { get; set; }
        public List<RTBillDetailModel> RTDetailsData { get; set; }
        public List<RTBillComponentsModel> RTComponentsData { get; set; }
    }
}