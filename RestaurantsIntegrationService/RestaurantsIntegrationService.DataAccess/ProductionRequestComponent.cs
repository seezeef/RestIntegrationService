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
    
    public partial class ProductionRequestComponent
    {
        public Nullable<long> DocSer { get; set; }
        public int Food_No { get; set; }
        public Nullable<double> I_QTY { get; set; }
        public Nullable<double> P_QTY { get; set; }
        public long SerialID { get; set; }
        public short Branch_No { get; set; }
    
        public virtual Food Food { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual ProductionRequestMst ProductionRequestMst { get; set; }
    }
}
