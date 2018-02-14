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
    
    public partial class Dlvr_Dtl
    {
        public long ASerial { get; set; }
        public Nullable<int> Order_No { get; set; }
        public Nullable<int> C_Serial_No { get; set; }
        public Nullable<long> Customer_No { get; set; }
        public Nullable<int> Area_No { get; set; }
        public Nullable<int> S_No { get; set; }
        public string D_Desc { get; set; }
        public Nullable<int> Dr_No { get; set; }
        public int Service_No { get; set; }
        public Nullable<short> Bill_Type { get; set; }
        public Nullable<short> User_ID { get; set; }
        public short Handle_User_ID { get; set; }
        public short Branch_No { get; set; }
        public int Foods_Time { get; set; }
        public Nullable<System.DateTime> Handle_Date { get; set; }
        public Nullable<System.DateTime> Handle_Time { get; set; }
        public decimal Handle_Amount { get; set; }
        public int POS_No { get; set; }
        public Nullable<double> Serial_No { get; set; }
        public bool Closed { get; set; }
        public Nullable<int> Order_Restart { get; set; }
        public Nullable<short> Bill_Serial_Type { get; set; }
        public Nullable<int> Bill_Serial_No { get; set; }
        public Nullable<System.DateTime> Go_Time { get; set; }
        public Nullable<System.DateTime> DlvrTime { get; set; }
        public Nullable<System.DateTime> BackTime { get; set; }
        public Nullable<System.DateTime> ElapsedTime { get; set; }
        public int DestTime { get; set; }
        public int Status_No { get; set; }
        public bool Canceled_Bill { get; set; }
        public string Canceled_Desc { get; set; }
        public int Ref_No { get; set; }
        public bool PDA_Upload { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public Nullable<int> Last_Modified_User { get; set; }
        public short U_Sync { get; set; }
        public short B_Sync { get; set; }
        public bool RptPrinted { get; set; }
        public bool PDA_Download { get; set; }
        public int Sync_No { get; set; }
        public int Post_No { get; set; }
        public bool F_ACO { get; set; }
        public Nullable<int> Method_No { get; set; }
    
        public virtual POS POS { get; set; }
        public virtual User User { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
