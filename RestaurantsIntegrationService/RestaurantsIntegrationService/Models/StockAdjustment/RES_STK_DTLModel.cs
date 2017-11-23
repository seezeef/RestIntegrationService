using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.StockAdjustment
{
    public class RES_STK_DTLModel
    {
        public int STK_TYPE { get; set; }
        public int DOC_NO { get; set; }
        public Nullable<long> Doc_Ser { get; set; }
        public string I_Code { get; set; }
        public string ITM_UNT { get; set; }
        public float P_SIZE { get; set; }
        public Nullable<double> I_QTY { get; set; }
        public Nullable<double> P_QTY { get; set; }
        public short w_code { get; set; }
        public string CC_Code { get; set; }
        public Nullable<System.DateTime> EXPIRE_DATE { get; set; }
        public Nullable<int> ITEM_DESC { get; set; }
        public Nullable<long> RCRD_NO { get; set; }
        public Nullable<long> Stk_ID { get; set; }
    }
}