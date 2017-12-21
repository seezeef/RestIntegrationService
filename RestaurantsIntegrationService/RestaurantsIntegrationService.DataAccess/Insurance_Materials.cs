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
    
    public partial class Insurance_Materials
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Insurance_Materials()
        {
            this.Insurance_Bills_DTL = new HashSet<Insurance_Bills_DTL>();
            this.RT_Ins_DTL = new HashSet<RT_Ins_DTL>();
        }
    
        public int M_No { get; set; }
        public string M_Name { get; set; }
        public string M_Name_E { get; set; }
        public Nullable<decimal> M_Price { get; set; }
        public short Branch_No { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Insurance_Bills_DTL> Insurance_Bills_DTL { get; set; }
        [JsonIgnore]
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<RT_Ins_DTL> RT_Ins_DTL { get; set; }
    }
}
