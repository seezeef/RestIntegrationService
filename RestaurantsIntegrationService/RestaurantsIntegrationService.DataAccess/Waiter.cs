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
    
    public partial class Waiter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Waiter()
        {
            this.Deleted_H = new HashSet<Deleted_H>();
            this.HstrRest_H = new HashSet<HstrRest_H>();
            this.Restaurant_H = new HashSet<Restaurant_H>();
            this.Waiters_Privileges = new HashSet<Waiters_Privileges>();
        }
    
        public short Waiter_No { get; set; }
        public string Waiter_Name { get; set; }
        public string Password { get; set; }
        public bool All_Benches { get; set; }
        public short Branch_No { get; set; }
        public string Account_No { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deleted_H> Deleted_H { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HstrRest_H> HstrRest_H { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Restaurant_H> Restaurant_H { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Waiters_Privileges> Waiters_Privileges { get; set; }
    }
}
