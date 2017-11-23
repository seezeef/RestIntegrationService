using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.WHTRNS
{
    public class RES_WHTRNS_DTLModel
    {
        public Nullable<short> TR_INOUT_TYPE { get; set; }
        public Nullable<short> TR_TYPE { get; set; }
        public int TR_NO { get; set; }
        public string TR_SER { get; set; }
        public string I_Code { get; set; }
        public string ITM_UNT { get; set; }
        public Nullable<double> TR_QTY { get; set; }
        public Nullable<double> I_QTY { get; set; }
        public float P_SIZE { get; set; }
        public Nullable<double> P_QTY { get; set; }
        public Nullable<short> W_CODE { get; set; }
        public Nullable<short> F_W_CODE { get; set; }
        public Nullable<short> T_W_CODE { get; set; }
        public string CC_CODE { get; set; }
        public string ITEM_DESC { get; set; }
        public Nullable<long> F_TR_NO { get; set; }
        public string F_TR_SER { get; set; }
        public int USE_SERIALNO { get; set; }
        public int BATCH_NO { get; set; }
        public Nullable<long> RCRD_NO { get; set; }
        public Nullable<System.DateTime> Expire_Date { get; set; }
    }
}