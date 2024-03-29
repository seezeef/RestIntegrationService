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
    
    public partial class Delivery_Options
    {
        public bool Use_Delivery { get; set; }
        public decimal Fixed_Amount { get; set; }
        public decimal Max_Bill_Amount { get; set; }
        public decimal Min_Bill_Amount { get; set; }
        public bool All_Free { get; set; }
        public decimal FreeIFBillAmount { get; set; }
        public bool UseBlackList { get; set; }
        public short Branch_No { get; set; }
        public short Restart_Type { get; set; }
        public int Restart_No { get; set; }
        public bool Print_Cashier_Copy { get; set; }
        public Nullable<System.DateTime> StartWork { get; set; }
        public Nullable<System.DateTime> EndWork { get; set; }
        public bool PriceByMethods { get; set; }
        public bool AutoReceiptDeliveryInvoice { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
