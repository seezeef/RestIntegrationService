using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.SecondInputDtos
{
    public class BenchDto
    {
        public short Bench_No { get; set; }
        public string Bench_Name { get; set; }
        public string Bench_Desc { get; set; }
        public Nullable<short> Bench_Type { get; set; }
        public Nullable<byte> Bench_Capacity { get; set; }
        public Nullable<short> Section_No { get; set; }
        public int Bench_Left { get; set; }
        public int Bench_Top { get; set; }
        public int Bench_W { get; set; }
        public int Bench_H { get; set; }
        public Nullable<int> Use_Count { get; set; }
        public short Branch_No { get; set; }
    }
}
