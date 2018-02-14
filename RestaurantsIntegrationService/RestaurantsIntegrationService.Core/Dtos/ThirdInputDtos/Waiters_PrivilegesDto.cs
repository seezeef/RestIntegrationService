using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.ThirdInputDtos
{
    public class Waiters_PrivilegesDto
    {
        public short Waiter_No { get; set; }
        public short Bench_No { get; set; }
        public bool Can_Use { get; set; }
        public short Branch_No { get; set; }
    }
}
