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
    
    public partial class RES_WHTRNS_DTL_T
    {
        public int Rec_ID { get; set; }
        public Nullable<short> TR_INOUT_TYPE { get; set; }
        public Nullable<short> TR_TYPE { get; set; }
        public Nullable<long> TR_NO { get; set; }
        public string TR_SER { get; set; }
        public int Food_No { get; set; }
        public Nullable<double> TR_QTY { get; set; }
        public Nullable<double> I_QTY { get; set; }
        public Nullable<double> P_QTY { get; set; }
        public Nullable<short> W_CODE { get; set; }
        public Nullable<short> T_W_CODE { get; set; }
        public Nullable<short> F_W_CODE { get; set; }
        public string CC_CODE { get; set; }
        public string ITEM_DESC { get; set; }
        public Nullable<long> F_TR_NO { get; set; }
        public string F_TR_SER { get; set; }
        public Nullable<System.DateTime> Expire_Date { get; set; }
        public bool B_Sync { get; set; }
        public short Branch_No { get; set; }
        public long DocSer { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
