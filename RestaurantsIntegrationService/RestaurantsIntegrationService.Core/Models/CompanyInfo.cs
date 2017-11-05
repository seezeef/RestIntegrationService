using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Models
{
    public class CompanyInfo
    {
        public int BranchNumber { get; set; }
        public string CompanyNumber { get; set; }
        public string BranchUser { get; set; }
        public string ProjectNumber { get; set; }
        public string BranchYear { get; internal set; }
    }
}
