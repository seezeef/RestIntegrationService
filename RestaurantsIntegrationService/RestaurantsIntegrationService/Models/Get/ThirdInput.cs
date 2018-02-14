using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantsIntegrationService.Core.Dtos.ThirdInputDtos;
using RestaurantsIntegrationService.DataAccess;

namespace RestaurantsIntegrationService.Models.Get
{
    public class ThirdInput
    {
        public List<Waiters_PrivilegesDto> WaitersPrivileges { get; set; }
        public List<UserDto> Users { get; set; }
        public List<Restaurant_PeriodsDto> RestaurantPeriods { get; set; }
        public List<Users_PeriodsDto> UsersPeriods { get; set; }
        public List<Users_OptionsDto> UsersOptions { get; set; }
        public List<Privileges_SBFDto> PrivilegesSbfs { get; set; }
        public List<PrivilegeDto> Privileges { get; set; }
        public List<MyPointDto> MyPoints { get; set; }
        public List<MyPoints_DTLDto> MyPointsDtls { get; set; }
        public List<UnitDto> Units { get; set; }

    }
}