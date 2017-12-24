using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using RestaurantsIntegrationService.DataAccess;
using RestaurantsIntegrationService.Models.Get;
using RestaurantsIntegrationService.Models.Result;

namespace RestaurantsIntegrationService.Controllers
{
    [Authorize]
    [RoutePrefix("api/get")]
    public class GetController : ApiController
    {

        [HttpGet]
        [Route("GetFirstInputs/{branchNo}")]
        public IHttpActionResult GetFirstInputs(short branchNo)
        {
            var inputs = new FirstInput();
            using (var context = new Restaurants())
            {
                inputs.System = context.System_Options.Where(b => b.Branch_No == branchNo).ToList();
                inputs.DeliveryOptionses = context.Delivery_Options.Where(b => b.Branch_No == branchNo).ToList();
                inputs.InvoTypeses = context.Restaurant_InvoTypes.Where(b => b.Branch_No == branchNo).ToList();
                inputs.SmsSupllierses = context.SMS_Suplliers.Where(b => b.Branch_No == branchNo).ToList();
                inputs.SmsDtls = context.SMS_DTL.Where(b => b.Branch_No == branchNo).ToList();
                inputs.RestTaxeses = context.Rest_Taxes.Where(b => b.Branch_No == branchNo).ToList();
                inputs.BarCodeSetups = context.BarCode_Setup.Where(b => b.Branch_No == branchNo).ToList();
                inputs.CreditCards = context.CreditCards.Where(x => x.Branch_No == branchNo).ToList();
                inputs.CurrencyCategorieses = context.Currency_Categories.Where(x => x.Branch_No == branchNo).ToList();
                inputs.EmployeeGroupses = context.Employee_Groups.Where(x => x.Branch_No == branchNo).ToList();
                //var json = JsonConvert.SerializeObject(inputs);
                return Ok(new AjaxResponse<object>() { Success = true, Input = inputs });
            }
        }


        [HttpGet]
        [Route("GetSecondInputs/{branchNo}")]
        public IHttpActionResult GetSecondInputs(short branchNo)
        {
            var inputs = new SecondInput();
            using (var context = new Restaurants())
            {
                inputs.Employees = context.Employees.Where(b => b.Branch_No == branchNo).ToList();
                inputs.WarehouseDetailss = context.WAREHOUSE_DETAILS.Where(b => b.Branch_No == branchNo).ToList();
                inputs.CostCenterss = context.COST_CENTERS.Where(b => b.Branch_No == branchNo).ToList();
                inputs.Drivers = context.Drivers.Where(b => b.Branch_No == branchNo).ToList();
                inputs.TransferTypess = context.TRANSFER_TYPES.Where(b => b.Branch_No == branchNo).ToList();
                inputs.RequestTypess = context.REQUEST_TYPES.Where(b => b.Branch_No == branchNo).ToList();
                inputs.DriversWorkDayses = context.Drivers_Work_Days.Where(b => b.Branch_No == branchNo).ToList();
                inputs.BenchesSectionses = context.Benches_Sections.Where(b => b.Branch_No == branchNo).ToList();
                inputs.Benches = context.Benches.Where(x => x.Branch_No == branchNo).ToList();
                inputs.Waiters = context.Waiters.Where(x => x.Branch_No == branchNo).ToList();
                //var json = JsonConvert.SerializeObject(inputs);
                return Ok(new AjaxResponse<object>() { Success = true, SecondInput = inputs });
            }
        }

