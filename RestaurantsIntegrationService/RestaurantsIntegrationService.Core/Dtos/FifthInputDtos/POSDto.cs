using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FifthInputDtos
{
    public class POSDto
    {
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
        public short SS_User_ID { get; set; }
        public bool StopPrintCheck { get; set; }
        public Nullable<int> DlvryWCode { get; set; }
        public Nullable<int> DlvryReQType { get; set; }
        public short Branch_No { get; set; }
        public string ServerName { get; set; }
    }
}
