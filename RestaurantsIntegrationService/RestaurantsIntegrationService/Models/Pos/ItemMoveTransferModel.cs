using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Pos
{
    public class ItemMoveTransferModel
    {
        public List<Item_Move> Master { get; set; }
    }
}