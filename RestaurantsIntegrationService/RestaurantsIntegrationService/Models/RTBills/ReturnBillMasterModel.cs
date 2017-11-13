using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.RTBills
{
    public class ReturnBillMasterModel
    {
        public long RT_Bill_No { get; set; }
        public string RT_BILL_SER { get; set; }
        public long BILL_NO { get; set; }
        public Nullable<short> PAY_TYPE { get; set; }
        public Nullable<System.DateTime> BILL_DATE { get; set; }
        public string A_CY { get; set; }
        public int AC_RATE { get; set; }
        public Nullable<double> BILL_AMT { get; set; }
        public Nullable<double> DISC_AMT { get; set; }
        public Nullable<short> VAT_AMT { get; set; }
        public int OTHR_AMT { get; set; }
        public Nullable<int> AC_DTL_TYP { get; set; }
        public Nullable<int> AC_CODE_DTL { get; set; }
        public string A_CODE { get; set; }
        public Nullable<short> Cash_No { get; set; }
        public string CC_CODE { get; set; }
        public int DOC_POST { get; set; }
        public Nullable<short> W_Code { get; set; }
        public int MACHINE_NO { get; set; }
        public Nullable<short> U_ID { get; set; }
        public int MOVE_BILL { get; set; }
        public int MOVE_INC { get; set; }
        public int MOVE_OUT { get; set; }
        public int POS_No { get; set; }
        public short Branch_No { get; set; }
    }
}