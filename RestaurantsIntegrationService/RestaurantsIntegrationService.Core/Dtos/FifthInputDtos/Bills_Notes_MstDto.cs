using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FifthInputDtos
{
    public class Bills_Notes_MstDto
    {
        public int Note_No { get; set; }
        public string Note_Text { get; set; }
        public short Branch_No { get; set; }
    }
}
