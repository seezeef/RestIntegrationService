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
    
    public partial class Items_Notes_Dtl
    {
        public int Note_No { get; set; }
        public int Food_No { get; set; }
        public Nullable<short> Group_No { get; set; }
        public short Branch_No { get; set; }
    
        [JsonIgnore]
        public virtual Food Food { get; set; }
        [JsonIgnore]
        public virtual Items_Notes_Mst Items_Notes_Mst { get; set; }
        [JsonIgnore]
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
