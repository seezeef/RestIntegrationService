using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.SecondInputDtos
{
    public class WAREHOUSE_DETAILSDto
    {
        public short W_CODE { get; set; }
        public string W_NAME { get; set; }
        public string W_E_NAME { get; set; }
        public string CC_CODE { get; set; }
        public short Branch_No { get; set; }
    }
}
