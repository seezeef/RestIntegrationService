using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Get
{
    public class LastInput
    {
        public List<Customer> Customers { get; set; }
        public List<Customers_Address> CustomersAddres { get; set; }
        public List<Customers_Types> CustomersTypes { get; set; }
    }
}