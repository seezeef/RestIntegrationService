//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace RestaurantsIntegrationService.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class WAREHOUSE_DETAILS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WAREHOUSE_DETAILS()
        {
            this.IAS_OUT_REQUEST_MST = new HashSet<IAS_OUT_REQUEST_MST>();
            this.IAS_OUT_REQUEST_DTL = new HashSet<IAS_OUT_REQUEST_DTL>();
        }
    
        public short W_CODE { get; set; }
        public string W_NAME { get; set; }
        public string W_E_NAME { get; set; }
        public string CC_CODE { get; set; }
        public short Branch_No { get; set; }
        [JsonIgnore]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IAS_OUT_REQUEST_MST> IAS_OUT_REQUEST_MST { get; set; }
        [JsonIgnore]
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<IAS_OUT_REQUEST_DTL> IAS_OUT_REQUEST_DTL { get; set; }
    }
}
