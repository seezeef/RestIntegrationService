using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Get
{
    public class FifthInput
    {
        public List<Discount_MST> DiscountMsts { get; set; }
        public List<Foods_Attach> FoodsAttaches { get; set; }
        public List<Foods_Components> FoodComponents { get; set; }
        public List<Foods_Components_End> FoodsComponentsEnds { get; set; }
        public List<Insurance_Materials> InsuranceMaterialses { get; set; }
        public List<Restaurant_Menus> RestaurantMenus{ get; set; }
        public List<Restaurant_Menus_Food> RestaurantMenusFoods { get; set; }
        public List<Bills_Notes_Mst> BillsNotesMsts { get; set; }
        public List<Area> Areas { get; set; }
        public List<Areas_Drivers> AreasDrivers { get; set; }
        public List<Street> Streets { get; set; }
        public List<Cells_Groups> CellsGroups { get; set; }
        public List<Cell> Cells { get; set; }
        public List<POS> Poss { get; set; }

    }
}