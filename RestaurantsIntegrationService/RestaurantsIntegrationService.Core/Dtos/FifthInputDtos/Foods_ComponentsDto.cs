using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FifthInputDtos
{
    public class Foods_ComponentsDto
    {
        public short Branch_No { get; set; }
        public int Food_Parent_No { get; set; }
        public int Food_No { get; set; }
        public bool Raw_OR_Food { get; set; }
        public Nullable<double> Food_Qty { get; set; }
        public Nullable<double> Food_Per { get; set; }
        public bool Mandatory { get; set; }
    }
}
