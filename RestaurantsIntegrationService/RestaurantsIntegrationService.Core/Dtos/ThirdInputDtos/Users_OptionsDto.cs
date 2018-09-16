using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsIntegrationService.Core.Dtos.ThirdInputDtos
{
    public class Users_OptionsDto
    {
        public short User_ID { get; set; }
        public Nullable<short> iRoundTo { get; set; }
        public bool MenuChange { get; set; }
        public bool MenuQtyChange { get; set; }
        public bool MenuPriceChange { get; set; }
        public bool MenuChangeAdd { get; set; }
        public bool CanAddMaually { get; set; }
        public bool ChangePrinter { get; set; }
        public bool AddCustomer { get; set; }
        public short Branch_No { get; set; }
        public Nullable<int> AddedBy { get; set; }
        public bool Authorized { get; set; }
        public bool EditQtyOrders { get; set; }
        public bool AddFreeItem { get; set; }
        public bool AddToPrice { get; set; }
        public bool ChangePayType { get; set; }
        public bool ChangeBillType { get; set; }
        public bool StopCloseBill { get; set; }
        public bool ChangeItemPrice { get; set; }
        public bool NotOpenUserTable { get; set; }
        public bool StopItem { get; set; }
        public bool StopInsurancePrt { get; set; }
        public bool CloseDelivery { get; set; }
        public bool NotAddResAdvAmt { get; set; }
        public bool NotEditResAdvAmt { get; set; }
        public bool ClosingCash { get; set; }
        public bool AddOpenBuffet { get; set; }
        public bool AddFreeBill { get; set; }
        public bool CanPrintBillMoreOne { get; set; }
        public bool AddPayLater { get; set; }
        public bool InsuranceBack { get; set; }
        public bool EditInsPrice { get; set; }
        public bool CanPrintResMoreOne { get; set; }
        public bool CanNotEditAfterPrintBill { get; set; }
        public bool CanCloseIns { get; set; }
        public bool TemporarilyStopItems { get; set; }
        public bool StopSuspendBill { get; set; }
        public bool AllSalesInCashierReport { get; set; }
    }
}
