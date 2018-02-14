using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantsIntegrationService.Core.Dtos.FourthInputDtos;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Get
{
    public class FourthInput
    {
        public List<Foods_TypesDto> FoodsTypes { get; set; }
        public List<Foods_GroupsDto> FoodsGroups { get; set; }
        public List<FoodDto> Foods { get; set; }
        public List<Foods_UnitsDto> FoodsUnits { get; set; }
        public List<Foods_PricesDto> FoodsPrices { get; set; }
        public List<Groups_ItemsDto> GroupsItems { get; set; }
        public List<Items_Notes_MstDto> ItemsNotesMsts { get; set; }
        public List<Items_Notes_DtlDto> ItemsNotesDtls { get; set; }
        public List<Sub_ItemsDto> SubItems { get; set; }
        public List<Foods_AltrantvDto> FoodsAltrantvs { get; set; }
        
    }
}


