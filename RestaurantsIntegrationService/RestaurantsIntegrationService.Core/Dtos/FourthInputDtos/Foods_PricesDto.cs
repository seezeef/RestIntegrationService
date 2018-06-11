using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FourthInputDtos
{
    public class Foods_PricesDto
    {
        public int IDSer { get; set; }
        public short Branch_No { get; set; }
        public short? Type_No { get; set; }
        public short? Group_No { get; set; }
        public int Food_No { get; set; }
        public int? Unit_No { get; set; }
        public int Unit_Size { get; set; }
        public double? Food_Price { get; set; }
        public short Food_Disc { get; set; }
        public short? Price_Type { get; set; }
    }
}
