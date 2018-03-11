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
    
    public partial class Stock_Adjst_DTL
    {
        public int Doc_No { get; set; }
        public int Food_No { get; set; }
        public Nullable<double> F_Qty { get; set; }
        public Nullable<double> S_Qty { get; set; }
        public Nullable<double> Av_Qty { get; set; }
        public Nullable<double> Inv_Qty { get; set; }
        public short Branch_no { get; set; }
        public Nullable<System.DateTime> Expire_Date { get; set; }
        public int RCRD_No { get; set; }
        public bool B_Sync { get; set; }
        public Nullable<long> DocSer { get; set; }
        public int SyncSerial { get; set; }
    
        public virtual Food Food { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual Stock_Adjst_MST Stock_Adjst_MST { get; set; }
    }
}
