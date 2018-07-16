using System.Collections.Generic;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class CustomerPamentsModel
    {
        public List<Customers_Payment> CustomerPaymnets { get; set; }
    }
}