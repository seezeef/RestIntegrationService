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
    
    public partial class ProductionRequestMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductionRequestMst()
        {
            this.ProductionRequestComponents = new HashSet<ProductionRequestComponent>();
            this.ProductionRequestDtls = new HashSet<ProductionRequestDtl>();
        }
    
        public Nullable<int> DocID { get; set; }
        public Nullable<System.DateTime> DocDate { get; set; }
        public Nullable<short> W_CODE { get; set; }
        public Nullable<short> F_W_CODE { get; set; }
        public string CC_CODE { get; set; }
        public string REF_NO { get; set; }
        public string DocDesc { get; set; }
        public bool DocOutgoing { get; set; }
        public bool DocIncoming { get; set; }
        public bool B_Sync { get; set; }
        public bool Acc_Posted { get; set; }
        public Nullable<short> User_ID { get; set; }
        public long DocSer { get; set; }
        public short Branch_No { get; set; }
        public Nullable<int> POS_No { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionRequestComponent> ProductionRequestComponents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionRequestDtl> ProductionRequestDtls { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}