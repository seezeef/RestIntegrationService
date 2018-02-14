using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.ThirdInputDtos
{
   public class UserDto
    {
        public short User_Id { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public string Account_No { get; set; }
        public string User_Acc_No { get; set; }
        public short Language { get; set; }
        public int User_Type { get; set; }
        public Nullable<byte> Max_Change { get; set; }
        public Nullable<byte> Min_Change { get; set; }
        public short Group_No { get; set; }
        public bool CanChangePassword { get; set; }
        public bool PasswordChangesOnce { get; set; }
        public bool Stopped { get; set; }
        public Nullable<byte> Icons_Size { get; set; }
        public bool Lang_Change { get; set; }
        public Nullable<short> Type_No { get; set; }
        public bool CanLog_AnyTime { get; set; }
        public bool JustCasherWin { get; set; }
        public short WorkType { get; set; }
        public short Pay_Type { get; set; }
        public string Card_ID { get; set; }
        public int EmpNo { get; set; }
        public Nullable<double> CMSN_Per { get; set; }
        public bool CloseYear { get; set; }
        public bool OpenYear { get; set; }
        public Nullable<int> POS_No { get; set; }
        public Nullable<int> Dr_No { get; set; }
    }
}
