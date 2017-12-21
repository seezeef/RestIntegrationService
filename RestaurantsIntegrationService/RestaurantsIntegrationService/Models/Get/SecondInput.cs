using RestaurantsIntegrationService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models.Get
{
    public class SecondInput
    {
        public List<Employee> Employees { get; set; }
        public List<WAREHOUSE_DETAILS> WarehouseDetailss { get; set; }
        public List<COST_CENTERS> CostCenterss { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<TRANSFER_TYPES> TransferTypess { get; set; }
        public List<REQUEST_TYPES> RequestTypess { get; set; }
        public List<Drivers_Work_Days> DriversWorkDayses { get; set; }
        public List<Benches_Sections> BenchesSectionses { get; set; }
        public List<Bench> Benches { get; set; }
        public List<Waiter> Waiters { get; set; }
    }
}