using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FirstInputDtos
{
    public class BarCode_SetupDto
    {
        public short Branch_No { get; set; }
        public string Weight_Begin { get; set; }
        public Nullable<short> Barcode_No_Length { get; set; }
        public Nullable<short> Item_No_Length { get; set; }
        public Nullable<int> Weight_Basic { get; set; }
        public bool Weight_Begin_Align { get; set; }
    }
}
