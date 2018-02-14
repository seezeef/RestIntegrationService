using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FirstInputDtos
{
    public class Currency_CategoriesDto
    {
        public int Category_No { get; set; }
        public Nullable<double> Category_Value { get; set; }
        public short Branch_No { get; set; }
    }
}
