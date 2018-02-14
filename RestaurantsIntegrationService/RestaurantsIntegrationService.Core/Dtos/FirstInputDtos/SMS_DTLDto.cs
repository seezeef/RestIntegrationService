using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FirstInputDtos
{
    public class SMS_DTLDto
    {
        public short Branch_No { get; set; }
        public short MsgType { get; set; }
        public string MsgTypeNM { get; set; }
        public string MsgText { get; set; }
        public bool MsgActv { get; set; }
        public bool ShowOrderNo { get; set; }
    }
}