        [HttpGet]
        [Route("GetThirdInputs/{branchNo}")]
        public IHttpActionResult GetThirdInputs(short branchNo)
        {
            var inputs = new ThirdInput();
            using (var context = new Restaurants())
            {
                inputs.WaitersPrivilegeses = context.Waiters_Privileges.Where(b => b.Branch_No == branchNo).ToList();
                inputs.Users = context.Users.ToList();
                inputs.RestaurantPeriodses = context.Restaurant_Periods.Where(b => b.Branch_No == branchNo).ToList();
                inputs.UsersPeriodses = context.Users_Periods.Where(b => b.Branch_No == branchNo).ToList();
                inputs.UsersOptionses = context.Users_Options.Where(b => b.Branch_No == branchNo).ToList();
                inputs.PrivilegesSbfs = context.Privileges_SBF.Where(b => b.Branch_No == branchNo).ToList();
                inputs.Privileges = context.Privileges.Where(b => b.Branch_No == branchNo).ToList();
                inputs.MyPoints = context.MyPoints.Where(b => b.Branch_No == branchNo).ToList();
                inputs.MyPointsDtls = context.MyPoints_DTL.Where(x => x.Branch_No == branchNo).ToList();
                inputs.Units = context.Units.Where(x => x.Branch_No == branchNo).ToList();
                //var json = JsonConvert.SerializeObject(inputs);
                return Ok(new AjaxResponse<object>() { Success = true, ThirdInput = inputs });
            }
        }
        [HttpGet]
        [Route("GetFourthInputs/{branchNo}")]
        public IHttpActionResult GetFourthInputs(short branchNo)
        {
            var inputs = new FourthInput();
            using (var context = new Restaurants())
            {
                inputs.FoodsTypeses = context.Foods_Types.Where(b => b.Branch_No == branchNo).ToList();
                inputs.FoodsGroupses = context.Foods_Groups.Where(b => b.Branch_No == branchNo).ToList();
                inputs.Foods = context.Foods.Where(b => b.Branch_No == branchNo).ToList();
                inputs.FoodsUnits = context.Foods_Units.Where(b => b.Branch_No == branchNo).ToList();
                inputs.FoodsPriceses = context.Foods_Prices.Where(b => b.Branch_No == branchNo).ToList();
                inputs.GroupsItems = context.Groups_Items.Where(b => b.Branch_No == branchNo).ToList();
                inputs.ItemsNotesMsts = context.Items_Notes_Mst.Where(b => b.Branch_No == branchNo).ToList();
                inputs.ItemsNotesDtls = context.Items_Notes_Dtl.Where(b => b.Branch_No == branchNo).ToList();
                inputs.SubItemses = context.Sub_Items.Where(x => x.Branch_No == branchNo).ToList();
                inputs.FoodsAltrantvs = context.Foods_Altrantv.Where(x => x.Branch_No == branchNo).ToList();
                //var json = JsonConvert.SerializeObject(inputs);
                return Ok(new AjaxResponse<object>() { Success = true, FourthInput = inputs });
            }            
        }

        [HttpGet]
        [Route("GetFifthInputs/{branchNo}")]
        public IHttpActionResult GetFifthInputs(short branchNo)
        {
            var inputs = new FifthInput();
            using (var context = new Restaurants())
            {
                inputs.DiscountMsts = context.Discount_MST.Where(b => b.Branch_No == branchNo).ToList();
                inputs.FoodsAttaches = context.Foods_Attach.Where(b => b.Branch_No == branchNo).ToList();
                inputs.FoodComponents = context.Foods_Components.Where(b => b.Branch_No == branchNo).ToList();
                inputs.FoodsComponentsEnds = context.Foods_Components_End.Where(b => b.Branch_No == branchNo).ToList();
                inputs.InsuranceMaterialses = context.Insurance_Materials.Where(b => b.Branch_No == branchNo).ToList();
                inputs.RestaurantMenus = context.Restaurant_Menus.Where(b => b.Branch_No == branchNo).ToList();
                inputs.RestaurantMenusFoods = context.Restaurant_Menus_Food.Where(b => b.Branch_No == branchNo).ToList();
                inputs.BillsNotesMsts = context.Bills_Notes_Mst.Where(b => b.Branch_No == branchNo).ToList();
                inputs.Areas = context.Areas.Where(x => x.Branch_No == branchNo).ToList();
                inputs.AreasDrivers = context.Areas_Drivers.Where(x => x.Branch_No == branchNo).ToList();
                inputs.Streets = context.Streets.Where(x => x.Branch_No == branchNo).ToList();
                inputs.CellsGroups = context.Cells_Groups.Where(x => x.Branch_No == branchNo).ToList();
                inputs.Cells = context.Cells.Where(x => x.Branch_No == branchNo).ToList();
                inputs.Poss = context.POS.Where(x => x.Branch_No == branchNo).ToList();
                //var json = JsonConvert.SerializeObject(inputs);
                return Ok(new AjaxResponse<object>() { Success = true, FifthInput = inputs });
            }
        }

        [HttpGet]
        [Route("GetLastInputs/{branchNo}")]
        public IHttpActionResult GetLastInputs(short branchNo)
        {
            var inputs = new LastInput();
            using (var context = new Context())
            {
                inputs.CustomersTypes = context.Customers_Types.Where(b => b.Branch_No == branchNo).ToList();
                inputs.Customers = context.Customers.Where(b => b.Branch_No == branchNo).ToList();
                inputs.CustomersAddres = context.Customers_Address.Where(b => b.Branch_No == branchNo).ToList();
                return Ok(new AjaxResponse<object>() { Success = true, LastInput = inputs });
            }
        }

    }
}
