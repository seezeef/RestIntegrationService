﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Bills
{
    public class BillDetailModel
    {
        public long BILL_NO { get; set; }
        public string BILL_SER { get; set; }
        public Nullable<short> Pay_Type { get; set; }
        public string I_Code { get; set; }
        public string ITM_UNT { get; set; }
        public float P_SIZE { get; set; }
        public Nullable<double> I_QTY { get; set; }
        public Nullable<double> P_QTY { get; set; }
        public Nullable<float> I_PRICE { get; set; }
        public int VAT_AMT { get; set; }
        public int OTHR_AMT { get; set; }
        public Nullable<double> DISC_AMT { get; set; }
        public Nullable<short> W_Code { get; set; }
        public Nullable<short> OUT_W_CODE { get; set; }
        public bool SERVICE_ITEM { get; set; }
        public string CC_CODE { get; set; }
        public double S_ID { get; set; }
        public short Branch_No { get; set; }
        public int POS_No { get; set; }
        public Nullable<System.DateTime> Expire_Date { get; set; }
        public int Batch_No { get; set; }
    }
}