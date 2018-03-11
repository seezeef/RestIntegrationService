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
    
    public partial class RES_WHTRNS_MST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RES_WHTRNS_MST()
        {
            this.RES_WHTRNS_DTL = new HashSet<RES_WHTRNS_DTL>();
        }
    
        public Nullable<int> Rec_ID { get; set; }
        public Nullable<short> TR_INOUT_TYPE { get; set; }
        public Nullable<short> TR_TYPE { get; set; }
        public Nullable<long> TR_NO { get; set; }
        public string TR_SER { get; set; }
        public Nullable<System.DateTime> TR_DATE { get; set; }
        public Nullable<System.DateTime> TR_Time { get; set; }
        public Nullable<short> W_CODE { get; set; }
        public Nullable<short> T_W_CODE { get; set; }
        public Nullable<short> F_W_CODE { get; set; }
        public string CC_CODE { get; set; }
        public string REF_NO { get; set; }
        public string TR_DESC { get; set; }
        public bool PROCESSED { get; set; }
        public Nullable<long> F_TR_NO { get; set; }
        public string F_TR_SER { get; set; }
        public bool Rec_Read { get; set; }
        public bool B_Sync { get; set; }
        public bool P_Onyx { get; set; }
        public int F_Rec_ID { get; set; }
        public Nullable<short> User_ID { get; set; }
        public string POS_Name { get; set; }
        public bool W_Posted { get; set; }
        public bool DRVR_DLVR { get; set; }
        public Nullable<short> DG_No { get; set; }
        public long DocSer { get; set; }
        public short Branch_No { get; set; }
        public Nullable<int> POS_No { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
    
        public virtual COST_CENTERS COST_CENTERS { get; set; }
        public virtual Delegate Delegate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RES_WHTRNS_DTL> RES_WHTRNS_DTL { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual TRANSFER_TYPES TRANSFER_TYPES { get; set; }
    }
}
