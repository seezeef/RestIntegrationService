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
    
    public partial class MyPoint
    {
        public bool Use_MyPoints { get; set; }
        public short Point_Percent { get; set; }
        public short Point_UseAfter { get; set; }
        public short Point_BillType { get; set; }
        public int Point_Expire { get; set; }
        public short Len_MyPoints_Card { get; set; }
        public short Branch_No { get; set; }

        [JsonIgnore]
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
