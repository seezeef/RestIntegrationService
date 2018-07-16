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
    
    public partial class Reserved_Foods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reserved_Foods()
        {
            this.RSRVD_Payments = new HashSet<RSRVD_Payments>();
            this.RSRVD_RefundPayment = new HashSet<RSRVD_RefundPayment>();
        }
    
        public int Res_No { get; set; }
        public Nullable<System.DateTime> WillBeAt { get; set; }
        public string P_Name { get; set; }
        public string Tel_No { get; set; }
        public Nullable<long> Customer_No { get; set; }
        public Nullable<short> Menu_No { get; set; }
        public Nullable<short> Persons { get; set; }
        public Nullable<decimal> PricePerPerson { get; set; }
        public bool Cancelled { get; set; }
        public bool Closed { get; set; }
        public short Branch_No { get; set; }
        public Nullable<decimal> Net_Amount { get; set; }
        public Nullable<decimal> Pay_Amount { get; set; }
        public Nullable<decimal> RemainingAmount { get; set; }
        public Nullable<decimal> AddItemsTotal { get; set; }
        public int Ins_No { get; set; }
        public Nullable<short> User_ID { get; set; }
        public Nullable<System.DateTime> Res_Date { get; set; }
        public Nullable<System.DateTime> Res_Time { get; set; }
        public string R_Desc { get; set; }
        public Nullable<System.DateTime> Insert_Date { get; set; }
        public bool Res_Posted { get; set; }
        public bool Posted { get; set; }
        public bool Acc_Posted { get; set; }
        public bool SysClosed { get; set; }
        public bool Confirmed { get; set; }
        public Nullable<System.DateTime> Pay_Date { get; set; }
        public bool Printed { get; set; }
        public bool FromPastYear { get; set; }
        public Nullable<double> ItemsTaxAmt { get; set; }
        public Nullable<double> DiscPer { get; set; }
        public Nullable<double> DiscAmt { get; set; }
        public bool Produced { get; set; }
        public int ProductionID { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RSRVD_Payments> RSRVD_Payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RSRVD_RefundPayment> RSRVD_RefundPayment { get; set; }
    }
}
