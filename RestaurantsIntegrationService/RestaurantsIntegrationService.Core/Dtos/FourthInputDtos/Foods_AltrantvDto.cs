using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FourthInputDtos
{
    public class Foods_AltrantvDto
    {
        public int Food_No { get; set; }
        public int Food_No_Altrantv { get; set; }
        public Nullable<double> EQty { get; set; }
        public int ORDR_NO { get; set; }
        public short Branch_No { get; set; }
    }
}
