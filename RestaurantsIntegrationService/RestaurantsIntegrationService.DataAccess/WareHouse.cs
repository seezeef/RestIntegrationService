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
    
    public partial class WareHouse
    {
        public short Branch_No { get; set; }
        public int Food_No { get; set; }
        public short Group_No { get; set; }
        public string I_Code { get; set; }
        public string ITM_UNT { get; set; }
        public Nullable<double> P_SIZE { get; set; }
        public Nullable<double> Qty { get; set; }
        public Nullable<double> Def_Qty { get; set; }
        public short W_Code { get; set; }
        public Nullable<System.DateTime> W_Date { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
