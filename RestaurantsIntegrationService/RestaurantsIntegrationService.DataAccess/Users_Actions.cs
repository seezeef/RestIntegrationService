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
    
    public partial class Users_Actions
    {
        public Nullable<short> UserID { get; set; }
        public Nullable<int> ActionID { get; set; }
        public Nullable<System.DateTime> Action_Date { get; set; }
        public Nullable<System.DateTime> Action_Time { get; set; }
        public Nullable<double> Record_No { get; set; }
        public Nullable<short> Form_No { get; set; }
        public Nullable<decimal> Change { get; set; }
        public string Action_Desc { get; set; }
        public short Branch_No { get; set; }
        public bool U_Sync { get; set; }
        public bool B_Sync { get; set; }
    
        public virtual Action Action { get; set; }
        public virtual Form_Details Form_Details { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
