using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.SecondInputDtos
{
    public class Spends_TypesDto
    {
        public int Sp_Type { get; set; }
        public string SP_NAME_L { get; set; }
        public string SP_NAME_F { get; set; }
        public short Branch_No { get; set; }
    }
}
