using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RestaurantsIntegrationService.Core.Dtos.FifthInputDtos;
using RestaurantsIntegrationService.Core.Dtos.FirstInputDtos;
using RestaurantsIntegrationService.Core.Dtos.FourthInputDtos;
using RestaurantsIntegrationService.Core.Dtos.LastInputDtos;
using RestaurantsIntegrationService.Core.Dtos.SecondInputDtos;
using RestaurantsIntegrationService.Core.Dtos.ThirdInputDtos;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.App_Start
{
    public class AutoMapperConfig
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper != null) return _mapper;
                if (_mapperConfiguration == null)
                    Configure();

                if (_mapperConfiguration != null) _mapper = _mapperConfiguration.CreateMapper();
                return _mapper;
            }
            set { _mapper = value; }
        }

        public static void Configure()
        {
            _mapperConfiguration = new MapperConfiguration(configure =>
            {                
                configure.CreateMap<Customers_Address, Customers_AddressDto>();
                configure.CreateMap<Customers_Types, Customers_TypesDto>();
                configure.CreateMap<BarCode_Setup, BarCode_SetupDto>();
                configure.CreateMap<System_Options, System_OptionsDto>();
                configure.CreateMap<CreditCard, CreditCardDto>();
                configure.CreateMap<Currency_Categories, Currency_CategoriesDto>();
                configure.CreateMap<Delivery_Options, Delivery_OptionsDto>();
                configure.CreateMap<Employee_Groups, Employee_GroupsDto>();
                configure.CreateMap<Rest_Taxes, Rest_TaxesDto>();
                configure.CreateMap<Restaurant_InvoTypes, Restaurant_InvoTypesDto>();
                configure.CreateMap<SMS_DTL, SMS_DTLDto>();
                configure.CreateMap<Bench, BenchDto>();
                configure.CreateMap<Benches_Sections, Benches_SectionsDto>();
                configure.CreateMap<Drivers_Work_Days, Drivers_Work_DaysDto>();
                configure.CreateMap<Employee, EmployeeDto>();
                configure.CreateMap<REQUEST_TYPES, REQUEST_TYPESDto>();
                configure.CreateMap<Spends_Types, Spends_TypesDto>();
                configure.CreateMap<TRANSFER_TYPES, TRANSFER_TYPESDto>();
                configure.CreateMap<WAREHOUSE_DETAILS, WAREHOUSE_DETAILSDto>();
                configure.CreateMap<MyPoint, MyPointDto>();
                configure.CreateMap<Privilege, PrivilegeDto>();
                configure.CreateMap<Privileges_SBF, Privileges_SBFDto>();
                configure.CreateMap<Restaurant_Periods, Restaurant_PeriodsDto>();
                configure.CreateMap<Unit, UnitDto>();
                configure.CreateMap<User, UserDto>();
                configure.CreateMap<Users_Options, Users_OptionsDto>();
                configure.CreateMap<Users_Periods, Users_PeriodsDto>();
                configure.CreateMap<Waiters_Privileges, Waiters_PrivilegesDto>();
                configure.CreateMap<Food, FoodDto>();
                configure.CreateMap<Foods_Altrantv, Foods_AltrantvDto>();
                configure.CreateMap<Foods_Groups, Foods_GroupsDto>();
                configure.CreateMap<Foods_Prices, Foods_PricesDto>();
                configure.CreateMap<Foods_Types, Foods_TypesDto>();
                configure.CreateMap<Foods_Units, Foods_UnitsDto>();
                configure.CreateMap<Groups_Items, Groups_ItemsDto>();
                configure.CreateMap<Items_Notes_Mst, Items_Notes_MstDto>();
                configure.CreateMap<Area, AreaDto>();
                configure.CreateMap<Areas_Drivers, Areas_DriversDto>();
                configure.CreateMap<Bills_Notes_Mst, Bills_Notes_MstDto>();
                configure.CreateMap<Cell, CellDto>();
                configure.CreateMap<Cells_Groups, Cells_GroupsDto>();
                configure.CreateMap<Discount_MST, Discount_MSTDto>();
                configure.CreateMap<Foods_Attach, Foods_AttachDto>();
                configure.CreateMap<Foods_Components_End, Foods_Components_EndDto>();
                configure.CreateMap<Foods_Components, Foods_ComponentsDto>();
                configure.CreateMap<Insurance_Materials, Insurance_MaterialsDto>();
                configure.CreateMap<POS, POSDto>();
                configure.CreateMap<Restaurant_Menus_Food, Restaurant_Menus_FoodDto>();
                configure.CreateMap<Restaurant_Menus, Restaurant_MenusDto>();
                configure.CreateMap<Street, StreetDto>();
                configure.CreateMap<Customer, CustomerDto>();
                configure.CreateMap<Customers_Address, Customers_AddressDto>();
                configure.CreateMap<Customers_Types, Customers_TypesDto>();

            });
        }

    }
}