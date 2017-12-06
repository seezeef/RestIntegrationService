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
    
    public partial class Driver
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Driver()
        {
            this.Areas_Drivers = new HashSet<Areas_Drivers>();
            this.Dlvr_Dtl = new HashSet<Dlvr_Dtl>();
            this.DriverGps = new HashSet<DriverGp>();
            this.Drivers_Work_Days = new HashSet<Drivers_Work_Days>();
        }
    
        public int Dr_No { get; set; }
        public string Dr_Name { get; set; }
        public string Address { get; set; }
        public string Tel_No { get; set; }
        public string Account_No { get; set; }
        public bool Stopped { get; set; }
        public Nullable<short> Max_Orders { get; set; }
        public string Password { get; set; }
        public short Branch_No { get; set; }
        public string D_Color { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Areas_Drivers> Areas_Drivers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dlvr_Dtl> Dlvr_Dtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriverGp> DriverGps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Drivers_Work_Days> Drivers_Work_Days { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}