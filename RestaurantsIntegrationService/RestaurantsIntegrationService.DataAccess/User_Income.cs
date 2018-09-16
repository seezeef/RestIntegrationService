//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantsIntegrationService.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_Income
    {
        public int Income_Serail { get; set; }
        public short Branch_No { get; set; }
        public Nullable<short> User_ID { get; set; }
        public Nullable<System.DateTime> Income_Date { get; set; }
        public Nullable<System.DateTime> Income_Time { get; set; }
        public Nullable<decimal> Income_Amount { get; set; }
        public Nullable<decimal> Income_Visa_Amount { get; set; }
        public decimal Back_Amount { get; set; }
        public decimal Ins_Amount { get; set; }
        public decimal ReturnIns_Amount { get; set; }
        public decimal ResFood_Amount { get; set; }
        public decimal Cancel_Res_Amount { get; set; }
        public decimal RT_Amount { get; set; }
        public string Income_Note { get; set; }
        public Nullable<int> User_Edit { get; set; }
        public bool Approved { get; set; }
        public Nullable<double> CMSN_Per { get; set; }
        public Nullable<double> CMSN_Amt { get; set; }
        public Nullable<double> Purch_Amt { get; set; }
        public bool U_Sync { get; set; }
        public bool B_Sync { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public bool Posted { get; set; }
        public bool Acc_Posted { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual User User { get; set; }
    }
}
