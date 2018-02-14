using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FourthInputDtos
{
    public class Foods_TypesDto
    {
        public short Type_No { get; set; }
        public string Type_Name { get; set; }
        public string Type_E_Name { get; set; }
        public short Branch_No { get; set; }
    }
}
