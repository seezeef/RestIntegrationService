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
    
    public partial class Coupons_Mst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Coupons_Mst()
        {
            this.Coupons_Dtl = new HashSet<Coupons_Dtl>();
        }
    
        public int Trans_ID { get; set; }
        public string Trans_Desc { get; set; }
        public Nullable<System.DateTime> Trans_Date { get; set; }
        public Nullable<short> User_ID { get; set; }
        public short Branch_No { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coupons_Dtl> Coupons_Dtl { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
