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
    
    public partial class RT_Ins_MST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RT_Ins_MST()
        {
            this.RT_Ins_DTL = new HashSet<RT_Ins_DTL>();
        }
    
        public int RT_Ins_No { get; set; }
        public Nullable<int> Ins_No { get; set; }
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
        public Nullable<int> Order_No { get; set; }
        public short Branch_No { get; set; }
        public bool U_Sync { get; set; }
        public bool B_Sync { get; set; }
        public int POS_No { get; set; }
        public long ASerial { get; set; }
        public int Service_No { get; set; }
        public bool B_Suspend { get; set; }
        public int Sync_No { get; set; }
        public bool FromPastYear { get; set; }
        public bool RptPrinted { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
    
        public virtual Insurance Insurance { get; set; }
        public virtual POS POS { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RT_Ins_DTL> RT_Ins_DTL { get; set; }
    }
}
