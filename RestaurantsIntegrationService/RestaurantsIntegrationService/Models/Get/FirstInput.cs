using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Get
{
    public class FirstInput
    {
        public List<System_Options> System { get; set; }
        public List<Delivery_Options> DeliveryOptionses { get; set; }
        public List<Restaurant_InvoTypes> InvoTypeses { get; set; }
        public List<SMS_Suplliers> SmsSupllierses { get; set; }
        public List<SMS_DTL> SmsDtls { get; set; }
        public List<Rest_Taxes> RestTaxeses { get; set; }
        public List<BarCode_Setup> BarCodeSetups { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<Currency_Categories> CurrencyCategorieses { get; set; }
        public List<Employee_Groups> EmployeeGroupses { get; set; }
    }
}