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
    
    public partial class AccSys_Accounts
    {
        public string A_code { get; set; }
        public string A_Cy { get; set; }
        public Nullable<short> A_Level { get; set; }
        public string A_Name { get; set; }
        public string A_Name_Eng { get; set; }
        public string A_Parent { get; set; }
        public string A_Report { get; set; }
        public Nullable<short> A_S_M { get; set; }
        public bool AC_Close { get; set; }
        public string AC_Type { get; set; }
        public bool AccountForCustomer { get; set; }
        public string AccNote { get; set; }
        public short Branch_No { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
