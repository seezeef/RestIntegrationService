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
    
    public partial class Black_List
    {
        public int Serial_No { get; set; }
        public Nullable<long> Customer_No { get; set; }
        public Nullable<short> State_No { get; set; }
        public string B_Desc { get; set; }
        public short Branch_No { get; set; }
    
        public virtual List_States List_States { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
