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
    
    public partial class SaveSetting
    {
        public short Branch_No { get; set; }
        public Nullable<short> Form_No { get; set; }
        public string S_String { get; set; }
        public string S_Name { get; set; }
    
        public virtual Form_Details Form_Details { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}