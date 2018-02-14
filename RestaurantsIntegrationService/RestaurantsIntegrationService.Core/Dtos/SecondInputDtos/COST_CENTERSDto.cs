using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.SecondInputDtos
{
    public class COST_CENTERSDto
    {
        public Nullable<int> CC_NO { get; set; }
        public string CC_CODE { get; set; }
        public string CC_A_NAME { get; set; }
        public string CC_E_NAME { get; set; }
        public short Branch_No { get; set; }
    }
}
