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
    
    public partial class Restaurant_Menus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant_Menus()
        {
            this.HstrRest_H = new HashSet<HstrRest_H>();
            this.Restaurant_H = new HashSet<Restaurant_H>();
            this.Restaurant_Menus_Food = new HashSet<Restaurant_Menus_Food>();
        }
    
        public short Menu_No { get; set; }
        public string Menu_Name { get; set; }
        public string Menu_E_Name { get; set; }
        public Nullable<decimal> Menu_Person_Price { get; set; }
        public bool Can_Use { get; set; }
        public short Branch_No { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HstrRest_H> HstrRest_H { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Restaurant_H> Restaurant_H { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Restaurant_Menus_Food> Restaurant_Menus_Food { get; set; }
    }
}