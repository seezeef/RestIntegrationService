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
    
    public partial class Users_Acc_Link
    {
        public short User_ID { get; set; }
        public Nullable<short> Acc_U_ID { get; set; }
        public Nullable<short> Cash_No { get; set; }
        public short Branch_No { get; set; }
    
        public virtual User User { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
