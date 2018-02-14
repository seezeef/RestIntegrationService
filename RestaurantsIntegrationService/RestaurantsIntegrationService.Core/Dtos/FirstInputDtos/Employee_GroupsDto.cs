using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FirstInputDtos
{
    public class Employee_GroupsDto
    {
        public short Group_No { get; set; }
        public string Group_Name { get; set; }
        public string Group_E_Name { get; set; }
        public Nullable<short> Menu_No { get; set; }
        public short Branch_No { get; set; }
    }
}
