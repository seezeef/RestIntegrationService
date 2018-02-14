using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.SecondInputDtos
{
    public class DriverDto
    {
        public int Dr_No { get; set; }
        public string Dr_Name { get; set; }
        public string Address { get; set; }
        public string Tel_No { get; set; }
        public string Account_No { get; set; }
        public bool Stopped { get; set; }
        public Nullable<short> Max_Orders { get; set; }
        public string Password { get; set; }
        public short Branch_No { get; set; }
        public string D_Color { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
