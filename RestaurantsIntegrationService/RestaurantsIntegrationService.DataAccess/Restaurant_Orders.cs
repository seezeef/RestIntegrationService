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
    
    public partial class Restaurant_Orders
    {
        public long ASerial { get; set; }
        public Nullable<int> Order_Restart { get; set; }
        public Nullable<int> Order_No { get; set; }
        public Nullable<short> Bill_Serial_Type { get; set; }
        public Nullable<int> Bill_Serial_No { get; set; }
        public Nullable<int> Service_No { get; set; }
        public long Serial_No { get; set; }
        public short Branch_No { get; set; }
        public Nullable<short> User_ID { get; set; }
        public Nullable<System.DateTime> OpenAt { get; set; }
        public Nullable<System.DateTime> ClosedAt { get; set; }
        public bool U_Sync { get; set; }
        public bool B_Sync { get; set; }
        public int POS_No { get; set; }
        public Nullable<double> BSerial_No { get; set; }
        public int Sync_No { get; set; }
    
        public virtual POS POS { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual User User { get; set; }
    }
}
