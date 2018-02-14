using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using RestaurantsIntegrationService.Core.Dtos.FirstInputDtos;
using RestaurantsIntegrationService.Core.Dtos.SecondInputDtos;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Get
{
    public class FirstInput
    {
        public List<System_OptionsDto> System { get; set; }
        public List<Delivery_OptionsDto> DeliveryOptionses { get; set; }
        public List<Restaurant_InvoTypesDto> InvoTypeses { get; set; }
        public List<SMS_SuplliersDto> SmsSupllierses { get; set; }
        public List<SMS_DTLDto> SmsDtls { get; set; }
        public List<Rest_TaxesDto> RestTaxes { get; set; }
        public List<BarCode_SetupDto> BarCodeSetups { get; set; }
        public List<CreditCardDto> CreditCards { get; set; }
        public List<Currency_CategoriesDto> CurrencyCategories { get; set; }
        public List<Employee_GroupsDto> EmployeeGroups { get; set; }
        public List<Spends_TypesDto> SpendsTypes { get; set; }
    }
}