using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FifthInputDtos
{
    public class Restaurant_MenusDto
    {
        public short Menu_No { get; set; }
        public string Menu_Name { get; set; }
        public string Menu_E_Name { get; set; }
        public Nullable<decimal> Menu_Person_Price { get; set; }
        public bool Can_Use { get; set; }
        public short Branch_No { get; set; }
    }
}
