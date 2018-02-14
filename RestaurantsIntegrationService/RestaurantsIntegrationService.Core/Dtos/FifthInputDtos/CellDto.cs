using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FifthInputDtos
{
    public class CellDto
    {
        public int Cell_No { get; set; }
        public string Cell_Name { get; set; }
        public string Cell_Name_F { get; set; }
        public Nullable<int> Food_No { get; set; }
        public Nullable<double> Cell_Price { get; set; }
        public int Status_No { get; set; }
        public int Group_No { get; set; }
        public byte[] Cell_Pic { get; set; }
        public bool Cell_Alert { get; set; }
        public short Branch_No { get; set; }
    }
}
