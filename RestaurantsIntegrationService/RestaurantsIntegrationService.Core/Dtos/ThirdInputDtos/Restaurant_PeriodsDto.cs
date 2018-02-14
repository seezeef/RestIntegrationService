using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.ThirdInputDtos
{
    public class Restaurant_PeriodsDto
    {
        public int Period_No { get; set; }
        public string Period_Name { get; set; }
        public Nullable<System.DateTime> Period_Start { get; set; }
        public Nullable<System.DateTime> Period_End { get; set; }
        public Nullable<short> AlertMinutes { get; set; }
        public bool Period_Stop { get; set; }
        public short Branch_No { get; set; }
    }
}
