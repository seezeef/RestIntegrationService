using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.ThirdInputDtos
{
    public class Users_PeriodsDto
    {
        public short User_Id { get; set; }
        public short Branch_No { get; set; }
        public int Period_No { get; set; }
        public bool Can_Login { get; set; }
    }
}
