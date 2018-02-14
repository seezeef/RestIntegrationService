using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FirstInputDtos
{
    public class Rest_TaxesDto
    {
        public short Tax_No { get; set; }
        public string Tax_NameA { get; set; }
        public string Tax_NameE { get; set; }
        public Nullable<byte> Tax_Group { get; set; }
        public Nullable<int> Tax_SubGroup { get; set; }
        public bool Tax_Type { get; set; }
        public Nullable<byte> Tax_Per { get; set; }
        public Nullable<double> Tax_Val { get; set; }
        public short Branch_No { get; set; }
    }
}
