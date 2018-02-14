using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FifthInputDtos
{
    public class Foods_AttachDto
    {
        public int Food_No { get; set; }
        public int Attach_Food_No { get; set; }
        public string Attach_LNm { get; set; }
        public string Attach_FNm { get; set; }
        public Nullable<int> Attach_Price { get; set; }
        public short Branch_No { get; set; }
        public string Attach_PrinterNm { get; set; }
        public short RCRD_NO { get; set; }
    }
}
