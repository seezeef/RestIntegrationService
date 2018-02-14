using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.LastInputDtos
{
    public class Customers_AddressDto
    {
        public int Serial_No { get; set; }
        public Nullable<long> Customer_No { get; set; }
        public string Customer_Name { get; set; }
        public string Tel_No { get; set; }
        public Nullable<int> Area_No { get; set; }
        public Nullable<int> S_No { get; set; }
        public string Court_No { get; set; }
        public string Floor_No { get; set; }
        public string Apartment_No { get; set; }
        public string A_Desc { get; set; }
        public string C_Color { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool F_Android { get; set; }
        public short Branch_No { get; set; }
        public short Act_No { get; set; }
        public string A_Name { get; set; }
    }
}
