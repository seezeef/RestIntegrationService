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
    
    public partial class ConfirmConsume_MST
    {
        public Nullable<int> Doc_No { get; set; }
        public Nullable<System.DateTime> Doc_Date { get; set; }
        public Nullable<short> W_CODE { get; set; }
        public string Damage_Reason { get; set; }
        public string REF_NO { get; set; }
        public string DOC_DESC { get; set; }
        public bool PROCESSED { get; set; }
        public bool B_Sync { get; set; }
        public bool P_Onyx { get; set; }
        public Nullable<short> User_ID { get; set; }
        public short Branch_No { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual User User { get; set; }
    }
}