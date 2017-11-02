using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Bills
{
    public class BillDetailModel
    {
        public long BILL_NO { get; set; }
        public string BILL_SER { get; set; }
        public Nullable<short> PAY_TYPE { get; set; }
        public string I_Code { get; set; }
        public string ITM_UNT { get; set; }
        public float P_SIZE { get; set; }
        public Nullable<double> I_QTY { get; set; }
        public Nullable<double> P_QTY { get; set; }
        public Nullable<float> I_PRICE { get; set; }
        public int VAT_AMT { get; set; }
        public int OTHR_AMT { get; set; }
        public Nullable<double> DISC_AMT { get; set; }
        public string CC_CODE { get; set; }
        public Nullable<int> PJ_NO { get; set; }
        public Nullable<int> ACTV_NO { get; set; }
        public Nullable<short> W_Code { get; set; }
        public Nullable<short> OUT_W_CODE { get; set; }
        public bool SERVICE_ITEM { get; set; }
        public Nullable<decimal> CMP_NO { get; set; }
        public Nullable<decimal> brn_no { get; set; }
        public Nullable<decimal> BRN_YEAR { get; set; }
        public Nullable<decimal> BRN_USR { get; set; }
    }
}