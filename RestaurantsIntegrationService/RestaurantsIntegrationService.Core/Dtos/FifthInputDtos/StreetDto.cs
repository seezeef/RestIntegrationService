using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FifthInputDtos
{
    public class StreetDto
    {
        public int S_No { get; set; }
        public string S_A_Name { get; set; }
        public string S_E_Name { get; set; }
        public short Branch_No { get; set; }
        public int Area_No { get; set; }
        public string S_Desc { get; set; }
        public Nullable<decimal> Dr_Amount { get; set; }
        public Nullable<short> Dr_Percent { get; set; }
        public Nullable<short> Max_Time { get; set; }
    }
}
