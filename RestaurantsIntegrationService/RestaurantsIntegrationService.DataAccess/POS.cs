//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace RestaurantsIntegrationService.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class POS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public POS()
        {
            this.Bills_Components = new HashSet<Bills_Components>();
            this.DeleteRests = new HashSet<DeleteRest>();
            this.Dlvr_Dtl = new HashSet<Dlvr_Dtl>();
            this.HstrRest_D = new HashSet<HstrRest_D>();
            this.HstrRest_D_Combo = new HashSet<HstrRest_D_Combo>();
            this.HstrRest_D_DTL = new HashSet<HstrRest_D_DTL>();
            this.Insurances = new HashSet<Insurance>();
            this.Item_Move = new HashSet<Item_Move>();
            this.ItemAchvs = new HashSet<ItemAchv>();
            this.POS_Printers = new HashSet<POS_Printers>();
            this.Reservations = new HashSet<Reservation>();
            this.Restaurant_Bill_No = new HashSet<Restaurant_Bill_No>();
            this.Restaurant_D = new HashSet<Restaurant_D>();
            this.Restaurant_H = new HashSet<Restaurant_H>();
            this.Restaurant_Orders = new HashSet<Restaurant_Orders>();
            this.RT_Bill_DTL_DTL = new HashSet<RT_Bill_DTL_DTL>();
            this.RT_Bill_DTL = new HashSet<RT_Bill_DTL>();
            this.RT_Bill_MST = new HashSet<RT_Bill_MST>();
            this.RT_Ins_DTL = new HashSet<RT_Ins_DTL>();
            this.RT_Ins_MST = new HashSet<RT_Ins_MST>();
            this.Split_Bills = new HashSet<Split_Bills>();
            this.Stock_Adjst_MST = new HashSet<Stock_Adjst_MST>();
            this.Tables_Status = new HashSet<Tables_Status>();
            this.Transfer_Orders = new HashSet<Transfer_Orders>();
            this.Users_Current_Login = new HashSet<Users_Current_Login>();
        }
    
        public int POS_No { get; set; }
        public string POS_Name { get; set; }
        public string Computer_Name { get; set; }
        public bool POS_Stop { get; set; }
        public bool POS_Separate { get; set; }
        public bool Tablet { get; set; }
        public int Section_No { get; set; }
        public bool Force_WorkType { get; set; }
        public short WorkType { get; set; }
        public bool Stop_Print_Order { get; set; }
        public Nullable<short> W_Code { get; set; }
        public string CC_Code { get; set; }
        public short Col_No { get; set; }
        public short Row_No { get; set; }
        public short Cell_H { get; set; }
        public short Cell_W { get; set; }
        public bool PC_Link_Remote { get; set; }
        public string Invoice_Printer { get; set; }
        public Nullable<byte> Print_Count { get; set; }
        public string RPT_Printer { get; set; }
        public bool SelfService { get; set; }
        public Nullable<short> SS_User_ID { get; set; }
        public short Branch_No { get; set; }
        public bool StopPrintCheck { get; set; }
        public Nullable<int> DlvryWCode { get; set; }
        public Nullable<int> DlvryReQType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Bills_Components> Bills_Components { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<DeleteRest> DeleteRests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Dlvr_Dtl> Dlvr_Dtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<HstrRest_D> HstrRest_D { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<HstrRest_D_Combo> HstrRest_D_Combo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<HstrRest_D_DTL> HstrRest_D_DTL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Insurance> Insurances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Item_Move> Item_Move { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<ItemAchv> ItemAchvs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<POS_Printers> POS_Printers { get; set; }
        [JsonIgnore]
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Reservation> Reservations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Restaurant_Bill_No> Restaurant_Bill_No { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Restaurant_D> Restaurant_D { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Restaurant_H> Restaurant_H { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Restaurant_Orders> Restaurant_Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<RT_Bill_DTL_DTL> RT_Bill_DTL_DTL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<RT_Bill_DTL> RT_Bill_DTL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<RT_Bill_MST> RT_Bill_MST { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<RT_Ins_DTL> RT_Ins_DTL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<RT_Ins_MST> RT_Ins_MST { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Split_Bills> Split_Bills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Stock_Adjst_MST> Stock_Adjst_MST { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Tables_Status> Tables_Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Transfer_Orders> Transfer_Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Users_Current_Login> Users_Current_Login { get; set; }
    }
}
