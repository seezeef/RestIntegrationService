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
    
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customers_Address>().ToTable("Customers_Address");
            modelBuilder.Entity<Customers_Types>().ToTable("Customers_Types");

        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customers_Address> Customers_Address { get; set; }
        public virtual DbSet<Customers_Types> Customers_Types { get; set; }
    }
}
