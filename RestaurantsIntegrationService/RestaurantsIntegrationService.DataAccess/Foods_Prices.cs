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
    
    public partial class Foods_Prices
    {
        public short Branch_No { get; set; }
        public short Type_No { get; set; }
        public Nullable<short> Group_No { get; set; }
        public int Food_No { get; set; }
        public Nullable<int> Unit_No { get; set; }
        public int Unit_Size { get; set; }
        public Nullable<float> Food_Price { get; set; }
        public short Food_Disc { get; set; }
        public short Price_Type { get; set; }
        public int IDSer { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
