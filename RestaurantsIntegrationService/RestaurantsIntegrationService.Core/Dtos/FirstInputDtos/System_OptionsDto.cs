using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FirstInputDtos
{
    public class System_OptionsDto
    {
        public int Option_No { get; set; }
        public int Option_Type { get; set; }
        public string Option_Name_A { get; set; }
        public string Option_Name_E { get; set; }
        public bool Option_Value { get; set; }
        public string Option_Var1 { get; set; }
        public string Option_Var2 { get; set; }
        public short MSG_No { get; set; }
        public short Branch_No { get; set; }
    }
}
