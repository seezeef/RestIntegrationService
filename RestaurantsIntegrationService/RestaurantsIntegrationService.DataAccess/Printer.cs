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
    
    public partial class Printer
    {
        public short PrinterID { get; set; }
        public string PrinterName { get; set; }
        public string PrinterFName { get; set; }
        public string PrinterDevice { get; set; }
        public Nullable<short> PaperType { get; set; }
        public Nullable<short> PrintBy { get; set; }
        public Nullable<short> SplitBy { get; set; }
        public Nullable<short> CopiesNumber { get; set; }
        public string ReportFile { get; set; }
        public short Branch_No { get; set; }
    
        public virtual Restaurant_Info Restaurant_Info { get; set; }
    }
}
