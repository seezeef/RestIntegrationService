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
    
    public partial class Privilege
    {
        public bool Add_On { get; set; }
        public bool Del_On { get; set; }
        public short Form_No { get; set; }
        public bool Modify_On { get; set; }
        public short User_ID { get; set; }
        public bool View_On { get; set; }
        public short Branch_No { get; set; }
    
        public virtual Form_Details Form_Details { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual User User { get; set; }
    }
}
