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
    
    public partial class FingerDevice
    {
        public short DeviceNo { get; set; }
        public string ComputerName { get; set; }
        public string IPAddress { get; set; }
        public Nullable<int> PortNO { get; set; }
        public Nullable<short> CommunicationKey { get; set; }
        public short Branch_No { get; set; }
        public Nullable<short> Section_No { get; set; }
        public Nullable<short> Bench_No { get; set; }
        public Nullable<short> Type_No { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
