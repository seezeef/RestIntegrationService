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
    
    public partial class Restaurant_H
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant_H()
        {
            this.Restaurant_D = new HashSet<Restaurant_D>();
        }
    
        public long ASerial { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<decimal> Net_Amount { get; set; }
        public Nullable<int> Order_No { get; set; }
        public string P_Name { get; set; }
        public Nullable<short> Persons { get; set; }
        public Nullable<int> Chair_No { get; set; }
        public Nullable<int> Room_No { get; set; }
        public Nullable<System.DateTime> S_Date { get; set; }
        public Nullable<short> Table_No { get; set; }
        public short Tax { get; set; }
        public Nullable<short> Waiter_No { get; set; }
        public Nullable<int> Service_No { get; set; }
        public Nullable<long> Company_No { get; set; }
        public Nullable<int> Emp_No { get; set; }
        public bool ACC_Posted { get; set; }
        public Nullable<System.DateTime> S_Time { get; set; }
        public Nullable<short> Bill_Type { get; set; }
        public bool Closed { get; set; }
        public Nullable<System.DateTime> OpenAt_Date { get; set; }
        public Nullable<System.DateTime> OpenAt_Time { get; set; }
        public Nullable<short> Menu_No { get; set; }
        public short Service_Charges { get; set; }
        public Nullable<decimal> PricePerPerson { get; set; }
        public Nullable<short> User_ID { get; set; }
        public Nullable<int> DiscountBy { get; set; }
        public Nullable<System.DateTime> Will_Be_At { get; set; }
        public short Branch_No { get; set; }
        public Nullable<long> Last_Serial { get; set; }
        public Nullable<long> Customer_No { get; set; }
        public bool Printed { get; set; }
        public Nullable<double> Discount_Ratio { get; set; }
        public bool QTY_Posted { get; set; }
        public string Note { get; set; }
        public bool Posted { get; set; }
        public Nullable<System.DateTime> S_RealDate { get; set; }
        public Nullable<short> Bill_Pay_Type { get; set; }
        public Nullable<decimal> PrintAmount { get; set; }
        public Nullable<decimal> Pay_Amount { get; set; }
        public Nullable<int> Order_Restart { get; set; }
        public string Ref_No { get; set; }
        public Nullable<decimal> Extra_Service { get; set; }
        public Nullable<decimal> Amount_Before_Round { get; set; }
        public bool CreditCard { get; set; }
        public Nullable<int> CreditCard_Type { get; set; }
        public string CreditCard_No { get; set; }
        public Nullable<int> Period_No { get; set; }
        public Nullable<short> Bill_Serial_Type { get; set; }
        public Nullable<int> Bill_Serial_No { get; set; }
        public Nullable<int> H_Reservation_No { get; set; }
        public int ResFood_No { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public Nullable<int> Last_Modified_User { get; set; }
        public int POS_No { get; set; }
        public Nullable<double> Serial_No { get; set; }
        public bool BillPrinted { get; set; }
        public bool RptPrinted { get; set; }
        public int Trans_Table { get; set; }
        public int Sync_No { get; set; }
        public int Dr_No { get; set; }
        public long Cust_No { get; set; }
        public int Cust_S_No { get; set; }
        public decimal Dr_Amount { get; set; }
        public int Ins_No { get; set; }
        public Nullable<int> Cell_No { get; set; }
        public Nullable<System.DateTime> Setting_Time { get; set; }
        public bool B_Suspend { get; set; }
        public Nullable<int> OB_No { get; set; }
        public decimal OB_Price { get; set; }
        public bool Pay_Later { get; set; }
        public bool F_Android { get; set; }
        public bool DiscCard { get; set; }
        public bool PaidByPoints { get; set; }
        public bool F_ACO { get; set; }
        public bool F_SS { get; set; }
        public Nullable<double> Itm_Disc { get; set; }
        public bool Dstrbut_DISC_TAX { get; set; }
        public Nullable<System.DateTime> S_DateTime { get; set; }
        public decimal ItemsAmount { get; set; }
        public Nullable<double> ItemsTaxAmt { get; set; }
        public Nullable<double> VisaAmt { get; set; }
        public bool IsItemPriceIncludeTax { get; set; }
        public string Coupon_No { get; set; }
        public Nullable<double> Coupon_Amount { get; set; }
    
        public virtual Bench Bench { get; set; }
        public virtual Cell Cell { get; set; }
        public virtual Coupons_Dtl Coupons_Dtl { get; set; }
        public virtual CreditCard CreditCard1 { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual OpenBuffet OpenBuffet { get; set; }
        public virtual POS POS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Restaurant_D> Restaurant_D { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual Restaurant_InvoTypes Restaurant_InvoTypes { get; set; }
        public virtual Restaurant_Menus Restaurant_Menus { get; set; }
        public virtual Restaurant_Periods Restaurant_Periods { get; set; }
        public virtual Waiter Waiter { get; set; }
    }
}
