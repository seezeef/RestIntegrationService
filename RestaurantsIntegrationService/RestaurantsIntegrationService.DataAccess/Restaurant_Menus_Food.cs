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
    
    public partial class Restaurant_Menus_Food
    {
        public short Menu_No { get; set; }
        public int Food_No { get; set; }
        public Nullable<double> QTY { get; set; }
        public Nullable<double> Price { get; set; }
        public short Branch_No { get; set; }
    
        [JsonIgnore]
        public virtual Food Food { get; set; }
        [JsonIgnore]
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        [JsonIgnore]
        public virtual Restaurant_Menus Restaurant_Menus { get; set; }
    }
}
