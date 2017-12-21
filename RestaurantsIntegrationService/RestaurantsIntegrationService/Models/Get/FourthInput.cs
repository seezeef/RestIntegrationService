using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Get
{
    public class FourthInput
    {
        public List<Foods_Types> FoodsTypeses { get; set; }
        public List<Foods_Groups> FoodsGroupses { get; set; }
        public List<Food> Foods { get; set; }
        public List<Foods_Units> FoodsUnits { get; set; }
        public List<Foods_Prices> FoodsPriceses { get; set; }
        public List<Groups_Items> GroupsItems { get; set; }
        public List<Items_Notes_Mst> ItemsNotesMsts { get; set; }
        public List<Items_Notes_Dtl> ItemsNotesDtls { get; set; }
        public List<Sub_Items> SubItemses { get; set; }
        public List<Foods_Altrantv> FoodsAltrantvs { get; set; }
        
    }
}


