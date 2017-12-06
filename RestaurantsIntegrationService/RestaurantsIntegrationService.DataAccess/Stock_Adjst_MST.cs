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
    
    public partial class Stock_Adjst_MST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stock_Adjst_MST()
        {
            this.Stock_Adjst_DTL = new HashSet<Stock_Adjst_DTL>();
        }
    
        public int Doc_No { get; set; }
        public System.DateTime Doc_Date { get; set; }
        public Nullable<System.TimeSpan> Doc_Time { get; set; }
        public string Doc_Desc { get; set; }
        public short W_Code { get; set; }
        public short Branch_No { get; set; }
        public short User_ID { get; set; }
        public Nullable<int> Inv_No { get; set; }
        public int POS_No { get; set; }
        public bool Posted { get; set; }
        public bool Processed { get; set; }
        public bool B_Sync { get; set; }
        public long DocSer { get; set; }
    
        public virtual POS POS { get; set; }
        public virtual Restaurant_Info Restaurant_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock_Adjst_DTL> Stock_Adjst_DTL { get; set; }
    }
}