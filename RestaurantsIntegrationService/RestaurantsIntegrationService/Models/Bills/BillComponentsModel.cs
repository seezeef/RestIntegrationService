using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Bills
{
    public class BillComponentsModel
    {
        public long BILL_NO { get; set; }
        public string BILL_SER { get; set; }
        public string I_Code { get; set; }
        public string ITM_UNT { get; set; }
        public float P_SIZE { get; set; }
        public int P_food { get; set; }
        public Nullable<double> Prnt_qty { get; set; }
        public int DFood_no { get; set; }
        public string DI_code { get; set; }
        public string DI_UNT { get; set; }
        public float DP_SIZE { get; set; }
        public Nullable<double> Di_qty { get; set; }
        public Nullable<short> W_Code { get; set; }
    }
}