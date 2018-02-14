using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.SecondInputDtos
{
    public class REQUEST_TYPESDto
    {
        public short REQ_TYPE { get; set; }
        public string REQ_NAME { get; set; }
        public string REQ_E_NAME { get; set; }
        public short Branch_No { get; set; }
    }
}
