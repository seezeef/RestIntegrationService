using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FifthInputDtos
{
    public class Insurance_MaterialsDto
    {
        public int M_No { get; set; }
        public string M_Name { get; set; }
        public string M_Name_E { get; set; }
        public Nullable<decimal> M_Price { get; set; }
        public short Branch_No { get; set; }
    }
}
