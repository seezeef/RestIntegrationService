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
    
    public partial class Damage_MST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Damage_MST()
        {
            this.Damage_DTL = new HashSet<Damage_DTL>();
        }
    
        public Nullable<int> Doc_no { get; set; }
        public Nullable<System.DateTime> Doc_Date { get; set; }
        public Nullable<short> W_CODE { get; set; }
        public string Damage_Reason { get; set; }
        public string REF_NO { get; set; }
        public string DOC_DESC { get; set; }
        public short Out_Type { get; set; }
        public bool PROCESSED { get; set; }
        public bool B_Sync { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public bool P_Onyx { get; set; }
        public Nullable<short> User_ID { get; set; }
        public string AD_TRMNL_NM { get; set; }
        public long DocSer { get; set; }
        public short Branch_No { get; set; }
        public Nullable<int> POS_No { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Damage_DTL> Damage_DTL { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual User User { get; set; }
    }
}
