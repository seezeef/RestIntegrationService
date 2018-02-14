using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FourthInputDtos
{
    public class Foods_GroupsDto
    {
        public short Group_No { get; set; }
        public string Group_A_Name { get; set; }
        public string Group_E_Name { get; set; }
        public Nullable<short> FoodGroup_Type { get; set; }
        public byte[] Group_Pic { get; set; }
        public short Branch_No { get; set; }
        public string Account_No { get; set; }
        public string RT_Acc { get; set; }
        public string Cost_Center { get; set; }
        public Nullable<short> W_Code { get; set; }
        public string Chef_Printer { get; set; }
        public string Chef_Report { get; set; }
        public bool Force_Chef_Printer { get; set; }
        public Nullable<byte> Print_Count { get; set; }
        public string ComputerName { get; set; }
        public Nullable<int> Group_Color { get; set; }
        public Nullable<int> Group_Order { get; set; }
        public bool W_Link { get; set; }
        public bool M_ReQ { get; set; }
        public Nullable<int> Chef_No { get; set; }
        public bool Stop_Print { get; set; }
        public bool Link_W_Item { get; set; }
        public int Main_W_Item { get; set; }
    }
}
