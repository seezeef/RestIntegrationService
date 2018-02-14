using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.ThirdInputDtos
{
    public class Privileges_SBFDto
    {
        public short UserID { get; set; }
        public int Group_No { get; set; }
        public bool Can_Use { get; set; }
        public int Type_No { get; set; }
        public short Branch_No { get; set; }
    }
}
