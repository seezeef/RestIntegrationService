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
    
    public partial class COST_CENTERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COST_CENTERS()
        {
            this.IAS_OUT_REQUEST_MST = new HashSet<IAS_OUT_REQUEST_MST>();
            this.RES_WHTRNS_DTL = new HashSet<RES_WHTRNS_DTL>();
            this.RES_WHTRNS_MST = new HashSet<RES_WHTRNS_MST>();
        }
    
        public Nullable<int> CC_NO { get; set; }
        public string CC_CODE { get; set; }
        public string CC_A_NAME { get; set; }
        public string CC_E_NAME { get; set; }
        public short Branch_No { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IAS_OUT_REQUEST_MST> IAS_OUT_REQUEST_MST { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RES_WHTRNS_DTL> RES_WHTRNS_DTL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RES_WHTRNS_MST> RES_WHTRNS_MST { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
