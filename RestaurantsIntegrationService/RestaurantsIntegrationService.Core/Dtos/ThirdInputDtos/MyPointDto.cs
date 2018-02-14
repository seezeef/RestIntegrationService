using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.ThirdInputDtos
{
    public class MyPointDto
    {
        public short Level_No { get; set; }
        public int MaxAmt { get; set; }
        public int MinAmt { get; set; }
        public short No_Of_points { get; set; }
        public short Branch_No { get; set; }
    }
}
