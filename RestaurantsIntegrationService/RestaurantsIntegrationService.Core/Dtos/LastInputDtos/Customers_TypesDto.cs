using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.LastInputDtos
{
    public class Customers_TypesDto
    {
        public int Type_No { get; set; }
        public string Type_Name_L { get; set; }
        public string Type_Name_F { get; set; }
        public int Card_Disc { get; set; }
        public Nullable<double> Type_Disc { get; set; }
        public short Branch_No { get; set; }
        public short Act_No { get; set; }
    }
}
