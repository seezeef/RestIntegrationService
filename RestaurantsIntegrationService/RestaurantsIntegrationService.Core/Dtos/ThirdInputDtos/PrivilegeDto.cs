using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.ThirdInputDtos
{
    public class PrivilegeDto
    {
        public bool Add_On { get; set; }
        public bool Del_On { get; set; }
        public short Form_No { get; set; }
        public bool Modify_On { get; set; }
        public short User_ID { get; set; }
        public bool View_On { get; set; }
        public short Branch_No { get; set; }
    }
}
