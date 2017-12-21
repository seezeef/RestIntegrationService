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
    
    public partial class Street
    {
        public int S_No { get; set; }
        public string S_A_Name { get; set; }
        public string S_E_Name { get; set; }
        public short Branch_No { get; set; }
        public int Area_No { get; set; }
        public string S_Desc { get; set; }
        [JsonIgnore]
        public Nullable<decimal> Dr_Amount { get; set; }
        [JsonIgnore]
        public Nullable<short> Dr_Percent { get; set; }
        [JsonIgnore]
        public Nullable<short> Max_Time { get; set; }

        [JsonIgnore]
        public virtual Area Area { get; set; }
        [JsonIgnore]
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
