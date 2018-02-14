using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.SecondInputDtos
{
    public class WaiterDto
    {
        public short Waiter_No { get; set; }
        public string Waiter_Name { get; set; }
        public string Password { get; set; }
        public bool All_Benches { get; set; }
        public short Branch_No { get; set; }
        public string Account_No { get; set; }
    }
}
