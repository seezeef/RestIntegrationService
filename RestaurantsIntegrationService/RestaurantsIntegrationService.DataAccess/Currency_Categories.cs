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
    
    public partial class Currency_Categories
    {
        public int Category_No { get; set; }
        public Nullable<double> Category_Value { get; set; }
        public short Branch_No { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
