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
    
    public partial class Incoming_Types
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Incoming_Types()
        {
            this.InComing_DTL = new HashSet<InComing_DTL>();
            this.InComing_Mst = new HashSet<InComing_Mst>();
        }
    
        public short Type_No { get; set; }
        public string Type_AName { get; set; }
        public string Type_EName { get; set; }
        public short Branch_No { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InComing_DTL> InComing_DTL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InComing_Mst> InComing_Mst { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}