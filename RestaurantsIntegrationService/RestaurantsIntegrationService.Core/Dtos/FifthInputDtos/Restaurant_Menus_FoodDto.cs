using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FifthInputDtos
{
    public class Restaurant_Menus_FoodDto
    {
        public short Menu_No { get; set; }
        public int Food_No { get; set; }
        public Nullable<double> QTY { get; set; }
        public Nullable<double> Price { get; set; }
        public short Branch_No { get; set; }
    }
}
