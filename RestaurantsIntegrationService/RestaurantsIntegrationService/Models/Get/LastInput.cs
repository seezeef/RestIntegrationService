using System.Collections.Generic;
using RestaurantsIntegrationService.Core.Dtos.LastInputDtos;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Get
{
    public class LastInput
    {
        public List<CustomerDto> Customers { get; set; }
        public List<Customers_AddressDto> CustomersAddres { get; set; }
        public List<Customers_TypesDto> CustomersTypes { get; set; }
    }
}