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
    
    public partial class Restaurant_D
    {
        public long ASerial { get; set; }
        public string Food_Name { get; set; }
        public int Food_No { get; set; }
        public Nullable<double> Food_Price { get; set; }
        public Nullable<short> Food_Type { get; set; }
        public int Order_No { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<double> S_Qty { get; set; }
        public double S_Size { get; set; }
        public Nullable<int> Service_No { get; set; }
        public short Branch_No { get; set; }
        public Nullable<long> Serial_Code { get; set; }
        public bool Posted { get; set; }
        public bool Printed { get; set; }
        public Nullable<int> Order_Serial { get; set; }
        public int Order_Restart { get; set; }
        public string Food_Note { get; set; }
        public bool FoodDone { get; set; }
        public string Unit_Code { get; set; }
        public string BarCode_No { get; set; }
        public Nullable<short> Bill_Serial_Type { get; set; }
        public Nullable<int> Bill_Serial_No { get; set; }
        public int POS_No { get; set; }
        public bool Food_Free { get; set; }
        public Nullable<double> Real_Price { get; set; }
        public Nullable<int> Ins_No { get; set; }
        public int M_No { get; set; }
        public int M_Qty { get; set; }
        public decimal M_Price { get; set; }
        public Nullable<double> Ins_Amount { get; set; }
        public Nullable<double> Serial_No { get; set; }
        public int FG_SN { get; set; }
        public int Item_Count { get; set; }
        public int Sub_Item { get; set; }
        public int Attach_Food_No { get; set; }
        public Nullable<short> W_Code { get; set; }
        public int G_No { get; set; }
        public double S_ID { get; set; }
        public int Sync_No { get; set; }
        public int Main_Food_No { get; set; }
        public short Sub_Food { get; set; }
        public Nullable<double> I_DiscAmt { get; set; }
        public Nullable<double> I_DiscPer { get; set; }
        public bool Promo { get; set; }
        public int PromoType { get; set; }
        public Nullable<System.DateTime> Expire_Date { get; set; }
        public Nullable<double> Bill_Disc { get; set; }
        public Nullable<double> Bill_Tax { get; set; }
        public Nullable<double> Bill_Extra_Service { get; set; }
        public Nullable<double> Bill_Service_Charges { get; set; }
        public Nullable<double> Bill_Amount_Before { get; set; }
        public bool IsCombo { get; set; }
        public Nullable<double> I_TaxAmt { get; set; }
        public Nullable<double> I_TaxPer { get; set; }
        public short AttMainFoodNo { get; set; }
        public Nullable<double> FoodPriceVAT { get; set; }
    
        public virtual Foods_Types Foods_Types { get; set; }
        public virtual POS POS { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual Restaurant_H Restaurant_H { get; set; }
    }
}
