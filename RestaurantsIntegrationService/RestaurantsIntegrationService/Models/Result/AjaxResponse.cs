using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantsIntegrationService.Models.Get;

namespace RestaurantsIntegrationService.Models.Result
{
    public class AjaxResponse<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public FirstInput Input { get; set; }
        public SecondInput SecondInput { get; set; }
        public ThirdInput ThirdInput { get; set; }
        public FourthInput FourthInput { get; set; }
        public FifthInput FifthInput { get; set; }
        public LastInput LastInput { get; set; }
    }
}