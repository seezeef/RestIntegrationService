using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FirstInputDtos
{
    public class Delivery_OptionsDto
    {
        public bool Use_Delivery { get; set; }
        public decimal Fixed_Amount { get; set; }
        public decimal Max_Bill_Amount { get; set; }
        public decimal Min_Bill_Amount { get; set; }
        public bool All_Free { get; set; }
        public decimal FreeIFBillAmount { get; set; }
        public bool UseBlackList { get; set; }
        public short Branch_No { get; set; }
        public short Restart_Type { get; set; }
        public int Restart_No { get; set; }
        public bool Print_Cashier_Copy { get; set; }
        public DateTime? StartWork { get; set; }
        public DateTime? EndWork { get; set; }
        public bool PriceByMethods { get; set; }
    }
}
