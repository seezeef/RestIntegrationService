using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FourthInputDtos
{
    public class Sub_ItemsDto
    {
        public int Food_No { get; set; }
        public int Sub_Food_No { get; set; }
        public short F_Type { get; set; }
        public short Branch_No { get; set; }
    }
}
