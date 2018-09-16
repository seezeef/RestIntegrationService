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
    
    public partial class InComing_Mst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InComing_Mst()
        {
            this.InComing_DTL = new HashSet<InComing_DTL>();
        }
    
        public Nullable<int> Doc_No { get; set; }
        public Nullable<System.DateTime> Doc_Date { get; set; }
        public Nullable<short> W_CODE { get; set; }
        public Nullable<double> Doc_Amt { get; set; }
        public short Incom_Type { get; set; }
        public string AD_TRMNL_NM { get; set; }
        public string REF_NO { get; set; }
        public string DOC_DESC { get; set; }
        public bool PROCESSED { get; set; }
        public bool B_Sync { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public bool P_Onyx { get; set; }
        public Nullable<short> User_ID { get; set; }
        public short Branch_No { get; set; }
        public string AccAccount { get; set; }
        public int AccUserID { get; set; }
        public int AccCashNo { get; set; }
        public int AccEmpNo { get; set; }
        public long DocSer { get; set; }
        public Nullable<int> POS_No { get; set; }
        public bool Periodic { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InComing_DTL> InComing_DTL { get; set; }
        public virtual Incoming_Types Incoming_Types { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
