using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.StockAdjustment
{
    public class RES_STK_MSTModel
    {
        public int STK_TYPE { get; set; }
        public int DOC_NO { get; set; }
        public Nullable<long> DOC_SER { get; set; }
        public long Stk_ID { get; set; }
        public System.DateTime DOC_DATE { get; set; }
        public short W_CODE { get; set; }
        public string CC_Code { get; set; }
        public string DOC_DESC { get; set; }
        public int DOC_POST { get; set; }
        public int MOVE_STK { get; set; }
        public Nullable<short> AD_U_ID { get; set; }
        public System.DateTime AD_DATE { get; set; }
        public string AD_TRMNL_NM { get; set; }
        public short Branch_No { get; set; }
        public int POS_No { get; set; }
    }
}