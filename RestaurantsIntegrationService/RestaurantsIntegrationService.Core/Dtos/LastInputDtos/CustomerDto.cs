using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.LastInputDtos
{
    public class CustomerDto
    {
        public long Customer_No { get; set; }
        public string Customer_Name { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string Tel_No { get; set; }
        public byte C_Gender { get; set; }
        public Nullable<int> Customer_Type { get; set; }
        public byte C_Lang { get; set; }
        public System.DateTime REG_Date { get; set; }
        public short InActive { get; set; }
        public string Activation_Code { get; set; }
        public string Password { get; set; }
        public bool F_Android { get; set; }
        public string Card_ID { get; set; }
        public bool Card_Stop { get; set; }
        public string Card_Stop_Desc { get; set; }
        public bool Stopped { get; set; }
        public string MyPoints_Card_ID { get; set; }
        public short Branch_No { get; set; }
        public short Act_No { get; set; }
    }
}
