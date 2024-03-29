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
    
    public partial class RT_Bill_DTL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RT_Bill_DTL()
        {
            this.RT_Bill_DTL_DTL = new HashSet<RT_Bill_DTL_DTL>();
        }
    
        public long RT_Bill_No { get; set; }
        public long ASerial { get; set; }
        public string Food_Name { get; set; }
        public int Food_No { get; set; }
        public Nullable<double> Food_Price { get; set; }
        public Nullable<double> FoodPriceVAT { get; set; }
        public Nullable<short> Food_Type { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<double> S_Qty { get; set; }
        public double S_Size { get; set; }
        public Nullable<int> Service_No { get; set; }
        public short Branch_No { get; set; }
        public bool Posted { get; set; }
        public bool Printed { get; set; }
        public string Unit_Code { get; set; }
        public string BarCode_No { get; set; }
        public bool U_Sync { get; set; }
        public bool B_Sync { get; set; }
        public int POS_No { get; set; }
        public bool Food_Free { get; set; }
        public Nullable<double> Real_Price { get; set; }
        public Nullable<int> Ins_No { get; set; }
        public Nullable<double> Ins_Amount { get; set; }
        public int Item_Count { get; set; }
        public int Sub_Item { get; set; }
        public Nullable<short> W_Code { get; set; }
        public Nullable<double> I_DiscAmt { get; set; }
        public Nullable<double> I_DiscPer { get; set; }
        public int G_No { get; set; }
        public double S_ID { get; set; }
        public int Sync_No { get; set; }
        public Nullable<double> Bill_Disc { get; set; }
        public Nullable<double> Bill_Tax { get; set; }
        public Nullable<double> Bill_Extra_Service { get; set; }
        public Nullable<double> Bill_Service_Charges { get; set; }
        public Nullable<double> Bill_Amount_Before { get; set; }
        public Nullable<double> I_TaxAmt { get; set; }
        public Nullable<double> I_TaxPer { get; set; }
    
        public virtual Food Food { get; set; }
        public virtual Insurance Insurance { get; set; }
        public virtual POS POS { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RT_Bill_DTL_DTL> RT_Bill_DTL_DTL { get; set; }
        public virtual RT_Bill_MST RT_Bill_MST { get; set; }
    }
}
