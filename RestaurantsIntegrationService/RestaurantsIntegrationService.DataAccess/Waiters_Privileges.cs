//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace RestaurantsIntegrationService.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Waiters_Privileges
    {
        public short Waiter_No { get; set; }
        public short Bench_No { get; set; }
        public bool Can_Use { get; set; }
        public short Branch_No { get; set; }
    
        [JsonIgnore]
        public virtual Bench Bench { get; set; }
        [JsonIgnore]
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        [JsonIgnore]
        public virtual Waiter Waiter { get; set; }
    }
}
