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
    
    public partial class Restaurant_Shortcuts
    {
        public short User_ID { get; set; }
        public short Branch_No { get; set; }
        public Nullable<byte> Food_HotKey { get; set; }
        public Nullable<byte> Menu_HotKey { get; set; }
        public Nullable<byte> Banquet_HotKey { get; set; }
        public Nullable<byte> Save_HotKey { get; set; }
        public Nullable<byte> Print_HotKey { get; set; }
        public Nullable<byte> Close_HotKey { get; set; }
        public Nullable<byte> Exit_HotKey { get; set; }
        public Nullable<byte> Type1_HotKey { get; set; }
        public Nullable<byte> Type2_HotKey { get; set; }
        public Nullable<byte> Type3_HotKey { get; set; }
        public Nullable<byte> Type4_HotKey { get; set; }
        public Nullable<byte> Type5_HotKey { get; set; }
    
        public virtual User User { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
