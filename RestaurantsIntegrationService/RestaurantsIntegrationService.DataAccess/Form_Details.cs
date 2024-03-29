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
    
    public partial class Form_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Form_Details()
        {
            this.Privileges = new HashSet<Privilege>();
            this.SaveSettings = new HashSet<SaveSetting>();
            this.Users_Actions = new HashSet<Users_Actions>();
            this.Users_History = new HashSet<Users_History>();
        }
    
        public string Arabic_name { get; set; }
        public string Form_Name { get; set; }
        public short Form_No { get; set; }
        public Nullable<byte> Form_Type { get; set; }
        public string Form_Order { get; set; }
        public string Source_Name { get; set; }
        public string Form_Default { get; set; }
        public int Tab_No { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Privilege> Privileges { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaveSetting> SaveSettings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users_Actions> Users_Actions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users_History> Users_History { get; set; }
    }
}
