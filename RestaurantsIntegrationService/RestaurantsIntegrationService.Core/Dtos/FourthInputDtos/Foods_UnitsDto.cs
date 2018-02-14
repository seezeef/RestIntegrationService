using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FourthInputDtos
{
    public class Foods_UnitsDto
    {
        public int Unit_No { get; set; }
        public int Food_No { get; set; }
        public Nullable<int> Unit_Size { get; set; }
        public bool Main_Unit { get; set; }
        public decimal Unit_Price { get; set; }
        public short Branch_No { get; set; }
    }
}
