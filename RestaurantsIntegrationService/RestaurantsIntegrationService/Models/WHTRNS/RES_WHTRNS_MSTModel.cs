using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.WHTRNS
{
    public class RES_WHTRNS_MSTModel

    {
        public Nullable<short> TR_INOUT_TYPE { get; set; }
        public Nullable<short> TR_TYPE { get; set; }
        public int TR_NO { get; set; }
        public string TR_SER { get; set; }
        public Nullable<System.DateTime> TR_DATE { get; set; }
        public Nullable<short> W_CODE { get; set; }
        public Nullable<short> F_W_CODE { get; set; }
        public Nullable<short> T_W_CODE { get; set; }
        public string CC_CODE { get; set; }
        public string REF_NO { get; set; }
        public string TR_DESC { get; set; }
        public bool PROCESSED { get; set; }
        public Nullable<long> F_TR_NO { get; set; }
        public string F_TR_SER { get; set; }
        public Nullable<short> AD_U_ID { get; set; }
        public System.DateTime AD_DATE { get; set; }
        public Nullable<short> DRIVER_NO { get; set; }
        public long DocSer { get; set; }
        public short Branch_No { get; set; }
    }
}