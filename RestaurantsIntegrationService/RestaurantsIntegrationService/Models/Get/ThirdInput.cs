using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Get
{
    public class ThirdInput
    {
        public List<Waiters_Privileges> WaitersPrivilegeses { get; set; }
        public List<User> Users { get; set; }
        public List<Restaurant_Periods> RestaurantPeriodses { get; set; }
        public List<Users_Periods> UsersPeriodses { get; set; }
        public List<Users_Options> UsersOptionses { get; set; }
        public List<Privileges_SBF> PrivilegesSbfs { get; set; }
        public List<Privilege> Privileges { get; set; }
        public List<MyPoint> MyPoints { get; set; }
        public List<MyPoints_DTL> MyPointsDtls { get; set; }
        public List<Unit> Units { get; set; }

    }
}