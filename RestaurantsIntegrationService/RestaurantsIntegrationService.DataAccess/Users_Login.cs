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
    
    public partial class Users_Login
    {
        public short UserID { get; set; }
        public Nullable<System.DateTime> LogIn_Date { get; set; }
        public Nullable<System.DateTime> LogIn_Time { get; set; }
        public Nullable<System.DateTime> LogOff_Date { get; set; }
        public Nullable<System.DateTime> LogOff_Time { get; set; }
        public Nullable<System.DateTime> LastAction_Date { get; set; }
        public Nullable<System.DateTime> LastAction_Time { get; set; }
        public string Computer_Name { get; set; }
        public string Windows_User { get; set; }
        public Nullable<byte> Sub_System { get; set; }
        public int Login_No { get; set; }
        public short Branch_No { get; set; }
        public bool U_Sync { get; set; }
        public bool B_Sync { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual User User { get; set; }
    }
}
