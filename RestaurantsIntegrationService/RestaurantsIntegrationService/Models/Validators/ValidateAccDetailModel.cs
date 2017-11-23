using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Validators
{
    public class ValidateAccDetailModel
    {
        public int? CacheNo { get; set; }
        public int? CardNo { get; set; }
        public int? CustomerCode { get; set; }
        public int? AccountTypeId { get; set; }
    }
}