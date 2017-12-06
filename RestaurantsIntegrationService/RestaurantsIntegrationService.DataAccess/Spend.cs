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
    
    public partial class Spend
    {
        public int Sp_No { get; set; }
        public Nullable<decimal> Sp_Amount { get; set; }
        public Nullable<System.DateTime> Sp_Date { get; set; }
        public Nullable<System.DateTime> Sp_Time { get; set; }
        public string Sp_Desc { get; set; }
        public Nullable<short> User_ID { get; set; }
        public short Branch_No { get; set; }
        public bool Posted { get; set; }
        public bool Acc_Posted { get; set; }
        public bool U_Sync { get; set; }
        public bool B_Sync { get; set; }
        public Nullable<int> Sp_Type { get; set; }
        public long DocSer { get; set; }
        public Nullable<int> POS_No { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual Spends_Types Spends_Types { get; set; }
        public virtual User User { get; set; }
    }
}