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
    
    public partial class EvalutionEstimate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EvalutionEstimate()
        {
            this.EvalutionModelEstimates = new HashSet<EvalutionModelEstimate>();
        }
    
        public short EstmID { get; set; }
        public string EstmName { get; set; }
        public string EstmFName { get; set; }
        public Nullable<short> EstmFRatio { get; set; }
        public Nullable<short> EstmTRatio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvalutionModelEstimate> EvalutionModelEstimates { get; set; }
    }
}
