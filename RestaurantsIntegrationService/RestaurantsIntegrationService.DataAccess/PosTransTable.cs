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
    
    public partial class PosTransTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PosTransTable()
        {
            this.PosTransTable1 = new HashSet<PosTransTable>();
        }
    
        public int Id { get; set; }
        public string TableName { get; set; }
        public string Where { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<int> ParentId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PosTransTable> PosTransTable1 { get; set; }
        public virtual PosTransTable PosTransTable2 { get; set; }
    }
}
