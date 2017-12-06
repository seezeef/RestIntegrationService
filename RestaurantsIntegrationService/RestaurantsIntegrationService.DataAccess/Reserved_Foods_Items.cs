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
    
    public partial class Reserved_Foods_Items
    {
        public int Res_No { get; set; }
        public int Food_No { get; set; }
        public Nullable<int> Unit_No { get; set; }
        public int Unit_Size { get; set; }
        public Nullable<double> QTY { get; set; }
        public Nullable<double> S_Qty { get; set; }
        public double S_Size { get; set; }
        public decimal Price { get; set; }
        public string Food_Note { get; set; }
        public bool Printed { get; set; }
        public int M_No { get; set; }
        public int M_Qty { get; set; }
        public decimal M_Price { get; set; }
        public Nullable<double> Ins_Amount { get; set; }
        public bool FromPastYear { get; set; }
        public Nullable<double> RC_ID { get; set; }
        public short Branch_No { get; set; }
        public double I_TaxAmt { get; set; }
        public double I_TaxPer { get; set; }
    
        public virtual Food Food { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual Unit Unit { get; set; }
    }
}