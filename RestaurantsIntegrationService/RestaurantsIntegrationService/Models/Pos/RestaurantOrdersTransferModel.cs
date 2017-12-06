using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class RestaurantOrdersTransferModel
    {
        public List<Restaurant_Orders> Master { get; set; }
    }
}