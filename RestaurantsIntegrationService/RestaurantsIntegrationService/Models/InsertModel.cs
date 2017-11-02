using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models
{
    public class TransferModel<T>
    {
        public T Items { get; set; }
        public string DatabaseName { get; set; }
        public  int OnyxBranchNumber { get; set; }
    }
}