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
    
    public partial class RT_Bill_DTL_DTL
    {
        public long RT_Bill_No { get; set; }
        public string Food_Name { get; set; }
        public int Food_No { get; set; }
        public Nullable<float> Food_Price { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<double> S_Qty { get; set; }
        public double S_Size { get; set; }
        public Nullable<int> Service_No { get; set; }
        public short Branch_No { get; set; }
        public string Unit_Code { get; set; }
        public bool U_Sync { get; set; }
        public bool B_Sync { get; set; }
        public int POS_No { get; set; }
        public bool Food_Free { get; set; }
        public Nullable<float> Real_Price { get; set; }
        public Nullable<short> W_Code { get; set; }
        public double S_ID { get; set; }
        public int Sync_No { get; set; }
        public int RCRD_No { get; set; }
    
        public virtual Food Food { get; set; }
        public virtual POS POS { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual RT_Bill_DTL RT_Bill_DTL { get; set; }
    }
}
