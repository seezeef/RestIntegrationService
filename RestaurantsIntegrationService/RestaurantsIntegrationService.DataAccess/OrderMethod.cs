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
    
    public partial class OrderMethod
    {
        public short Method_No { get; set; }
        public string Method_Name { get; set; }
        public string Method_Name_F { get; set; }
        public short Branch_No { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
