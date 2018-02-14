using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantsIntegrationService.Core.Dtos.FifthInputDtos;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Get
{
    public class FifthInput
    {
        public List<Discount_MSTDto> DiscountMsts { get; set; }
        public List<Foods_AttachDto> FoodsAttaches { get; set; }
        public List<Foods_ComponentsDto> FoodComponents { get; set; }
        public List<Foods_Components_EndDto> FoodsComponentsEnds { get; set; }
        public List<Insurance_MaterialsDto> InsuranceMaterialses { get; set; }
        public List<Restaurant_MenusDto> RestaurantMenus{ get; set; }
        public List<Restaurant_Menus_FoodDto> RestaurantMenusFoods { get; set; }
        public List<Bills_Notes_MstDto> BillsNotesMsts { get; set; }
        public List<AreaDto> Areas { get; set; }
        public List<Areas_DriversDto> AreasDrivers { get; set; }
        public List<StreetDto> Streets { get; set; }
        public List<Cells_GroupsDto> CellsGroups { get; set; }
        public List<CellDto> Cells { get; set; }
        public List<POSDto> Poss { get; set; }

    }
}