﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.RTBills
{
    public class ReturnBillComponentsModel
    {
        public long RT_Bill_No { get; set; }
        public string RT_BILL_SER { get; set; }
        public string I_Code { get; set; }
        public string ITM_UNT { get; set; }
        public float P_SIZE { get; set; }
        public Nullable<double> I_QTY { get; set; }
        public Nullable<double> P_QTY { get; set; }
        public string DI_Code { get; set; }
        public string DITM_UNT { get; set; }
        public float DP_SIZE { get; set; }
        public Nullable<double> DI_QTY { get; set; }
        public Nullable<double> DP_QTY { get; set; }
        public Nullable<short> W_Code { get; set; }
        public string Expire_Date { get; set; }
        public int Batch_No { get; set; }
    }
}