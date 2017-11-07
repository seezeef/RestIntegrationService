using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Bills
{
    public class TransferBillModel
    {
        public List<BillMasterModel> MasterData { get; set; }
        public List<BillDetailModel> DetailsData { get; set; }
        public List<BillComponentsModel> ComponentsData { get; set; }
    }
}