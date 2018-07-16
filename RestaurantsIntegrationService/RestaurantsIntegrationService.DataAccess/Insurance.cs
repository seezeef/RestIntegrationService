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
    
    public partial class Insurance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Insurance()
        {
            this.Insurance_Bills_DTL = new HashSet<Insurance_Bills_DTL>();
            this.RT_Bill_DTL = new HashSet<RT_Bill_DTL>();
            this.RT_Bill_MST = new HashSet<RT_Bill_MST>();
            this.RT_Ins_DTL = new HashSet<RT_Ins_DTL>();
            this.RT_Ins_MST = new HashSet<RT_Ins_MST>();
        }
    
        public int Ins_No { get; set; }
        public Nullable<System.DateTime> Ins_Date { get; set; }
        public Nullable<decimal> Ins_Amount { get; set; }
        public string Ins_Desc { get; set; }
        public Nullable<long> Customer_No { get; set; }
        public string P_Name { get; set; }
        public string Tel_No { get; set; }
        public bool Closed { get; set; }
        public bool Returned { get; set; }
        public bool Warranty_Posted { get; set; }
        public bool Posted { get; set; }
        public Nullable<short> User_ID { get; set; }
        public Nullable<int> Bill_No { get; set; }
        public Nullable<int> Order_Restart { get; set; }
        public Nullable<int> Order_No { get; set; }
        public short Branch_No { get; set; }
        public Nullable<short> Bill_Serial_Type { get; set; }
        public Nullable<int> Bill_Serial_No { get; set; }
        public bool U_Sync { get; set; }
        public bool B_Sync { get; set; }
        public int POS_No { get; set; }
        public Nullable<double> Serial_No { get; set; }
        public long ASerial { get; set; }
        public int Service_No { get; set; }
        public bool B_Suspend { get; set; }
        public int Sync_No { get; set; }
        public bool Ins_Pay_Hand { get; set; }
        public bool FromPastYear { get; set; }
        public bool RptPrinted { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public int Bill_Pay_Type { get; set; }
        public Nullable<int> CreditCard_Type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Insurance_Bills_DTL> Insurance_Bills_DTL { get; set; }
        public virtual Insurances_Closed Insurances_Closed { get; set; }
        public virtual POS POS { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RT_Bill_DTL> RT_Bill_DTL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RT_Bill_MST> RT_Bill_MST { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RT_Ins_DTL> RT_Ins_DTL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RT_Ins_MST> RT_Ins_MST { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}
