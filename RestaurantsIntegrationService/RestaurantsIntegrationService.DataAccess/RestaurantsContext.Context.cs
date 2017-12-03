﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantsIntegrationService.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Restaurants : DbContext
    {
        public Restaurants()
            : base("name=Restaurants")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccSys_Accounts> AccSys_Accounts { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Areas_Drivers> Areas_Drivers { get; set; }
        public virtual DbSet<BarCode_Setup> BarCode_Setup { get; set; }
        public virtual DbSet<Bench> Benches { get; set; }
        public virtual DbSet<Benches_Sections> Benches_Sections { get; set; }
        public virtual DbSet<Benches_Types> Benches_Types { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Bills_Components> Bills_Components { get; set; }
        public virtual DbSet<Bills_Notes_Mst> Bills_Notes_Mst { get; set; }
        public virtual DbSet<Black_List> Black_List { get; set; }
        public virtual DbSet<Cell> Cells { get; set; }
        public virtual DbSet<Cells_Groups> Cells_Groups { get; set; }
        public virtual DbSet<Chef> Chefs { get; set; }
        public virtual DbSet<COST_CENTERS> COST_CENTERS { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Currency_Categories> Currency_Categories { get; set; }
        public virtual DbSet<Customer_Promo_MST> Customer_Promo_MST { get; set; }
        public virtual DbSet<Customers_Accounts> Customers_Accounts { get; set; }
        public virtual DbSet<Customers_Payment> Customers_Payment { get; set; }
        public virtual DbSet<Damage_MST> Damage_MST { get; set; }
        public virtual DbSet<Damage_Types> Damage_Types { get; set; }
        public virtual DbSet<Delegate> Delegates { get; set; }
        public virtual DbSet<Deleted_D> Deleted_D { get; set; }
        public virtual DbSet<Deleted_H> Deleted_H { get; set; }
        public virtual DbSet<DeleteRest> DeleteRests { get; set; }
        public virtual DbSet<Delivery_Options> Delivery_Options { get; set; }
        public virtual DbSet<Device_Token> Device_Token { get; set; }
        public virtual DbSet<Discount_MST> Discount_MST { get; set; }
        public virtual DbSet<Dlvr_Dtl> Dlvr_Dtl { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Drivers_Work_Days> Drivers_Work_Days { get; set; }
        public virtual DbSet<Employee_Groups> Employee_Groups { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employees_Foods> Employees_Foods { get; set; }
        public virtual DbSet<EvalutionElement> EvalutionElements { get; set; }
        public virtual DbSet<EvalutionEstimate> EvalutionEstimates { get; set; }
        public virtual DbSet<EvalutionModel> EvalutionModels { get; set; }
        public virtual DbSet<EvalutionModelDetail> EvalutionModelDetails { get; set; }
        public virtual DbSet<EvalutionMST> EvalutionMSTs { get; set; }
        public virtual DbSet<FingerDevice> FingerDevices { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Foods_Altrantv> Foods_Altrantv { get; set; }
        public virtual DbSet<Foods_Attach> Foods_Attach { get; set; }
        public virtual DbSet<Foods_Combo> Foods_Combo { get; set; }
        public virtual DbSet<Foods_Components> Foods_Components { get; set; }
        public virtual DbSet<Foods_Components_End> Foods_Components_End { get; set; }
        public virtual DbSet<Foods_Groups> Foods_Groups { get; set; }
        public virtual DbSet<Foods_Prices> Foods_Prices { get; set; }
        public virtual DbSet<Foods_Types> Foods_Types { get; set; }
        public virtual DbSet<Foods_Units> Foods_Units { get; set; }
        public virtual DbSet<FoodsReport_D> FoodsReport_D { get; set; }
        public virtual DbSet<FoodsReport_H> FoodsReport_H { get; set; }
        public virtual DbSet<Form_Details> Form_Details { get; set; }
        public virtual DbSet<Groups_Items> Groups_Items { get; set; }
        public virtual DbSet<HstrRest_D> HstrRest_D { get; set; }
        public virtual DbSet<HstrRest_D_Combo> HstrRest_D_Combo { get; set; }
        public virtual DbSet<HstrRest_D_DTL> HstrRest_D_DTL { get; set; }
        public virtual DbSet<HstrRest_H> HstrRest_H { get; set; }
        public virtual DbSet<IAS_OUT_REQUEST_MST> IAS_OUT_REQUEST_MST { get; set; }
        public virtual DbSet<InComing_DTL> InComing_DTL { get; set; }
        public virtual DbSet<InComing_Mst> InComing_Mst { get; set; }
        public virtual DbSet<Incoming_Types> Incoming_Types { get; set; }
        public virtual DbSet<Insurance_Bills_DTL> Insurance_Bills_DTL { get; set; }
        public virtual DbSet<Insurance_Materials> Insurance_Materials { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<Insurances_Closed> Insurances_Closed { get; set; }
        public virtual DbSet<Insurances_Deleted> Insurances_Deleted { get; set; }
        public virtual DbSet<Inventory_MST> Inventory_MST { get; set; }
        public virtual DbSet<Item_Move> Item_Move { get; set; }
        public virtual DbSet<ItemAchv> ItemAchvs { get; set; }
        public virtual DbSet<Items_Notes_Dtl> Items_Notes_Dtl { get; set; }
        public virtual DbSet<Items_Notes_Mst> Items_Notes_Mst { get; set; }
        public virtual DbSet<List_States> List_States { get; set; }
        public virtual DbSet<MNTNC_REQ> MNTNC_REQ { get; set; }
        public virtual DbSet<Mobile_Privillages> Mobile_Privillages { get; set; }
        public virtual DbSet<MyPoint> MyPoints { get; set; }
        public virtual DbSet<MyPoints_DTL> MyPoints_DTL { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<OpenBuffet> OpenBuffets { get; set; }
        public virtual DbSet<Options_Privileges> Options_Privileges { get; set; }
        public virtual DbSet<OUT_TYPES> OUT_TYPES { get; set; }
        public virtual DbSet<P_Meal_DTL> P_Meal_DTL { get; set; }
        public virtual DbSet<P_Meal_DTL_DTL> P_Meal_DTL_DTL { get; set; }
        public virtual DbSet<P_Meal_DTL_EXP> P_Meal_DTL_EXP { get; set; }
        public virtual DbSet<P_Meal_MST> P_Meal_MST { get; set; }
        public virtual DbSet<Penality> Penalities { get; set; }
        public virtual DbSet<POS> POS { get; set; }
        public virtual DbSet<POS_Printers> POS_Printers { get; set; }
        public virtual DbSet<PosTransTable> PosTransTables { get; set; }
        public virtual DbSet<Printer> Printers { get; set; }
        public virtual DbSet<Privilege> Privileges { get; set; }
        public virtual DbSet<Privileges_SBF> Privileges_SBF { get; set; }
        public virtual DbSet<REQUEST_TYPES> REQUEST_TYPES { get; set; }
        public virtual DbSet<RES_WHTRNS_MST> RES_WHTRNS_MST { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Reserved_Foods> Reserved_Foods { get; set; }
        public virtual DbSet<Reserved_Foods_Canceled> Reserved_Foods_Canceled { get; set; }
        public virtual DbSet<Reserved_Foods_Items> Reserved_Foods_Items { get; set; }
        public virtual DbSet<Rest_Targets> Rest_Targets { get; set; }
        public virtual DbSet<Rest_Taxes> Rest_Taxes { get; set; }
        public virtual DbSet<Restaurant_D> Restaurant_D { get; set; }
        public virtual DbSet<Restaurant_H> Restaurant_H { get; set; }
        public virtual DbSet<Restaurant_Info> Restaurant_Info { get; set; }
        public virtual DbSet<Restaurant_InvoTypes> Restaurant_InvoTypes { get; set; }
        public virtual DbSet<Restaurant_Menus> Restaurant_Menus { get; set; }
        public virtual DbSet<Restaurant_Menus_Food> Restaurant_Menus_Food { get; set; }
        public virtual DbSet<Restaurant_Orders> Restaurant_Orders { get; set; }
        public virtual DbSet<Restaurant_Periods> Restaurant_Periods { get; set; }
        public virtual DbSet<Restaurant_Shortcuts> Restaurant_Shortcuts { get; set; }
        public virtual DbSet<RSRVD_Payments> RSRVD_Payments { get; set; }
        public virtual DbSet<RSRVD_RefundPayment> RSRVD_RefundPayment { get; set; }
        public virtual DbSet<RT_Bill_DTL> RT_Bill_DTL { get; set; }
        public virtual DbSet<RT_Bill_DTL_DTL> RT_Bill_DTL_DTL { get; set; }
        public virtual DbSet<RT_Bill_MST> RT_Bill_MST { get; set; }
        public virtual DbSet<RT_Ins_DTL> RT_Ins_DTL { get; set; }
        public virtual DbSet<RT_Ins_MST> RT_Ins_MST { get; set; }
        public virtual DbSet<SchduleOption> SchduleOptions { get; set; }
        public virtual DbSet<SMS_DTL> SMS_DTL { get; set; }
        public virtual DbSet<SMS_Suplliers> SMS_Suplliers { get; set; }
        public virtual DbSet<Spend> Spends { get; set; }
        public virtual DbSet<Spends_Types> Spends_Types { get; set; }
        public virtual DbSet<Split_Bills> Split_Bills { get; set; }
        public virtual DbSet<Stock_Adjst_MST> Stock_Adjst_MST { get; set; }
        public virtual DbSet<Stock_QtyAv> Stock_QtyAv { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Sub_Items> Sub_Items { get; set; }
        public virtual DbSet<Suggestions_Types> Suggestions_Types { get; set; }
        public virtual DbSet<SyncData> SyncDatas { get; set; }
        public virtual DbSet<SyncTable> SyncTables { get; set; }
        public virtual DbSet<System_Initial> System_Initial { get; set; }
        public virtual DbSet<System_Options> System_Options { get; set; }
        public virtual DbSet<Tables_Status> Tables_Status { get; set; }
        public virtual DbSet<Transfer_Orders> Transfer_Orders { get; set; }
        public virtual DbSet<TRANSFER_TYPES> TRANSFER_TYPES { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User_Income> User_Income { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Users_Acc_Link> Users_Acc_Link { get; set; }
        public virtual DbSet<Users_Current_Login> Users_Current_Login { get; set; }
        public virtual DbSet<Users_Login> Users_Login { get; set; }
        public virtual DbSet<Users_Options> Users_Options { get; set; }
        public virtual DbSet<Users_Periods> Users_Periods { get; set; }
        public virtual DbSet<Waiter> Waiters { get; set; }
        public virtual DbSet<Waiters_Privileges> Waiters_Privileges { get; set; }
        public virtual DbSet<WareHouse> WareHouses { get; set; }
        public virtual DbSet<WAREHOUSE_DETAILS> WAREHOUSE_DETAILS { get; set; }
        public virtual DbSet<Bill_details> Bill_details { get; set; }
        public virtual DbSet<ConfirmConsume_DTL> ConfirmConsume_DTL { get; set; }
        public virtual DbSet<ConfirmConsume_MST> ConfirmConsume_MST { get; set; }
        public virtual DbSet<Customer_Promo_DTL> Customer_Promo_DTL { get; set; }
        public virtual DbSet<Damage_Components> Damage_Components { get; set; }
        public virtual DbSet<Damage_DTL> Damage_DTL { get; set; }
        public virtual DbSet<Discount_DTL> Discount_DTL { get; set; }
        public virtual DbSet<DriverGp> DriverGps { get; set; }
        public virtual DbSet<EvalutionDTL> EvalutionDTLs { get; set; }
        public virtual DbSet<EvalutionModelEstimate> EvalutionModelEstimates { get; set; }
        public virtual DbSet<IAS_NO_ITM_FOUND> IAS_NO_ITM_FOUND { get; set; }
        public virtual DbSet<IAS_OUT_REQUEST_DTL> IAS_OUT_REQUEST_DTL { get; set; }
        public virtual DbSet<Inventory_DTL> Inventory_DTL { get; set; }
        public virtual DbSet<JournalTable> JournalTables { get; set; }
        public virtual DbSet<PrinterDetail> PrinterDetails { get; set; }
        public virtual DbSet<RES_WHTRNS_DTL> RES_WHTRNS_DTL { get; set; }
        public virtual DbSet<RES_WHTRNS_DTL_T> RES_WHTRNS_DTL_T { get; set; }
        public virtual DbSet<Restaurant_Bill_No> Restaurant_Bill_No { get; set; }
        public virtual DbSet<SaveSetting> SaveSettings { get; set; }
        public virtual DbSet<Stock_Adjst_DTL> Stock_Adjst_DTL { get; set; }
        public virtual DbSet<Sys_Errors> Sys_Errors { get; set; }
        public virtual DbSet<Users_Actions> Users_Actions { get; set; }
        public virtual DbSet<Users_History> Users_History { get; set; }
    }
}
