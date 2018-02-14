using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantsIntegrationService.Core.Dtos.SecondInputDtos;

namespace RestaurantsIntegrationService.Models.Get
{
    public class SecondInput
    {
        public List<EmployeeDto> Employees { get; set; }
        public List<WAREHOUSE_DETAILSDto> WarehouseDetails { get; set; }
        public List<COST_CENTERSDto> CostCenters { get; set; }
        public List<DriverDto> Drivers { get; set; }
        public List<TRANSFER_TYPESDto> TransferTypes { get; set; }
        public List<REQUEST_TYPESDto> RequestTypes { get; set; }
        public List<Drivers_Work_DaysDto> DriversWorkDays { get; set; }
        public List<Benches_SectionsDto> BenchesSections { get; set; }
        public List<BenchDto> Benches { get; set; }
        public List<WaiterDto> Waiters { get; set; }
    }
}