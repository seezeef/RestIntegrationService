using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FirstInputDtos
{
    public class CreditCardDto
    {
        public int Card_No { get; set; }
        public string Card_Name_A { get; set; }
        public string Card_Name_E { get; set; }
        public string Start_No { get; set; }
        public string Account_No { get; set; }
        public int Bank_No { get; set; }
        public string Bank_Name { get; set; }
        public short Branch_No { get; set; }
        public bool UnUsed { get; set; }
    }
}
