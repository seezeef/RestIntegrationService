using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FourthInputDtos
{
    public class FoodDto
    {
        public int Food_No { get; set; }
        public string Food_AName { get; set; }
        public string Food_EName { get; set; }
        public float Food_Price { get; set; }
        public short Food_Type { get; set; }
        public string Food_Unit { get; set; }
        public decimal Food_Cost { get; set; }
        public string I_Code { get; set; }
        public Nullable<short> Group_No { get; set; }
        public string Food_ADesc { get; set; }
        public string Food_EDesc { get; set; }
        public byte[] Food_Pic { get; set; }
        public short Branch_No { get; set; }
        public bool Has_Component { get; set; }
        public short Food_Disc { get; set; }
        public Nullable<int> Food_Color { get; set; }
        public Nullable<int> Food_Order { get; set; }
        public Nullable<int> Main_Unit_Code { get; set; }
        public string BarCode_No { get; set; }
        public bool Item_Weight { get; set; }
        public bool Sub_Unit { get; set; }
        public string Item_Weight_No { get; set; }
        public bool Food_Disable { get; set; }
        public string Chef_Printer { get; set; }
        public bool ChangePrice { get; set; }
        public bool Delivery_Item { get; set; }
        public Nullable<short> Max_Time { get; set; }
        public Nullable<short> Max_Qty_Time { get; set; }
        public Nullable<short> Min_Qty { get; set; }
        public Nullable<short> Max_Qty { get; set; }
        public Nullable<short> W_Code { get; set; }
        public int Sub_Item { get; set; }
        public bool W_Link { get; set; }
        public float P_SIZE { get; set; }
        public bool Use_Qty_Fraction { get; set; }
        public bool Main_Unit { get; set; }
        public short Unt_Level { get; set; }
        public Nullable<int> Main_Food_No { get; set; }
        public bool Use_Attach { get; set; }
        public bool Item_App { get; set; }
        public bool UseExpireDate { get; set; }
        public bool IsCombo { get; set; }
        public bool IsGNRL { get; set; }
        public bool ReturnAsDamaged { get; set; }
        public float ItemTax { get; set; }
        public bool IsProduct { get; set; }
    }
}
