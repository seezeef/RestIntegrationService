using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FirstInputDtos
{
    public class Restaurant_InvoTypesDto
    {
        public short Type_No { get; set; }
        public string Type_Name { get; set; }
        public string Type_E_Name { get; set; }
        public Nullable<float> Tax { get; set; }
        public Nullable<byte> Service_Charges { get; set; }
        public Nullable<byte> Discount { get; set; }
        public short Branch_No { get; set; }
        public short Target_Type { get; set; }
        public bool Stop_Type { get; set; }
        public string Chef_Printer { get; set; }
        public bool Force_Chef_Printer { get; set; }
        public Nullable<short> Bill_Copy_No { get; set; }
        public Nullable<short> Print_Copy_No { get; set; }
        public bool CopyChefOrders { get; set; }
        public string CopyChefOrdersPrinter { get; set; }
        public long Feed_Cust_No { get; set; }
        public int Use_Android { get; set; }
        public int StopPrintCheck { get; set; }
        public bool DefaultReservation { get; set; }
    }
}
