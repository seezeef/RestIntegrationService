using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.FirstInputDtos
{
    public class SMS_SuplliersDto
    {
        public int Supllier_No { get; set; }
        public string Supllier_Name { get; set; }
        public string U_Name { get; set; }
        public string U_PWD { get; set; }
        public string Sender_Name { get; set; }
        public string URL_Link { get; set; }
        public string URL_Blnc { get; set; }
        public bool SMS_Encrypt { get; set; }
        public string Def_Msg_Text { get; set; }
        public bool ActvSupllier { get; set; }
        public string UserInUrl { get; set; }
        public string PWDInUrl { get; set; }
        public string SenderInUrl { get; set; }
        public string TxtMsgInUrl { get; set; }
        public string PhonNoInUrl { get; set; }
        public short Branch_No { get; set; }
    }
}
