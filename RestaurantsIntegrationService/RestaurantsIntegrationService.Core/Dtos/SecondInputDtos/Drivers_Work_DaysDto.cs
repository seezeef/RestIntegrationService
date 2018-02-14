using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.SecondInputDtos
{
    public class Drivers_Work_DaysDto
    {
        public short Day_No { get; set; }
        public short Branch_No { get; set; }
        public int Dr_No { get; set; }
        public Nullable<System.DateTime> P1_FTime { get; set; }
        public Nullable<System.DateTime> P1_TTime { get; set; }
        public Nullable<System.DateTime> P2_FTime { get; set; }
        public Nullable<System.DateTime> P2_TTime { get; set; }
        public bool Stopped { get; set; }
        public bool Active { get; set; }
    }
}
