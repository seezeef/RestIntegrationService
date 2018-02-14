using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FourthInputDtos
{
    public class Items_Notes_DtlDto
    {
        public int Note_No { get; set; }
        public int Food_No { get; set; }
        public Nullable<short> Group_No { get; set; }
        public short Branch_No { get; set; }
    }
}
