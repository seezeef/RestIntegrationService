using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.SecondInputDtos
{
    public class Benches_SectionsDto
    {
        public short Section_No { get; set; }
        public string Section_Name { get; set; }
        public string Section_Name_F { get; set; }
        public short Branch_No { get; set; }
        public string Invoice_Printer { get; set; }
        public Nullable<byte> Print_Count { get; set; }
        public byte[] Section_Pic { get; set; }
        public Nullable<short> BGType { get; set; }
        public Nullable<int> BGColor { get; set; }
    }
}
