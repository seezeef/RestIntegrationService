using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.SecondInputDtos
{
    public class TRANSFER_TYPESDto
    {
        public short TR_TYPE { get; set; }
        public string TR_NAME { get; set; }
        public string TR_E_NAME { get; set; }
        public Nullable<short> TR_SR { get; set; }
        public Nullable<short> TR_REC { get; set; }
        public short Branch_No { get; set; }
    }
}
