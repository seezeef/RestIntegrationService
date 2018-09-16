using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using RestaurantsIntegrationService.App_Start;
using RestaurantsIntegrationService.Core.Dtos.FifthInputDtos;
using RestaurantsIntegrationService.Core.Dtos.FirstInputDtos;
using RestaurantsIntegrationService.Core.Dtos.FourthInputDtos;
using RestaurantsIntegrationService.Core.Dtos.LastInputDtos;
using RestaurantsIntegrationService.Core.Dtos.SecondInputDtos;
using RestaurantsIntegrationService.Core.Dtos.ThirdInputDtos;
using RestaurantsIntegrationService.Core.Extensions;
using RestaurantsIntegrationService.DataAccess;
using RestaurantsIntegrationService.Models.Get;
using RestaurantsIntegrationService.Models.Result;

namespace RestaurantsIntegrationService.Controllers {
    [Authorize]
    [RoutePrefix("api/get")]
    public class GetController : ApiController {
        //first 10 tables from synctables in db
        [HttpGet]
        [Route("GetFirstInputs/{branchNo}")]
        public IHttpActionResult GetFirstInputs(short branchNo)
        {
            try
            {
                var inputs = new FirstInput();
                using (var context = new Restaurants())
                {
                    var systems = context.System_Options.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.System = AutoMapperConfig.Mapper.Map<List<System_OptionsDto>>(systems);
                    var derliveryOptions = context.Delivery_Options.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.DeliveryOptionses = AutoMapperConfig.Mapper.Map<List<Delivery_OptionsDto>>(derliveryOptions);
                    var invoTypes = context.Restaurant_InvoTypes.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.InvoTypeses = AutoMapperConfig.Mapper.Map<List<Restaurant_InvoTypesDto>>(invoTypes);
                    var smsSuppliers = context.SMS_Suplliers.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.SmsSupllierses = AutoMapperConfig.Mapper.Map<List<SMS_SuplliersDto>>(smsSuppliers);
                    var smsDtls = context.SMS_DTL.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.SmsDtls = AutoMapperConfig.Mapper.Map<List<SMS_DTLDto>>(smsDtls);
                    var restTaxes = context.Rest_Taxes.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.RestTaxes = AutoMapperConfig.Mapper.Map<List<Rest_TaxesDto>>(restTaxes);
                    var barcodeSetup = context.BarCode_Setup.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.BarCodeSetups = AutoMapperConfig.Mapper.Map<List<BarCode_SetupDto>>(barcodeSetup);
                    var creditCards = context.CreditCards.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.CreditCards = AutoMapperConfig.Mapper.Map<List<CreditCardDto>>(creditCards);
                    var currencyCategories = context.Currency_Categories.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.CurrencyCategories = AutoMapperConfig.Mapper.Map<List<Currency_CategoriesDto>>(currencyCategories);
                    var employeeGroups = context.Employee_Groups.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.EmployeeGroups = AutoMapperConfig.Mapper.Map<List<Employee_GroupsDto>>(employeeGroups);
                    var spendTypes = context.Spends_Types.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.SpendsTypes = AutoMapperConfig.Mapper.Map<List<Spends_TypesDto>>(spendTypes);
                    //var json = JsonConvert.SerializeObject(inputs);
                    return Ok(new AjaxResponse<object>() { Success = true, Input = inputs });
                }
            }
            catch (Exception e)
            {
                return Ok(new AjaxResponse<object>() { Success = false,
                    ErrorMessage = $"In web api Can not get data from server in GetFirstInputs .. {e.GetLastException()} " });
            }

        }
        //seccond 10 tables
        [HttpGet]
        [Route("GetSecondInputs/{branchNo}")]
        public IHttpActionResult GetSecondInputs(short branchNo)
        {
            try
            {
                var inputs = new SecondInput();
                using (var context = new Restaurants())
                {
                    var employees = context.Employees.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.Employees = AutoMapperConfig.Mapper.Map<List<EmployeeDto>>(employees);
                    var warehouseDetails = context.WAREHOUSE_DETAILS.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.WarehouseDetails = AutoMapperConfig.Mapper.Map<List<WAREHOUSE_DETAILSDto>>(warehouseDetails);
                    var costCenters = context.COST_CENTERS.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.CostCenters = AutoMapperConfig.Mapper.Map<List<COST_CENTERSDto>>(costCenters);
                    var drivers = context.Drivers.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.Drivers = AutoMapperConfig.Mapper.Map<List<DriverDto>>(drivers);
                    var transferTypes = context.TRANSFER_TYPES.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.TransferTypes = AutoMapperConfig.Mapper.Map<List<TRANSFER_TYPESDto>>(transferTypes);
                    var requestTypes = context.REQUEST_TYPES.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.RequestTypes = AutoMapperConfig.Mapper.Map<List<REQUEST_TYPESDto>>(requestTypes);
                    var driversWorkDays = context.Drivers_Work_Days.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.DriversWorkDays = AutoMapperConfig.Mapper.Map<List<Drivers_Work_DaysDto>>(driversWorkDays);
                    var benchesSections = context.Benches_Sections.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.BenchesSections = AutoMapperConfig.Mapper.Map<List<Benches_SectionsDto>>(benchesSections);
                    var benches = context.Benches.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.Benches = AutoMapperConfig.Mapper.Map<List<BenchDto>>(benches);
                    var waiters = context.Waiters.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.Waiters = AutoMapperConfig.Mapper.Map<List<WaiterDto>>(waiters);
                    //var json = JsonConvert.SerializeObject(inputs);
                    return Ok(new AjaxResponse<object>() { Success = true, SecondInput = inputs });
                }
            }
            catch (Exception e)
            {
                return Ok(new AjaxResponse<object>() { Success = false,
                    ErrorMessage = $"In web api Can not get data from server in GetSecondInputs ..{e.GetLastException()} " });
            }

        }
        //third 10 tables
        [HttpGet]
        [Route("GetThirdInputs/{branchNo}")]
        public IHttpActionResult GetThirdInputs(short branchNo)
        {
            try
            {
                var inputs = new ThirdInput();
                using (var context = new Restaurants())
                {
                    var waitersPrivileges = context.Waiters_Privileges.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.WaitersPrivileges = AutoMapperConfig.Mapper.Map<List<Waiters_PrivilegesDto>>(waitersPrivileges);
                    var users = context.Users.ToList();
                    inputs.Users = AutoMapperConfig.Mapper.Map<List<UserDto>>(users);
                    var restaurantPeriods = context.Restaurant_Periods.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.RestaurantPeriods = AutoMapperConfig.Mapper.Map<List<Restaurant_PeriodsDto>>(restaurantPeriods);
                    var usersPeriods = context.Users_Periods.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.UsersPeriods = AutoMapperConfig.Mapper.Map<List<Users_PeriodsDto>>(usersPeriods);
                    var usersOptions = context.Users_Options.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.UsersOptions = AutoMapperConfig.Mapper.Map<List<Users_OptionsDto>>(usersOptions);
                    var privilegesSbfs = context.Privileges_SBF.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.PrivilegesSbfs = AutoMapperConfig.Mapper.Map<List<Privileges_SBFDto>>(privilegesSbfs);
                    var privileges = context.Privileges.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.Privileges = AutoMapperConfig.Mapper.Map<List<PrivilegeDto>>(privileges);
                    var myPoints = context.MyPoints.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.MyPoints = AutoMapperConfig.Mapper.Map<List<MyPointDto>>(myPoints);
                    var myPointsDtls = context.MyPoints_DTL.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.MyPointsDtls = AutoMapperConfig.Mapper.Map<List<MyPoints_DTLDto>>(myPointsDtls);
                    var units = context.Units.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.Units = AutoMapperConfig.Mapper.Map<List<UnitDto>>(units);
                    //var json = JsonConvert.SerializeObject(inputs);
                    return Ok(new AjaxResponse<object>() { Success = true, ThirdInput = inputs });
                }
            }
            catch (Exception e)
            {
                return Ok(new AjaxResponse<object>() { Success = false,
                    ErrorMessage = $"In web api Can not get data from server in ThirdInput .. {e.GetLastException()} " });
            }

        }
        //fourth 10 tables
        [HttpGet]
        [Route("GetFourthInputs/{branchNo}")]
        public IHttpActionResult GetFourthInputs(short branchNo)
        {
            try
            {
                var inputs = new FourthInput();
                using (var context = new Restaurants())
                {
                    var foodsTypes = context.Foods_Types.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.FoodsTypes = AutoMapperConfig.Mapper.Map<List<Foods_TypesDto>>(foodsTypes);

                    var foodsGroups = context.Foods_Groups.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.FoodsGroups = AutoMapperConfig.Mapper.Map<List<Foods_GroupsDto>>(foodsGroups);

                    var foods = context.Foods.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.Foods = AutoMapperConfig.Mapper.Map<List<FoodDto>>(foods);

                    var foodsUnits = context.Foods_Units.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.FoodsUnits = AutoMapperConfig.Mapper.Map<List<Foods_UnitsDto>>(foodsUnits);

                    var foodsPrices = context.Foods_Prices.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.FoodsPrices = AutoMapperConfig.Mapper.Map<List<Foods_PricesDto>>(foodsPrices);

                    var groupsItems = context.Groups_Items.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.GroupsItems = AutoMapperConfig.Mapper.Map<List<Groups_ItemsDto>>(groupsItems);

                    var itemsNotesMsts = context.Items_Notes_Mst.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.ItemsNotesMsts = AutoMapperConfig.Mapper.Map<List<Items_Notes_MstDto>>(itemsNotesMsts);

                    var itemsNotesDtls = context.Items_Notes_Dtl.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.ItemsNotesDtls = AutoMapperConfig.Mapper.Map<List<Items_Notes_DtlDto>>(itemsNotesDtls);

                    var subItemses = context.Sub_Items.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.SubItems = AutoMapperConfig.Mapper.Map<List<Sub_ItemsDto>>(subItemses);

                    var foodsAltrantvs = context.Foods_Altrantv.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.FoodsAltrantvs = AutoMapperConfig.Mapper.Map<List<Foods_AltrantvDto>>(foodsAltrantvs);
                    //var json = JsonConvert.SerializeObject(inputs);
                    return Ok(new AjaxResponse<object>() { Success = true, FourthInput = inputs });
                }
            }           
            catch (Exception ex)
            {                
                return Ok(new AjaxResponse<object>() { Success = false,
                    ErrorMessage = $"In web api Can not get data from server in GetFourthInputs .. {ex.GetLastException()}" });
            }

        }
        //fifth 10 tables
        [HttpGet]
        [Route("GetFifthInputs/{branchNo}")]
        public IHttpActionResult GetFifthInputs(short branchNo)
        {
            try
            {
                var inputs = new FifthInput();
                using (var context = new Restaurants())
                {
                    var discountMsts = context.Discount_MST.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.DiscountMsts = AutoMapperConfig.Mapper.Map<List<Discount_MSTDto>>(discountMsts);
                    var foodsAttaches = context.Foods_Attach.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.FoodsAttaches = AutoMapperConfig.Mapper.Map<List<Foods_AttachDto>>(foodsAttaches);
                    var foodComponents = context.Foods_Components.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.FoodComponents = AutoMapperConfig.Mapper.Map<List<Foods_ComponentsDto>>(foodComponents);
                    var foodsComponentsEnds = context.Foods_Components_End.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.FoodsComponentsEnds = AutoMapperConfig.Mapper.Map<List<Foods_Components_EndDto>>(foodsComponentsEnds);
                    var insuranceMaterialses = context.Insurance_Materials.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.InsuranceMaterialses = AutoMapperConfig.Mapper.Map<List<Insurance_MaterialsDto>>(insuranceMaterialses);
                    var restaurantMenus = context.Restaurant_Menus.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.RestaurantMenus = AutoMapperConfig.Mapper.Map<List<Restaurant_MenusDto>>(restaurantMenus);
                    var restaurantMenusFoods = context.Restaurant_Menus_Food.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.RestaurantMenusFoods = AutoMapperConfig.Mapper.Map<List<Restaurant_Menus_FoodDto>>(restaurantMenusFoods);
                    var billsNotesMsts = context.Bills_Notes_Mst.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.BillsNotesMsts = AutoMapperConfig.Mapper.Map<List<Bills_Notes_MstDto>>(billsNotesMsts);
                    var areas = context.Areas.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.Areas = AutoMapperConfig.Mapper.Map<List<AreaDto>>(areas);
                    var areasDrivers = context.Areas_Drivers.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.AreasDrivers = AutoMapperConfig.Mapper.Map<List<Areas_DriversDto>>(areasDrivers);
                    var streets = context.Streets.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.Streets = AutoMapperConfig.Mapper.Map<List<StreetDto>>(streets);
                    var cellsGroups = context.Cells_Groups.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.CellsGroups = AutoMapperConfig.Mapper.Map<List<Cells_GroupsDto>>(cellsGroups);
                    var cells = context.Cells.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.Cells = AutoMapperConfig.Mapper.Map<List<CellDto>>(cells);
                    var poss = context.POS.Where(x => x.Branch_No == branchNo).ToList();
                    inputs.Poss = AutoMapperConfig.Mapper.Map<List<POSDto>>(poss);
                    //var json = JsonConvert.SerializeObject(inputs);
                    return Ok(new AjaxResponse<object>() { Success = true, FifthInput = inputs });
                }
            }
            catch (Exception e)
            {
                return Ok(new AjaxResponse<object>() { Success = false,
                    ErrorMessage = $"In web api Can not get data from server in GetFifthInputs.. .. {e.GetLastException()} " });
            }
            
        }
        //last tables
        [HttpGet]
        [Route("GetLastInputs/{branchNo}")]
        public IHttpActionResult GetLastInputs(short branchNo)
        {
            try
            {
                var inputs = new LastInput();
                using (var context = new Context())
                {
                    var customersTypes = context.Customers_Types.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.CustomersTypes = AutoMapperConfig.Mapper.Map<List<Customers_TypesDto>>(customersTypes);
                    var customers = context.Customers.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.Customers = AutoMapperConfig.Mapper.Map<List<CustomerDto>>(customers);
                    var customersAddres = context.Customers_Address.Where(b => b.Branch_No == branchNo).ToList();
                    inputs.CustomersAddres = AutoMapperConfig.Mapper.Map<List<Customers_AddressDto>>(customersAddres);
                    return Ok(new AjaxResponse<object>() { Success = true, LastInput = inputs });
                }
            }
            catch (Exception e)
            {
                return Ok(new AjaxResponse<object>() { Success = false,
                    ErrorMessage = $"In web api Can not get data from server in GetLastInputs .. {e.GetLastException()} " });
            }
           
        }
    }
}
