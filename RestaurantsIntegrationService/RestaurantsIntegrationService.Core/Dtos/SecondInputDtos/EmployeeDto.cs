using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.SecondInputDtos
{
    public class EmployeeDto
    {
        public int Emp_No { get; set; }
        public string Emp_Name { get; set; }
        public Nullable<short> Group_No { get; set; }
        public string Account_No { get; set; }
        public short Branch_No { get; set; }
        public Nullable<int> Finger_No { get; set; }
        public Nullable<int> Meal_Price { get; set; }
        public short Meals_Count { get; set; }
        public Nullable<int> Acc_Emp_No { get; set; }
    }
}
