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
    
    public partial class SyncData
    {
        public short Branch_No { get; set; }
        public Nullable<short> OperationType { get; set; }
        public Nullable<short> Sync_Type { get; set; }
        public Nullable<short> Data_Type { get; set; }
        public int Sync_No { get; set; }
        public string Sync_Name { get; set; }
        public Nullable<System.DateTime> Sync_From_Date { get; set; }
        public Nullable<System.DateTime> Sync_To_Date { get; set; }
        public Nullable<System.DateTime> Se_Sync_Date { get; set; }
        public Nullable<System.DateTime> Se_Sync_Time { get; set; }
        public Nullable<short> Se_By_User_ID { get; set; }
        public Nullable<System.DateTime> Re_Sync_Date { get; set; }
        public Nullable<System.DateTime> Re_Sync_Time { get; set; }
        public Nullable<short> Re_By_User_ID { get; set; }
        public bool ReplaceExist { get; set; }
        public bool Sync_Done { get; set; }
        public string Computer_Name { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
