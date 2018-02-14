using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FifthInputDtos
{
    public class Discount_MSTDto
    {
        public int Disc_No { get; set; }
        public string Disc_Desc { get; set; }
        public Nullable<System.DateTime> FDate { get; set; }
        public Nullable<System.DateTime> TDate { get; set; }
        public Nullable<System.DateTime> FTime { get; set; }
        public Nullable<System.DateTime> TTime { get; set; }
        public string DiscDays { get; set; }
        public Nullable<short> DiscType { get; set; }
        public Nullable<double> DiscAmt { get; set; }
        public int PromoType { get; set; }
        public Nullable<double> MainQty { get; set; }
        public int PromoFood_No { get; set; }
        public Nullable<double> PromoQty { get; set; }
        public short Branch_No { get; set; }
    }
}
